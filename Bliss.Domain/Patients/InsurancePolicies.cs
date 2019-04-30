using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bliss.Domain.Patients
{
    
    public sealed class InsurancePolicies : ISubmitConsultationValidation

    {
        private readonly List<InsurancePolicy> _policies;

        public InsurancePolicies()
        {
            _policies = new List<InsurancePolicy>();
        }

        //Readonly enforces us to add the policies via the behavior methods below
        public IReadOnlyCollection<InsurancePolicy> GetInsurancePolicies()
        {
            IReadOnlyCollection<InsurancePolicy> policies = new ReadOnlyCollection<InsurancePolicy>(_policies);
            return policies;
        }

        public InsurancePolicy AddPolicy(Name companyName, PolicyNumber policyNumber, string street1, string street2, string city, State state, ZipCode zip)
        {
            Address address = new Address(street1, street2, city, state, zip);

            InsurancePolicy policy = new InsurancePolicy(companyName, policyNumber, address);

            InsurancePolicy existingPolicy = Find(policy);

            if (existingPolicy == null)
                _policies.Add(policy);
            else
                return existingPolicy;

            return policy;
        }

        public void DeletePolicy(Guid policyId)
        {
            InsurancePolicy existingPolicy = Find(policyId);

            if (existingPolicy != null)
                _policies.Remove(existingPolicy);
            
        }

        private bool DoesPolicyExist(InsurancePolicy policy)
        {
            foreach (InsurancePolicy policyInList in _policies)
            {
                if (policyInList.Equals(policy))
                    return true;
            }

            return false;
        }

        private InsurancePolicy Find(Guid policyId)
        {
            foreach (InsurancePolicy policyInList in _policies)
            {
                if (policyInList.Id == policyId)
                    return policyInList;
            }

            return null;
        }

        private InsurancePolicy Find(InsurancePolicy policy)
        {
            foreach (InsurancePolicy policyInList in _policies)
            {
                if (policyInList.Equals(policy))
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
