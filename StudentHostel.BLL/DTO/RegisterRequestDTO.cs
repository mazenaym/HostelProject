namespace StudentHostelAPI.DTO
{
    public class RegisterRequestDTO
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public string PhoneNumber { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
