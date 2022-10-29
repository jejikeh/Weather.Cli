using Newtonsoft.Json;

namespace Weather.Cli.Models
{
    /// <summary>
    /// Cloudiness, %
    /// </summary>
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }

        public override string ToString()
        {
            return $"Clouds: All({All:F})";
        }
    }
}