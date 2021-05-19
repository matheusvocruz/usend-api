using FluentValidation;
using USend.Application.Requests.User;

namespace USend.Application.Validations.User
{
    public class DeleteUserRequestValidation : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserRequestValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id não pode ser nulo.");
        }
    }
}
