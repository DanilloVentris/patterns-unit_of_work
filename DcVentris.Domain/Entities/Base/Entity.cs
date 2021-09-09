using System;
using System.Collections.Generic;
using System.Linq;
using DcVentris.Core.Exceptions;
using DcVentris.Domain.Extensions;
using DcVentris.Domain.Interfaces;
using DcVentris.Domain.Validators.Base;

namespace DcVentris.Domain.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; private set; }

        //EF
        protected Entity() => Id = Guid.NewGuid();


        internal List<string> _errors = new();
        public IReadOnlyCollection<string> Errors => _errors.ToList();


        public override bool Equals(object obj)
        {
            if (obj is not Entity other) return false;

            if (ReferenceEquals(this, other)) return true;

            if (GetUnproxiedType(this) != GetUnproxiedType(other)) return false;

            if (Id.Equals(default) || other.Id.Equals(default)) return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null) return true;

            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetUnproxiedType(this).ToString() + Id).GetHashCode();
        }

        internal static Type GetUnproxiedType(object obj)
        {
            const string EFCoreProxyPrefix = "Castle.Proxies.";

            Type type = obj.GetType();
            string typeString = type.ToString();

            if (typeString.Contains(EFCoreProxyPrefix))
                return type.BaseType;

            return type;
        }

        public virtual bool Validate()
        {
            var validator = new EntityValidator();
            var result = validator.Validate(this);
            var isValid = result.IsValid;
            if (!isValid)
            {
                _errors.AddErrorsFromValidator(result);

                throw new DomainException("Campos inválidos!\n", _errors);
            }

            return isValid;
        }
    }
}
