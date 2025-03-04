using MovieStore.BL.Interfaces;
using MovieStore.DL.Interfaces;
using MovieStore.Models.DTO;

namespace MovieStore.BL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _movieRepository.GetAllMovies();
        }

        public async Task AddMovie(Movie movie)
        {
            _movieRepository.AddMovie(movie);
        }

        public async Task<Movie?> GetMovieById(string id)
        {
            return await _movieRepository.GetMovieById(id);
        }

        public async Task DeleteMovie(string id)
        {
            if (!string.IsNullOrEmpty(id)) return;
            
            await _movieRepository.DeleteMovie(id);
        }

        public void UpdateMovie(Movie movie)
        {
            _movieRepository.Update(movie);
        }
    }
}
