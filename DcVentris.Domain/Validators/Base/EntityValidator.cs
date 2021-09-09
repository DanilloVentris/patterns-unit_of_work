using DcVentris.Domain.Entities.Base;
using FluentValidation;

namespace DcVentris.Domain.Validators.Base
{
    public class EntityValidator : AbstractValidator<Entity>
    {
        public EntityValidator()
        {
            var nameFieldId = nameof(Entity.Id);

            RuleFor(entidade => entidade.Id)
                .NotNull().WithMessage($"O [{nameFieldId}] campo não pode ser nulo.")
                .NotEmpty().WithMessage($"O [{nameFieldId}] campo não pode ser vazio.");
        }
    }
}
