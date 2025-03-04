using Mapster;
using FootballClubs.Models.DTO;
using FootballClubs.Models.Requests;

namespace FootballClubs.MapsterConfig
{
    public class MapsterConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<Movie, AddMovieRequest>
            .NewConfig()
            .TwoWays();

            TypeAdapterConfig<UpdateMovieRequest, Movie>
            .NewConfig()
            .TwoWays();
        }

        
    }
}
