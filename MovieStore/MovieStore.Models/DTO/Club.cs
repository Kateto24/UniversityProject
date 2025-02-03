namespace FootballClubs.Models.DTO
{
    public class Club
    {
        public string Id { get; set; }

        public string NameOfClub { get; set; } = string.Empty;

        public int Year { get; set; }

        public List<string> Players { get; set; }

    }
}
