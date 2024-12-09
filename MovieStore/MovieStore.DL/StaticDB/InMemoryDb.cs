using MovieStore.Models.DTO;

namespace MovieStore.DL.StaticDB
{
    internal static class InMemoryDb
    {
        internal static List<Actor> Actors = new List<Actor>
        {
            new Actor
            {
                Id = 1,
                Name = "Silvester Stalone"
            },
            new Actor
            {
                Id = 2,
                Name = "Jorge"
            }
        };

        internal static List<Movie> Movies = new List<Movie>
        {
            new Movie
            {
                Id = "1",
                Title = "The Shawshank Redemption",
                Year = 1994,
                Actors = new List<int>
                {
                    1
                }
            },
            new Movie
            {
                Id = "2",
                Title = "The Godfather",
                Year = 1972,
                Actors = new List<int>
                {
                    2
                }
            },
            new Movie
            {
                Id = "3",
                Title = "The Dark Knight",
                Year = 2008
            },
        };
    }
}