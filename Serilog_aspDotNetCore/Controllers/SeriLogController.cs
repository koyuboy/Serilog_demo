using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Context;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Serilog_aspDotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriLogController : ControllerBase
    {
        private readonly ILogger _logger;

        public SeriLogController(ILogger<SeriLogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] int x, int y)
        {
            try
            {
                _logger.LogInformation("INFO - Operation starts with {x}/{y}.", x, y);
                _logger.LogWarning("WARNING - Operation starts with {x}/{y}.", x, y);

                var result = x / y;
            }
            catch (Exception ex)
            {
                LogContext.PushProperty("ExceptionMessage", ex.Message);
                _logger.LogError("ERROR - An error occured!, {error}", ex);

                return BadRequest();
            }

            return Ok();
        }
    }
}
