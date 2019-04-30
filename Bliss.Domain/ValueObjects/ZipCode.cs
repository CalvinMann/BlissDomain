using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public sealed class ZipCode
    {
        private string _zipCode;

        public ZipCode(string zipCode)
        {
            
            _zipCode = zipCode;
        }

        public static implicit operator ZipCode(string zipCode)
        {
            return new ZipCode(zipCode);
        }

        public static implicit operator string(ZipCode zipCode)
        {
            return zipCode._zipCode;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is string)
            {
                return obj.ToString() == _zipCode;
            }

            return ((ZipCode)obj)._zipCode == _zipCode;
        }

        public List<ValidationError> Validate()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            if (string.IsNullOrEmpty(_zipCode))
            {
                validationErrors.Add(new ValidationError("Zipcode cannot be empty", nameof(ZipCode)));
                return validationErrors;
            }

            if (_zipCode.ToCharArray().Length != 5)
                validationErrors.Add(new ValidationError("Zipcode must be 5 digits long", nameof(ZipCode)));


            return validationErrors;
        }
    }
}
