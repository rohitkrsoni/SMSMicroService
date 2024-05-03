using SMSMicroService;
using SMSMicroService.Implementations;

namespace SmsMicroservice.Tests
{
    public class SmsMicroserviceTests
    {
        private readonly SMSMicroService.SmsMicroservice _smsMicroservice;
        private readonly EventBus _eventBus;


        public SmsMicroserviceTests()
        {
            _eventBus = new EventBus();
            _smsMicroservice = new SMSMicroService.SmsMicroservice(new MessageQueue(), _eventBus, new ConsoleLogger());
        }

        private async Task<SmsSentEvent> InvokeSendSmsAsync(SendSmsCommand command)
        {
            var methodInfo = typeof(SMSMicroService.SmsMicroservice).GetMethod("SendSmsAsync", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return await (Task<SmsSentEvent>)methodInfo.Invoke(_smsMicroservice, [command]);
        }

        [Fact]
        public async Task SendSmsAsync_ValidCommand_ReturnsSmsSentEvent()
        {
            // Arrange
            var command = new SendSmsCommand
            {
                PhoneNumber = "7001239875",
                SmsText = "Hello from Test Project"
            };

            // Act
            var result = await InvokeSendSmsAsync(command);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.SmsSent);
            Assert.Equal(command.PhoneNumber, result.PhoneNumber);
            Assert.Equal(command.SmsText, result.SmsText);
        }

		[Fact]
		public async Task SendSmsAsync_InValidCommand_ReturnsSmsSentEvent()
		{
			// Arrange
			var command = new SendSmsCommand
			{
				PhoneNumber = "1234567890", // Invalid PhoneNumber
				SmsText = "Hello from ABC!" // Invalid TextMessage
			};

			// Act
			var result = await InvokeSendSmsAsync(command);

			// Assert
			Assert.NotNull(result);
			Assert.False(result.SmsSent);
			Assert.Equal(command.PhoneNumber, result.PhoneNumber);
			Assert.Equal(command.SmsText, result.SmsText);
		}
    }
}
