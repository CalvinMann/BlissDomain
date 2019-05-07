using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public class Dosage : ValueObject
    {
        public Dosage(int quantity, UnitsNet.Units.VolumeUnit volumnUnit )
        {
            Quantity = quantity;
            VolumnUnit = volumnUnit;
        }

        public int Quantity { get; private set; }

        public UnitsNet.Units.VolumeUnit VolumnUnit { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Quantity;
            yield return VolumnUnit;
        }
    }
}
