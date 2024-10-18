namespace Server.Models
{
    abstract public class User
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Role { get; set; }
    }
}
