using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleDistributor.Logging;

namespace ModuleDistributor.TestApplication.Controllers
{
#pragma warning disable CS1998
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ParameterLoggerController : ControllerBase
    {
        [HttpGet]
        [Logging]
        public int GetLoggerFromParameterValueType([FromServices] ILogger<ParameterLoggerController> logger)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Logging]
        public object GetLoggerFromParameterReference([FromServices] ILogger<ParameterLoggerController> logger)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ExLogging]
        public async ValueTask<int> GetLoggerFromParameterValueTypeValueTaskAsync([FromServices] ILogger<ParameterLoggerController> logger)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ExLogging]
        public async ValueTask<object> GetLoggerFromParameterReferenceValueTaskAsync([FromServices] ILogger<ParameterLoggerController> logger)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ExLogging]
        public async Task<int> GetLoggerFromParameterValueTypeTaskAsync([FromServices] ILogger<ParameterLoggerController> logger)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ExLogging]
        public async Task<object> GetLoggerFromParameterReferenceTaskAsync([FromServices] ILogger<ParameterLoggerController> logger)
        {
            throw new NotImplementedException();
        }
    }
}
