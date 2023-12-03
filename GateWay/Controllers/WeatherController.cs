using Microsoft.AspNetCore.Mvc;
using GateWay.Models;
using Newtonsoft.Json;

namespace GateWay.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherModel _weatherModel;

        public WeatherController()
        {
            _weatherModel = new WeatherModel();
        }

        [HttpGet("{cityName}")]
        public async Task<IActionResult> GetWeather(string cityName)
        {
            try
            {
                var weatherResponse = await _weatherModel.GetWeatherForCity(cityName);

                if (weatherResponse != null)
                {
                    var weather = new
                    {
                        temp = weatherResponse.Main.Temp,
                        feelslike = weatherResponse.Main.FeelsLike,
                        tempmin = weatherResponse.Main.TempMin,
                        tempmax = weatherResponse.Main.TempMax,
                        pressure = weatherResponse.Main.Pressure,
                        humidity = weatherResponse.Main.Humidity,
                        main = weatherResponse.Weather[0].Main,
                        description = weatherResponse.Weather[0].Description,
                    };
                    return Ok(weather);
                }
                else
                {
                    return StatusCode(500, "Failed to retrieve weather data.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}