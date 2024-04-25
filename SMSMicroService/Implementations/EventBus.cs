using SMSMicroService.Interfaces;


namespace SMSMicroService.Implementations
{
	internal class EventBus: IEventBus
	{
        private readonly List<Object> _publishedEvents;

        public EventBus()
        {
			_publishedEvents = [];
        }

        public async Task PublishEventAsync<T>(T evt)
        {
            if (evt != null) {
                _publishedEvents.Add(evt);
            }
            await Task.Delay(0);
        }
    }
}
