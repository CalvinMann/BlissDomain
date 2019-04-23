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
        public string State { get; }
        public int ZipCode { get; }

        public Address(string street1, string street2, string city, string state, int zipCode)
        {
            throw new NotImplementedException(); //Test validations
            //Run validation checks here
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
            yield return City;
            yield return State;
            yield return ZipCode;
        }
    }
}
