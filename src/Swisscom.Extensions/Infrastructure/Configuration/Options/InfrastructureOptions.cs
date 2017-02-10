using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public class InfrastructureOptions
    {
        public SmtpOptions Smtp { get; set; }
    }

    /// <summary>
    /// Gets or sets the smtp configuration.
    /// </summary>
    public class SmtpOptions
    {
        public string Host { get; set; } = "";
        public int Port { get; set; } = 0;
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string SenderDisplayName { get; set; } = "";
        public string SenderAddress { get; set; } = "";
    }
}
