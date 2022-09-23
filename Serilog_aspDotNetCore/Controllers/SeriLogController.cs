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
                _logger.LogInformation("Operation starts.");
                var result = x / y;
            }
            catch (Exception ex)
            {
                var a = new { x = "fisrt", y = 2 };
                _logger.LogWarning("test {a}", a);
                using (LogContext.PushProperty("UserName", "huzeyfe-error"))
                {
                    _logger.LogError("test- Error occured!, {error}", ex);
                }

            }
            //finally
            //{
            //    Log.CloseAndFlush();
            //}

            return Ok();
        }
    }
}
