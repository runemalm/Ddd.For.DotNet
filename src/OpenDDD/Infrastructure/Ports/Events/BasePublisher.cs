﻿using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OpenDDD.Domain.Model;
using OpenDDD.Domain.Model.Event;

namespace OpenDDD.Infrastructure.Ports.Events
{
	public abstract class BasePublisher<T> : IPublisher<T> 
		where T : IEvent
	{
		private ILogger _logger;
		protected IOutbox _outbox;

		public BasePublisher(ILogger logger, IOutbox outbox)
		{
			_logger = logger;
			_outbox = outbox;
		}

		public async Task PublishAsync(T theEvent)
		{
			_logger.LogInformation($"Publishing {theEvent.Header.Name} ({theEvent.Header.DomainModelVersion})");
			await _outbox.AddEventAsync(theEvent);
		}
	}
}
