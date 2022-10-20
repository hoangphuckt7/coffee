using AdminManager.Models;
using AdminManager.Utils;
using Data.AppException;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.DataAccessLayer
{
    public class ApiBuilder
    {
        public static StringContent BuildRequestBody<T>(T data)
        {
            var dataConvert = JsonConvert.SerializeObject(data);
            return new StringContent(dataConvert, Encoding.UTF8, "application/json");
        }

        public static async Task<HttpResponseMessage> SendRequest<T>(string apiPath, T? requestBody, RequestMethod method, bool? needAuth, string returnUrl)
        {
            HttpResponseMessage responseMessage = new();
            if (needAuth != null && needAuth.Value && string.IsNullOrEmpty(Sessions.TOKEN))
            {
                throw new NotLoginException(returnUrl);
            }
            try
            {
                HttpClient client = new();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Sessions.TOKEN);

                switch (method)
                {
                    case RequestMethod.GET:
                        responseMessage = await client.GetAsync(Sessions.HOST + apiPath);
                        break;
                    case RequestMethod.POST:
                        responseMessage = await client.PostAsync(Sessions.HOST + apiPath, BuildRequestBody(requestBody));
                        break;
                    case RequestMethod.PUT:
                        var ra = BuildRequestBody(requestBody);
                        responseMessage = await client.PutAsync(Sessions.HOST + apiPath, BuildRequestBody(requestBody));
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
                Sessions.TOKEN = "";
                Sessions.LOGIN_ERROR_MESSAGE = "Vui lòng đăng nhập lại";
                throw new NotLoginException(returnUrl);
            }
            else if (responseMessage.StatusCode == HttpStatusCode.Forbidden)
            {
                Sessions.TOKEN = "";
                Sessions.LOGIN_ERROR_MESSAGE = "Bạn không có quyền xử dụng tính năng này";
                throw new NotLoginException(returnUrl);
            }
            return responseMessage;
        }

        public static async Task<byte[]?> SendImageRequest(string apiPath)
        {
            try
            {
                HttpClient client = new();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Sessions.TOKEN);
                HttpResponseMessage responseMessage = new();

                responseMessage = await client.GetAsync(Sessions.HOST + apiPath);

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

        public static async Task<T> ParseToData<T>(HttpResponseMessage responseMessage)
        {
            string json = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json)!;
        }
    }
}
