using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public class PolicyNumber 
    {
        private string _number;

        public PolicyNumber(string number)
        {
            //Check if a policy number has special traits (ex: lenght, certain # of characters)
            if (string.IsNullOrWhiteSpace(number))
                throw new Exception("'Number' field is required");

            _number = number;
        }

        public static implicit operator PolicyNumber(string number)
        {
            return new PolicyNumber(number);
        }

        public static implicit operator string(PolicyNumber number)
        {
            return number._number;
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
                return obj.ToString() == _number;
            }

            return ((PolicyNumber)obj)._number == _number;
        }
    }

  
}
