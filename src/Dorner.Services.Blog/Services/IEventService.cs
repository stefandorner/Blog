using Dorner.BlogServiceCore.Events;
using System.Threading.Tasks;

namespace Dorner.BlogServiceCore.Services
{
    /// <summary>
    /// Models a recipient of notification of events
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Raises the specified event.
        /// </summary>
        /// <param name="evt">The event.</param>
        Task RaiseAsync<T>(Event<T> evt);
    }
}
