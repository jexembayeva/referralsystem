using Microsoft.Extensions.DependencyInjection;
using ReferralSystem.Database;
using ReferralSystem.Database.Repositories.Devices;
using ReferralSystem.Database.Repositories.Providers;
using ReferralSystem.Database.Repositories.Providers.Districts;
using ReferralSystem.Database.Repositories.Routes;
using ReferralSystem.Database.Repositories.Segments;
using ReferralSystem.Database.Repositories.Stops;
using ReferralSystem.Database.Repositories.VehicleBases;
using ReferralSystem.Database.Repositories.Vehicles;
using ReferralSystem.Domain.Services.Devices;
using ReferralSystem.Domain.Services.Providers;
using ReferralSystem.Domain.Services.Routes;
using ReferralSystem.Domain.Services.Segments;
using ReferralSystem.Domain.Services.Stops;
using ReferralSystem.Domain.Services.VehicleBases;
using ReferralSystem.Domain.Services.Vehicles;

namespace ReferralSystem.Api.Config
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, string optiroConnectionString)
        {
            services.AddSingleton(optiroConnectionString);

            services.AddTransient<IDatabaseConnectionFactory, DatabaseConnectionFactory>();

            services.AddTransient<IRouteService>(options =>
                        new RouteService(options.GetRequiredService<IRouteRepository>()))
                    .AddTransient<IVehicleBaseService>(options =>
                        new VehicleBaseService(options.GetRequiredService<IVehicleBaseRepository>()))
                    .AddTransient<IDeviceService>(options =>
                        new DeviceService(options.GetRequiredService<IDeviceRepository>()))
                    .AddTransient<IProviderService>(options =>
                        new ProviderService(options.GetRequiredService<IProviderRepository>()))
                    .AddTransient<IStopService>(options =>
                        new StopService(options.GetRequiredService<IStopRepository>()))
                    .AddTransient<ISegmentService>(options =>
                        new SegmentService(options.GetRequiredService<ISegmentRepository>(), options.GetRequiredService<IDistrictRepository>()))
                    .AddTransient<IVehicleService>(options =>
                        new VehicleService(options.GetRequiredService<IVehicleRepository>()));

            services.AddScoped<IRouteRepository, RouteRepository>()
                    .AddScoped<IVehicleBaseRepository, VehicleBaseRepository>()
                    .AddScoped<IDeviceRepository, DeviceRepository>()
                    .AddScoped<IProviderRepository, ProviderRepository>()
                    .AddScoped<IStopRepository, StopRepository>()
                    .AddScoped<ISegmentRepository, SegmentRepository>()
                    .AddScoped<IVehicleRepository, VehicleRepository>()
                    .AddScoped<IDistrictRepository, DistrictRepository>();

            return services;
        }
    }
}
