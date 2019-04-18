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

        public Patient(Name firstName, Name lastName, SSN ssn, Gender gender)
        {

            //Init 
            Addresses = new Addresses();

            //Assign
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            SSN = ssn;
            Gender = gender;
        }

        #endregion

        #region Fields

        public Guid Id { get; private set; }
        public Name FirstName { get; private set; }
        public Name LastName { get; private set; }
        public SSN SSN { get; private set; }
        public Gender Gender { get; private set; }
        public Addresses Addresses { get; private set; }

        #endregion

        #region Behaviors
        //Behaviors
        public Address AddAddress(string street1, string street2, string city, string state, int zip)
        {

            Address address = new Address(street1, street2, city, state, zip);

            Addresses.AddAddress(address);

            return address;

        }

        #endregion
    }
}
