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

        public void AddClub(Club club)
        {
            club.Id = Guid.NewGuid().ToString();
            _clubs.InsertOne(club);
        }

        public void DeleteClub(string id)
        {
            throw new NotImplementedException();
        }

        public List<Club> GetAllClubs()
        {
            return _clubs.Find(club => true).ToList();
        }

        public Club? GetClubById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            return _clubs.Find(club => club.Id == id).FirstOrDefault();
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
