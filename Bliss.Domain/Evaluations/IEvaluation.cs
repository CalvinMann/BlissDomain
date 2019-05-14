using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations
{
    public interface IEvaluation
    {
       EvaluationType EvaluationType { get; }

        Date CreationDate { get; }

    }
}
