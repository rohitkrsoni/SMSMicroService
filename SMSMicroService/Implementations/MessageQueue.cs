using SMSMicroService.Interfaces;
using System.Collections.Concurrent;
using SMSMicroService.Helper;

namespace SMSMicroService.Implementations
{
	public class MessageQueue: IMessageQueue
	{
        private readonly ConcurrentQueue<object> _queue;

        public MessageQueue()
        {
            _queue = new ConcurrentQueue<object>();           
        }

        public void SendMessage<T>(T message)
        {
            if (message != null)
            {
                _queue.Enqueue(message);

            }
        }

        public async Task<T> ReceiveMessageAsync<T>()
        {
            while (true)
            {
				if (_queue.TryDequeue(out var message))
                {
                    return (T)message;
                }
                await Task.Delay(1000); // Adjust delay according to your requirement
            }
        }

        public void StartAddingRandomMessagesAsync()
        {
            while (true)
            {
                var phoneNumber = PhoneNumberHelper.GenerateRandomPhoneNumber();
                var smsText = TextMessageHelper.GenerateRandomTextMessage();
                SendMessage(new SendSmsCommand { PhoneNumber = phoneNumber, SmsText = smsText });
                Thread.Sleep(1500); // Adjust delay according to your requirement
            }
        }
    }
}
