using System;

namespace USend.Application.Responses.User
{
    public class TokenResponse
    {
        public UserResponse User { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
