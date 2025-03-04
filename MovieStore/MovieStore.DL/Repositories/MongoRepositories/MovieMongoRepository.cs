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

        public async Task AddMovie(Movie movie)
        {
            try
            {
                movie.Id = Guid.NewGuid().ToString();
                await _movies.InsertOneAsync(movie);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        public async Task DeleteMovie(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            var result = await _movies.FindAsync(movie => true);
            
            return result.ToList();
        }

        public async Task<Movie?> GetMovieById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var result = await _movies.FindAsync(movie => movie.Id == id);
            return result.FirstOrDefault();
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
