using MovieStore.BL.Interfaces;
using MovieStore.DL.Interfaces;
using MovieStore.Models.DTO;
using MovieStore.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.BL.Services
{
    internal class MovieBLService : IMovieBLService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;

        public MovieBLService(IMovieRepository movieRepository, IActorRepository actorRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
        }

        public IEnumerable<MovieView> GetDetailedMovies()
        {
            var result = new List<MovieView>();

            var movies = _movieRepository.GetAllMovies();
            foreach (var movie in movies) 
            {
                var actors = new List<Actor>(movie.Actors.Count());

                var movieView = new MovieView
                {
                    MovieId = movie.Id,
                    MovieTitle = movie.Title,
                    MovieYear = movie.Year
                   
                };

                foreach (var id in movie.Actors)
                {
                    var actorDto = _actorRepository.GetActorById(id);
                    actors.Add(actorDto);
                }
                movieView.Actors = actors;

                result.Add(movieView);
            }


            return result;
        }

    }

    
}
