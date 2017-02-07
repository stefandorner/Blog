using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Dorner.Services.Blog.EntityFramework.DbContexts;

namespace Dorner.Net.Blog.Migrations
{
    [DbContext(typeof(BlogEngineDbContext))]
    partial class BlogEngineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Dorner.Services.Blog.EntityFramework.Entities.BlogEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlogEntryId")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Description");

                    b.Property<string>("Text");

                    b.Property<string>("Title")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("BlogEntries");
                });
        }
    }
}
