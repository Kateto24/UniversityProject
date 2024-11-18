using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.BL.Interfaces;
using MovieStore.DL.Interfaces;
using MovieStore.Models.DTO;
using MovieStore.Models.Requests;

namespace MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        public IEnumerable<Movie> Get()
        {
            return _movieService.GetAllMovies();
        }

        [HttpPost("Add")]
        public void Add(AddMovieRequest movie)
        {
             var movieDto = _mapper.Map<Movie>(movie);
             _movieService.AddMovie(movieDto);
        }

        [HttpPost("Update")]
        public void Update(UpdateMovieRequest movie)
        {
            var movieDto = _mapper.Map<Movie>(movie);
            _movieService.UpdateMovie(movieDto);
        }

        [HttpGet("GetById")]
        public Movie GetMovieById(int id)
        {
            return _movieService.GetMovieById(id);
        }

        [HttpDelete("DeleteById")]
        public void DeleteMovie(int id)
        {
            _movieService.DeleteMovie(id);
        }

    }
}
