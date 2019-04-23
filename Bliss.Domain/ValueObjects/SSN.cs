using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Bliss.Domain.ValueObjects
{
    public sealed class SSN
    {
        private string _ssn;
        const string RegExForValidation = @"^\d{3}-\d{2}-\d{4}$";

        public SSN(string ssn)
        {
            if (string.IsNullOrWhiteSpace(ssn))
                throw new Exception("The 'SSN' field is required");

            Regex regex = new Regex(RegExForValidation);
            Match match = regex.Match(ssn);

            if (!match.Success)
                throw new Exception("Invalid SSN format.");

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
    }
}
