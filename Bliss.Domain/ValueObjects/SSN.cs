using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Bliss.Domain.ValueObjects
{
    public sealed class SSN
    {
        private string _text;
        const string RegExForValidation = @"^\d{3}-\d{2}-\d{4}$";

        public SSN(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new Exception("The 'SSN' field is required");

            Regex regex = new Regex(RegExForValidation);
            Match match = regex.Match(text);

            if (!match.Success)
                throw new Exception("Invalid SSN format.");

            _text = text;
        }

        public static implicit operator SSN(string text)
        {
            return new SSN(text);
        }

        public static implicit operator string(SSN ssn)
        {
            return ssn._text;
        }
    }
}
