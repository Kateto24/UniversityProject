using Microsoft.VisualBasic;
using Moq;
using FootballClubs.BL.Services;
using FootballClubs.DL.Interfaces;
using FootballClubs.Models.DTO;
using System.Reflection;

namespace MovieService.Tests
{
    public class ClubBlServiceTests
    {
        private Mock<IClubRepository> _clubRepositoryMock;
        private Mock<IPlayerRepository> _playerRepositoryMock;

        public ClubBlServiceTests()
        {
            _clubRepositoryMock = new Mock<IClubRepository>();
            _playerRepositoryMock = new Mock<IPlayerRepository>();
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

        private List<Player> _players = new List<Player>
        {
            new Player()
            {
                Id = "9",
                Name = "Lewandowski"
            }
        };

        [Fact]
        public void GetDetailedClubs_Ok()
        {
            //setup
            var expectedCount = 2;
            

            _clubRepositoryMock.Setup(x => x.GetAllClubs()).Returns(_clubs);

            _playerRepositoryMock.Setup(x => x.GetPlayerById(It.IsAny<string>())).Returns((string id) => _players.FirstOrDefault(x => x.Id == id));

            //inject 
            var clubBlService = new FootballClubsBLService(
                _clubRepositoryMock.Object,
                _playerRepositoryMock.Object);


            var result = clubBlService.GetDetailedClubs();

            //Act
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count());
        }

    }
}