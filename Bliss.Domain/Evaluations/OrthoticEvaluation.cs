using Bliss.Domain.Core;
using Bliss.Domain.Evaluations.Components.Biometrics;
using Bliss.Domain.Evaluations.Components.Medications;
using Bliss.Domain.Evaluations.Components.Surgeries;
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
        private Surgeries _surgeries;

        #region Constructors

        private OrthoticEvaluation() { }

        #endregion

        #region Factories

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
                _treatments = new Treatments(),
                _surgeries = new Surgeries()

            };

            return orthoticEvaluation;
        }

        #endregion

        #region Properties

        public Guid Id { private set; get; }

        public EvaluationType EvaluationType { private set; get; }

        public Date CreationDate { private set; get; }

        public Complaint ChiefComplaint { private set; get; }

        public BodyDimensions BodyDimensions { private set; get; }

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

        public IReadOnlyCollection<ISurgery> Surgeries
        {
            get
            {
                IReadOnlyCollection<ISurgery> readOnly = _surgeries.GetSurgeries();
                return readOnly;
            }
        }


        #endregion

        #region Behaviors

        public void AddComplaint(Complaint complaint)
        {
            ChiefComplaint = complaint;
        }

        public void AddBodyDimensions(BodyDimensions bodyDimensions)
        {
            BodyDimensions = bodyDimensions;
        }

        public void AddMedicineTreatment(Medication medication, Frequency frequency, TimePeriod treatmentPeriod)
        {
            _treatments.AddMedicine(medication, frequency, treatmentPeriod);
        }

        public void AddMedication(Medication medication, Frequency frequency, TimePeriod treatmentPeriod)
        {
            _treatments.AddMedicine(medication, frequency, treatmentPeriod);
        }

        public void AddPainSymptom(PainLevel painLevel, Frequency frequency, string description, SymptomBodyLocation bodyLocation, TimePeriod symptomPeriod)
        {
            _symptoms.AddPainSymptom(painLevel, frequency, description, bodyLocation, symptomPeriod);
        }

        public void AddSurgery(Date dateOfSurgery, SurgeryType surgeryType, string description)
        {
            _surgeries.AddSurgery(dateOfSurgery, surgeryType, description);
        }

        #endregion
    }
}
