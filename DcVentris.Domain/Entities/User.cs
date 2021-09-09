using DcVentris.Core.Exceptions;
using DcVentris.Domain.Entities.Base;
using DcVentris.Domain.Extensions;
using DcVentris.Domain.Validators;
using System;

namespace DcVentris.Domain.Entities
{
    public class User : EntityAudit
    {
        public string PrimeiroNome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }

        //EF
        protected User()
        { }

        public User(string primeiroNome, string sobrenome, string email, Guid modificadoPor)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;
            Email = email;
            ModificadoPor = modificadoPor;
            
            Validate();
        }

        public override bool Validate()
        {
            if (!base.Validate()) return false;

            var validator = new UsuarioValidator();
            var result = validator.Validate(this);
            var isValid = result.IsValid;
            if (!isValid)
            {
                _errors.AddErrorsFromValidator(result);

                throw new DomainException($"Campos inválidos: ", _errors);
            }

            return isValid;
        }

    }
}
