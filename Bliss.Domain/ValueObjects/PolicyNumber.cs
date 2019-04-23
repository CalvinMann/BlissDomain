using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public class PolicyNumber : ValueObject
    {
        public PolicyNumber()
        {
            throw new NotImplementedException(); //Test validations
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
