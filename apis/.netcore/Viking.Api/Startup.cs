using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Viking.Api.Middleware;
using Viking.Sdk;

namespace Viking.Api
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
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddTokenAuthentication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                        {
                            var error = context.Features.Get<IExceptionHandlerFeature>();
                            if (error != null)
                            {
                                var err = JsonConvert.SerializeObject(new
                                {
                                    Stacktrace = error.Error.StackTrace,
                                    DetailedMessage = error.Error.Message,
                                });
                                string appDefinition = await new StreamReader(context.Request.Body).ReadToEndAsync();
                                Log.ErrorLog("InternalError", JsonConvert.SerializeObject(err), $"Input: {JObject.Parse(appDefinition)}");
                                context.Response.AddApplicationError("Internal error ocurred. Please contact your administrator");
                            }

                        });
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
