using AutoMapper;
using FilmesApi.Data;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterAPI.Data.Dtos.MovieTheater;
using MovieTheaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTheaterAPI.Controllers
{
        [ApiController]
        [Route("movieTheater")]
        public class MovieTheaterController : ControllerBase
        {
            private AppDbContext _context;
            private IMapper _mapper;

            public MovieTheaterController(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            [Route("addMovieTheater")]
            [HttpPost]
            public IActionResult AddMovieTheater([FromBody] MovieTheaterDTO movieTheaterDTO)
            {
                MovieTheaterModel movieTheater = _mapper.Map<MovieTheaterModel>(movieTheaterDTO);
                _context.MovieTheater.Add(movieTheater);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetMovieTheaterById), new { Id = movieTheater.Id }, movieTheater);
            }

            [Route("getMovieTheater")]
            [HttpGet]
            public IEnumerable<MovieTheaterModel> GetMovieTheater([FromQuery] string movieTitle)
            {
                return _context.MovieTheater;
            }

            [Route("getMovieTheaterById")]
            [HttpGet]
            public IActionResult GetMovieTheaterById(int id)
            {
                MovieTheaterModel cinema = _context.MovieTheater.FirstOrDefault(movieTheater => movieTheater.Id == id);
                if (cinema != null)
                {
                    MovieTheaterDTO movieTheaterDTO = _mapper.Map<MovieTheaterDTO>(cinema);
                    return Ok(movieTheaterDTO);
                }
                return NotFound();
            }

            [Route("updateMovieTheater")]
            [HttpPut]
            public IActionResult UpdateMovieTheater(int id, [FromBody] MovieTheaterDTO movieTheaterDTO)
            {
                MovieTheaterModel movieTheater = _context.MovieTheater.FirstOrDefault(movieTheater => movieTheater.Id == id);
                if (movieTheater == null)
                {
                    return NotFound();
                }
                _mapper.Map(movieTheaterDTO, movieTheater);
                _context.SaveChanges();
                return NoContent();
            }

            [Route("deleteMovieTheater")]
            [HttpDelete]
            public IActionResult DeleteMovieTheater(int id)
            {
                MovieTheaterModel movieTheater = _context.MovieTheater.FirstOrDefault(movieTheater => movieTheater.Id == id);
                if (movieTheater == null)
                {
                    return NotFound();
                }
                _context.Remove(movieTheater);
                _context.SaveChanges();
                return NoContent();
            }

        }
    }
