using Newtonsoft.Json;

namespace Weather.Cli.Models
{
    public class Snow
    {
        [JsonProperty("3h")] 
        public double SnowVolume { get; set; }

        public override string ToString()
        {
            return $"SnowVolume: ({SnowVolume:F})";
        }
    }
}