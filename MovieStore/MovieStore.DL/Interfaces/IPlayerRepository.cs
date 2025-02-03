using FootballClubs.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.DL.Interfaces
{
    public interface IPlayerRepository
    {
        List<Player> GetAllPlayers();
        void AddPlayer(Player player);
        Player? GetPlayerById(string id);
        //void AddMovie(Movie movie);
        //void UpdateMovie(Movie movie);
        void DeletePlayer(string id);
        void Update(Player player);
    }
}
