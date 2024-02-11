using HttpClientSample.ApiClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

internal class Program
{
    //https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        ServiceCollection services = new();
        services.AddHttpClient();
        services.AddHttpClient("WeatherForecast", httpClient => {
            httpClient.BaseAddress = new Uri("https://api.open-meteo.com/v1/");
            httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "HttpClientFactory");
        });

        services.AddScoped<IWeatherForecastClient, WeatherForecastClient>();

        var provider = services.BuildServiceProvider();

        var weatherForecastClient = provider.GetService<IWeatherForecastClient>();
        var weatherTask = weatherForecastClient.GetWeatherForecast();
        weatherTask.Wait();
        var response = weatherTask.Result;

        Console.WriteLine("Complete");
    }
}