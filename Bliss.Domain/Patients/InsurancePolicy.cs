using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Patients
{
    public class InsurancePolicy : IEntity, IInsurancePolicy, ISubmitConsultationValidation
    {
        #region Constructors

        public InsurancePolicy(Name companyName, PolicyNumber policyNumber, Address address)
        {
            //init 
            this.Id = Guid.NewGuid();

            //assign
            this.CompanyName = companyName;
            this.PolicyNumber = policyNumber;
            this.Address = address;
        }
        #endregion

        #region Fields

        public Guid Id { get; private set; }
        public Name CompanyName { get; private set; }
        public PolicyNumber PolicyNumber { get; private set; }
        public Address Address { get; private set; }


        public List<ValidationError> Validate()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            if (string.IsNullOrWhiteSpace(CompanyName))
                validationErrors.Add(new ValidationError("'CompanyName' field is required", nameof(CompanyName)));
            else
                validationErrors.AddRange(CompanyName.Validate());

            if (string.IsNullOrWhiteSpace(PolicyNumber))
                validationErrors.Add(new ValidationError("'PolicyNumber' field is required", nameof(PolicyNumber)));
            else
                validationErrors.AddRange(PolicyNumber.Validate());

            if (Address == null)
                validationErrors.Add(new ValidationError("'Address' field is required", nameof(Address)));
            else
                validationErrors.AddRange(Address.Validate());

            return validationErrors;
        }

        #endregion
    }
}
