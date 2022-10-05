using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.DataAccessLayer
{
    public enum RequestMethod
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public class ApiBuilder
    {
        public static StringContent BuildRequestBody<T>(T data)
        {
            var dataConvert = JsonConvert.SerializeObject(data);
            return new StringContent(dataConvert, Encoding.UTF8, "application/json");
        }

        public static async Task<string> SendRequest<T>(string apiPath, T? requestBody, RequestMethod method)
        {
            try
            {
                HttpClient client = new();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "");
                HttpResponseMessage responseMessage = new();

                switch (method)
                {
                    case RequestMethod.GET:
                        responseMessage = await client.GetAsync(Sessions.Sessions.HOST + apiPath);
                        break;
                    case RequestMethod.POST:
                        responseMessage = await client.PostAsync(Sessions.Sessions.HOST + apiPath, BuildRequestBody(requestBody));
                        break;
                    case RequestMethod.PUT:
                        var ra = BuildRequestBody(requestBody);
                        responseMessage = await client.PutAsync(Sessions.Sessions.HOST + apiPath, BuildRequestBody(requestBody));
                        break;
                    case RequestMethod.DELETE:
                        responseMessage = await client.DeleteAsync(Sessions.Sessions.HOST + apiPath);
                        break;
                }

                if (responseMessage.IsSuccessStatusCode)
                {
                    string json = await responseMessage.Content.ReadAsStringAsync();
                    return json;
                }
               
            }
            catch (HttpRequestException)
            {
            }
            return "";
        }

        public static async Task<byte[]> SendImageRequest(string apiPath)
        {
            try
            {
                HttpClient client = new();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "");
                HttpResponseMessage responseMessage = new();

                responseMessage = await client.GetAsync(Sessions.Sessions.HOST + apiPath);

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
