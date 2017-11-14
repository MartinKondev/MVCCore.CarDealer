using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarDealer.Data;
using Microsoft.EntityFrameworkCore;
using CarDealer.Services;

namespace CarDealer.App
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
            services.AddTransient<DBInitializer>();
            services.AddDbContext<CarDealerDbContext>(o => o.
                UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=CarDealer;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<ISalesService, SalesService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                                IHostingEnvironment env,
                                DBInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
              {
                routes.MapRoute(
                    name: "carsByMake",
                    template: "car/{action=CarsFromMake}/{make}");

                  routes.MapRoute(
                      name: "customersById",
                      template: "customer/index/{id}");

                  routes.MapRoute(
                      name: "customers",
                      template: "customer/{action=all}/{sortOrder}");

                  routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //dbInitializer.Seed().Wait();
        }
    }
}
