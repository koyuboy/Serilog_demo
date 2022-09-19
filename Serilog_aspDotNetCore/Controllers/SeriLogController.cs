using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Context;

namespace Serilog_aspDotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriLogController : ControllerBase
    {
        private readonly ILogger<SeriLogController> _logger;
        public SeriLogController(ILogger<SeriLogController> logger)
        {
            _logger = logger;

        }

        [HttpGet]
        public ActionResult Get([FromQuery] int x, int y)
        {
            try
            {
                Log.Information("Operation starts.");
                var result = x / y;
            }
            catch (Exception ex)
            {
                using (LogContext.PushProperty("UserName", "huzeyfe"))
                {
                    Log.Error("test- Error occured!, {error}", ex);
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
