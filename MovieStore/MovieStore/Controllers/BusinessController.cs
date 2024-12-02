using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.BL.Interfaces;
using MovieStore.Models.DTO;
using MovieStore.Models.Requests;

namespace MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IMovieBLService _movieBLService;
        private readonly IMapper _mapper;
        private readonly ILogger<BusinessController> _logger;

        public BusinessController(IMovieBLService movieBLService, IMapper mapper, ILogger<BusinessController> logger)
        {
            _movieBLService = movieBLService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _movieBLService.GetDetailedMovies();

            if (result == null/* || result.Count == 0*/)
            {
                return NotFound("No movies found");
            }

            return Ok(result);
        }

        //[HttpPost("Add")]
        //public IActionResult Add(AddMovieRequest movie)
        //{
        //    try
        //    {
        //        var movieDto = _mapper.Map<Movie>(movie);

        //        if (movieDto == null)
        //        {
        //            return BadRequest("Can't convert movie");
        //        }

        //        _movieService.AddMovie(movieDto);
        //        return Ok();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        _logger.LogError(ex, $"Error adding movie with");

        //        return BadRequest(ex.Message);
        //    }
        //    //var movieDto = _mapper.Map<Movie>(movie);
        //    // _movieService.AddMovie(movieDto);
        //    //return Ok();
        //}

        //[HttpPost("Update")]
        //public void Update(UpdateMovieRequest movie)
        //{
        //    var movieDto = _mapper.Map<Movie>(movie);
        //    _movieService.UpdateMovie(movieDto);
        //}

        //[HttpGet("GetById")]
        //[ProducesResponseType<Movie>(StatusCodes.Status200OK)]
        //[ProducesResponseType<Movie>(StatusCodes.Status404NotFound)]
        //[ProducesResponseType<Movie>(StatusCodes.Status400BadRequest)]
        //public IActionResult GetMovieById(int id)
        //{
        //    _logger.LogInformation($"Getting movie with id: {id}");
        //    if (id <= 0)
        //    {
        //        return BadRequest("Id must be greater than 0");
        //    }

        //    var result = _movieService.GetMovieById(id);

        //    if (result == null)
        //    {
        //        return NotFound($"Movie with ID:{id} not found");
        //    }

        //    return Ok(result);
        //}

        //[HttpDelete("DeleteById")]
        //public IActionResult DeleteMovie(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest("Id must be greater than 0");
        //    }

        //    //var result = _movieService.GetMovieById(id);

        //    //if (result == null)
        //    //{
        //    //    return NotFound($"Movie with ID:{id} not found");
        //    //}

        //    return Ok();
        //    //_movieService.DeleteMovie(id);
        //}

    }
}
