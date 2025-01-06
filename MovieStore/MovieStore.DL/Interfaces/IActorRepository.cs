using MovieStore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DL.Interfaces
{
    public interface IActorRepository
    {
        List<Actor> GetAllActors();
        void AddActor(Actor actor);
        Actor? GetActorById(string id);
        //void AddMovie(Movie movie);
        //void UpdateMovie(Movie movie);
        void DeleteActor(string id);
        void Update(Actor actor);
    }
}
