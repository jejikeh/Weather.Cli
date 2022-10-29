using Newtonsoft.Json;

namespace Weather.Cli.Models
{
    public class Main
    {
        [JsonProperty("temp")] 
        public double Temp { get; set; }
        
        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }
        
        [JsonProperty("temp_min")]
        public double TempMin { get; set; }
        
        [JsonProperty("temp_max")] 
        public double TempMax { get; set; }

        public override string ToString()
        {
            return $"Now: ({WeatherResponse.KelvinToCelsius(Temp):F})\t" +
                   $"Feels: ({WeatherResponse.KelvinToCelsius(FeelsLike):F})";
        }
    }
}