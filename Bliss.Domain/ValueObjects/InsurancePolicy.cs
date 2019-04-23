using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public sealed class InsurancePolicy : ValueObject
    {

        #region Constructors

        public InsurancePolicy(string companyName, PolicyNumber policyNumber, Address address)
        {
            throw new NotImplementedException(); //Test validations

            //assigned
            this.CompanyName = companyName;
            this.PolicyNumber = policyNumber;
            this.Address = address;
        }
        #endregion

        #region Fields

        public string CompanyName { get; private set; }
        public PolicyNumber PolicyNumber { get; private set; }
        public Address Address { get; set; }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CompanyName;
            yield return PolicyNumber;
            yield return Address;
        }

        #endregion
    }
}
