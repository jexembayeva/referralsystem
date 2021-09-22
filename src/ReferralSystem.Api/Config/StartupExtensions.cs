using Microsoft.Extensions.DependencyInjection;
using ReferralSystem.Database;
using ReferralSystem.Database.Repositories.Devices;
using ReferralSystem.Database.Repositories.Devices.FirmWares;
using ReferralSystem.Database.Repositories.Devices.SimCards;
using ReferralSystem.Database.Repositories.Devices.Stabilizers;
using ReferralSystem.Database.Repositories.Providers;
using ReferralSystem.Database.Repositories.Providers.Cities;
using ReferralSystem.Database.Repositories.Providers.Districts;
using ReferralSystem.Database.Repositories.Providers.Regions;
using ReferralSystem.Database.Repositories.Providers.Segments;
using ReferralSystem.Database.Repositories.Providers.Streets;
using ReferralSystem.Database.Repositories.Routes;
using ReferralSystem.Database.Repositories.Routes.Alternatives;
using ReferralSystem.Database.Repositories.Routes.DayPeriodTypes;
using ReferralSystem.Database.Repositories.Routes.DedicatedLanes;
using ReferralSystem.Database.Repositories.Routes.Lads;
using ReferralSystem.Database.Repositories.Routes.LadStops;
using ReferralSystem.Database.Repositories.Routes.RoutePlans;
using ReferralSystem.Database.Repositories.Routes.RouteSchedules;
using ReferralSystem.Database.Repositories.Stops;
using ReferralSystem.Database.Repositories.VehicleBases;
using ReferralSystem.Database.Repositories.Vehicles;
using ReferralSystem.Domain.Services.Devices;
using ReferralSystem.Domain.Services.Devices.SimCards;
using ReferralSystem.Domain.Services.Providers;
using ReferralSystem.Domain.Services.Providers.Cities;
using ReferralSystem.Domain.Services.Providers.Districts;
using ReferralSystem.Domain.Services.Providers.Regions;
using ReferralSystem.Domain.Services.Providers.Segments;
using ReferralSystem.Domain.Services.Providers.Streets;
using ReferralSystem.Domain.Services.Routes;
using ReferralSystem.Domain.Services.Routes.Alternatives;
using ReferralSystem.Domain.Services.Routes.DayPeriodTypes;
using ReferralSystem.Domain.Services.Routes.DedicatedLanes;
using ReferralSystem.Domain.Services.Routes.Lads;
using ReferralSystem.Domain.Services.Routes.LadStops;
using ReferralSystem.Domain.Services.Routes.RoutePlans;
using ReferralSystem.Domain.Services.SimCards;
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
                     .AddTransient<IAlternativeService>(options =>
                        new AlternativeService(options.GetRequiredService<IAlternativeRepository>(), options.GetRequiredService<IRouteRepository>()))
                     .AddTransient<IDayPeriodTypeService>(options =>
                        new DayPeriodTypeService(options.GetRequiredService<IDayPeriodTypeRepository>()))
                     .AddTransient<IDedicatedLaneService>(options =>
                        new DedicatedLaneService(options.GetRequiredService<IDedicatedLaneRepository>()))
                     .AddTransient<ILadService>(options =>
                        new LadService(options.GetRequiredService<ILadRepository>()))
                     .AddTransient<ILadStopService>(options =>
                        new LadStopService(options.GetRequiredService<ILadStopRepository>()))
                     .AddTransient<IRoutePlanService>(options =>
                        new RoutePlanService(options.GetRequiredService<IRoutePlanRepository>()))
                     .AddTransient<IRouteScheduleService>(options =>
                        new RouteScheduleService(options.GetRequiredService<IRouteScheduleRepository>()))
                    .AddTransient<IVehicleBaseService>(options =>
                        new VehicleBaseService(options.GetRequiredService<IVehicleBaseRepository>()))
                    .AddTransient<IDeviceService>(options =>
                        new DeviceService(options.GetRequiredService<IDeviceRepository>()))
                    .AddTransient<IFirmWareService>(options =>
                        new FirmWareService(options.GetRequiredService<IFirmWareRepository>()))
                    .AddTransient<ISimCardService>(options =>
                        new SimCardService(options.GetRequiredService<ISimCardRepository>()))
                    .AddTransient<IStabilizerService>(options =>
                        new StabilizerService(options.GetRequiredService<IStabilizerRepository>()))
                    .AddTransient<IVehicleBaseService>(options =>
                        new VehicleBaseService(options.GetRequiredService<IVehicleBaseRepository>()))
                    .AddTransient<IVehicleBaseService>(options =>
                        new VehicleBaseService(options.GetRequiredService<IVehicleBaseRepository>()))
                    .AddTransient<IProviderService>(options =>
                        new ProviderService(options.GetRequiredService<IProviderRepository>()))
                    .AddTransient<ICityService>(options =>
                        new CityService(options.GetRequiredService<ICityRepository>()))
                    .AddTransient<IDistrictService>(options =>
                        new DistrictService(options.GetRequiredService<IDistrictRepository>()))
                    .AddTransient<IRegionService>(options =>
                        new RegionService(options.GetRequiredService<IRegionRepository>()))
                    .AddTransient<IStreetService>(options =>
                        new StreetService(options.GetRequiredService<IStreetRepository>()))
                    .AddTransient<IVehicleService>(options =>
                        new VehicleService(options.GetRequiredService<IVehicleRepository>()))
                    .AddTransient<IDistrictService>(options =>
                        new DistrictService(options.GetRequiredService<IDistrictRepository>()))
                    .AddTransient<IStopService>(options =>
                        new StopService(options.GetRequiredService<IStopRepository>()))
                    .AddTransient<ISegmentService>(options =>
                        new SegmentService(options.GetRequiredService<ISegmentRepository>(), options.GetRequiredService<IDistrictRepository>()))
                    .AddTransient<IVehicleService>(options =>
                        new VehicleService(options.GetRequiredService<IVehicleRepository>()));

            services
                    .AddScoped<IDeviceRepository, DeviceRepository>()
                    .AddScoped<IFirmWareRepository, FirmWareRepository>()
                    .AddScoped<ISimCardRepository, SimCardRepository>()
                    .AddScoped<IStabilizerRepository, StabilizerRepository>()
                    .AddScoped<IVehicleBaseRepository, VehicleBaseRepository>()
                    .AddScoped<IProviderRepository, ProviderRepository>()
                    .AddScoped<ICityRepository, CityRepository>()
                    .AddScoped<IDistrictRepository, DistrictRepository>()
                    .AddScoped<IRegionRepository, RegionRepository>()
                    .AddScoped<ISegmentRepository, SegmentRepository>()
                    .AddScoped<IStreetRepository, StreetRepository>()
                    .AddScoped<IRouteRepository, RouteRepository>()
                    .AddScoped<IStopRepository, StopRepository>()
                    .AddScoped<IVehicleRepository, VehicleRepository>()
                    .AddScoped<IDistrictRepository, DistrictRepository>()
                    .AddScoped<IAlternativeRepository, AlternativeRepository>()
                    .AddScoped<IDayPeriodTypeRepository, DayPeriodTypeRepository>()
                    .AddScoped<IDedicatedLaneRepository, DedicatedLaneRepository>()
                    .AddScoped<ILadRepository, LadRepository>()
                    .AddScoped<ILadStopRepository, LadStopRepository>()
                    .AddScoped<IRoutePlanRepository, RoutePlanRepository>()
                    .AddScoped<IRouteScheduleRepository, RouteScheduleRepository>();

            return services;
        }
    }
}
