using Newtonsoft.Json;

namespace Weather.Cli.Models
{
    public class Wind
    {
        [JsonProperty("speed")] 
        public double Speed { get; set; }

        [JsonProperty("deg")] 
        public double Deg { get; set; }

        [JsonProperty("gust")] 
        public double Gust { get; set; }

        public override string ToString()
        {
            return $"speed: ({Speed:F})\t" +
                   $"wind direction: ({Deg})\t" +
                   $"gust: ({Gust})";
        }
    }
}