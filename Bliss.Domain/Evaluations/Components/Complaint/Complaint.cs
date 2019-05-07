using System;
using System.Collections.Generic;
using System.Text;
using Bliss.Domain.Core;
using Bliss.Domain.Evaluations.Components.Symptom;

namespace Bliss.Domain.Evaluations.Components.Complaint
{
   public class Complaint : IEntity, IComplaint
    {
        private Symptoms _symptoms;

        public Complaint(string chiefComplaint)
        {
            Id = Guid.NewGuid();
            _symptoms = new Symptoms();
        }

        public Guid Id { get; private set; }

        public IReadOnlyCollection<ISymptom> Symptoms
        {
            get
            {
                IReadOnlyCollection<ISymptom> readOnly = _symptoms.GetSymptoms();
                return readOnly;
            }
        }

        public string ChiefComplaint { get; private set; }

     
        public void AddSymptom()
        {
            throw new NotImplementedException();

            _symptoms.AddSymptom();
        }
    }
}
