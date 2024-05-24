using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace backend.Data.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Surname { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        [AllowedValues("Służbowy", "Prywatny", "inny")]
        public required string Category { get; set; }

        public string? Subcategory { get; set; }

        [Phone]
        public string? Phone { get; set; }
    }
}
