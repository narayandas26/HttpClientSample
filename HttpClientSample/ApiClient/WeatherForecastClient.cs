using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientSample.ApiClient
{
    internal class WeatherForecastClient : IWeatherForecastClient
    {
        //private static readonly HttpClient _httpClient = new();
        private readonly HttpClient _httpClient;

        public WeatherForecastClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("WeatherForecast");
        }

        public async Task<string> GetWeatherForecast()
        {
            var response = await _httpClient.GetStringAsync($"forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m");
            return response;
        }
    }
}
