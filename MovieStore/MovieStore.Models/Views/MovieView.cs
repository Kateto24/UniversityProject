using MovieStore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Models.Views
{
    public class MovieView
    {
        public int MovieId { get; set; }

        public string MovieTitle { get; set; } = string.Empty;

        public int MovieYear { get; set; }

        public IEnumerable<Actor> Actors { get; set; } = [];

    }
}
