using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public sealed class Gender
    {
        private static string genderStr = "|M|F|";

        private char _gender;

        public Gender(char gender)
        {
            if (char.IsWhiteSpace(gender))
                throw new Exception("The 'Gender' field is required");

            if ((genderStr.IndexOf(gender.ToString()) > 0) == false)
                throw new Exception("Gender abv is not valid");

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
    }
}
