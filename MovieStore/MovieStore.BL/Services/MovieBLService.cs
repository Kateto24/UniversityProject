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

        public async Task<IEnumerable<MovieView>> GetDetailedMovies()
        {
            var result = new List<MovieView>();

            var movies = await _movieRepository.GetAllMovies();
            foreach (var movie in movies)
            {
                var actors = new List<Actor>(movie.Actors.Count());

                var movieView = new MovieView
                {
                    MovieId = movie.Id,
                    MovieTitle = movie.Title,
                    MovieYear = movie.Year

                };

                var tasks = movie.Actors.Select(id => _actorRepository.GetActorById(id));

                //foreach (var id in movie.Actors)
                //{
                //    var actorDto = await _actorRepository.GetActorById(id);
                //    actors.Add(actorDto);
                //}

                //movieView.Actors = ;
                var response = await Task.WhenAll(tasks);

                if (response != null && response.Any())
                {
                    movieView.Actors = response.ToList();
                }
                

                result.Add(movieView);
            }


            return result;
        }

    }

    
}
