namespace Playground.Microservices.API
{
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Playground.Microservices.API.Constants;
    using Playground.Microservices.API.Repositories.EntityFramework;
    using System;
    using System.IO;
    using System.Reflection;

    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IHostEnvironment hostEnvironment;

        public Startup(
            IConfiguration configuration,
            IHostEnvironment hostEnvironment)
        {
            this.configuration = configuration;
            this.hostEnvironment = hostEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigurationServices(this.configuration);
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(this.configuration.GetConnectionString("ConnectionString"), options =>
                {
                    options.EnableRetryOnFailure();
                }));
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddMigrationServices();
            services.AddSingletonServices();
            services.AddRepositories();
            services.AddMvc();
            services.AddMediatR(typeof(Startup));
            services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc(SwaggerName.Version, new OpenApiInfo
                 {
                     Version = SwaggerName.Version,
                     Title = SwaggerName.Title,
                     Description = SwaggerName.Description,
                     TermsOfService = new Uri("https://example.com/terms"),
                     Contact = new OpenApiContact
                     {
                         Name = SwaggerName.ContactName,
                         Email = SwaggerName.ContactEmail,
                         Url = new Uri(SwaggerName.ContactUrl),
                     },
                 });

                 var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                 var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                 c.IncludeXmlComments(xmlPath);
             });
            services.AddCors(
                    options =>
                    {
                        options.AddPolicy(
                            CorsPolicyName.AllowAny,
                            builder => builder
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());
                    });
        }

        public void Configure(
            IApplicationBuilder app)
        {
            if (this.hostEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(CorsPolicyName.AllowAny);
            app.UseRouting();
            app.UseSwagger();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    SwaggerName.SwaggerEndpoint,
                    SwaggerName.Title);
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
