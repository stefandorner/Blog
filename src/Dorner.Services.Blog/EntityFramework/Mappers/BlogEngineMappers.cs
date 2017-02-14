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

        public static Models.BlogPost ToModel(this Entities.BlogPost blogEntry)
        {
            return Mapper.Map<Models.BlogPost>(blogEntry);
        }

        public static Models.BlogCategory ToModel(this Entities.BlogCategory blogCategory)
        {
            return Mapper.Map<Models.BlogCategory>(blogCategory);
        }

        public static Models.BlogAuthor ToModel(this Entities.BlogAuthor entity)
        {
            return Mapper.Map<Models.BlogAuthor>(entity);
        }

        public static List<Models.BlogPost> ToModelList(this IQueryable<Entities.BlogPost> blogEntries)
        {
            List<Models.BlogPost> list = new List<Models.BlogPost>();

            foreach (var entry in blogEntries)
            {
                list.Add(Mapper.Map<Models.BlogPost>(entry));
            }

            return list;
        }

        public static List<Models.BlogCategory> ToModelList(this IQueryable<Entities.BlogCategory> blogCategories)
        {
            List<Models.BlogCategory> list = new List<Models.BlogCategory>();

            foreach (var entry in blogCategories)
            {
                list.Add(Mapper.Map<Models.BlogCategory>(entry));
            }

            return list;
        }

        public static Entities.BlogPost ToEntity(this Models.BlogPost blogEntry)
        {
            return Mapper.Map<Entities.BlogPost>(blogEntry);
        }

        public static Entities.BlogCategory ToEntity(this Models.BlogCategory blogCategory)
        {
            return Mapper.Map<Entities.BlogCategory>(blogCategory);
        }

        public static Entities.BlogPostCategory ToEntity(this Models.BlogPostCategory entity)
        {
            return Mapper.Map<Entities.BlogPostCategory>(entity);
        }

        public static Entities.BlogAuthor ToEntity(this Models.BlogAuthor blogEntry)
        {
            return Mapper.Map<Entities.BlogAuthor>(blogEntry);
        }


    }
}
