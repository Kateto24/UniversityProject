using FootballClubs.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Models.Responses
{
    public class GetDetailedClubResponse
    {
        public Club Club { get; set; }

        public List<Player> Players { get; set; }
    }
}
