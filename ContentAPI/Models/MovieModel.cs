using System.ComponentModel.DataAnnotations;

namespace ContentAPI.Models
{
    public class MovieModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is necessary")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Gender is necessary")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Director is necessary")]
        public string Director { get; set; }

        public int Duration { get; set; }

        public int AgeRating { get; set; }

    }
}
