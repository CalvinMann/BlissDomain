using Bliss.Domain.Core;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Patients
{
    public sealed class Patient : IAggregateRoot
    {

        #region Constructors

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

            Address address = new Address(street1, street2, city, state, zip);

            Addresses.AddAddress(address);

            return address;

        }

        public InsurancePolicy AddInsurancePolicy(Name companyName, PolicyNumber policyNumber, string street1, string street2, string city, State state, ZipCode zip)
        {
            Address address = new Address(street1, street2, city, state, zip);

            InsurancePolicy insurancePolicy = new InsurancePolicy(companyName, policyNumber, address);

            InsurancePolicies.AddPolicy(insurancePolicy);

            return insurancePolicy;
        }

        public void AddGender(Gender gender)
        {
            this.Gender = gender;
        }

        #endregion
    }
}
