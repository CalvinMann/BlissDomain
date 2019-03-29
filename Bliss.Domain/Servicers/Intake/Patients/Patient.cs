using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Servicers.Intake.Patients
{
    public sealed class Patient : IAggregateRoot
    {
        public Guid Id => throw new NotImplementedException();
    }
}
