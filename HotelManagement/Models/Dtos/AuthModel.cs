namespace HotelManagement.Models.Dtos
{
    public class AuthModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
