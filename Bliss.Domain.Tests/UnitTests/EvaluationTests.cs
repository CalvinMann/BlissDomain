using Bliss.Domain.Evaluations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Bliss.Domain.Tests.UnitTests
{
    public class EvaluationTests
    {
        [Fact]
        public void CreatedOrthoticEvaluationShouldHaveAnId()
        {

            OrthoticEvaluation orthoticEvaluation =  OrthoticEvaluation.New(EvaluationType.Orthotic);

            Assert.NotEqual(orthoticEvaluation.Id, Guid.Empty);
            Assert.Equal(EvaluationType.Orthotic, orthoticEvaluation.EvaluationType);
            Assert.Equal(EvaluationType.Orthotic, orthoticEvaluation.EvaluationType);
            Assert.NotNull(orthoticEvaluation.CreationDate);
        }

      
    }
}
