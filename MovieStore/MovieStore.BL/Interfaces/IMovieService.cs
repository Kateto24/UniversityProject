using MovieStore.Models.DTO;

namespace MovieStore.BL.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMovies();

        Task AddMovie(Movie movie);

        Task<List<Movie?>> GetMovieById(string id);

        Task DeleteMovie(string id);

        Task UpdateMovie(Movie movie);
    }
}
