using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Weather.NET;
using System.IO;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController1 : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly WeatherSettings _weatherSettings;

        // Injecting FileService and WeatherSettings configuration
        public ValuesController1(IFileService fileService, IOptions<WeatherSettings> weatherSettings)
        {
            _fileService = fileService;
            _weatherSettings = weatherSettings.Value;
        }

        // Existing Weather API (Modified to Restrict to Ahmedabad)
        [HttpPost("location/{city}")]
        public IActionResult WeatherPost(string city)
        {
            try
            {
                // Restrict to Ahmedabad only
                if (!string.Equals(city, _weatherSettings.AllowedCity, StringComparison.OrdinalIgnoreCase))
                {
                    return BadRequest("Only Ahmedabad city data is allowed.");
                }

                string API_Key = "3a7fd9b0b9f9b0b95d1f307e2e8d3d67";
                WeatherClient weather = new WeatherClient(API_Key);
                var currentweather = weather.GetCurrentWeather(city);
                return Ok(currentweather);
            }
            catch
            {
                return BadRequest();
            }
        }

        // New API: Read Data from File
        [HttpGet("read-file")]
        public async Task<IActionResult> ReadFileData()
        {
            try
            {
                var fileData = await _fileService.ReadFileAsync();
                return Ok(new { data = fileData });
            }
            catch
            {
                return StatusCode(500, "Error reading the file.");
            }
        }
    }
}
 