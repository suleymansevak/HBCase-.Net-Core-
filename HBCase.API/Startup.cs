using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBCase.Business.Interface;
using HBCase.Business.Services;
using HBCase.Data.EntityFramework;
using HBCase.Data.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HBCase.API
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
            services.AddSwaggerGen();
            services.AddScoped<ICampaignService, CampaignService>();
            services.AddScoped<ICampaignData, CampaignData>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderData, OrderData>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductData, ProductData>();

            //services.AddDbContext<HBCaseDbContext>(item => item.UseSqlServer(Configuration["HBCaseDatabase"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HBCase API");
            });

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
