using Bliss.Domain.Core;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Meds = Bliss.Domain.Evaluations.Components.Medication;

namespace Bliss.Domain.Evaluations.Components.Treatments
{
    public class Medicine : IEntity, IMedicineTreatment
    {

        public Medicine(Meds.Medication medication)
        {
            Id = Guid.NewGuid();
            Medication = medication;
        }

        public Guid Id { private set; get; }

        public Meds.Medication Medication { private set; get; }

        public Frequency Frequency { set; get; }

        public TimePeriod TreatmentPeriod { set; get; }


    }
}
