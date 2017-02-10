using Microsoft.Extensions.DependencyInjection;
using System;
namespace Dorner.AspNetCore.Infrastructure
{
    public interface IInfrastructureBuilder
    {
        IServiceCollection Services { get; }

        IInfrastructureBuilder AddDefaultServices();
    }


    public class InfrastructureBuilder : IInfrastructureBuilder
    {

        public InfrastructureBuilder(Type email, Type sms, IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

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

        
        public virtual IInfrastructureBuilder AddDefaultServices()
        {
            ServiceCollectionServiceExtensions.AddTransient(this.Services, this.EmailType, typeof(SendGridMessageSender));
            ServiceCollectionServiceExtensions.AddTransient(this.Services, this.SmsType, typeof(DefaultSmsProvider));
            return this;
        }


    }
}
