using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Consultations
{
    public interface ISubmitConsultationValidation
    {
        List<ValidationError> Validate();
    }
}
