using Weather.Cli.Models;

namespace Weather.Cli
{
    public static class Program
    {
        private static readonly ObservableDictionary<string, ForecastResponse> CachedWeather =
            new ObservableDictionary<string, ForecastResponse>();

        private delegate Task<ForecastResponse> OpenWeatherMethodByCityName(string city);

        public static async Task Main(string[] args)
        {
            var client = new OpenWeatherClient();
            OpenWeatherMethodByCityName downloadForecast = client.DownloadForecast;

            await ArgumentsManager(args, downloadForecast);
        }
        
        /// <summary>
        /// Calls the necessary methods to get the weather
        /// </summary>
        /// <param name="args">Command arguments</param>
        /// <param name="downloadWeather">The method that is called if the city is not in the dictionary</param>
        private static async Task ArgumentsManager(IReadOnlyList<string> args, OpenWeatherMethodByCityName downloadWeather)
        {
            var cityName = args[1];
            switch (args[0])
            {
                case "-c":
                    if (!CachedWeather.ContainsKey(cityName))
                        CachedWeather.Add(new KeyValuePair<string, ForecastResponse>(cityName, await downloadWeather(cityName)));
                
                    var downloadedCurrentForecast = CachedWeather[cityName];
                    foreach (var day in downloadedCurrentForecast.Days.Where(day => day.Date == DateTime.Today))
                    {
                        Console.WriteLine(day);
                        return;
                    }
                    
                    CachedWeather.Add(new KeyValuePair<string, ForecastResponse>(cityName, await downloadWeather(cityName)));
                    Console.WriteLine(CachedWeather[cityName].Days[0]);
                    break;
                case "-w":
                    if (!CachedWeather.ContainsKey(cityName))
                        CachedWeather.Add(new KeyValuePair<string, ForecastResponse>(cityName, await downloadWeather(cityName)));
                    
                    var downloadedForecast = CachedWeather[cityName];
                    if(downloadedForecast.Days[0].Date != DateTime.Today)
                        CachedWeather.Add(new KeyValuePair<string, ForecastResponse>(cityName, await downloadWeather(cityName)));

                    Console.WriteLine(CachedWeather[cityName]);
                    break;
            }
        }
    }
}

