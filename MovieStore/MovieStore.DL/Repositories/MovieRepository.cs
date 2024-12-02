using MovieStore.DL.Interfaces;
using MovieStore.DL.StaticDB;
using MovieStore.Models.DTO;

namespace MovieStore.DL.Repositories
{
    internal class MovieRepository : IMovieRepository
    {

        public List<Movie> GetAllMovies()
        {
            return InMemoryDb.Movies;
        }

        public void AddMovie(Movie movie)
        {
            InMemoryDb.Movies.Add(movie);
        }

        public Movie? GetMovieById(int id)
        {
            return InMemoryDb.Movies.FirstOrDefault(m => m.Id == id);
        }

        public void DeleteMovie(int id)
        {
            var movie = InMemoryDb.Movies.FirstOrDefault(m => m.Id == id);
            
            InMemoryDb.Movies.Remove(movie);
        }

        public void Update(Movie movie)
        {
            var result = InMemoryDb.Movies.FirstOrDefault(m => m.Id == movie.Id);

            result.Title = movie.Title;
            result.Year = movie.Year;
        }

        
    }
}
