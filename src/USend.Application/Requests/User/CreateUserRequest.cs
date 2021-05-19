using System;
using USend.Application.Responses.ApiResponse;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace USend.Application.Requests.User
{
    public class CreateUserRequest : IRequest<ApiResponse>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
