using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bliss.Domain.Patients
{
    public sealed class Addresses
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

        public void AddAddress(Address address)
        {
            if (DoesDuplicateAddressExist(address) == false)
                _addresses.Add(address);
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
    }
}
