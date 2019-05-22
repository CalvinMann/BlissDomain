using Bliss.Domain.Evaluations;
using Bliss.Domain.Evaluations.Components.Medications;
using Bliss.Domain.Evaluations.Components.Treatments;
using Bliss.Domain.ValueObjects;
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


        [Fact]
        public void Medicine_shouldhave_Id_Medication_andTreatmentType()
        {
            Medication medication = new Medication("Tylenol", MedicationType.OverTheCounter, "Tylenol", null, null, null);

            Medicine medicine = new Medicine(medication);

            Assert.Equal(medicine.TreatmentType, TreatmentType.Medicine);
            Assert.NotEqual(medicine.Id, Guid.Empty);
            Assert.Equal(medicine.Medication, medication);
        }

    }
}
