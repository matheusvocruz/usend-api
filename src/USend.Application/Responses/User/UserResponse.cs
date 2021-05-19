using System;

namespace USend.Application.Responses.User
{
    public class UserResponse
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public string Avatar { get; set; }
    }
}
