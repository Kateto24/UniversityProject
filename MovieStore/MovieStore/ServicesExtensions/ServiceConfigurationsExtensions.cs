using MovieStore.Models.Configurations;

namespace MovieStore.ServicesExtensions
{
    public static class ServiceConfigurationsExtensions
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure<MongoDbConfigurations>(configuration.GetSection(nameof(MongoDbConfigurations)));
        }
    }
}
