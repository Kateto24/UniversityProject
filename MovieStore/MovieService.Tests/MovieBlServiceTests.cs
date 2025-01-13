using Microsoft.VisualBasic;
using Moq;
using MovieStore.BL.Services;
using MovieStore.DL.Interfaces;
using MovieStore.Models.DTO;
using System.Reflection;

namespace MovieService.Tests
{
    public class MovieBlServiceTests
    {
        private Mock<IMovieRepository> _movieRepositoryMock;
        private Mock<IActorRepository> _actorRepositoryMock;

        public MovieBlServiceTests()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _actorRepositoryMock = new Mock<IActorRepository>();
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

        private List<Actor> _actors = new List<Actor>
        {
            new Actor()
            {
                Id = "",
                Name = "Actor 1"
            }
        };

        [Fact]
        public void GetDetailedMovies_Ok()
        {
            //setup
            var expectedCount = 2;
            

            _movieRepositoryMock.Setup(x => x.GetAllMovies()).Returns(_movies);

            _actorRepositoryMock.Setup(x => x.GetActorById(It.IsAny<string>())).Returns((string id) => _actors.FirstOrDefault(x => x.Id == id));

            //inject 
            var movieBlService = new MovieBLService(
                _movieRepositoryMock.Object,
                _actorRepositoryMock.Object);


            var result = movieBlService.GetDetailedMovies();

            //Act
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count());
        }

    }
}