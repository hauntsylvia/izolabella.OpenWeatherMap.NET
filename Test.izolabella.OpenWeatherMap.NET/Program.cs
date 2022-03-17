using izolabella.OpenWeatherMap.NET;
using izolabella.OpenWeatherMap.NET.Classes;
using izolabella.OpenWeatherMap.NET.Classes.Responses;

namespace Test.izolabella.OpenWeatherMap.NET
{
    public class Program
    {
        public static async Task Main(string[] Args)
        {
            OpenWeatherMapClient Client = new(File.ReadAllText("OWM.txt"), UnitTypes.Imperial);
            WeatherResponse? Response = await Client.Processors.CurrentWeatherDataProcessor.GetWeatherByZipCodeAsync("60453", "US");
            Console.WriteLine(Response != null ? $"city name [{Response.CityName}]" : "error processing");

            OneCallWeatherResponse? OneCallWeatherResponse = await Client.Processors.OneCallProcessor.CallAsync(0m, 0m);
            Console.WriteLine(OneCallWeatherResponse != null ? $"name [{OneCallWeatherResponse.TimezoneName}]" : "error processing");

            await Task.Delay(-1);
        }
    }
}