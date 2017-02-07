using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public interface IBlogEngineBuilder
    {
        IServiceCollection Services { get; }
    }

    public class BlogEngineBuilder : IBlogEngineBuilder
    {
        public BlogEngineBuilder(IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
