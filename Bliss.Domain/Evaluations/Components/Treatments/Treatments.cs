using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Treatments
{

    public sealed class Treatments
    {
        private readonly IList<ITreatment> _treatments;

        public Treatments()
        {
            _treatments = new List<ITreatment>();
        }

        public IReadOnlyCollection<ITreatment> GetTreatments()
        {
            IReadOnlyCollection<ITreatment> treatments = new ReadOnlyCollection<ITreatment>(_treatments);
            return treatments;
        }

        public void AddMedicine(Medication medication, Frequency frequency, TimePeriod treatmentPeriod )
        {

            Medicine medicine = new Medicine( medication);
            medicine.TreatmentPeriod = treatmentPeriod;
            medicine.Frequency = frequency;

            _treatments.Add(medicine);
        }


        public void RemoveTreatment(Guid id)
        {
            throw new NotImplementedException();
        }

        private ITreatment Find(ITreatment treatment)
        {
            foreach (ITreatment treatmentInList in _treatments)
            {
                if (treatmentInList.Equals(treatment))
                    return treatmentInList;
            }

            return null;
        }
    }
}
