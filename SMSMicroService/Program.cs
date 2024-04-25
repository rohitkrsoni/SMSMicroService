using SMSMicroService.Implementations;

namespace SMSMicroService
{
	internal class Program
	{
        static async Task Main(string[] args)
        {
            var messageQueue = new MessageQueue();
            var eventBus = new EventBus();
            var logger = new ConsoleLogger();
            var smsMicroservice = new SmsMicroservice(messageQueue, eventBus, logger);
            Thread addRandomMessages = new(() => messageQueue.StartAddingRandomMessagesAsync());
            addRandomMessages.Start();
            await smsMicroservice.Start();
        }
    }
}
