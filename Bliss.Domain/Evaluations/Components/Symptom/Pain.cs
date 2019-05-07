using Bliss.Domain.Core;
using Bliss.Domain.Evaluations.Components.Treatments;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Symptom
{
    public class Pain : IEntity, IPain
    {

        public Pain()
        {
            Id = Guid.NewGuid();

        }

        public Guid Id { private set; get; }

        public PainLevel PainLevel {  set; get ; }

        public Frequency Frequency { set; get; }

        public string Description { set; get; }

        public SymptomBodyLocation BodyLocation { set; get; }

        public TimePeriod SymptomPeriod { set; get; }

        public ITreatment AppliedTreatment { set; get; }
    }
}
