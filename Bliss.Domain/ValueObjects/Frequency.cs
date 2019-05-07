using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public class Frequency : ValueObject
    {
        public Frequency(int quantity, UnitsNet.Units.DurationUnit duration)
        {
            Quantity = quantity;
            Duration = duration;
        }

        public int Quantity { get; }

        public UnitsNet.Units.DurationUnit Duration { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Quantity;

            yield return Duration;
        }
    }
}
