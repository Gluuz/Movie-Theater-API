using AutoMapper;
using FilmesApi.Data;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterAPI.Data.Dtos.Adress;
using MovieTheaterAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieTheaterAPI.Controllers
{
    [ApiController]
    [Route("address")]
    public class AddressController : ControllerBase
    {
        private AppDbContext _context;
        
        private IMapper _mapper;

        public AddressController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [Route("addAddress")]
        [HttpPost]
        public IActionResult AddAddress([FromBody] AddressDTO addressDTO)
        {
            AddressModel address = _mapper.Map<AddressModel>(addressDTO);
            _context.Address.Add(address);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAddressById), new { Id = address.Id }, address);
        }

        [Route("getAddress")]
        [HttpGet]
        public IEnumerable<AddressModel> GetAdress()
        {
            return _context.Address;
        }

        [HttpGet("getAddressById")]
        public IActionResult GetAddressById(int id)
        {
            AddressModel address = _context.Address.FirstOrDefault(address => address.Id == id);
            if (address != null)
            {
                AddressDTO addressDTO = _mapper.Map<AddressDTO>(address);

                return Ok(addressDTO);
            }
            return NotFound();
        }

        [HttpPut("updateAddress")]
        public IActionResult UpdateAddress(int id, [FromBody] AddressDTO addressDTO)
        {
            AddressModel address = _context.Address.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            _mapper.Map(addressDTO, address);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("deleteAdress")]
        public IActionResult DeleteAddress(int id)
        {
            AddressModel address = _context.Address.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            _context.Remove(address);
            _context.SaveChanges();
            return NoContent();
        }

    }
}