using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Dorner.BlogEngineCore.Events
{
    public class EventServiceHelper
    {
        private readonly BlogEngineOptions _options;
        private readonly IHttpContextAccessor _context;

        public EventServiceHelper(BlogEngineOptions options, IHttpContextAccessor context)
        {
            _options = options;
            _context = context;
        }

        public bool CanRaiseEvent<T>(Event<T> evt)
        {
            switch (evt.EventType)
            {
                case EventTypes.Failure:
                    return _options.Events.RaiseFailureEvents;
                case EventTypes.Information:
                    return _options.Events.RaiseInformationEvents;
                case EventTypes.Success:
                    return _options.Events.RaiseSuccessEvents;
                case EventTypes.Error:
                    return _options.Events.RaiseErrorEvents;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public virtual Event<T> PrepareEvent<T>(Event<T> evt)
        {
            if (evt == null) throw new ArgumentNullException("evt");

            evt.Context = new EventContext
            {
                ActivityId = _context.HttpContext.TraceIdentifier,
                TimeStamp = DateTime.UtcNow,
                ProcessId = Process.GetCurrentProcess().Id,
            };

            if (_context.HttpContext.Connection.RemoteIpAddress != null)
            {
                evt.Context.RemoteIpAddress = _context.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {
                evt.Context.RemoteIpAddress = "unknown";
            }

            //var principal = _context.HttpContext.User;
            //if (principal != null && principal.Identity != null)
            //{
            //    var subjectClaim = principal.FindFirst(JwtClaimTypes.Subject);
            //    if (subjectClaim != null)
            //    {
            //        evt.Context.SubjectId = subjectClaim.Value;
            //    }
            //}

            return evt;
        }
    }
}
