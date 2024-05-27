using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tests.Data{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string surname { get; set; }

        [EmailAddress]
        public string? email { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string category { get; set; }

        public string? subcategory { get; set; }

        [Phone]
        public string? phone { get; set; }

        [Required]
        public DataType dateOfBirth { get; set; }
    }
}