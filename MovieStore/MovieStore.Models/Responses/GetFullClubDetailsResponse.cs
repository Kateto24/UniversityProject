using FootballClubs.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Models.Responses
{
    public class GetFullClubDetailsResponse
    {
        IEnumerable<ClubView> Clubs { get; set; } = [];
    }
}
