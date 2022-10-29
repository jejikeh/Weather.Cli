using System.Net;
using Newtonsoft.Json;
using Weather.Cli.Models;

namespace Weather.Cli
{
    public class OpenWeatherClient
    {
        private const string ApiKey = "_";
        private static readonly HttpClient Client = new HttpClient()
        {
            BaseAddress = new Uri("https://api.openweathermap.org/")
        };
        
        /// <summary>
        /// Downloading the weather forecast for 5 days
        /// </summary>
        /// <param name="cityName">Name of the city</param>
        /// <exception cref="ArgumentException">Error while downloading forecast</exception>
        public async Task<ForecastResponse> DownloadForecast(string cityName)
        {
            try
            {
                var cityCoords = await GetCityCoords(cityName);
                var responseJsonWeather = await Client.GetAsync($"data/2.5/forecast?lat={cityCoords.Item1}&lon={cityCoords.Item2}&appid={ApiKey}");
                
                if (responseJsonWeather.StatusCode is >= HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout)
                    throw new ArgumentException("Time out. Please check your internet connection");

                var forecast = JsonConvert.DeserializeObject<ForecastResponse>(await responseJsonWeather.Content.ReadAsStringAsync());
                return forecast;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }

            throw new Exception("Some thing went wrong");
        }
        
        private static async Task<Tuple<string,string>> GetCityCoords(string cityName)
        {
            var responseJsonCity = await Client.GetAsync($"/geo/1.0/direct?q={cityName}&appid={ApiKey}");
            if (responseJsonCity.StatusCode is >= HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout)
                throw new ArgumentException("Time out. Please check your internet connection");

            dynamic cityCoords = JsonConvert.DeserializeObject(await responseJsonCity.Content.ReadAsStringAsync());
            if (cityCoords.ToString() == "[]")
                throw new ArgumentException($"{cityName} was not found");

            return new Tuple<string, string>($"{cityCoords[0]["lat"]:F}",$"{cityCoords[0]["lon"]:F}");
        }
    }
}