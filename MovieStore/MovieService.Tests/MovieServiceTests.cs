using Moq;
using MovieStore.BL.Services;
using MovieStore.DL.Interfaces;
using MovieStore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieService.Tests
{
    public class MovieServiceTests
    {
        private Mock<IMovieRepository> _movieRepositoryMock;

        public MovieServiceTests()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
        }

        private List<Movie> _movies = new List<Movie>
        {
            new Movie()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Movie 1",
                Year = 2021,
                Actors = ["Actor 1", "Actor 2"]

            },
            new Movie()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Movie 2",
                Year = 2022,
                Actors = ["Actor 3", "Actor 4"]
            }
        };

        [Fact]
        public void GetAllMovies_Ok()
        {
            //setup
            var expectedCount = 2;


            _movieRepositoryMock.Setup(x => x.GetAllMovies()).Returns(_movies);


            //inject 
            var movieBlService = new MoviesService(_movieRepositoryMock.Object);


            var result = movieBlService.GetAllMovies();

            //Act
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count());
        }


        [Fact]
        public void AddMovie_Ok()
        {
            //setup
            var expectedCount = 3;
            var movie = new Movie()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Movie 3",
                Year = 2023,
                Actors = ["Actor 1", "Actor 2"]
            };

            _movieRepositoryMock.Setup(x => x.AddMovie(movie)).Callback( () =>
            {
                _movies.Add(movie);
            });


            //inject 
            var movieBlService = new MoviesService(_movieRepositoryMock.Object);


            movieBlService.AddMovie(movie);

            //Act
            //Assert.NotNull(result);
            Assert.Equal(expectedCount, _movies.Count());
        }
    }
}
