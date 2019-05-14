using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Medications
{
    public sealed class Medications
    {
        private readonly IList<IMedication> _medication;

        public Medications()
        {
            _medication = new List<IMedication>();
        }

        public IReadOnlyCollection<IMedication> GetMedications()
        {
            IReadOnlyCollection<IMedication> medication = new ReadOnlyCollection<IMedication>(_medication);
            return medication;
        }

        public IMedication AddMedication()
        {
            throw new NotImplementedException();

        }

        public void RemoveMedication(Guid id)
        {
            throw new NotImplementedException();
        }

        private IMedication Find(IMedication medication)
        {
            foreach (IMedication medicationInList in _medication)
            {
                if (medicationInList.Equals(medication))
                    return medicationInList;
            }

            return null;
        }
    }
}
