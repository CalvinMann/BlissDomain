using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;


namespace Bliss.Domain.Evaluations.Components.Treatments
{
    public interface IMedicine
    {
        Medication Medication { get; }
    }
}
