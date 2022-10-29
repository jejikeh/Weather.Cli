using Newtonsoft.Json;

namespace Weather.Cli.Models
{
    /// <summary>
    /// Abbreviated weather information for weekly forecasts
    /// </summary>
    public class WeatherResponse
    {
        [JsonProperty("main")] 
        public Main Main { get; set; } = new Main();

        [JsonProperty("weather")] 
        public List<Weather> Weather { get; set; } = new List<Weather>();

        [JsonProperty("clouds")] 
        public Clouds Clouds { get; set; } = new Clouds();

        [JsonProperty("snow")] 
        public Snow Snow { get; set; } = new Snow();

        [JsonProperty("wind")] 
        public Wind Wind { get; set; } = new Wind();

        [JsonProperty("rain")] 
        public Rain Rain { get; set; } = new Rain();

        [JsonProperty("dt_txt")] 
        public DateTime Date { get; set; } = DateTime.Today;

        [JsonProperty("visibility")] 
        public int Visibility { get; set; }
        
        public override string ToString()
        {
            var weathers = Weather.Aggregate(string.Empty, (current, weatherData) => current + weatherData);

            return  $"\t\t\t--- {DateTime.Now.Date} ---\n" +
                    $"\t1. Temperature\n" +
                    $"\t\t{Main}\n" +
                    $"\t2. Weather\n" +
                    $"\t\t{weathers}\n" +
                    $"\t3. Wind\n" +
                    $"\t\t{Wind}\n";
        }
        
        /// <summary>
        /// Converting temperature from Kelvins to degrees Celsius
        /// </summary>
        /// <param name="kelvin">temperature in kelvins</param>
        /// <returns></returns>
        internal static double KelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15d;
        }
    }
}