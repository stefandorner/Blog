using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Dorner.Net.Blog.Models;
using Swisscom.Extensions.Configuration;
using Dorner.Net.Blog.Configuration;
using System.Reflection;
using Dorner.Services.Blog.EntityFramework.DbContexts;
using Dorner.Net.Blog.Data;
using MySQL.Data.Entity.Extensions;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;

namespace Dorner.Net.Blog
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddInfrastructure(Configuration)
                .AddDefaultServices();

            // Add Identity services
            services.AddDbContext<Data.ApplicationIdentityDbContext>(options =>
                options.UseMySQL(Configuration.GetMariaDBConnectionString(Configuration.GetValue<string>("BLOG_DB_NAME"))));
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<Data.ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            // Add Blog Engine services
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddBlogEngine()
                .AddBlogEngineStore(builder =>
                    builder.UseMySQL(Configuration.GetMariaDBConnectionString(Configuration.GetValue<string>("BLOG_DB_NAME")),
                        options => options.MigrationsAssembly(migrationsAssembly)));

            // Add compression
            services.Configure<GzipCompressionProviderOptions>
            (options => options.Level = CompressionLevel.Optimal);
                services.AddResponseCompression(options =>
                {
                    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                    {
                        // General
                        "text/plain",
                        // Static files
                        "text/css",
                        "application/javascript",
                        // MVC
                        "text/html",
                        "application/xml",
                        "text/xml",
                        "application/json",
                        "text/json"
                    });
                    options.EnableForHttps = true;
                    options.Providers.Add<GzipCompressionProvider>();
                });


            services.AddMvc();
            services.Configure<RazorViewEngineOptions>(opts =>
                opts.FileProviders.Add(new DatabaseFileProvider(Configuration.GetMariaDBConnectionString(Configuration.GetValue<string>("BLOG_DB_NAME"))))
            );
            // Add application services.
            //services.AddTransient<IEmailSender, SmtpMessageSender>();
            //services.AddTransient<ISmsSender, SmtpMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                
                OnPrepareResponse = ctx =>
                {
                    int durationInSeconds = 60 * 60 * 1;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + durationInSeconds;
                }
            });

            #region Setup Databases

            // Identity Service
            // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
            try
            {
                //ApplicationIdentityDbContextFactory.Create()
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var result = serviceScope.ServiceProvider.GetService<ApplicationIdentityDbContext>().Database.EnsureCreated();
                    DatabaseConfiguration.CreateAdminAccount(serviceScope).Wait();
                }
            }
            catch (System.Exception ex)
            {
                loggerFactory.CreateLogger<ApplicationIdentityDbContext>().LogError(ex.Message);
            }

            //Blog Engine Service
            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<BlogEngineDbContext>().Database.EnsureCreated();
                    serviceScope.ServiceProvider.GetService<BlogEngineDbContext>().Database.Migrate();
                    DatabaseConfiguration.EnsureSeedData(serviceScope.ServiceProvider.GetService<BlogEngineDbContext>());
                }
            }
            catch (System.Exception ex)
            {
                loggerFactory.CreateLogger<BlogEngineDbContext>().LogError(ex.Message);
            }

            #endregion

            app.UseIdentity();
            
            app.UseBlogEngine();
            app.UseResponseCompression();

            //app.Use(Startup.ChangeContextToHttps);
            
            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715
            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute", "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        //private static RequestDelegate ChangeContextToHttps(RequestDelegate next)
        //{
        //    return async context =>
        //    {
        //        context.Request.Scheme = "https";
        //        await next(context);
        //    };
        //}
    }

    
}
