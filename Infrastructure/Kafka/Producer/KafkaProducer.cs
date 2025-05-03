using System.Text;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using Microsoft.Extensions.Options;
using Google.Protobuf;
using Common.Infrastructure.Configuration;
using Common.Messaging;
using Common.RequestContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Common.Infrastructure.Localization;

namespace Common.Infrastructure.Kafka.Producer
{
    /// <summary>
    /// Implementation of <see cref="IKafkaProducer{TMessage}"/> for producing messages to Kafka.
    /// </summary>
    /// <typeparam name="TMessage">The type of the Kafka message.</typeparam>
    public class KafkaProducer<TMessage> : IKafkaProducer<TMessage> where TMessage : class, IMessage<TMessage>, new()
    {
        private readonly KafkaConfig _kafkaConfig;
        private readonly IEnumerable<string> _topics;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<KafkaProducer<TMessage>> _logger;
        private readonly IProducer<string, TMessage> _producer;
        private readonly CachedSchemaRegistryClient _schemaRegistryClient;


        /// <summary>
        /// Initializes a new instance of the <see cref="KafkaProducer{TMessage}"/> class.
        /// </summary>
        /// <param name="topics">The list of Kafka topics to produce messages to.</param>
        /// <param name="config">The Kafka configuration options.</param>
        /// <param name="serviceProvider">The service provider for resolving dependencies.</param>
        /// <param name="logger">The logger for logging messages.</param>
        public KafkaProducer(
            IEnumerable<string> topics,
            IOptions<KafkaConfig> config,
            IServiceProvider serviceProvider,
            ILogger<KafkaProducer<TMessage>> logger)
        {
            _topics = topics;
            _serviceProvider = serviceProvider;
            _kafkaConfig = config.Value;
            _logger = logger;

            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = _kafkaConfig.SchemaRegistryUrl
            };

            _schemaRegistryClient = new CachedSchemaRegistryClient(schemaRegistryConfig);

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = _kafkaConfig.BootstrapServers,
                LingerMs = 1,
                BatchSize = 32768, // 32KB
                CompressionType = CompressionType.Snappy,
                MessageMaxBytes = 10485760 // 10 MB
            };

            _producer = new ProducerBuilder<string, TMessage>(producerConfig)
                .SetValueSerializer(new ProtobufSerializer<TMessage>(_schemaRegistryClient))
                .Build();
        }

        /// <summary>
        /// Produces a Kafka message asynchronously.
        /// </summary>
        /// <param name="kafkaMessage">The Kafka message to be produced.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task ProduceAsync(KafkaMessage<TMessage> kafkaMessage)
        {
            var tasks = _topics.Select(async topic =>
            {
                var messageToProduce = new Message<string, TMessage>
                {
                    Key = kafkaMessage.MessageKey!,
                    Value = kafkaMessage.Message,
                    Headers = new Headers()
                };

                foreach (var header in kafkaMessage.Headers ?? new Dictionary<string, string>())
                {
                    messageToProduce.Headers.Add(header.Key, Encoding.UTF8.GetBytes(header.Value));
                }

                var requestContext = _serviceProvider.GetService<IRequestContext>();
                if (requestContext != null)
                {
                    AddRequestContextHeaders(messageToProduce.Headers, requestContext);
                }           

                var deliveryResult = await _producer.ProduceAsync(topic, messageToProduce);
                _logger.LogInformation($"Delivered message with key '{messageToProduce.Key}' to '{deliveryResult.TopicPartitionOffset}'");
            });
            await Task.WhenAll(tasks);
        }

        private void AddRequestContextHeaders(Headers headers, IRequestContext requestContext)
        {
            headers.Add(Constants.RequestIdHeaderName, Encoding.UTF8.GetBytes(requestContext.RequestId ?? ""));
            if (requestContext.UserId != null)
            {
                headers.Add(Constants.UserIdHeaderName, Encoding.UTF8.GetBytes(requestContext.UserId));
            }
            if (requestContext.TenantId != null)
            {
                headers.Add(Constants.TenantIdHeaderName, Encoding.UTF8.GetBytes(requestContext.TenantId));
            }
            if (!headers.Any(h => h.Key == Constants.Language))
            {
                var language = KafkaLocalizationContext.GetLanguage() ?? "en-US";
                headers.Add(Constants.Language, Encoding.UTF8.GetBytes(language));
            }

            //if (requestContext.AccessToken != null)
            //{
            //    headers.Add(Constants.AccessTokenHeaderName, Encoding.UTF8.GetBytes(requestContext.AccessToken));
            //}
        }
    }
}
