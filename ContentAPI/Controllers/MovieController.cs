using AutoMapper;
using ContentAPI.Data.Dtos;
using ContentAPI.Models;
using FilmesApi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ContentAPI.Controllers
{
    [ApiController]
    [Route("movie")]
    public class MovieController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public MovieController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("addMovie")]
        [HttpPost]
        public IActionResult addMovie([FromBody] MovieDTO movieDTO)
        {
            MovieModel movie = _mapper.Map<MovieModel>(movieDTO);
            _context.Movie.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getMoviesById), new { Id = movie.Id }, movie);
        }

        [Route("getMovies")]
        [HttpGet]
        public IEnumerable<MovieModel> getMovies()
        {
            return _context.Movie;
        }

        [Route("getMovieById")]
        [HttpGet]
        public IActionResult getMoviesById(int id)
        {
            MovieModel movie = _context.Movie.FirstOrDefault(movie => movie.Id == id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();

        }

        [Route("updateMovie")]
        [HttpPut]
        public IActionResult úpdateMovie(int id, [FromBody] MovieDTO movieDTO)
        {
            MovieModel movie = _context.Movie.FirstOrDefault(movie => movie.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _mapper.Map(movieDTO, movie);
            _context.SaveChanges();
            return NoContent();
        }

        [Route("deleteMovie")]
        [HttpDelete]
        public IActionResult deleteMovie(int id)
        {
            MovieModel movie = _context.Movie.FirstOrDefault(movie => movie.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _context.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}