using API.ExternalServices;
using API.Interfaces;
using API.Services;
using API.Contexts;
using API.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransferOrderAPI
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
            services.AddControllers();
            services.AddTransient<ICurrencyQuotationService, CurrencyQuotationService>();
            services.AddTransient<ICurrencyQuotationRepository, CurrencyQuotationRepository>();
            services.AddScoped<IScopedProcessingService, CurrencyQuotationService>();
            services.AddHostedService<QuotationsRetrievalService>();
            services.AddDbContext<CurrencyQuotationContext>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CurrencyQuotationDB;Trusted_Connection=True;"));
            services.AddDbContext<TransferOrderContext>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TransferOrderDB;Trusted_Connection=True;"));
            services.AddScoped<ITransferOrderRepository, TransferOrderRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CurrencyQuotationContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                context.Database.EnsureCreated();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
