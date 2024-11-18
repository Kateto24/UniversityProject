using MovieStore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Models.Responses
{
    public class GetDetailedMovieResponse
    {
        public Movie Movie{ get; set; }

        public List<Actor> Actors { get; set; }
    }
}
