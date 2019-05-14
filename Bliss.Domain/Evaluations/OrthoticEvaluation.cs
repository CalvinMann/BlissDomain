using Bliss.Domain.Core;
using Bliss.Domain.Evaluations.Components.Medications;
using Bliss.Domain.Evaluations.Components.Symptom;
using Bliss.Domain.Evaluations.Components.Treatments;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations
{
    public class OrthoticEvaluation : IAggregateRoot, IEvaluation
    {
        private Symptoms _symptoms;
        private Medications _medications;
        private Treatments _treatments;

        private OrthoticEvaluation() { }

        public static OrthoticEvaluation New(EvaluationType evaluationType)
        {
            OrthoticEvaluation orthoticEvaluation = new OrthoticEvaluation()
            {
                //init 
                Id = Guid.NewGuid(),
                EvaluationType = evaluationType,
                CreationDate = new Date(DateTime.Now),
                _symptoms = new Symptoms(),
                _medications = new Medications(),
                _treatments = new Treatments()

        };

            return orthoticEvaluation;
        }

        public Guid Id { private set; get; }

        public EvaluationType EvaluationType { private set; get; }

        public Date CreationDate { private set; get; }

        public Complaint ChiefComplaint { private set; get; }

        public IReadOnlyCollection<ISymptom> Symptoms
        {
            get
            {
                IReadOnlyCollection<ISymptom> readOnly = _symptoms.GetSymptoms();
                return readOnly;
            }
        }

        public IReadOnlyCollection<IMedication> Medications
        {
            get
            {
                IReadOnlyCollection<IMedication> readOnly = _medications.GetMedications();
                return readOnly;
            }
        }

        public IReadOnlyCollection<ITreatment> Treatments
        {
            get
            {
                IReadOnlyCollection<ITreatment> readOnly = _treatments.GetTreatments();
                return readOnly;
            }
        }

        public void AddComplaint(Complaint complaint)
        {
            ChiefComplaint = complaint;
        }
    }
}
