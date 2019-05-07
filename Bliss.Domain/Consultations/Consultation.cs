using Bliss.Domain.Core;
using Bliss.Domain.Evaluations;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Consultations
{
    public sealed class Consultation : IAggregateRoot, ISubmitConsultationValidation
    {

        private Availabilities _availabilities;

        #region Constructors
        public Consultation()
        {
            //init
            Id = Guid.NewGuid();
            _availabilities = new Availabilities();

        }


        private Consultation(Guid id, Guid patientId, Guid clincianGroupId, Guid supplierId, IEvaluation evaluation, Availabilities availabilities)
        {
            //assign
            Id = id;
            PatientId = patientId;
            ClinicianGroupId = clincianGroupId;
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

        public Guid ClinicianGroupId { private set; get; }

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
        public void AssignPatient(Guid patientId)
        {
            if (patientId == null || patientId == Guid.Empty)
                throw new Exception("Patient Id is null");

            PatientId = patientId;
        }

        public void AddAvailability(Date date, Zone zone, Time startTime, Duration duration)
        {
            _availabilities.AddAvailability(date, zone, startTime, duration);
        }

        public void AssignSupplier(Guid supplierId)
        {
            if (supplierId == null || supplierId == Guid.Empty)
                throw new Exception("Supplier Id is null");

            SupplierId = supplierId;
        }

        public void AssignClinicianGroup(Guid clinicianGroupId)
        {
            if (clinicianGroupId == null || clinicianGroupId == Guid.Empty)
                throw new Exception("ClinicianGroup Id is null");

            ClinicianGroupId = clinicianGroupId;
        }

        public IEvaluation AddEvaluation()
        {
            throw new NotImplementedException();
        }

        public List<ValidationError> Validate()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            if (Id == null)
                validationErrors.Add(new ValidationError("'Id' is required", nameof(Id)));

            if (PatientId == null)
                validationErrors.Add(new ValidationError("'PatientId' is required", nameof(PatientId)));

            if (ClinicianGroupId == null)
                validationErrors.Add(new ValidationError("'ClinicianGroupId' is required", nameof(ClinicianGroupId)));

            if (SupplierId == null)
                validationErrors.Add(new ValidationError("'SupplierId' is required", nameof(SupplierId)));

            return validationErrors;
        }

        #endregion
    }
}
