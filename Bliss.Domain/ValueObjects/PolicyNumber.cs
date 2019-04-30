using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public class PolicyNumber : ISubmitConsultationValidation
    {
        private string _number;

        public PolicyNumber(string number)
        {
          
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

        public List<ValidationError> Validate()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            //Check if a policy number has special traits (ex: lenght, certain # of characters)
            if (string.IsNullOrWhiteSpace(_number))
                validationErrors.Add(new ValidationError("'Number' field is required", nameof(PolicyNumber)));

            return validationErrors;
        }
    }

  
}
