using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bliss.Domain.Patients
{
    public sealed class Addresses : ISubmitConsultationValidation
    {
        private readonly IList<Address> _addresses;

        public Addresses()
        {
            _addresses = new List<Address>();
        }

        //Readonly enforces us to add the addresses via the behavior methods below
        public IReadOnlyCollection<Address> GetAddresses()
        {
            IReadOnlyCollection<Address> addresses = new ReadOnlyCollection<Address>(_addresses);
            return addresses;
        }

        public Address AddAddress(string street1, string street2, string city, State state, ZipCode zip)
        {
            Address address = new Address(street1, street2, city, state, zip);

            if (DoesDuplicateAddressExist(address) == false)
                _addresses.Add(address);

            return address;
        }

        public void DeleteAddress(Address address)
        {
            throw new NotImplementedException();
        }

        private bool DoesDuplicateAddressExist(Address address)
        {
            foreach(Address addressInList in _addresses)
            {
                if (addressInList.Equals(address))
                    return true;
            }

            return false;
        }

        public List<ValidationError> Validate()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            //Check if a policy number has special traits (ex: lenght, certain # of characters)
            if (_addresses.Count == 0)
            {
                validationErrors.Add(new ValidationError("'InsurancePolicy' is required", nameof(_addresses)));
                return validationErrors;
            }

            //Check validity of each policy
            foreach (ISubmitConsultationValidation addressValidation in _addresses)
                validationErrors.AddRange(addressValidation.Validate());

            return validationErrors;
        }
    }
}
