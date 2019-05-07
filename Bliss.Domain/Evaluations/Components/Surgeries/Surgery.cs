using Bliss.Domain.Core;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Surgeries
{
    public class Surgery : IEntity
    {

        public Surgery(Date dateOfSurgery, SurgeryType surgeryType)
        {
            Id = Guid.NewGuid();
            DateOfSurgery = dateOfSurgery;
            SurgeryType = surgeryType;
        }

        public Guid Id { get; private set; }

        public Date DateOfSurgery { get; private set; }

        public SurgeryType SurgeryType { get; private set; }

        public string Description { get; set; }


    }
}
