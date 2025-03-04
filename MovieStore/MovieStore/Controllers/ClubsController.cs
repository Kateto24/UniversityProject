using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using FootballClubs.BL.Interfaces;
using FootballClubs.DL.Interfaces;
using FootballClubs.Models.DTO;
using FootballClubs.Models.Requests;

namespace FootballClubs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClubsController : ControllerBase
    {
        private readonly IClubService _clubService;
        private readonly IMapper _mapper;
        private readonly ILogger<ClubsController> _logger;

        public ClubsController(IClubService clubService, IMapper mapper, ILogger<ClubsController> logger)
        {
            _clubService = clubService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var result = _clubService.GetAllClubs();

            if (result == null || result.Count == 0)
            {
                return NotFound("No clubs found");
            }

            return Ok(result);
        }

        [HttpPost("Add")]
<<<<<<< HEAD:MovieStore/MovieStore/Controllers/MoviesController.cs
        public async Task<IActionResult> Add(AddMovieRequest movie)
=======
        public IActionResult Add(AddClubRequest club)
>>>>>>> 8d8d5a7a039982bf83f7e32f3a7eeead6ce8281e:MovieStore/MovieStore/Controllers/ClubsController.cs
        {
            try
            {
                var clubDto = _mapper.Map<Club>(club);

                if (clubDto == null)
                {
                    return BadRequest("Can't convert club");
                }

<<<<<<< HEAD:MovieStore/MovieStore/Controllers/MoviesController.cs
                await _movieService.AddMovie(movieDto);
=======
                _clubService.AddClub(clubDto);
>>>>>>> 8d8d5a7a039982bf83f7e32f3a7eeead6ce8281e:MovieStore/MovieStore/Controllers/ClubsController.cs
                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,$"Error adding club with");

                return BadRequest(ex.Message);
            } 
            //var movieDto = _mapper.Map<Movie>(movie);
            // _movieService.AddMovie(movieDto);
            //return Ok();
        }

        [HttpPost("Update")]
        public void Update(UpdateClubRequest club)
        {
            var clubDto = _mapper.Map<Club>(club);
            _clubService.UpdateClub(clubDto);
        }

        [HttpGet("GetById")]
        [ProducesResponseType<Club>(StatusCodes.Status200OK)]
        [ProducesResponseType<Club>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<Club>(StatusCodes.Status400BadRequest)]
        public IActionResult GetClubById(string id)
        {
            _logger.LogInformation($"Getting club with id: {id}");
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id must be greater than 0");
            }
            
            var result = _clubService.GetClubById(id);

            if (result == null)
            {
                return NotFound($"Club with ID:{id} not found");
            }

            return Ok(result);
        }

        [HttpDelete("DeleteById")]
        public IActionResult DeleteClub(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than 0");
            }

            //var result = _movieService.GetMovieById(id);

            //if (result == null)
            //{
            //    return NotFound($"Movie with ID:{id} not found");
            //}

            return Ok();
            //_movieService.DeleteMovie(id);
        }

    }
}
