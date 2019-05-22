using Bliss.Domain.Evaluations.Components.Treatments;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Symptom
{
    public interface ISymptom
    {
        string Description {  get; }

        SymptomBodyLocation BodyLocation {  get; }

        TimePeriod SymptomPeriod {  get; }

        Frequency Frequency { get;  }
    }
}
