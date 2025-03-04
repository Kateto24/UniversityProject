using FootballClubs.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Models.Views
{
    public class ClubView
    {
        public string ClubId { get; set; }

        public string ClubTitle { get; set; } = string.Empty;

        public int ClubYear { get; set; }

        public IEnumerable<Player> Players { get; set; } = [];

    }
}
