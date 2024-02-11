using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientSample.ApiClient
{
    internal interface IWeatherForecastClient
    {
        Task<string> GetWeatherForecast();
    }
}
