using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NewsFeedDAL_EF.DataAccess;
using NewsFeedRepositories.Interface;
using NewsFeedServices.Factories;
using NewsFeedServices.Interfaces.Factories;
using NewsFeedServices.Interfaces.Services;
using NewsFeedServices.NewsFeedServices;
using NewsFeedRepositories.Repository;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace NewsFeedWebApiServer
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
            services.AddCors();
            //services.AddConTrollers
            services.AddDbContext<NewsFeedContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IPresConUsersRepoitory, PresConUsersRepoitory>();
            services.AddTransient<IArticleRepoitory, ArticleRepoitory>();
            services.AddTransient<IFeedsBackRepoitory, FeedsBackRepoitory>();
            services.AddSingleton<IFeedBackArticleExpressionFactory, ExpressionFactory>();
            services.AddTransient<IFeedBackArticleService, FeedBackArticleService>();
            services.AddSingleton<IFormatService, FormatService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(options => options
            .WithOrigins("*")
            .AllowAnyHeader()
            .WithMethods("POST", "PUT", "DELETE", "GET")
            );

            app.UseExceptionHandler(
                options =>
                {
                    options.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "text/html";
                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace }";
                            await context.Response.WriteAsync(err).ConfigureAwait(false);
                        }
                    });
                }
                );
            //app.UseMiddleware<RequestDiagnosticsMiddleware>();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
