using Newtonsoft.Json;

namespace Weather.Cli.Models
{
    /// <summary>
    /// City geo location
    /// </summary>
    public class Coord
    {
        /// <summary>
        /// Latitude
        /// </summary>
        [JsonProperty("lat")]
        public double Lat { get; set; }

        /// <summary>
        ///  Longitude
        /// </summary>
        [JsonProperty("lon")]
        public double Lon { get; set; }

        public Coord() { }

        public Coord(double lat, double lon)
        {
            Lat = lat;
            Lon = lon;
        }

        public override string ToString()
        {
            return $"Lat:({Lat}) Lon:({Lon})";
        }
    }
}