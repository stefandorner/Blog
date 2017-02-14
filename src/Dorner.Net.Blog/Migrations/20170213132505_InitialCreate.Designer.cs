﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Dorner.Services.Blog.EntityFramework.DbContexts;

namespace Dorner.Net.Blog.Migrations
{
    [DbContext(typeof(BlogEngineDbContext))]
    [Migration("20170213132505_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Dorner.Services.Blog.EntityFramework.Entities.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BaseUrl");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DatePublished");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<string>("HostHeader");

                    b.Property<string>("Title")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Dorner.Services.Blog.EntityFramework.Entities.BlogAuthor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("IdentityId");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("BlogAuthors");
                });

            modelBuilder.Entity("Dorner.Services.Blog.EntityFramework.Entities.BlogCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogId");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("BlogCategories");
                });

            modelBuilder.Entity("Dorner.Services.Blog.EntityFramework.Entities.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<int>("BlogId");

                    b.Property<string>("BlogPostId")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Body");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DatePublished");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Title")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BlogId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("Dorner.Services.Blog.EntityFramework.Entities.BlogPostCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogCategoryId");

                    b.Property<int>("BlogPostId");

                    b.HasKey("ID");

                    b.HasIndex("BlogCategoryId");

                    b.HasIndex("BlogPostId");

                    b.ToTable("BlogPostCategories");
                });

            modelBuilder.Entity("Dorner.Services.Blog.EntityFramework.Entities.BlogPostTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("BlogPostTag");
                });

            modelBuilder.Entity("Dorner.Services.Blog.EntityFramework.Entities.BlogCategory", b =>
                {
                    b.HasOne("Dorner.Services.Blog.EntityFramework.Entities.Blog", "Blog")
                        .WithMany("Categories")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dorner.Services.Blog.EntityFramework.Entities.BlogPost", b =>
                {
                    b.HasOne("Dorner.Services.Blog.EntityFramework.Entities.BlogAuthor", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dorner.Services.Blog.EntityFramework.Entities.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dorner.Services.Blog.EntityFramework.Entities.BlogPostCategory", b =>
                {
                    b.HasOne("Dorner.Services.Blog.EntityFramework.Entities.BlogCategory", "Category")
                        .WithMany()
                        .HasForeignKey("BlogCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dorner.Services.Blog.EntityFramework.Entities.BlogPost", "Post")
                        .WithMany("Categories")
                        .HasForeignKey("BlogPostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dorner.Services.Blog.EntityFramework.Entities.BlogPostTag", b =>
                {
                    b.HasOne("Dorner.Services.Blog.EntityFramework.Entities.BlogPost", "Post")
                        .WithMany("Tags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
