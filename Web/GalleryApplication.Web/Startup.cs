using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql;
using GalleryApplication.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using ProjectMVC.Services.Messaging;
using GalleryApplication.Data.Common;
using Microsoft.Extensions.FileProviders;
using System.IO;
using GalleryApplication.Services.DataServices;
using GalleryApplication.Data.Repositories;
using GalleryApplication.Services.Mapping;
using GalleryApplication.Services.Models.Home;
using GalleryApplication.Web.Models.Arts;
using GalleryApplication.Services.Models.Arts;
using AutoMapper;
using GalleryApplication.Services.DataServices.Interfaces;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace GalleryApplication.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Wont Use AutoMapper
            //services.AddAutoMapper(typeof(IndexViewModel).Assembly,
            //    typeof(CreateArtInputModel).Assembly,
            //    typeof(ArtDetailsViewModel).Assembly
            //    );

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<GalleryAppContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                //Password settings.
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            })
                //.AddRoles<IdentityRole>() //
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<GalleryAppContext>();

            //Adding external google login
            /* services.AddAuthentication()
                .AddGoogle(options =>
                {
                    IConfigurationSection googleAuthNSection =
                        Configuration.GetSection("Authentication:Google");

                    options.ClientId = googleAuthNSection["ClientId"];
                    options.ClientSecret = googleAuthNSection["ClientSecret"];
                });  */ // I do not need it at this moment

            //Aplication services
            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/images"))
                );
            services.AddTransient<IEmailSender, SendGridNewSender>();
            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IArtsService, ArtsServices>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IQuotesService, QuotesService>();
            services.AddScoped<IContactService, ContactService>();

            services.AddScoped<IArtRepository, ArtRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IQuotesRepository, QuotesRepository>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                    policy => policy.RequireRole("Administrator"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
