using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Symptom
{
    public interface ISymptom
    {
        string Description { set; get; }

        string Location { set; get; }
    }
}
