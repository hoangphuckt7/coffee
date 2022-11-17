using AdminManager.Models;
using AdminManager.Utils;
using Data.AppException;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;
using System.Text;

namespace BlueBirdCoffeManager.DataAccessLayer
{
    public class ApiBuilder
    {
        private static StringContent BuildRequestBody<T>(T data)
        {
            var dataConvert = JsonConvert.SerializeObject(data);
            return new StringContent(dataConvert, Encoding.UTF8, "application/json");
        }

        private static async Task<MultipartFormDataContent> BuildFromFormBody<T>(T data)
        {
            var result = new MultipartFormDataContent();

            PropertyInfo[] properties = data!.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                var propData = propertyInfo.GetValue(data)!;
                if (propertyInfo.PropertyType == typeof(List<IFormFile>))
                {
                    var filesData = (List<IFormFile>)propData;
                    await using var memoryStream = new MemoryStream();
                    foreach (var fileData in filesData)
                    {
                        await fileData.CopyToAsync(memoryStream);
                        result.Add(new ByteArrayContent(memoryStream.ToArray()), propertyInfo.Name, fileData.FileName);
                    }
                }
                else if (propertyInfo.PropertyType == typeof(IFormFile))
                {
                    var fileData = (IFormFile)propData;
                    await using var memoryStream = new MemoryStream();
                    await fileData.CopyToAsync(memoryStream);
                    result.Add(new ByteArrayContent(memoryStream.ToArray()), propertyInfo.Name, fileData.FileName);
                }
                else
                {
                    result.Add(new StringContent(propData.ToString()!), propertyInfo.Name);
                }
            }
            return result;
        }

        public static async Task<HttpResponseMessage> SendRequest<T>(string apiPath, T? requestBody, RequestMethod method, bool? needAuth, string returnUrl, ISession? session)
        {
            HttpResponseMessage responseMessage = new();

            if (needAuth != null && needAuth.Value && string.IsNullOrEmpty(session!.GetString("Token")))
            {
                throw new NotLoginException(returnUrl);
            }
            try
            {
                HttpClient client = new();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + session!.GetString("Token"));

                switch (method)
                {
                    case RequestMethod.GET:
                        responseMessage = await client.GetAsync(Sessions.HOST + apiPath);
                        break;
                    case RequestMethod.POST:
                        responseMessage = await client.PostAsync(Sessions.HOST + apiPath, BuildRequestBody(requestBody));
                        break;
                    case RequestMethod.PUT:
                        responseMessage = await client.PutAsync(Sessions.HOST + apiPath, BuildRequestBody(requestBody));
                        break;
                    case RequestMethod.MULTIPART_POST:
                        responseMessage = await client.PostAsync(Sessions.HOST + apiPath, await BuildFromFormBody(requestBody));
                        break;
                    case RequestMethod.MULTIPART_PUT:
                        responseMessage = await client.PutAsync(Sessions.HOST + apiPath, await BuildFromFormBody(requestBody));
                        break;
                    case RequestMethod.DELETE:
                        responseMessage = await client.DeleteAsync(Sessions.HOST + apiPath);
                        break;
                }
            }
            catch (HttpRequestException e)
            {
                throw new AppException(e.Message);
            }

            if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                session!.SetString("Token", "");
                session!.SetString("LoginErrorMessage", "Vui lòng đăng nhập lại");
                throw new NotLoginException(returnUrl);
            }
            else if (responseMessage.StatusCode == HttpStatusCode.Forbidden)
            {
                session!.SetString("Token", "");
                session!.SetString("LoginErrorMessage", "Bạn không có quyền xử dụng tính năng này");
                throw new NotLoginException(returnUrl);
            }
            return responseMessage;
        }
        public static async Task<T> ParseToData<T>(HttpResponseMessage responseMessage)
        {
            string json = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json)!;
        }

        public static async Task<byte[]?> ReadImageFromRequest(HttpResponseMessage responseMessage)
        {
            try
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var json = await responseMessage.Content.ReadAsByteArrayAsync();
                    return json;
                }
            }
            catch (HttpRequestException)
            {

            }
            return null;
        }
    }
}
