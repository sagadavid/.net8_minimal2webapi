using System.ComponentModel.DataAnnotations;

namespace webapi_.net8_MinimalAPI
{
    public class ShirtModel
    {

        public int Id { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        [CustomValidationSize]
        public int? Size { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
