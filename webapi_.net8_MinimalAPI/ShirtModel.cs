using System.ComponentModel.DataAnnotations;

namespace webapi_.net8_MinimalAPI
{
    public class ShirtModel
    {
     
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Color { get; set; }
        public string? Gender { get; set; }
        [Required]
        [CustomValidationSize]
        public int? Size { get; set; }    
        public double Price { get; set; }

    }
}
