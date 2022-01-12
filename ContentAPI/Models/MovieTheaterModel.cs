using System.ComponentModel.DataAnnotations;

namespace MovieTheaterAPI.Models
{
    public class MovieTheaterModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is necessary!")]
        public string Name { get; set; }

    }
}
