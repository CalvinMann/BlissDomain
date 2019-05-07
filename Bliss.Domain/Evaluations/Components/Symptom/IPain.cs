using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Symptom
{
    public interface IPain : ISymptom
    {
        PainLevel PainLevel { get; }

        Frequency Frequency { get; }
    }
}
