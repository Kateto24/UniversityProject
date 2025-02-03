using Moq;
using FootballClubs.BL.Services;
using FootballClubs.DL.Interfaces;
using FootballClubs.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieService.Tests
{
    public class ClubServiceTests
    {
        private Mock<IClubRepository> _clubRepositoryMock;

        public ClubServiceTests()
        {
            _clubRepositoryMock = new Mock<IClubRepository>();
        }

        private List<Club> _clubs = new List<Club>
        {
            new Club()
            {
                Id = Guid.NewGuid().ToString(),
                NameOfClub = "Barcelona",
                Year = 1899,
                Players = ["Gavi", "Pedri"]

            },
            new Club()
            {
                Id = Guid.NewGuid().ToString(),
                NameOfClub = "Real Madrid",
                Year = 1902,
                Players = ["Mbappe", "Bellingham"]
            }
        };

        [Fact]
        public void GetAllClubs_Ok()
        {
            //setup
            var expectedCount = 2;


            _clubRepositoryMock.Setup(x => x.GetAllClubs()).Returns(_clubs);


            //inject 
            var clubBlService = new FootballClubsService(_clubRepositoryMock.Object);


            var result = clubBlService.GetAllClubs();

            //Act
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count());
        }


        [Fact]
        public void AddClub_Ok()
        {
            //setup
            var expectedCount = 3;
            var club = new Club()
            {
                Id = Guid.NewGuid().ToString(),
                NameOfClub = "Juventus",
                Year = 1897,
                Players = ["Vlahovic", "Kenan Yildiz"]
            };

            _clubRepositoryMock.Setup(x => x.AddClub(club)).Callback( () =>
            {
                _clubs.Add(club);
            });


            //inject 
            var clubBlService = new FootballClubsService(_clubRepositoryMock.Object);


            clubBlService.AddClub(club);

            //Act
            //Assert.NotNull(result);
            Assert.Equal(expectedCount, _clubs.Count());
        }
    }
}
