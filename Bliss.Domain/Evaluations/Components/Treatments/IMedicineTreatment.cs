using System;
using System.Collections.Generic;
using System.Text;
using Bliss.Domain.Evaluations.Components.Medication;
using Meds = Bliss.Domain.Evaluations.Components.Medication;

namespace Bliss.Domain.Evaluations.Components.Treatments
{
    public interface IMedicineTreatment : ITreatment
    {
        Meds.Medication Medication { get; }
    }
}
