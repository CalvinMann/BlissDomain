using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public sealed class Address : ValueObject, ISubmitConsultationValidation
    {
        public string Street1 { get; }
        public string Street2 { get; }
        public string City { get; }
        public State State { get; }
        public ZipCode ZipCode { get; }

        public Address(string street1, string street2, string city, State state, ZipCode zipCode)
        {
          
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

        public List<ValidationError> Validate()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            if (string.IsNullOrEmpty(Street1))
                validationErrors.Add( new ValidationError("Stree1 cannot be null", nameof(Street1)));

            if (string.IsNullOrEmpty(City))
                validationErrors.Add(new ValidationError("City cannot be null", nameof(Street1)));

            return validationErrors;
        }
    }
}
