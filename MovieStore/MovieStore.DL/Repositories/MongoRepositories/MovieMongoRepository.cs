using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieStore.DL.Interfaces;
using MovieStore.Models.Configurations;
using MovieStore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DL.Repositories.MongoRepositories
{
    public class MovieMongoRepository : IMovieRepository
    {

        //private readonly IOptionsMonitor<MongoDbConfigurations> _mongoConfig;
        private readonly IMongoCollection<Movie> _movies;
        private readonly ILogger<MovieMongoRepository> _logger;

        public MovieMongoRepository(IOptionsMonitor<MongoDbConfigurations> mongoConfig, ILogger<MovieMongoRepository> logger)
        {
            //mongoConfig = mongoConfig;

            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);

            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);

            _movies = database.GetCollection<Movie>($"{nameof(Movie)}");
            _logger = logger;
        }

        //public MovieMongoRepository()
        //{

        //}

        public void AddMovie(Movie movie)
        {
            movie.Id = Guid.NewGuid().ToString();
            _movies.InsertOne(movie);
        }

        public void DeleteMovie(string id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAllMovies()
        {
            return _movies.Find(movie => true).ToList();
        }

        public Movie? GetMovieById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            return _movies.Find(movie => movie.Id == id).FirstOrDefault();
        }

        public Movie? GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
