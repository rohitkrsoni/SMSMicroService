namespace SMSMicroService.Helper
{
	internal class PhoneNumberHelper
	{
		public static string GenerateRandomPhoneNumber()
		{
            Random random = new();
            return string.Format("{0:000}{1:000}{2:0000}", random.Next(700, 999), random.Next(0, 999), random.Next(0, 9999));
		}
	}
}
