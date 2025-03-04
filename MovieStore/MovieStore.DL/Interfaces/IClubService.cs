using FootballClubs.Models.DTO;

namespace FootballClubs.DL.Interfaces
{
    public interface IClubRepository
    {
        List<Club> GetAllClubs();
        void AddClub(Club club);
        Club? GetClubById(string id);
        //void AddMovie(Movie movie);
        //void UpdateMovie(Movie movie);
        void DeleteClub(string id);
        void Update(Club movie);
        
    }
}
