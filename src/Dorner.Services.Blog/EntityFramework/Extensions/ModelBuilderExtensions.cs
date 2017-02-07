using Dorner.Services.Blog.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.EntityFramework.Extensions
{
    public static class ModelBuilderExtensions
    {
        private static EntityTypeBuilder<TEntity> ToTable<TEntity>(this EntityTypeBuilder<TEntity> entityTypeBuilder, TableConfiguration configuration)
            where TEntity : class
        {
            return string.IsNullOrWhiteSpace(configuration.Schema) ? entityTypeBuilder.ToTable(configuration.Name) : entityTypeBuilder.ToTable(configuration.Name, configuration.Schema);
        }

        public static void ConfigureBlogEngineContext(this ModelBuilder modelBuilder, BlogEngineStoreOptions storeOptions)
        {
            if (!string.IsNullOrWhiteSpace(storeOptions.DefaultSchema)) modelBuilder.HasDefaultSchema(storeOptions.DefaultSchema);

            modelBuilder.Entity<Entities.BlogEntry>(blogEntry =>
            {
                blogEntry.ToTable(storeOptions.BlogEntries);
                blogEntry.HasKey(x => x.Id);

                blogEntry.Property(x => x.BlogEntryId).HasMaxLength(200).IsRequired();
                //policy.Property(x => x.ProtocolType).HasMaxLength(200).IsRequired();
                blogEntry.Property(x => x.Title).HasMaxLength(200);
                //policy.Property(x => x.ClientUri).HasMaxLength(2000);

                blogEntry.HasIndex(x => x.Id).IsUnique();

                //policy.HasMany(x => x.AllowedGrantTypes).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
                //policy.HasMany(x => x.RedirectUris).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
                //policy.HasMany(x => x.PostLogoutRedirectUris).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
                //policy.HasMany(x => x.AllowedScopes).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
                //policy.HasMany(x => x.ClientSecrets).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
                //policy.HasMany(x => x.Claims).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
                //policy.HasMany(x => x.IdentityProviderRestrictions).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
                //policy.HasMany(x => x.AllowedCorsOrigins).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            //modelBuilder.Entity<ClientGrantType>(grantType =>
            //{
            //    grantType.ToTable(storeOptions.ClientGrantType);
            //    grantType.Property(x => x.GrantType).HasMaxLength(250).IsRequired();
            //});

            //modelBuilder.Entity<ClientRedirectUri>(redirectUri =>
            //{
            //    redirectUri.ToTable(storeOptions.ClientRedirectUri);
            //    redirectUri.Property(x => x.RedirectUri).HasMaxLength(2000).IsRequired();
            //});

            //modelBuilder.Entity<ClientPostLogoutRedirectUri>(postLogoutRedirectUri =>
            //{
            //    postLogoutRedirectUri.ToTable(storeOptions.ClientPostLogoutRedirectUri);
            //    postLogoutRedirectUri.Property(x => x.PostLogoutRedirectUri).HasMaxLength(2000).IsRequired();
            //});

            //modelBuilder.Entity<ClientScope>(scope =>
            //{
            //    scope.ToTable(storeOptions.ClientScopes);
            //    scope.Property(x => x.Scope).HasMaxLength(200).IsRequired();
            //});

            //modelBuilder.Entity<ClientSecret>(secret =>
            //{
            //    secret.ToTable(storeOptions.ClientSecret);
            //    secret.Property(x => x.Value).HasMaxLength(2000).IsRequired();
            //    secret.Property(x => x.Type).HasMaxLength(250);
            //    secret.Property(x => x.Description).HasMaxLength(2000);
            //});

            //modelBuilder.Entity<ClientClaim>(claim =>
            //{
            //    claim.ToTable(storeOptions.ClientClaim);
            //    claim.Property(x => x.Type).HasMaxLength(250).IsRequired();
            //    claim.Property(x => x.Value).HasMaxLength(250).IsRequired();
            //});

            //modelBuilder.Entity<ClientIdPRestriction>(idPRestriction =>
            //{
            //    idPRestriction.ToTable(storeOptions.ClientIdPRestriction);
            //    idPRestriction.Property(x => x.Provider).HasMaxLength(200).IsRequired();
            //});

            //modelBuilder.Entity<ClientCorsOrigin>(corsOrigin =>
            //{
            //    corsOrigin.ToTable(storeOptions.ClientCorsOrigin);
            //    corsOrigin.Property(x => x.Origin).HasMaxLength(150).IsRequired();
            //});
        }
    }
}
