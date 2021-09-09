using DcVentris.Domain.Entities.Base;
using FluentValidation;

namespace DcVentris.Domain.Validators.Base
{
    public class EntityAuditValidator: AbstractValidator<EntityAudit>
    {
        public EntityAuditValidator()
        {
            var nameFieldModificadoPor = nameof(EntityAudit.ModificadoPor);
            RuleFor(entidadeAuditavel => entidadeAuditavel.ModificadoPor)
                .NotNull().WithMessage($"O [{nameFieldModificadoPor}] não pode ser nullo.")
                .NotEmpty().WithMessage($"O [{nameFieldModificadoPor}] não pode ser vazio.");

            
            var nameFieldDataDeCriacaoNoFormatoUTC = nameof(EntityAudit.DataDeCriacaoNoFormatoUTC);
            RuleFor(entidadeAuditavel => entidadeAuditavel.DataDeCriacaoNoFormatoUTC)
                .NotNull().WithMessage($"A [{nameFieldDataDeCriacaoNoFormatoUTC}] não pode ser nullo.")
                .NotEmpty().WithMessage($"A [{nameFieldDataDeCriacaoNoFormatoUTC}] não pode ser vazio.");

            var nameFieldDataDaUltimaModificacaoNoFormatoUTC = nameof(EntityAudit.DataDaModificacaoNoFormatoUTC);
            RuleFor(entidadeAuditavel => entidadeAuditavel.DataDaModificacaoNoFormatoUTC)
                .NotNull().WithMessage($"A [{nameFieldDataDaUltimaModificacaoNoFormatoUTC}] não pode ser nullo.")
                .NotEmpty().WithMessage($"A [{nameFieldDataDaUltimaModificacaoNoFormatoUTC}] não pode ser vazio.");
        }
    }
}
