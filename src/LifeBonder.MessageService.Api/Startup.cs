
using LifeBonder.MessageService.Api.DataAccess.Config;
using ApiService=LifeBonder.MessageService.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LifeBonder.MessageService.Api.Services.ServiceHandler;
using LifeBonder.MessageService.Api.DataAccess.Repository;
using LifeBonder.MessageService.Api.Services.Builders.Request;
using LifeBonder.MessageService.Api.DataAccess;
using LifeBonder.MessageService.Api.Services.Builders.Response;

namespace LifeBonder.MessageService.Api
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
            services.AddOptions();
            services.AddControllers();

            services.AddDbContext<MessageDbContext>();

            services.Configure<DatabaseSettings>(Configuration.GetSection("DbConfig"));

            services.AddScoped<ApiService.IMessageService, ApiService.MessageService>();
            services.AddScoped<IMessageServiceHandler, MessageServiceHandler>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            services.AddScoped<IContactResponseBuilderFactory, ContactResponseBuilderFactory>();

            services.AddScoped<IMessageResponseBuilderFactory, MessageResponseBuilderFactory>();

            services.AddScoped<IMessageRepository, MessageRepository>();

            services.AddOpenApiDocument(
                config =>
                {
                    config.PostProcess = document =>
                    {
                        document.Info.Title = "Message Service API";
                        document.Info.Description = "API for managing user messages";
                    };
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
