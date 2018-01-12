using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace NetCoreAngularApp.Web
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
            services.AddDbContext<Core.Data.StoreContext>(opt => opt.UseInMemoryDatabase("Store"));
            services.AddTransient<Core.ICustomerRepository, Core.Data.CustomerRepository>();
            services.AddTransient<Core.IOrderRepository, Core.Data.OrderRepository>();
            services.AddTransient<Core.IProductRepository, Core.Data.ProductRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            SeedDatabase(app.ApplicationServices.GetService<Core.Data.StoreContext>());

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

        private void SeedDatabase(Core.Data.StoreContext storeContext)
        {
            storeContext.CustomerStatuses.AddRange(new[] {
                new Core.Data.CustomerStatus
                {
                    CustomerStatusId = 1,
                    StatusText = "Active"
                },
                new Core.Data.CustomerStatus
                {
                    CustomerStatusId = 2,
                    StatusText = "InActive"
                }
            });
            storeContext.SaveChanges();

            storeContext.Customers.AddRange(new[] {
                new Core.Data.Customer
                {
                    CustomerStatusId = 1,
                    FirstName = "John",
                    LastName = "Doe"
                },
                new Core.Data.Customer
                {
                    CustomerStatusId = 1,
                    FirstName = "Jane",
                    LastName = "Doe"
                },
                new Core.Data.Customer
                {
                    CustomerStatusId = 1,
                    FirstName = "Bob",
                    LastName = "Thomas"
                },
                new Core.Data.Customer
                {
                    CustomerStatusId = 1,
                    FirstName = "William",
                    LastName = "Wallace"
                },
                new Core.Data.Customer
                {
                    CustomerStatusId = 2,
                    FirstName = "Andrew",
                    LastName = "Something"
                }
            });
            storeContext.SaveChanges();

            storeContext.Orders.AddRange(new[] {
                new Core.Data.Order
                {
                    CustomerId = 1,
                    Total = 100M
                },
                new Core.Data.Order
                {
                    CustomerId = 1,
                    Total = 200M
                },
                new Core.Data.Order
                {
                    CustomerId = 1,
                    Total = 300M
                }
            });
            storeContext.SaveChanges();

            storeContext.Products.AddRange(new[] {
                new Core.Data.Product
                {
                    OrderId = 1,
                    ProductName = "Widget 1",
                    Price = 1M
                },
                new Core.Data.Product
                {
                    OrderId = 2,
                    ProductName = "Widget 1",
                    Price = 1M
                },
                new Core.Data.Product
                {
                    OrderId = 3,
                    ProductName = "Widget 1",
                    Price = 1M
                }
            });

            storeContext.SaveChanges();
        }

    }
}
