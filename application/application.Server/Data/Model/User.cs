using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace application.Server.Data.Model
{
    public class User
    {
        [Key]
        public required string login { get; set; }
        
        [Required]
        public required string password { get; set; }
    }
}
