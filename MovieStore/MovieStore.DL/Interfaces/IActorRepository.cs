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
        Task<List<Actor>> GetAllActors();
        Task AddActor(Actor actor);
        Task<Actor?> GetActorById(string id);
        //void AddMovie(Movie movie);
        //void UpdateMovie(Movie movie);
        Task DeleteActor(string id);
        Task Update(Actor actor);
    }
}
