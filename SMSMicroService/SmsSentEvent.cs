using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSMicroService
{
	public class SmsSentEvent
	{
        public required bool SmsSent { get; set; }
        public required string PhoneNumber { get; set; }
        public required string SmsText { get; set; }
        public required DateTime Timestamp { get; set; }
    }
}
