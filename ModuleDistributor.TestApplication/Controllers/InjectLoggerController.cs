using Microsoft.AspNetCore.Mvc;
using ModuleDistributor.Logging;
using ModuleDistributor.Serilog;

namespace ModuleDistributor.TestApplication.Controllers
{
#pragma warning disable CS1998
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InjectLoggerController : ControllerBase, ILoggerProxy
    {
        public ILogger Logger { get; }

        public InjectLoggerController(ILogger<InjectLoggerController> logger)
            => Logger = logger;


        [HttpGet]
        [Logging]
        public int GetLoggerFromInjectValueType()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Logging]
        public object GetLoggerFromInjectReference()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Logging]
        public void GetLoggerFromInject()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ExLogging]
        public async ValueTask<int> GetLoggerFromInjectValueTypeValueTaskAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ExLogging]
        public async ValueTask<object> GetLoggerFromInjectReferenceValueTaskAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ExLogging]
        public async ValueTask GetLoggerFromInjectValueTaskAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ExLogging]
        public async Task<int> GetLoggerFromInjectValueTypeTaskAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ExLogging]
        public async Task<object> GetLoggerFromInjectReferenceTaskAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ExLogging]
        public async Task GetLoggerFromInjectTaskAsync()
        {
            throw new NotImplementedException();
        }
    }
}