using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using FootballClubs.BL.Interfaces;

namespace FootballClubs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IFootballClubsBLService _clubService;
        private readonly IMapper _mapper;
        private readonly ILogger<BusinessController> _logger;

        public BusinessController(IFootballClubsBLService movieService, IMapper mapper, ILogger<BusinessController> logger)
        {
            _clubService = movieService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _clubService.GetDetailedClubs();

            if (result == null/* || result.Count == 0*/)
            {
                return NotFound("No movies found");
            }

            return Ok(result);
        }

        

    }
}
