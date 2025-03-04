

namespace FootballClubs.Models.Requests
{
    public class AddClubRequest
    {
         public string Title { get; set; }

         public int Year { get; set; } 

        public List<string> Players { get; set; }
    }
}
