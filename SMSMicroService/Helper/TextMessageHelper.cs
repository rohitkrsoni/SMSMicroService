using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSMicroService.Helper
{
	internal class TextMessageHelper
	{
		public static string GenerateRandomTextMessage()
		{
            Random random = new();
            string[] messages =
			[
			"Thank you for choosing us! We appreciate your business.",
            "Hi! Just a quick note to say thank you for your support.",
            "Your satisfaction is our top priority. Let us know if you need assistance.",
            "Hello! We're here to provide you with excellent service.",
            "Thanks for being a valued customer! Have a great day!",
            "We're grateful for your trust in us. Have a fantastic day!",
            "Dear client, your feedback is important to us. Let us know how we're doing!",
            "Thanks for choosing us. We're committed to your satisfaction.",
            "Hello! We appreciate your business. Wishing you a wonderful day!",
            "Your satisfaction is important to us. We're here to help!"
            ];

            return messages[random.Next(0,9)];
        }
	}
}
