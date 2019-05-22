using Bliss.Domain.Core;
using Bliss.Domain.Evaluations.Components.Symptom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public class Pain : ValueObject, Evaluations.Components.Symptom.IPain, Evaluations.Components.Symptom.ISymptom
    {
        public Pain(PainLevel painLevel, Frequency frequency, string description, SymptomBodyLocation bodyLocation, TimePeriod symptomPeriod)
        {

        }

        public PainLevel PainLevel { private set; get; }

        public Frequency Frequency { private set; get; }

        public string Description { private set; get; }

        public SymptomBodyLocation BodyLocation { private set; get; }

        public TimePeriod SymptomPeriod { private set; get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PainLevel;
            yield return Frequency;
            yield return Description;
            yield return BodyLocation;
            yield return SymptomPeriod;

        }
    }
}
