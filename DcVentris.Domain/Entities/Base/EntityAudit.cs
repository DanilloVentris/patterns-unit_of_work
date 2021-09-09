using System;
using DcVentris.Core.Exceptions;
using DcVentris.Domain.Extensions;
using DcVentris.Domain.Interfaces;
using DcVentris.Domain.Validators.Base;

namespace DcVentris.Domain.Entities.Base
{
    public abstract class EntityAudit : Entity, IEntityAudit
    {
        public DateTime DataDeCriacaoNoFormatoUTC { get; private set; } = DateTime.UtcNow;
        public DateTime DataDaModificacaoNoFormatoUTC { get; private set; } = DateTime.UtcNow;
        public Guid ModificadoPor { get; protected set; }

        //EF core
        protected EntityAudit() { }

        protected EntityAudit(Guid modificadoPor) =>
            ModificadoPor = modificadoPor;

        public override bool Validate()
        {
            if (!base.Validate()) return false;

            var validator = new EntityAuditValidator();
            var result = validator.Validate(this);
            var isValid = result.IsValid;
            if (!isValid)
            {
                _errors.AddErrorsFromValidator(result);

                throw new DomainException("Campos inválidos!\n", _errors);
            }

            return base.Validate();
        }
    }
}
