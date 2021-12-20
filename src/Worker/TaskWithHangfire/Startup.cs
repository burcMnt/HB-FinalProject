using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TaskWithHangfire.Data;

namespace TaskWithHangfire
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddHangfire(x => x.UseSQLiteStorage("Filename=Hepsiburada.db;", new SQLiteStorageOptions()));
            services.AddHangfire(config =>
            {
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseDefaultTypeSerializer()
                .UseMemoryStorage();
            });

            services.AddHangfireServer();

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<IItemListFirstTen, ItemListFirstTen>();
            services.AddWorkerServices();

           //Redis Cache
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("Redis");
                options.InstanceName = "HepsiBuradaFinalProject_";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IRecurringJobManager recurringJobManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            app.UseHangfireDashboard("/hangfire");

            RecurringJob.AddOrUpdate<ItemListFirstTen>(x => x.GetAllData(), Cron.Minutely());
            RecurringJob.AddOrUpdate<ItemListFirstTen>(x => x.GetUserAllData(), Cron.Minutely());

            //recurringJobManager.AddOrUpdate("Run every an hour", 
            //    () => serviceProvider.GetService<ItemListFirstTen>().GetAllData(), Cron.Minutely);
            //recurringJobManager.AddOrUpdate("Run every an hour",
            //    () => serviceProvider.GetService<ItemListFirstTen>().GetUserAllData(), Cron.Minutely);
        }
    }
}
