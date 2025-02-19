using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Weather.NET;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController1 : ControllerBase
    {

        [HttpPost("location/{city}")]
        public IActionResult WeatherPost(string city)
        {
            try 
            { string API_Key = "3a7fd9b0b9f9b0b95d1f307e2e8d3d67";
                WeatherClient wether = new WeatherClient(API_Key);
                var currentweather = wether.GetCurrentWeather(city);
                return Ok(currentweather);

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}