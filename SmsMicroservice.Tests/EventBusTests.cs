using SMSMicroService;
using SMSMicroService.Implementations;

namespace SmsMicroservice.Tests
{
	public class EventBusTests
	{
		private readonly EventBus _eventBus;
		public EventBusTests() { 
			_eventBus = new EventBus();
		}

		[Fact]
		public async Task PublishEventAsync_AddsSuccessEventToList()
		{
			// Arrange
			var testEvent = new SmsSentEvent()
			{
				SmsSent = true,
				PhoneNumber = "7006789876",
				SmsText = "Hello from test",
				Timestamp = DateTime.Now
			};

			// Act
			await _eventBus.PublishEventAsync(testEvent);

			// Assert
			Assert.Contains(testEvent, _eventBus.GetPublishedEvents());
		}

		[Fact]
		public async Task PublishEventAsync_AddsFailureEventToList()
		{
			// Arrange
			var testEvent = new SmsSentEvent()
			{
				SmsSent = false,
				PhoneNumber = "7006789876",
				SmsText = "Hello from test",
				Timestamp = DateTime.Now
			};

			// Act
			await _eventBus.PublishEventAsync(testEvent);

			// Assert
			Assert.Contains(testEvent, _eventBus.GetPublishedEvents());
		}

	}
}
