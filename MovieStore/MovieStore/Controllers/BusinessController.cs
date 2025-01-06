using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.BL.Interfaces;

namespace MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IMovieBLService _movieService;
        private readonly IMapper _mapper;
        private readonly ILogger<BusinessController> _logger;

        public BusinessController(IMovieBLService movieService, IMapper mapper, ILogger<BusinessController> logger)
        {
            _movieService = movieService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _movieService.GetDetailedMovies();

            if (result == null/* || result.Count == 0*/)
            {
                return NotFound("No movies found");
            }

            return Ok(result);
        }

        

    }
}
