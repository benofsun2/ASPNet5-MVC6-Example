using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Routing;
using Messages.Services;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.Configuration;

namespace Messages
{
    public class Startup
    {
        //public Startup()
        //{
        //    Configuration = new Configuration()
        //        .AddJsonFile("config.json")
        //        .AddEnvironmentVariables();

        //}


        public Startup(IApplicationEnvironment appEnv)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables()
                .Build();
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940

        public Microsoft.Framework.ConfigurationModel.IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // the following Instance will essencially be a Singleton 
            //services.AddInstance<IGreetingService>(new GreetingService());

            // the following forces an instance foreach providee.
            services.AddTransient<IGreetingService>(p => new GreetingService(Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            app.UseMvc();

            //app.UseMvc(routes => routes.MapRoute("default","{controller=home}/{action=default}"));
            
            
            
            
            // 1,2 & 3 are previously used in the instruction
            // 1) app.UseIISPlatformHandler();

            // 2)   app.Run(async (context) =>
            //      {
            //          await context.Response.WriteAsync("Hello World!");
            //      });

            // 3)     app.UseWelcomePage();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
    