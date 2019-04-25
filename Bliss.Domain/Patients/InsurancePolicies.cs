using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bliss.Domain.Patients
{
    
    public sealed class InsurancePolicies

    {
        private readonly IList<InsurancePolicy> _policies;

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

        public void AddPolicy(InsurancePolicy policy)
        {
            if (DoesDuplicatePoliciesExist(policy) == false)
                _policies.Add(policy);
        }

        public void DeletePolicy(InsurancePolicy policy)
        {
            throw new NotImplementedException();
        }

        private bool DoesDuplicatePoliciesExist(InsurancePolicy address)
        {
            foreach (InsurancePolicy addressInList in _policies)
            {
                if (addressInList.Equals(address))
                    return true;
            }

            return false;
        }
    }
}
