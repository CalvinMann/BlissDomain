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
        private Addresses _addresses;
        private InsurancePolicies _insurancePolicies;

        #region Constructors

        private Patient() { }

        public Patient(Name firstName, Name lastName, SSN ssn)
        {

            //Init 
            _addresses = new Addresses();
            _insurancePolicies = new InsurancePolicies();

            //Assign
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            SSN = ssn;
        }

        #endregion

        #region References

        public Guid Id { get; private set; }
        public Name FirstName { get; private set; }
        public Name LastName { get; private set; }
        public SSN SSN { get; private set; }
        public Gender Gender { get; private set; }

        public IReadOnlyCollection<Address> Addresses
        {
            get
            {
                IReadOnlyCollection<Address> readOnly = _addresses.GetAddresses();
                return readOnly;
            }
        }

        public IReadOnlyCollection<IInsurancePolicy> InsurancePolicies
        {
            get
            {
                IReadOnlyCollection<IInsurancePolicy> readOnly = _insurancePolicies.GetInsurancePolicies();
                return readOnly;
            }
        }

        #endregion

        #region Behaviors
        //Behaviors
        public void AddAddress(Address address)
        {
            _addresses.AddAddress(address);
        }

        public void AddInsurancePolicy(Name companyName, PolicyNumber policyNumber, Address address)
        {
             _insurancePolicies.AddPolicy(companyName, policyNumber, address); 
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

            ISubmitConsultationValidation addressValidation = this._addresses as ISubmitConsultationValidation;
            validationErrors.AddRange(addressValidation.Validate());

            ISubmitConsultationValidation insuranceValidation = this._insurancePolicies as ISubmitConsultationValidation;
            validationErrors.AddRange(insuranceValidation.Validate());
           

            return validationErrors;
        }

        #endregion
    }
}
