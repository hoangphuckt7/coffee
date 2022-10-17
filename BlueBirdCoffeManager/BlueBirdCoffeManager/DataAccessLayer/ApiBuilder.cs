using BlueBirdCoffeManager.Models;
using Newtonsoft.Json;
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

        public static async Task<string> SendRequest<T>(string apiPath, T? requestBody, RequestMethod method)
        {
            try
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
                    return json;
                }
                else if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    string message = "Vui lòng đăng nhập lại";
                    string caption = "Thông báo";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (responseMessage.StatusCode == HttpStatusCode.Forbidden)
                {
                    string message = "Bạn không có quyền xử dụng tính năng này";
                    string caption = "Thông báo";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    string caption = "Lỗi";
                    string? x = responseMessage.Content.ToString();
                    MessageBox.Show(x, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException)
            {
                string message = "Lỗi kết nối. Vui lòng kiểm tra lại đường truyền.";
                string caption = "Lỗi";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "";
        }

        public static async Task<byte[]> SendImageRequest(string apiPath)
        {
            try
            {
                HttpClient client = new();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Sessions.Sessions.TOKEN);
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
                const string message = "Lỗi kết nối. Vui lòng kiểm tra lại đường truyền.";
                const string caption = "Lỗi";
                var rr = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // If the no button was pressed ...
                if (rr == DialogResult.OK)
                {
                }
            }
            return null;
        }
    }
}
