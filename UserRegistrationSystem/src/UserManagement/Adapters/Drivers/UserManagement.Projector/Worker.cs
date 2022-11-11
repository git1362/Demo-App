using EventStore.ClientAPI;
using Framework.Core.Events;
using Framework.Persistence.ES;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Domain.Contracts.Events;
using UserManagement.Projector.Framework;

namespace UserManagement.Projector
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICursor _cursor;
        private readonly IEventTypeResolver _typeResolver;
        private readonly IEventBus _eventBus;

        public Worker(ILogger<Worker> logger, 
            ICursor cursor, 
            IEventTypeResolver typeResolver, 
            IEventBus eventBus)
        {
            _logger = logger;
            //_config = config;
            _cursor = cursor;
            _typeResolver = typeResolver;
            _eventBus = eventBus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            _typeResolver.AddTypesFromAssembly(typeof(UserRegistered).Assembly);
            var conn = EventStoreConnection.Create(new Uri("tcp://admin:changeit@192.168.211.205:1113"));
            await conn.ConnectAsync();

            conn.SubscribeToAllFrom(_cursor.CurrentPosition(), CatchUpSubscriptionSettings.Default, EventAppeared);

        }

        private async Task EventAppeared(EventStoreCatchUpSubscription arg1, ResolvedEvent @event)
        {
            try
            {
                if (!@event.OriginalEvent.EventType.StartsWith("$"))
                {
                    _logger.LogInformation($"Event Appeared : {@event.OriginalEvent.EventType}");

                    //TODO: consider using domain event factory
                    var type = _typeResolver.GetType(@event.OriginalEvent.EventType);
                    if (type != null)
                    {
                        var body = Encoding.UTF8.GetString(@event.OriginalEvent.Data);
                        var domainEvent = (JsonConvert.DeserializeObject(body, type));

                        await _eventBus.Publish((dynamic)domainEvent);      //In-Memory
                    }
                    else
                    {
                        _logger.LogWarning($"type '{@event.OriginalEvent.EventType}' not found !");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}