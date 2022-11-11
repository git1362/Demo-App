using System.Threading.Tasks;
using Framework.Domain.Snapshots;

namespace Framework.Domain
{
    public class EventSourceRepository<T, TKey> : IEventSourceRepository<T, TKey> where T : AggregateRoot<TKey>
    {
        private readonly IEventStore _eventStore;
        private readonly IAggregateFactory _aggregateFactory;
        public EventSourceRepository(IEventStore eventStore, IAggregateFactory aggregateFactory)
        {
            _eventStore = eventStore;
            _aggregateFactory = aggregateFactory;
        }
        public async Task<T> GetById(TKey id)
        {
            var listOfEvents = await _eventStore.GetEventsOfStream<T,TKey>(id, 0);
            return _aggregateFactory.Create<T>(listOfEvents);
        }

        public async Task AppendEvents(T aggregate)
        {
            await _eventStore.AppendEvents<T, TKey>(aggregate);
        }
    }
}