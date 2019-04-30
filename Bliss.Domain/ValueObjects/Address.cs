using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public sealed class Address : ValueObject
    {
        public string Street1 { get; }
        public string Street2 { get; }
        public string City { get; }
        public State State { get; }
        public ZipCode ZipCode { get; }

        public Address(string street1, string street2, string city, State state, ZipCode zipCode)
        {
            if (string.IsNullOrEmpty(street1))
                throw new Exception("Stree1 cannot be null");

            if (string.IsNullOrEmpty(city))
                throw new Exception("City cannot be null");

            Street1 = street1;
            Street2 = street2;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        //these are the fields we use to test equality
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street1;
            yield return Street2;
            yield return City;
            yield return State;
            yield return ZipCode;
        }

       
    }
}
