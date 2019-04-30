using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public sealed class Gender : ISubmitConsultationValidation
    {
        private static string genderStr = "|M|F|";

        private char _gender;

        public Gender(char gender)
        {
           
            _gender = gender;
        }

        public static implicit operator Gender(char gender)
        {
            return new Gender(gender);
        }

        public static implicit operator char(Gender gender)
        {
            return gender._gender;
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

          
            return ((Gender)obj)._gender == _gender;
        }

        public List<ValidationError> Validate()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            if (char.IsWhiteSpace(_gender))
            {
                validationErrors.Add(new ValidationError("The 'Gender' field is required", nameof(Gender)));
                return validationErrors;
            }

            if ((genderStr.IndexOf(_gender.ToString()) > 0) == false)
                validationErrors.Add(new ValidationError("Gender abv is not valid", nameof(Gender)));

            return validationErrors;
        }
    }
}
