using Bliss.Domain.Core;
using Bliss.Domain.Servicers.Intake.Evaluations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Servicers.Intake.Consultations
{
    public sealed class Consultation : IAggregateRoot
    {
        private Availabilities _availabilities;

        #region Constructors
        public Consultation(Guid patientId, Guid providerId, Guid supplierId)
        {
            //init
            Id = Guid.NewGuid();
            _availabilities = new Availabilities();

            //assign
            PatientId = patientId;
            ProviderId = providerId;
            SupplierId = supplierId;
        }

        private Consultation(Guid id, Guid patientId, Guid providerId, Guid supplierId, IEvaluation evaluation, Availabilities availabilities)
        {
            //assign
            Id = id;
            PatientId = patientId;
            ProviderId = providerId;
            SupplierId = supplierId;
            Evaluation = evaluation;
            _availabilities = availabilities;

        } 
        #endregion

        #region Factories
        public static Consultation Create(Guid id, Guid patientId, Guid providerId, Guid supplierId, IEvaluation evaluation, Availabilities availabilities)
        {
            Consultation consultation = new Consultation(id, patientId, providerId, supplierId, evaluation, availabilities);

            return consultation;
        } 
        #endregion

        #region References
        //References to aggregates by Id's
        public Guid Id { private set; get; }

        public Guid PatientId { private set; get; }

        public Guid ProviderId { private set; get; }

        public Guid SupplierId { private set; get; }


        //References to Entities 
        public IEvaluation Evaluation { private set; get; }

        public IReadOnlyCollection<IAvailability> Availabilities
        {
            get
            {
                IReadOnlyCollection<IAvailability> readOnly = _availabilities.GetAvailabilities();
                return readOnly;
            }
        }

        #endregion

        #region Behaviors
        //Behaviors
        public IEvaluation AddEvaluation()
        {
            throw new NotImplementedException();
        }

        public SpecificAvailability AddSpecificAvailability()
        {
            throw new NotImplementedException();
        }

        public TimeSpanAvailability AddTimeSpanAvailability()
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
