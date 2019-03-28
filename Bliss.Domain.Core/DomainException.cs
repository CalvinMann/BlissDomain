using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Core
{
    public class DomainException : Exception
    {
        internal DomainException(string businessMessage)
            : base(businessMessage)
        {
        }
    }
}
