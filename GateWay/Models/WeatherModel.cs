using GateWay.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;


namespace GateWay.Models
{
    public class WeatherModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "fef44efb89776abd3da0b74184d8a743"; // Replace with your OpenWeatherMap API key
        private readonly string _weatherApiUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherModel()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherResponse> GetWeatherForCity(string cityName)
        {
            try
            {
                string apiUrl = $"{_weatherApiUrl}?q={cityName}&appid={_apiKey}";

                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(content);
                    return weatherResponse;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}




