using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public sealed class Gender
    {
        private string _text;

        public Gender(string gender)
        {
            if (string.IsNullOrWhiteSpace(gender))
                throw new Exception("The 'Gender' field is required");

            _text = gender;
        }

        public static implicit operator Gender(string gender)
        {
            return new Gender(gender);
        }

        public static implicit operator string(Gender gender)
        {
            return gender._text;
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
                return obj.ToString() == _text;
            }

            return ((Gender)obj)._text == _text;
        }
    }
}
