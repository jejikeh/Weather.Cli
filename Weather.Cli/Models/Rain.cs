using Newtonsoft.Json;

namespace Weather.Cli.Models
{
    public class Rain
    {
        [JsonProperty("3h")] 
        public double RainVolume { get; set; }

        public override string ToString()
        {
            return $"Rain: RainVolume({RainVolume})";
        }
    }
}