using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dorner.Services.Blog.Models;
using Dorner.Services.Blog.EntityFramework.DbContexts;
using Dorner.Services.Blog.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Dorner.Net.Blog.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Dorner.Net.Blog.Configuration
{
    
    internal static class DatabaseConfiguration
    {
        internal static IEnumerable<Dorner.Services.Blog.Models.BlogPost> GetBlogPosts()
        {
            return new List<Dorner.Services.Blog.Models.BlogPost>
            {
                new Dorner.Services.Blog.Models.BlogPost
                {
                    Title = "Welcome to BlogService.Net",
                    BlogPostId = "welcome",
                    Body = "<p>Hello</p>",
                    Description = "Please ignore.",
                    AuthorId = 1,
                    BlogId = 1
                }
            };
        }

        internal static IEnumerable<Dorner.Services.Blog.Models.BlogCategory> GetBlogCategories()
        {
            return new List<Dorner.Services.Blog.Models.BlogCategory>
            {
                new Dorner.Services.Blog.Models.BlogCategory
                {
                    Name = "Generic",
                    Description = "",
                }
            };
        }

        internal static void EnsureSeedData(BlogEngineDbContext context)
        {
            
            if (!context.Authors.Any())
            {
                var newAuthor = context.Authors.Add(new Services.Blog.EntityFramework.Entities.BlogAuthor() {
                    DisplayName = "Administrator",
                    EmailAddress = "noreply@blogservice.net",
                    IdentityId = "" });
                context.SaveChanges();
            }

            if (!context.Blogs.Any())
            {
                var blogEntry = context.Blogs.Add(new Services.Blog.EntityFramework.Entities.Blog()
                {
                    Title = "My Blog"
                });
                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                var blogEntry = context.Categories.Add(new Services.Blog.EntityFramework.Entities.BlogCategory()
                {
                    BlogId = 1,
                    Name = "Generic"
                });
                context.SaveChanges();
            }

            if (!context.Posts.Any())
            {
                var blogEntry = context.Posts.Add(new Services.Blog.EntityFramework.Entities.BlogPost()
                {
                    Title = "Welcome to BlogService.Net",
                    BlogPostId = "welcome",
                    Body = "<p>Hello</p>",
                    Description = "Please ignore.",
                    DateCreated = DateTime.Today,
                    DateUpdated = DateTime.Today,
                    IsPublished = false,
                    AuthorId = 1,
                    BlogId = 1
                });
                context.SaveChanges();
            }

            if (!context.PostCategories.Any())
            {
                var blogEntry = context.PostCategories.Add(new Services.Blog.EntityFramework.Entities.BlogPostCategory()
                {
                    BlogCategoryId = 1,
                    BlogPostId = 1
                });
                context.SaveChanges();
            }



        }

        internal static async Task CreateAdminAccount(IServiceScope serviceScope)
        {
            UserManager<Models.ApplicationUser> userManager = serviceScope.ServiceProvider.GetService<UserManager<Models.ApplicationUser>>();
            SignInManager<Models.ApplicationUser> signInManager = serviceScope.ServiceProvider.GetService<SignInManager<Models.ApplicationUser>>();

            ApplicationIdentityDbContext dbContext = serviceScope.ServiceProvider.GetService<ApplicationIdentityDbContext>();
            if (!dbContext.Users.Any())
            {
                var user = new Models.ApplicationUser
                {
                    Email = "administrator@blogservice.local",
                    UserName = "Administrator",

                };
                var identityResult = await userManager.CreateAsync(user, "Pass@Word1");


                if (identityResult.Succeeded)
                {
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    //await signInManager.SignInAsync(user, isPersistent: false);
                    var result = await userManager.ConfirmEmailAsync(user, code);
                    //return View(result.Succeeded ? "ConfirmEmail" : "Error");
                }
                
            }

            



        }



    }
}
