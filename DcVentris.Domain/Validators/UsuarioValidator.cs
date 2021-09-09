using DcVentris.Domain.Entities;
using FluentValidation;

namespace DcVentris.Domain.Validators
{
    public class UsuarioValidator : AbstractValidator<User>
    {
        public UsuarioValidator()
        {
            RuleFor(usuario => usuario.PrimeiroNome)
                .NotNull()
                .WithMessage("Não pode ser nullo.")
                
                .NotEmpty()
                .WithMessage("Não pode ser vazio.")
                
                .MaximumLength(20)
                .WithMessage("Não pode exceder 20 caracteres");

            RuleFor(usuario => usuario.Sobrenome)
                .NotNull()
                .WithMessage("Não pode ser nullo.")

                .NotEmpty()
                .WithMessage("Não pode ser vazio.")

                .MaximumLength(80)
                .WithMessage("Não pode exceder 80 caracteres");

            RuleFor(usuario => usuario.Email)
                .NotNull()
                .WithMessage("Não pode ser nullo.")
                
                .NotEmpty()
                .WithMessage("Não pode ser vazio.")
                
                .EmailAddress()
                .WithMessage("Inválido.")
                
                .MaximumLength(80)
                .WithMessage("Não pode exceder 80 caracteres");
        }
    }
}
