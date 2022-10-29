using Newtonsoft.Json;

namespace Weather.Cli.Models
{
    public class City
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("coord")]
        public Coord Coord { get; set; } = new Coord();

        [JsonProperty("country")]
        public string Country { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"City: Name({Name}), Coord({Coord}), Country({Country}))";
        }
    }
}