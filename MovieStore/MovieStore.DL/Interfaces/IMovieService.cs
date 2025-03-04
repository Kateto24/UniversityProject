using MovieStore.Models.DTO;

namespace MovieStore.DL.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMovies();
        Task AddMovie(Movie movie);
        Task<Movie?> GetMovieById(string id);
        //void AddMovie(Movie movie);
        //void UpdateMovie(Movie movie);
        Task DeleteMovie(string id);
        Task Update(Movie movie);
        
    }
}
