using FootballClubs.Models.Configurations;

namespace FootballClubs.ServicesExtensions
{
    public static class ServiceConfigurationsExtensions
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure<MongoDbConfigurations>(configuration.GetSection(nameof(MongoDbConfigurations)));
        }
    }
}
