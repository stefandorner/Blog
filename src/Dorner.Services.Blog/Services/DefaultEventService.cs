using Dorner.BlogEngineCore.Events;
using Dorner.BlogEngineCore.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Dorner.BlogEngineCore.Services
{
    /// <summary>
    /// Default implementation of the event service. Write events raised to the log.
    /// </summary>
    public class DefaultEventService : IEventService
    {
        private readonly EventServiceHelper _helper;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;

        public DefaultEventService(ILogger<DefaultEventService> logger, EventServiceHelper helper)
        {
            _logger = logger;
            _helper = helper;
        }

        /// <summary>
        /// Raises the specified event.
        /// </summary>
        /// <param name="evt">The event.</param>
        /// <exception cref="System.ArgumentNullException">evt</exception>
        public virtual Task RaiseAsync<T>(Event<T> evt)
        {
            if (evt == null) throw new ArgumentNullException(nameof(evt));

            if (_helper.CanRaiseEvent(evt))
            {
                var json = LogSerializer.Serialize(_helper.PrepareEvent(evt));
                _logger.LogInformation(json);
            }

            return Task.FromResult(0);
        }
    }
}
