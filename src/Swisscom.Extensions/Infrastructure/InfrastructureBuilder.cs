using Microsoft.Extensions.DependencyInjection;
using System;
namespace Dorner.AspNetCore.Infrastructure
{
    public class InfrastructureBuilder
    {

        public InfrastructureBuilder(Type email, Type sms, IServiceCollection services)
        {
            this.EmailType = email;
            this.SmsType = sms;
            this.Services = services;
        }

        public Type EmailType
        {
            get;
            private set;
        }

        public Type SmsType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" /> services are attached to.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" /> services are attached to.
        /// </value>
        public IServiceCollection Services
        {
            get;
            private set;
        }

        
        public virtual InfrastructureBuilder AddDefaultServices()
        {
            ServiceCollectionServiceExtensions.AddTransient(this.Services, typeof(IEmailSender), typeof(SendGridMessageSender));
            ServiceCollectionServiceExtensions.AddTransient(this.Services, typeof(ISmsSender), typeof(DefaultSmsProvider));
            return this;
        }


    }
}
