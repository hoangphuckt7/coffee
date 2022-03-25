using BlueBirdCoffeManager.Sessions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Utils
{
    public interface IResponseAPI
    {
        StringContent GetContent<T>(T data);
        Task<T> ReadAsJsonAsync<T>(HttpContent content);
    }
    public class ResponseAPI : IResponseAPI
    {
        /// <summary>
        /// Link of host API
        /// </summary>
        [Required]
        public string APIHost { get; set; }
        private HttpClient client = new HttpClient();

        internal object GetContent<T>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ResponseAPI()
        {
            this.APIHost = Sessions.Sessions.HOST;
        }

        public HttpClient Initial()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(APIHost)
            };
            return client;
        }

        /// <summary>
        /// Convert Content To String Content
        /// </summary>
        /// <typeparam name="T">Type of Data</typeparam>
        /// <param name="data">Data</param>
        /// <returns></returns>
        public StringContent GetContent<T>(T data)
        {
            var dataConvert = JsonConvert.SerializeObject(data);
            var content = new StringContent(dataConvert, UnicodeEncoding.UTF8, "application/json");
            return content;
        }

        /// <summary>
        /// Read Json as Convert To Data
        /// </summary>
        /// <typeparam name="T">Type of Data</typeparam>
        /// <param name="content">HttpContent</param>
        /// <returns></returns>
        public async Task<T> ReadAsJsonAsync<T>(HttpContent content)
        {
            string json = await content.ReadAsStringAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            T value = JsonConvert.DeserializeObject<T>(json);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            return value;
        }

        /// <summary>
        /// Method GET Async
        /// </summary>
        /// <typeparam name="T">Type of Data</typeparam>
        /// <param name="path">Path of API</param>
        /// <returns></returns>
        public async Task<T> GetTAsync<T>(string path) where T : class
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            T result = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            using (client = Initial())
            {
                HttpResponseMessage rs = await client.GetAsync(path);
                if (rs.IsSuccessStatusCode)
                {
                    result = await ReadAsJsonAsync<T>(rs.Content);
                }
            }
            return result;
        }
    }
}
