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
        public void CreatedEvaluationShouldHaveAnId()
        {

            OrthoticEvaluation orthoticEvaluation = new OrthoticEvaluation(EvaluationType.Orthotic);

            Assert.NotEqual(orthoticEvaluation.Id, Guid.Empty);
            Assert.Equal(EvaluationType.Orthotic, orthoticEvaluation.EvaluationType);
            Assert.Equal(EvaluationType.Orthotic, orthoticEvaluation.EvaluationType);
            Assert.NotNull(orthoticEvaluation.CreationDate);
            Assert.NotNull(orthoticEvaluation.LastUpdatedDate);
            Assert.Same(orthoticEvaluation.CreationDate, orthoticEvaluation.LastUpdatedDate);
        }
    }
}
