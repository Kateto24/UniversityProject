using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieStore.DL.Interfaces;
using MovieStore.Models.Configurations;
using MovieStore.Models.DTO;

namespace MovieStore.DL.Repositories.MongoRepositories
{
    public class ActorMongoRepository : IActorRepository
    {

        //private readonly IOptionsMonitor<MongoDbConfigurations> _mongoConfig;
        private readonly IMongoCollection<Actor> _actor;
        private readonly ILogger<ActorMongoRepository> _logger;

        public ActorMongoRepository(IOptionsMonitor<MongoDbConfigurations> mongoConfig, ILogger<ActorMongoRepository> logger)
        {
            //mongoConfig = mongoConfig;

            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);

            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);

            _actor = database.GetCollection<Actor>(mongoConfig.CurrentValue.DatabaseName);
            _logger = logger;
        }

        //public MovieMongoRepository()
        //{

        //}

        public async Task AddActor(Actor actor)
        {
            actor.Id = Guid.NewGuid().ToString();
            _actor.InsertOne(actor);
        }

        public async Task DeleteActor(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Actor>> GetAllActors()
        {
            return _actor.Find(actor => true).ToList();
        }

        public async Task<Actor?> GetActorById(string id)
        {
            //if (string.IsNullOrEmpty(id))
            //{
            //    return null;
            //}

            return _actor.Find(actor => actor.Id == id).FirstOrDefault();
        }

        public async Task<List<Actor>> GetActorById(IEnumerable<string> actors)
        {
            //var filter = Builders<BsonDocument>.Filter.In("_id", actor);
            return _actor.Find(a => actors.Contains(a.Id)).ToList();
        }

        public async Task Update(Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
