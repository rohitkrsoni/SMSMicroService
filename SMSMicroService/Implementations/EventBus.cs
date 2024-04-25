using SMSMicroService.Interfaces;


namespace SMSMicroService.Implementations
{
	internal class EventBus: IEventBus
	{
        private readonly Dictionary<Type, List<Func<object, Task>>> _eventHandlers;

        public EventBus()
        {
            _eventHandlers = new Dictionary<Type, List<Func<object, Task>>>();
        }

        public void Subscribe<T>(Func<T, Task> handler)
        {
            if (!_eventHandlers.TryGetValue(typeof(T), out var handlers))
            {
                handlers = new List<Func<object, Task>>();
                _eventHandlers.Add(typeof(T), handlers);
            }

            handlers.Add(async @event => await handler((T)@event));
        }

        public async Task PublishEventAsync<T>(T @event)
        {
            if (_eventHandlers.TryGetValue(typeof(T), out var handlers))
            {
                foreach (var handler in handlers)
                {
					await handler(@event);
                }
            }
        }
    }
}
