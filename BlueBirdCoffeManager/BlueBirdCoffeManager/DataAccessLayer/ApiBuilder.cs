using BlueBirdCoffeManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static async Task<T> SendRequest<T>(string apiPath, T? requestBody, RequestMethod method)
        {
            HttpClient client = new();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Sessions.Sessions.TOKEN);
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
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                //const string message = "Đã xảy ra lỗi trong quá trình cập nhật!!";
                //const string caption = "Lỗi";
                //var rr = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //// If the no button was pressed ...
                //if (rr == DialogResult.OK)
                //{
                //}
                //throw new Exception(await responseMessage.Content.ReadAsStringAsync());
                return JsonConvert.DeserializeObject<T>("[]");
            }
        }
    }
}
