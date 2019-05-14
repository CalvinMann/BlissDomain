using Bliss.Domain.Core;
using Bliss.Domain.Evaluations.Components.Surgeries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public class Surgery : ValueObject, ISurgery
    {
        public Surgery(Date dateOfSurgery, SurgeryType surgeryType, string description)
        {
            DateOfSurgery = dateOfSurgery;
            SurgeryType = surgeryType;
            Description = description;
        }

        public Date DateOfSurgery { get; private set; }

        public SurgeryType SurgeryType { get; private set; }

        public string Description { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DateOfSurgery;
            yield return SurgeryType;
            yield return Description;
        }
    }

    public enum SurgeryType
    {

    }
}
