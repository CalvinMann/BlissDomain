using Bliss.Domain.Evaluations.Components.Symptom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Complaint
{
    public interface IComplaint
    {
       IReadOnlyCollection<ISymptom> Symptoms { get; }

        string ChiefComplaint { get;  }
    }
}
