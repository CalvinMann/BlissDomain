using Bliss.Domain.Core;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Treatments
{
    public class Medicine : IEntity, IMedicine, ITreatment
    {

        public Medicine(Medication medication)
        {
            TreatmentType = TreatmentType.Medicine;
            Id = Guid.NewGuid();
            Medication = medication;
        }

        public Guid Id { private set; get; }

        public Medication Medication { private set; get; }

        public TreatmentType TreatmentType { private set; get; }

        public Frequency Frequency { set; get; }

        public TimePeriod TreatmentPeriod { set; get; }


    }
}
