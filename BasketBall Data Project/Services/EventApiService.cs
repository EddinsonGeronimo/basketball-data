using BasketBall_Data_Project.Constants;
using BasketBall_Data_Project.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BasketBall_Data_Project.Services
{
    public class EventApiService : IEventApiService
    {
        //public string Date = DateTime.Now.ToString("yyyy-MM-dd");
        ISerializerService _serializerService;
        public EventApiService(ISerializerService serializerService)
        {
            _serializerService = serializerService;
        }

        public async Task<Events> GetInfoAsync()
        {
            Events Events = null;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Config.ApiUrl}/events"),//{Date}"),
                Headers =
                {
                    { Config.ApiKeyHeader, Config.ApiKey },
                    { Config.ApiHostHeader, Config.ApiHost },
                },
            };
            var client = new HttpClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Events = _serializerService.Deserialize<Events>(await response.Content.ReadAsStringAsync());
            }
            return Events;
        }
    }
}
