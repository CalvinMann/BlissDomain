using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public sealed class Complaint
    {
        private string _text;

        public Complaint(string text)
        {

            _text = text;
        }

        public static implicit operator Complaint(string text)
        {
            return new Complaint(text);
        }

        public static implicit operator string(Complaint name)
        {
            return name._text;
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

            return ((Complaint)obj)._text == _text;
        }

    }
}
