using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Servicers.Intake.Consultations
{
    public class Consultation : IAggregateRoot
    {
        public Guid Id { private set; get; }
    }
}
