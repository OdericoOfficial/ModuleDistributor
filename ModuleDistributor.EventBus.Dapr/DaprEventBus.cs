using Dapr.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ModuleDistributor.Dapr;
using ModuleDistributor.EventBus.Abstractions;

namespace ModuleDistributor.EventBus.Dapr
{
    internal class DaprEventBus : IEventBus
    {
        private readonly DaprClient _dapr;
        private readonly ILogger _logger;
        private readonly DaprOptions _options;

        public DaprEventBus(DaprClient dapr, IOptions<DaprOptions> options, ILogger<DaprEventBus> logger)
        {
            _dapr = dapr;
            _options = options.Value;
            _logger = logger;
        }

        public async Task PublishAsync(IntegrationEvent integrationEvent)
        {
            var topicName = integrationEvent.GetType().Name;
            _logger.LogInformation("Publishing event {@Event} to {PubsubName}.{TopicName}",
                integrationEvent, _options.PubSub!, topicName);
            await _dapr.PublishEventAsync(_options.PubSub, topicName, integrationEvent);
        }
    }
}