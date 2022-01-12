using ContentAPI.Models;
using Microsoft.EntityFrameworkCore;
using MovieTheaterAPI.Models;

namespace FilmesApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<MovieModel> Movie { get; set; }
        public DbSet<MovieTheaterModel> MovieTheater { get; set; }
        public DbSet<AddressModel> Address { get; set; }


    }
}