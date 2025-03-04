using Microsoft.Extensions.DependencyInjection;
using FootballClubs.DL.Interfaces;
using FootballClubs.DL.Repositories;
using FootballClubs.DL.Repositories.MongoRepositories;

namespace FootballClubs.DL
{
    public static class DependencyInjection
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services
                .AddSingleton<IClubRepository, ClubMongoRepository>()
                .AddSingleton<IPlayerRepository, PlayerMongoRepository>();
        }
    }
}
