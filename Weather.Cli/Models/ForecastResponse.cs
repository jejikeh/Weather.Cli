using Newtonsoft.Json;

namespace Weather.Cli.Models
{
    /// <summary>
    /// Weather forecast for 5 days
    /// </summary>
    public class ForecastResponse
    {
        [JsonProperty("cod")] 
        public string Cod { get; set; } = string.Empty;

        [JsonProperty("message")] 
        public int Message { get; set; }

        [JsonProperty("cnt")] 
        public int Cnt { get; set; }

        [JsonProperty("list")] 
        public List<WeatherResponse> Days { get; set; } = new List<WeatherResponse>();

        [JsonProperty("city")] 
        public City City { get; set; } = new City();

        public override string ToString()
        {
            var result = string.Empty;
            var lastDate = DateTime.MinValue;
            
            foreach (var weather in Days.Where(weather => lastDate.Date.Date != weather.Date.Date))
            {
                if (weather.Date.Date > lastDate.Date)
                    lastDate = weather.Date.Date;

                var weathers = weather.Weather.Aggregate(string.Empty, (current, weatherData) => current + weatherData);
                result += $"\t\t\t--- {weather.Date.Date.Date} ---\n\n" +
                          $"\t1. Temperature\n" +
                          $"\t\t{weather.Main}\n" +
                          $"\t2. Weather\n" +
                          $"\t\t{weathers}\n" +
                          $"\t3. Wind\n" +
                          $"\t\t{weather.Wind}\n\n";
            }

            return result;
        }
    }
}