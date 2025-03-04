using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FootballClubs.DL.Interfaces;
using FootballClubs.Models.Configurations;
using FootballClubs.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.DL.Repositories.MongoRepositories
{
    public class ClubMongoRepository : IClubRepository
    {

        //private readonly IOptionsMonitor<MongoDbConfigurations> _mongoConfig;
        private readonly IMongoCollection<Club> _clubs;
        private readonly ILogger<ClubMongoRepository> _logger;

        public ClubMongoRepository(IOptionsMonitor<MongoDbConfigurations> mongoConfig, ILogger<ClubMongoRepository> logger)
        {
            //mongoConfig = mongoConfig;

            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);

            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);

            _clubs = database.GetCollection<Club>($"{nameof(Club)}");
            _logger = logger;
        }

        //public MovieMongoRepository()
        //{

        //}

<<<<<<< HEAD:MovieStore/MovieStore.DL/Repositories/MongoRepositories/MovieMongoRepository.cs
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
=======
        public void AddClub(Club club)
        {
            club.Id = Guid.NewGuid().ToString();
            _clubs.InsertOne(club);
        }

        public void DeleteClub(string id)
>>>>>>> 8d8d5a7a039982bf83f7e32f3a7eeead6ce8281e:MovieStore/MovieStore.DL/Repositories/MongoRepositories/ClubMongoRepository.cs
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD:MovieStore/MovieStore.DL/Repositories/MongoRepositories/MovieMongoRepository.cs
        public async Task<List<Movie>> GetAllMovies()
        {
            var result = await _movies.FindAsync(movie => true);
            
            return result.ToList();
        }

        public async Task<Movie?> GetMovieById(string id)
=======
        public List<Club> GetAllClubs()
        {
            return _clubs.Find(club => true).ToList();
        }

        public Club? GetClubById(string id)
>>>>>>> 8d8d5a7a039982bf83f7e32f3a7eeead6ce8281e:MovieStore/MovieStore.DL/Repositories/MongoRepositories/ClubMongoRepository.cs
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

<<<<<<< HEAD:MovieStore/MovieStore.DL/Repositories/MongoRepositories/MovieMongoRepository.cs
            var result = await _movies.FindAsync(movie => movie.Id == id);
            return result.FirstOrDefault();
=======
            return _clubs.Find(club => club.Id == id).FirstOrDefault();
>>>>>>> 8d8d5a7a039982bf83f7e32f3a7eeead6ce8281e:MovieStore/MovieStore.DL/Repositories/MongoRepositories/ClubMongoRepository.cs
        }

        public Club? GetClubById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Club club)
        {
            throw new NotImplementedException();
        }
    }
}
