using System;
using System.Collections.Generic;
using System.Text;
using Bliss.Domain.Core;
using Bliss.Domain.Evaluations.Components.Medications;
using Bliss.Domain.ValueObjects;

namespace Bliss.Domain.ValueObjects
{
    public class Medication : ValueObject, IMedication
    {
        public Medication(string name, MedicationType medicationType, string manufacturingCompany,
            Date expirationDate, Dosage dosage, Frequency dosageFrequency)
        {
            //assign
            Name = name;
            MedicationType = medicationType;
            ManufacturingCompany = manufacturingCompany;
            ExpirationDate = expirationDate;
            Dosage = dosage;
            DosageFrequency = dosageFrequency;
        }

        public string Name { get; private set; }

        public string ManufacturingCompany { get;  set; }

        public MedicationType MedicationType { get; set; }

        public Date ExpirationDate { get;  set; }

        public Dosage Dosage { get;  set; }

        public Frequency DosageFrequency { get;  set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return ManufacturingCompany;
            yield return MedicationType;
            yield return ExpirationDate;
            yield return Dosage;
            yield return DosageFrequency;
        }
    }

   
}
