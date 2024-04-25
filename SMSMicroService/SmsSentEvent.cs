using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSMicroService
{
	internal class SmsSentEvent
	{
        public required string PhoneNumber { get; set; }
        public required string SmsText { get; set; }
        public required DateTime Timestamp { get; set; }
    }
}
