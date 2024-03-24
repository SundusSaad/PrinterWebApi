using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        [HttpGet("TempConvert")]
        public ActionResult<double> GetTemp([FromQuery]double temperatureC)
        {
            double TemperatureF = Math.Round(32 + (double)(temperatureC / 0.5556),4);
            return TemperatureF;

        }
    }
}
