using MovieStore.BL.Interfaces;
using MovieStore.DL.Interfaces;
using MovieStore.Models.DTO;

namespace MovieStore.BL.Services
{
    public class MoviesService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;

        public MoviesService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }

        public void AddMovie(Movie movie)
        {
            if (movie is null) return;

            foreach(var movieActor in movie.Actors)
            {
                var actor = _actorRepository.GetActorById(movieActor);

                if(actor is null)
                {
                    throw new Exception($"Actor with id {movieActor} does not exist");
                }
            }

            _movieRepository.AddMovie(movie);
        }

        public Movie? GetMovieById(string id)
        {
            return _movieRepository.GetMovieById(id);
        }

        public void DeleteMovie(string id)
        {
            _movieRepository.DeleteMovie(id);
        }

        public void UpdateMovie(Movie movie)
        {
            _movieRepository.Update(movie);
        }
    }
}
