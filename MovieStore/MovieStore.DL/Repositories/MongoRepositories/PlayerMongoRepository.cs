using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FootballClubs.DL.Interfaces;
using FootballClubs.Models.Configurations;
using FootballClubs.Models.DTO;

namespace FootballClubs.DL.Repositories.MongoRepositories
{
    public class PlayerMongoRepository : IPlayerRepository
    {

        //private readonly IOptionsMonitor<MongoDbConfigurations> _mongoConfig;
        private readonly IMongoCollection<Player> _player;
        private readonly ILogger<PlayerMongoRepository> _logger;

        public PlayerMongoRepository(IOptionsMonitor<MongoDbConfigurations> mongoConfig, ILogger<PlayerMongoRepository> logger)
        {
            //mongoConfig = mongoConfig;

            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);

            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);

            _player = database.GetCollection<Player>(mongoConfig.CurrentValue.DatabaseName);
            _logger = logger;
        }

        //public MovieMongoRepository()
        //{

        //}

        public void AddPlayer(Player player)
        {
            player.Id = Guid.NewGuid().ToString();
            _player.InsertOne(player);
        }

        public void DeletePlayer(string id)
        {
            throw new NotImplementedException();
        }

        public List<Player> GetAllPlayers()
        {
            return _player.Find(player => true).ToList();
        }

        public Player? GetPlayerById(string id)
        {
            //if (string.IsNullOrEmpty(id))
            //{
            //    return null;
            //}

            return _player.Find(player => player.Id == id).FirstOrDefault();
        }

        public List<Player> GetActorById(IEnumerable<string> player)
        {
            //var filter = Builders<BsonDocument>.Filter.In("_id", actor);
            return _player.Find(a => player.Contains(a.Id)).ToList();
        }

        public void Update(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
