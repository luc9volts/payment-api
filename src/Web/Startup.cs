using ApplicationCore;
using ApplicationCore.Abstract;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using web.Exceptions;

namespace web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvcCore()
                .AddJsonFormatters()
                .AddDataAnnotations();

            //Dependency Injection
            services.AddScoped<IPaymentFactory, PaymentFactoryCardOrBill>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandlingMiddleware();
            app.UseStaticFiles();
            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(@"Moip Technical Challenge<br/><br/>
                    Post api/v1/Payments<br/>
                    Get api/v1/Payments/{id}");
            });

        }
    }
}
