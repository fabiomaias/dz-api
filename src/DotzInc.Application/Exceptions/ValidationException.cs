using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace DotzInc.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("Erros de validação:")
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; }
        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

    }
}
