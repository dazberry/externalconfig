using Microsoft.AspNetCore.Mvc;

namespace ExternalConfiguration.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {       
        public class KeyRequest
        {
            public string Key { get; set; }
        }

        // POST api/values
        [HttpPost()]
        public IActionResult Get([FromBody] KeyRequest keyRequest)
        {
            var cfg = new
            {
                Key = keyRequest?.Key,
                ConnectionString = "This is the connection string"           
            };

            return Ok(cfg);
        }

       
    }
}
