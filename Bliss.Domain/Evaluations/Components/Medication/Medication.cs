using System;
using System.Collections.Generic;
using System.Text;
using Bliss.Domain.Core;
using Bliss.Domain.ValueObjects;

namespace Bliss.Domain.Evaluations.Components.Medication
{
    public class Medication : IEntity, IMedication
    {
        public Medication(string name, MedicationType medicationType)
        {
            //init
            Id = Guid.NewGuid();

            //assign
            Name = name;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string ManufacturingCompany { get;  set; }

        public MedicationType MedicationType { get; set; }

        public Date ExpirationDate { get;  set; }

        public Dosage Dosage { get;  set; }

        public Frequency DosageFrequency { get;  set; }
    }
}
