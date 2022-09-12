using FluentValidation;

namespace Application.Validators
{
    public static class ValidatorExtension
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MinimumLength(6)
                .WithMessage("La contraseña debe tener al menos 6 caracteres")
                .Matches("[A-Z]").WithMessage("La contraseña debe contener una letra mayúscula")
                .Matches("[a-z]").WithMessage("La contraseña debe contener al menos una letra minúscula")
                .Matches("[0-9]").WithMessage("La contraseña debe contener un número")
                .Matches("[^a-zA-Z-0-9]").WithMessage("La contraseña debe contener un número no alfanumérico");

            return options;
        }
    }
}
