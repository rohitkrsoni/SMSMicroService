# SMS Microservice

The SMS Microservice is a simple microservice that acts as a wrapper around the API for a third-party SMS service. It listens for `SendSms` commands on a message queue, sends an HTTP request to the third-party SMS service, and then publishes an `SmsSent` event to a global event bus upon successful SMS delivery.

## How to Build and Run the Application

1. **Download the Files**:

2. **Open the solution file**:

    - Navigate to the `SMSMicroservice` directory.
    - Open the `SMSMicroservice.sln` solution file in Visual Studio.

3. **Build the solution**:

    - Build the solution by clicking on the "Build" menu and selecting "Build Solution", or by pressing `Ctrl+Shift+B`.

4. **Run the application**:

    - Open the `Program.cs` file in the `SMSMicroservice` project.
    - Run the `Main` method.

## How to Run Tests

1. **Open the solution file**:

    - Navigate to the `SMSMicroservice` directory.
    - Open the `SMSMicroservice.sln` solution file in Visual Studio.

2. **Run the tests**:

    - Open the Test Explorer window by clicking on "Test" > "Test Explorer" from the top menu.
    - Run all tests by clicking on "Run All" in the Test Explorer window.

## Additional Information

### Components Used

- `IMessageQueue`: Interface for the message queue.
- `IEventBus`: Interface for the event bus.
- `ILogger`: Interface for the logger.
- `MessageQueue`: Concrete implementation of `IMessageQueue`.
- `EventBus`: Concrete implementation of `IEventBus`.
- `ConsoleLogger`: Concrete implementation of `ILogger`.
- `SendSmsCommand`: Command class for sending SMS.
- `SmsSentEvent`: Event class for successful SMS delivery.

### Features

- Asynchronous message-based communication.
- Reliable SMS delivery using an async flow.
- Basic error handling and logging.

### Next Steps

- Implement concrete implementations for the message queue, event bus, and logger.
- Write more extensive tests for the application logic.
- Implement retry logic for failed SMS deliveries.
- Improve error handling to handle edge cases and ensure graceful degradation.
