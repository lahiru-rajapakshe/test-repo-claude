using Microsoft.Extensions.Hosting;

namespace Common.Infrastructure.Kafka.TopicInitializer
{
    /// <summary>
    /// Hosted service for initializing Kafka topics.
    /// </summary>
    public class TopicInitializerHostedService : BackgroundService
    {
        private readonly ITopicInitializer _topicInitializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicInitializerHostedService"/> class.
        /// </summary>
        /// <param name="topicInitializer">The topic initializer implementation.</param>
        public TopicInitializerHostedService(ITopicInitializer topicInitializer)
        {
            _topicInitializer = topicInitializer;
        }

        /// <summary>
        /// Executes the background initialization task.
        /// </summary>
        /// <param name="stoppingToken">A <see cref="CancellationToken"/> that is triggered when the host is shutting down.</param>
        /// <returns>A task representing the initialization operation.</returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _topicInitializer.InitializeAsync();
        }
    }
}