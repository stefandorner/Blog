using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.EntityFramework.Mappers
{
    
    /// <summary>
    /// AutoMapper configuration for BlogEntry
    /// Between model and entity
    /// </summary>
    public class BlogEntryMapperProfile : Profile
    {
        /// <summary>
        /// <see>
        ///     <cref>{BlogEntryMapperProfile}</cref>
        /// </see>
        /// </summary>
        public BlogEntryMapperProfile()
        {
            CreateMap<Entities.Blog, Models.Blog>(MemberList.Destination);
            CreateMap<Models.Blog, Entities.Blog>(MemberList.Source);
            CreateMap<Entities.BlogAuthor, Models.BlogAuthor>(MemberList.Destination);
            CreateMap<Models.BlogAuthor, Entities.BlogAuthor>(MemberList.Source);
            // entity to model
            CreateMap<Entities.BlogPost, Models.BlogPost>(MemberList.Destination)
            //.ForMember(x => x.AllowedGrantTypes,
            //    opt => opt.MapFrom(src => src.AllowedGrantTypes.Select(x => x.GrantType)))
            //.ForMember(x => x.RedirectUris, opt => opt.MapFrom(src => src.RedirectUris.Select(x => x.RedirectUri)))
            //.ForMember(x => x.PostLogoutRedirectUris,
            //    opt => opt.MapFrom(src => src.PostLogoutRedirectUris.Select(x => x.PostLogoutRedirectUri)))
            //.ForMember(x => x.AllowedScopes, opt => opt.MapFrom(src => src.AllowedScopes.Select(x => x.Scope)))
            
            .ForMember(x => x.Categories, opt => opt.MapFrom(src => src.Categories.Select(x => x)))
            .ForMember(x => x.Tags, opt => opt.MapFrom(src => src.Tags.Select(x => x)))
            .ForMember(x => x.Author, c => c.MapFrom(e => e.Author))
            .ForMember(x => x.Blog, c => c.MapFrom(e => e.Blog))
            //.ForMember(x => x.Claims, opt => opt.MapFrom(src => src.Claims.Select(x => new Claim(x.Type, x.Value))))
            //.ForMember(x => x.IdentityProviderRestrictions,
            //    opt => opt.MapFrom(src => src.IdentityProviderRestrictions.Select(x => x.Provider)))
            //.ForMember(x => x.AllowedCorsOrigins,
            //    opt => opt.MapFrom(src => src.AllowedCorsOrigins.Select(x => x.Origin)))
            ;

            //CreateMap<ClientSecret, Models.Secret>(MemberList.Destination)
            //    .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null));

            //// model to entity
            CreateMap<Models.BlogPost, Entities.BlogPost>(MemberList.Source);
            //    .ForMember(x => x.AllowedGrantTypes,
            //        opt => opt.MapFrom(src => src.AllowedGrantTypes.Select(x => new ClientGrantType { GrantType = x })))
            //    .ForMember(x => x.RedirectUris,
            //        opt => opt.MapFrom(src => src.RedirectUris.Select(x => new ClientRedirectUri { RedirectUri = x })))
            //    .ForMember(x => x.PostLogoutRedirectUris,
            //        opt =>
            //            opt.MapFrom(
            //                src =>
            //                    src.PostLogoutRedirectUris.Select(
            //                        x => new ClientPostLogoutRedirectUri { PostLogoutRedirectUri = x })))
            //    .ForMember(x => x.AllowedScopes,
            //        opt => opt.MapFrom(src => src.AllowedScopes.Select(x => new ClientScope { Scope = x })))
            //    .ForMember(x => x.Claims,
            //        opt => opt.MapFrom(src => src.Claims.Select(x => new ClientClaim { Type = x.Type, Value = x.Value })))
            //    .ForMember(x => x.IdentityProviderRestrictions,
            //        opt =>
            //            opt.MapFrom(
            //                src => src.IdentityProviderRestrictions.Select(x => new ClientIdPRestriction { Provider = x })))
            //    .ForMember(x => x.AllowedCorsOrigins,
            //        opt => opt.MapFrom(src => src.AllowedCorsOrigins.Select(x => new ClientCorsOrigin { Origin = x })));
            //CreateMap<Models.Secret, ClientSecret>(MemberList.Source);

        }
    }
}
