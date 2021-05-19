using FluentValidation;
using USend.Application.Requests.User;

namespace USend.Application.Validations.User
{
    public class ActiveUserRequestValidation : AbstractValidator<ActiveUserRequest>
    {
        public ActiveUserRequestValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id não pode ser nulo.");
        }
    }
}
