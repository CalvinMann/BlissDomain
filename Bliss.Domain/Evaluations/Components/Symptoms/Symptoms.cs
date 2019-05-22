using Bliss.Domain.ValueObjects;
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

      

        public void AddPainSymptom(PainLevel painLevel, Frequency frequency, string description, SymptomBodyLocation bodyLocation, TimePeriod symptomPeriod)
        {
            Pain pain = new Pain(painLevel, frequency, description, bodyLocation, symptomPeriod);
      

            _symptoms.Add(pain);
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
