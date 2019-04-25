using Bliss.Domain.Core;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Patients
{
    public class InsurancePolicy : IEntity
    {
        #region Constructors

        public InsurancePolicy(Name companyName, PolicyNumber policyNumber, Address address)
        {
            //init 
            this.Id = Guid.NewGuid();
            //assigned
            this.CompanyName = companyName;
            this.PolicyNumber = policyNumber;
            this.Address = address;
        }
        #endregion

        #region Fields

        public Guid Id { get; private set; }
        public Name CompanyName { get; private set; }
        public PolicyNumber PolicyNumber { get; private set; }
        public Address Address { get; set; }

        #endregion
    }
}
