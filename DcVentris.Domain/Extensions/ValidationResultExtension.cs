using FluentValidation.Results;
using System.Collections.Generic;

namespace DcVentris.Domain.Extensions
{
    public static class ValidationResultExtension
    {
        public static void AddErrorsFromValidator(this IList<string> errors, ValidationResult result)
        {
            foreach (var err in result.Errors)
                errors.Add($"Propriedade: [{err.PropertyName}] - Mensagem: {err.ErrorMessage}");
        }
    }
}
