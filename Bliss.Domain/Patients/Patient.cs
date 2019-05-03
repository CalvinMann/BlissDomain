using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Bliss.Domain.Patients
{
    public sealed class Patient : IAggregateRoot, ISubmitConsultationValidation
    {

        #region Constructors

        private Patient() { }

        public Patient(Name firstName, Name lastName, SSN ssn)
        {

            //Init 
            Addresses = new Addresses();
            InsurancePolicies = new InsurancePolicies();

            //Assign
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            SSN = ssn;
        }

        #endregion

        #region Fields

        public Guid Id { get; private set; }
        public Name FirstName { get; private set; }
        public Name LastName { get; private set; }
        public SSN SSN { get; private set; }
        public Gender Gender { get; private set; }
        public Addresses Addresses { get; private set; }
        public InsurancePolicies InsurancePolicies { get; set; }

        #endregion

        #region Behaviors
        //Behaviors
        public Address AddAddress(string street1, string street2, string city, State state, ZipCode zip)
        {
           return Addresses.AddAddress(street1, street2, city, state, zip);
        }

        public InsurancePolicy AddInsurancePolicy(Name companyName, PolicyNumber policyNumber, string street1, string street2, string city, State state, ZipCode zip)
        {
            return InsurancePolicies.AddPolicy(companyName, policyNumber, street1, street2, city, state, zip); ;
        }

        public void AddGender(Gender gender)
        {
            this.Gender = gender;
        }

        public List<ValidationError> Validate()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            if(Id == null)
                validationErrors.Add(new ValidationError("'Id' is required", nameof(Id)));

            if (FirstName == null)
                validationErrors.Add(new ValidationError("'First Name' is required", nameof(FirstName)));

            if (LastName == null)
                validationErrors.Add(new ValidationError("'Last Name' is required", nameof(LastName)));

            if (SSN == null)
                validationErrors.Add(new ValidationError("'Social Security Number' is required", nameof(SSN)));

            if (Gender == null)
                validationErrors.Add(new ValidationError("'Gender' is required", nameof(Gender)));

            ISubmitConsultationValidation addressValidation = this.Addresses as ISubmitConsultationValidation;
            validationErrors.AddRange(addressValidation.Validate());

            ISubmitConsultationValidation insuranceValidation = this.InsurancePolicies as ISubmitConsultationValidation;
            validationErrors.AddRange(insuranceValidation.Validate());
           

            return validationErrors;
        }

        #endregion
    }
}
