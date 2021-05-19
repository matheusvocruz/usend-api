using System;
using FluentValidation;

namespace USend.Application.Validations.CustomValidations
{
    public static class CustomValidation
    {
        public static IRuleBuilderOptions<T, string> IsCpf<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CpfValidation());
        }

        public static IRuleBuilderOptions<T, string> IsPassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Senha não pode ser nula")
                .MinimumLength(8).WithMessage("Senha precisa ter 8 caracteres")
                .MaximumLength(16).WithMessage("Senha só pode ter 16 caracteres")
                .Matches("[0-9]+").WithMessage("Senha precisa ter número")
                .Matches("[A-Z]+").WithMessage("Senha precisa ter uma letra maiscula")
                .Matches(@"[""!@#$%^&*(){}:;<>,.?/+\-_=|'[\]~\\]").WithMessage("A senha precisa ter caracter especial")
                .Matches(@"\A\S+\z").WithMessage("Senha não pode ter espaço vazio");
        }
    }
}
