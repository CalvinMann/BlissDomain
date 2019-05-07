using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public sealed class PainLevel 
    {
        private int _painLevel;

        public PainLevel(int painLevel)
        {
            if (painLevel < 0 || painLevel > 10)
                throw new Exception("Level must be between 1 and 10");
            _painLevel = painLevel;
        }

        public static implicit operator PainLevel(int painLevel)
        {
            return new PainLevel(painLevel);
        }

        public static implicit operator int(PainLevel painLevel)
        {
            return painLevel._painLevel;
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

           

            return ((PainLevel)obj)._painLevel == _painLevel;
        }


    }
}
