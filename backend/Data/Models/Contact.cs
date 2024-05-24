namespace backend.Data.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string? Email { get; set; }
        public required string Password { get; set; }
        public required string Category { get; set; }
        public string? Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
