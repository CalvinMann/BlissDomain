using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    //I think this needs to be an entity vs a value object 
    public sealed class Availability : ValueObject, IAvailability
    {
        public Availability()
        {
           
        }

        public DateTime Day => throw new NotImplementedException();

        public TimeSpan TimeSpan => throw new NotImplementedException();

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Day;
        }
    }
}
