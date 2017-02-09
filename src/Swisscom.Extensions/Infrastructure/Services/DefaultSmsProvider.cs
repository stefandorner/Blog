using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.AspNetCore.Infrastructure
{
    public class DefaultSmsProvider : ISmsSender
    {
        public Task SendSmsAsync(string number, string message)
        {
            return Task.FromResult(0);
        }
    }
}
