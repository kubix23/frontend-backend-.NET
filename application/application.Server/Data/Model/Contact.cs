using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace application.Server.Data.Model
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public required string name { get; set; }

        [Required]
        public required string surname { get; set; }

        [EmailAddress]
        [Index(IsUnique = true)]
        public string? email { get; set; }

        [Required]
        public required string password { get; set; }

        [Required]
        [AllowedValues("Służbowy", "Prywatny", "inny")]
        public required string category { get; set; }

        public string? subcategory { get; set; }

        [Phone]
        public string? phone { get; set; }

        [Required]
        public DateOnly dateOfBirth { get; set; }
    }
}
