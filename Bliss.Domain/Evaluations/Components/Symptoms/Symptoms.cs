using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Symptom
{
    public sealed class Symptoms
    {
        private readonly IList<ISymptom> _symptoms;

        public Symptoms()
        {
            _symptoms = new List<ISymptom>();
        }

        public IReadOnlyCollection<ISymptom> GetSymptoms()
        {
            IReadOnlyCollection<ISymptom> symptoms = new ReadOnlyCollection<ISymptom>(_symptoms);
            return symptoms;
        }

        public ISymptom AddSymptom()
        {
            throw new NotImplementedException();

            //ISymptom sympotms = new ISymptom(date, zone, startTime, duration);

            //ISymptom existingSymptoms = Find(sympotms);

            //if (existingSymptoms == null)
            //    _symptoms.Add(sympotms);
            //else
            //    return existingSymptoms;

            //return sympotms;
        }

        public void RemoveSymptom(Guid id)
        {
            throw new NotImplementedException();
        }

        private ISymptom Find(ISymptom symptom)
        {
            foreach (ISymptom symptomsInList in _symptoms)
            {
                if (symptomsInList.Equals(symptom))
                    return symptomsInList;
            }

            return null;
        }
    }
}
