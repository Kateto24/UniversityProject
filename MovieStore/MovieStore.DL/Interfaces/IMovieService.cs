using MovieStore.Models.DTO;

namespace MovieStore.DL.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        void AddMovie(Movie movie);
        Movie? GetMovieById(string id);
        //void AddMovie(Movie movie);
        //void UpdateMovie(Movie movie);
        void DeleteMovie(string id);
        void Update(Movie movie);
        
    }
}
