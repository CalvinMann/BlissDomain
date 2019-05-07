using Bliss.Domain.Evaluations.Components.Treatments;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Symptom
{
    public interface ISymptom
    {
        string Description { set; get; }

        SymptomBodyLocation BodyLocation { set; get; }

        TimePeriod SymptomPeriod { set; get; }

        Frequency Frequency { get; set; }

        ITreatment AppliedTreatment { get; set; }
    }
}
