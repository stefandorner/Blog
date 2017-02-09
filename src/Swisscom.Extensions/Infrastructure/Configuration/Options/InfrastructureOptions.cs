using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public class InfrastructureOptions
    {

        public InfrastructureOptions()
        {
            Smtp = new SmtpOptions();
        }

        public InfrastructureOptions(IConfigurationRoot configuration)
        {
            Smtp = new SmtpOptions(configuration);
        }

        /// <summary>
        /// Gets or sets the endpoint configuration.
        /// </summary>
        /// <value>
        /// The endpoints configuration.
        /// </value>
        public SmtpOptions Smtp { get; set; }
    }

    /// <summary>
    /// Gets or sets the smtp configuration.
    /// </summary>
    public class SmtpOptions
    {

        public SmtpOptions()
        {

        }

        public SmtpOptions(IConfigurationRoot configuration)
        {
            Host = configuration.GetValue<string>("smtp:host");
            Password = configuration.GetValue<string>("smtp:password");
            Port = configuration.GetValue<int>("smtp:port");
            SenderDisplayName = configuration.GetValue<string>("smtp:senderdisplayname");
            SenderAddress = configuration.GetValue<string>("smtp:senderaddress");
            Username = configuration.GetValue<string>("smtp:username");
        }



        /// <summary>
        /// Gets or sets a value indicating whether the rss endpoint is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if the rss endpoint is enabled; otherwise, <c>false</c>.
        /// </value>
        public string Host { get; set; } = "";
        public int Port { get; set; } = 25;
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string SenderDisplayName { get; set; } = "";
        public string SenderAddress { get; set; } = "";
    }
}
