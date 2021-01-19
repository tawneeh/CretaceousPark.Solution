using System.ComponentModel.DataAnnotations; // needed to access Data Annotations

namespace CretaceousPark.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        [Range(0, 200, ErrorMessage = "Age must be between 0 and 200.")]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}

// While these basic validations are helpful, there are many other validations we might want to use that .NET doesn't provide. In that situation, we can consider custom validations or use an external library