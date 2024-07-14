using SMSMicroService.Interfaces;

namespace SMSMicroService
{
	public class SmsMicroservice
	{
        private readonly IMessageQueue _messageQueue;
        private readonly IEventBus _eventBus;
        private readonly ILogger _logger;
		public SmsMicroservice(IMessageQueue messageQueue, IEventBus eventBus, ILogger logger)
        {
            _messageQueue = messageQueue;
            _eventBus = eventBus;
            _logger = logger;
        }

        public async Task Start()
        {
            _logger.Log("SMS Microservice started.");

            while (true)
            {
                var command = await _messageQueue.ReceiveMessageAsync<SendSmsCommand>();

                _logger.Log($"Received SendSms command for phone number: {command.PhoneNumber}");

                var smsSentEvent = await SendSmsAsync(command);

                await _eventBus.PublishEventAsync(smsSentEvent);
            }
        }

        private async Task<SmsSentEvent> SendSmsAsync(SendSmsCommand command)
        {
            try
            {
				using var httpClient = new HttpClient();

				var requestContent = new StringContent($"{{'PhoneNumber': '{command.PhoneNumber}', 'SmsText': '{command.SmsText}'}}");
				var response = await httpClient.PostAsync("https://4kvv1.wiremockapi.cloud/sendSms", requestContent);

				if (!response.IsSuccessStatusCode)
				{
					_logger.Log($"Failed to send SMS to {command.PhoneNumber}. Status code: {response.StatusCode}");
					return new SmsSentEvent { SmsSent = false, PhoneNumber = command.PhoneNumber, SmsText = command.SmsText, Timestamp = DateTime.UtcNow };
					// Retry can be implemented
				}

				_logger.Log($"SMS sent successfully to {command.PhoneNumber}");

				return new SmsSentEvent { SmsSent = true, PhoneNumber = command.PhoneNumber, SmsText = command.SmsText, Timestamp = DateTime.UtcNow };
			}
            catch (Exception ex)
            {
                _logger.Log($"Error sending SMS to {command.PhoneNumber}: {ex.Message}");
                throw;
            }
        }
    }
}
