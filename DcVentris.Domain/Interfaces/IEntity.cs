using System;
using System.Collections.Generic;

namespace DcVentris.Domain.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; }

        IReadOnlyCollection<string> Errors { get; }
        bool Validate();

        bool Equals(object obj);
        int GetHashCode();
    }
}
