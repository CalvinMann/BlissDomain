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
            //ensure zip is 5 charachers
            if (string.IsNullOrEmpty(zipCode))
                throw new Exception("Zipcode cannot be empty");

            if(zipCode.ToCharArray().Length != 5)
                throw new Exception("Zipcode must be 5 digits long");

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
    }
}
