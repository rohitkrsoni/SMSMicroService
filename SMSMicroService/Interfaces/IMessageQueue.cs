﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSMicroService.Interfaces
{
	public interface IMessageQueue
	{
        Task<T> ReceiveMessageAsync<T>();
        public void SendMessage<T>(T message);
    }
}
