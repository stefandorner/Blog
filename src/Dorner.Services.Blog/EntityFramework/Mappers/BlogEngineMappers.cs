using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.EntityFramework.Mappers
{
    public static class BlogEngineMappers
    {
        static BlogEngineMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<BlogEntryMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Models.BlogEntry ToModel(this Entities.BlogEntry blogEntry)
        {
            return Mapper.Map<Models.BlogEntry>(blogEntry);
        }

        public static Entities.BlogEntry ToEntity(this Models.BlogEntry blogEntry)
        {
            return Mapper.Map<Entities.BlogEntry>(blogEntry);
        }
    }
}
