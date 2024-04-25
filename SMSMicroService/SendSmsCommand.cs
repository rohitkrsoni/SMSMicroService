namespace SMSMicroService
{
	internal class SendSmsCommand
	{
        public required string PhoneNumber { get; set; }
		public required string SmsText { get; set; }

    }
}
