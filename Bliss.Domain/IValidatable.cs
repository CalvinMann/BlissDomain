using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain
{
    public interface IValidatable
    {
        List<ValidationError> Validate();
    }
}
