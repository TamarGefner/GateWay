using GateWay.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace ServiceHW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HebcalController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public HebcalController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> GetHebrewDate()
        {
            try
            {
                var date = DateTime.Now.ToString("yyyy-MM-dd");
                string hebcalApiUrl = $"https://www.hebcal.com/converter?cfg=json&date={date}&g2h=1&strict=1";

                var response = await _httpClient.GetAsync(hebcalApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var hebrewDate = JsonConvert.DeserializeObject<HebcalRoot>(json);
                    var hebdate = new
                    {
                           hy = hebrewDate.hy,
                           hm = hebrewDate.hm,
                           hd = hebrewDate.hd,
                           hebrew = hebrewDate.hebrew,
                           events = string.Join(" , ", hebrewDate.events),
                    };
                    return Ok(hebdate);
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

