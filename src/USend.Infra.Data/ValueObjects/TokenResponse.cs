using USend.Domain.Entities;
using System;

namespace USend.Infra.Data.ValueObjects
{
    public class TokenResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
