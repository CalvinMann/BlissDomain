﻿using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Medication
{
    public interface IMedication
    {
        string Name { get; }

        string ManufacturingCompany { get; }

        MedicationType MedicationType { get; }

        Date ExpirationDate { get; }

        Dosage Dosage { get; }

        DosageFrequency DosageFrequency { get; }
    }
}
