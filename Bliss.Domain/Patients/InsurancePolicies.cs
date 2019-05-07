using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bliss.Domain.Patients
{

    internal sealed class InsurancePolicies : ISubmitConsultationValidation

    {
        private readonly List<IInsurancePolicy> _policies;

        public InsurancePolicies()
        {
            _policies = new List<IInsurancePolicy>();
        }

        //Readonly enforces us to add the policies via the behavior methods below
        public IReadOnlyCollection<IInsurancePolicy> GetInsurancePolicies()
        {
            IReadOnlyCollection<IInsurancePolicy> policies = new ReadOnlyCollection<IInsurancePolicy>(_policies);
            return policies;
        }

        public void AddPolicy(Name companyName, PolicyNumber policyNumber, Address address)
        { 
            IInsurancePolicy existingPolicy = Find(companyName, policyNumber);

            if (existingPolicy == null)
                _policies.Add( new InsurancePolicy(companyName, policyNumber, address));

        }

        public void DeletePolicy(Guid policyId)
        {
            IInsurancePolicy existingPolicy = Find(policyId);

            if (existingPolicy != null)
                _policies.Remove(existingPolicy);
            
        }


        private IInsurancePolicy Find(Guid policyId)
        {
            foreach (IEntity policyInList in _policies)
            {
                if (policyInList.Id == policyId)
                    return policyInList as IInsurancePolicy;
            }

            return null;
        }

        private IInsurancePolicy Find(Name companyName, PolicyNumber policyNumber)
        {
            foreach (IInsurancePolicy policyInList in _policies)
            {
                if (policyInList.CompanyName.Equals(companyName) && policyInList.PolicyNumber.Equals(policyInList))
                    return policyInList;
            }

            return null;
        }

        public List<ValidationError> Validate()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            //Check if a policy number has special traits (ex: lenght, certain # of characters)
            if (_policies.Count == 0)
            {
                validationErrors.Add(new ValidationError("'InsurancePolicy' is required", nameof(_policies)));
                return validationErrors;
            }

            //Check validity of each policy
            foreach(ISubmitConsultationValidation policyValidation in _policies)
                validationErrors.AddRange(policyValidation.Validate());

            return validationErrors;
        }
    }
}
