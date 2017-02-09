using Dorner.BlogEngineCore.Configuration.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    
    /// <summary>
    /// The AccessControlServerOptions class is the top level container for all configuration settings of AccessControlServer.
    /// </summary>
    public class BlogEngineOptions
    {


        /// <summary>
        /// Gets or sets the endpoint configuration.
        /// </summary>
        /// <value>
        /// The endpoints configuration.
        /// </value>
        public EndpointsOptions Endpoints { get; set; } = new EndpointsOptions();

        /// <summary>
        /// Gets or sets the discovery endpoint configuration.
        /// </summary>
        /// <value>
        /// The discovery endpoint configuration.
        /// </value>
        //public DiscoveryOptions Discovery { get; set; } = new DiscoveryOptions();

        /// <summary>
        /// Gets or sets the authentication options.
        /// </summary>
        /// <value>
        /// The authentication options.
        /// </value>
        //public AuthenticationOptions Authentication { get; set; } = new AuthenticationOptions();

        /// <summary>
        /// Gets or sets the protocol logout urls.
        /// </summary>
        /// <value>
        /// The protocol logout urls.
        /// </value>
        //public ICollection<string> ProtocolLogoutUrls { get; set; } = new HashSet<string>();

        /// <summary>
        /// Gets or sets the events options.
        /// </summary>
        /// <value>
        /// The events options.
        /// </value>
        public EventsOptions Events { get; set; } = new EventsOptions();

        /// <summary>
        /// Gets or sets the max input length restrictions.
        /// </summary>
        /// <value>
        /// The length restrictions.
        /// </value>
        //public InputLengthRestrictions InputLengthRestrictions { get; set; } = new InputLengthRestrictions();

        /// <summary>
        /// Gets or sets the options for the user interaction.
        /// </summary>
        /// <value>
        /// The user interaction options.
        /// </value>
        public UserInteractionOptions UserInteraction { get; set; } = new UserInteractionOptions();

        /// <summary>
        /// Gets or sets the caching options.
        /// </summary>
        /// <value>
        /// The caching options.
        /// </value>
        public CachingOptions Caching { get; set; } = new CachingOptions();

        /// <summary>
        /// Gets or sets the cors options.
        /// </summary>
        /// <value>
        /// The cors options.
        /// </value>
        public CorsOptions Cors { get; set; } = new CorsOptions();
    }
}
