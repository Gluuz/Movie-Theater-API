using System.ComponentModel.DataAnnotations;

namespace MovieTheaterAPI.Models
{
    public class AddressModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Adress { get; set; }

        public string District { get; set; }

        public int Number { get; set; }
    }
}
