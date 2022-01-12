using System.ComponentModel.DataAnnotations;

namespace MovieTheaterAPI.Data.Dtos.MovieTheater
{
    public class MovieTheaterDTO
    {
        [Required(ErrorMessage = "Name is necessary!")]
        public string Name { get; set; }
    }
}
