using System.ComponentModel.DataAnnotations;

namespace ContentAPI.Data.Dtos
{
    public class MovieDTO
    {
        [Required(ErrorMessage = "Title is necessary")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Gender is necessary")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Director is necessary")]
        public string Director { get; set; }
        public int Duration { get; set; }
    }
}
