using FluentValidation.Results;
using MediatR;

namespace USend.Application.Requests.User
{
    public class AuthenticateRequest : IRequest<ValidationResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
