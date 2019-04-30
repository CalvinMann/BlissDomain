using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Bliss.Domain.ValueObjects
{
    public sealed class SSN : ISubmitConsultationValidation
    {
        private string _ssn;
        const string RegExForValidation = @"^\d{3}-\d{2}-\d{4}$";

        public SSN(string ssn)
        {
           
            _ssn = ssn;
        }

        public static implicit operator SSN(string text)
        {
            return new SSN(text);
        }

        public static implicit operator string(SSN ssn)
        {
            return ssn._ssn;
        }

        public List<ValidationError> Validate()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            if (string.IsNullOrWhiteSpace(_ssn))
            {
                validationErrors.Add(new ValidationError("The 'SSN' field is required", nameof(SSN)));
                return validationErrors;
            }

            Regex regex = new Regex(RegExForValidation);
            Match match = regex.Match(_ssn);

            if (!match.Success)
                validationErrors.Add(new ValidationError("Invalid SSN format.", nameof(SSN)));

            return validationErrors;
        }
    }
}
