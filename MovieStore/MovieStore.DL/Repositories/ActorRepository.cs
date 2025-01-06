using MovieStore.DL.Interfaces;
using MovieStore.DL.StaticDB;
using MovieStore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DL.Repositories
{
    //internal class ActorRepository : IActorRepository
    //{
    //    public List<Actor> GetAllActors()
    //    {
    //        return InMemoryDb.Actors;
    //    }

    //    public void AddActor(Actor actor)
    //    {
    //        InMemoryDb.Actors.Add(actor);
    //    }

    //    public Actor? GetActorById(string id)
    //    { 
    //        return InMemoryDb.Actors.FirstOrDefault(a => a.Id == id);
    //    }

    //    public void DeleteActor(string id)
    //    {
    //        var actor = InMemoryDb.Actors.FirstOrDefault(a => a.Id == id);

    //        InMemoryDb.Actors.Remove(actor);
    //    }

    //    public void Update(Actor actor)
    //    {
    //        var result = InMemoryDb.Actors.FirstOrDefault(m => m.Id == actor.Id);

    //        result.Name = actor.Name;
            
    //    }
    //}
}
