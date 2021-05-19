using USend.Application.Validations.CustomValidations;
using FluentValidation;
using USend.Application.Requests.User;

namespace USend.Application.Validations.User
{
    public class CreateUserRequestValidation : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidation()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email não pode ser nulo.");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name não pode ser nulo.");

            RuleFor(c => c.Password)
                .IsPassword();

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("BirthDate não pode ser nulo.");

            RuleFor(c => c.Cpf)
                .IsCpf();

            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("Phone não pode ser nulo.");
        }
    }
}
