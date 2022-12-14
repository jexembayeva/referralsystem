using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Npgsql;
using ReferralSystem.Api.Config;
using ReferralSystem.General.Services.HealthChecks;
using ReferralSystem.General.Services.Middlewares;

namespace ReferralSystem.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = GetPostgresConnection("Data.ReferralSystem");

            services
                .AddHealthChecks()
                .AddNpgSql(connectionString, name: "npgsql.ReferralSystem");

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddServices(connectionString);

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonTimeSpanConverter());
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    _configuration["Swagger:ApiInfo:Version"],
                    _configuration.GetValue<OpenApiInfo>("Swagger:ApiInfo"));

                options.MapType<TimeSpan>(() => new OpenApiSchema { Type = "string", Format = "time" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(
                        _configuration["Swagger:Uri"],
                        _configuration["Swagger:ApiInfo:Title"]);
                });

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseCors(builder =>
            {
                builder
                    .WithOrigins(_configuration.GetSection("Cors").Get<string[]>())
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks(_configuration["HealthChecks:Uri"], new HealthCheckOptions()
                {
                    ResponseWriter = JsonResponseWriter.WriteResponseAsync,
                });

                endpoints.MapControllers();
            });
        }

        private string GetPostgresConnection(string configSectionName)
        {
            var configSection = _configuration.GetSection(configSectionName);

            return new NpgsqlConnectionStringBuilder(configSection["ServerUri"])
            {
                Username = configSection["UserName"],
                Password = configSection["Password"],
            }.ToString();
        }
    }
}