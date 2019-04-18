using Bliss.Application.Consultations.Commands;
using Bliss.Domain.Consultations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Bliss.Domain.Tests.UnitTests.Intake
{
    public class ConsultationTests
    {
        [Fact]
        public void NewConsultation_ShouldHave_Id()
        {
            Guid patientId = Guid.NewGuid();

            Consultation consultation = new Consultation();
            consultation.AssignPatient(patientId);


            Assert.NotEqual(consultation.Id, Guid.Empty);

            Assert.NotEqual(consultation.PatientId, Guid.Empty);
            Assert.Equal(consultation.PatientId, patientId);
        }

        [Fact]
        public void GivenANullPatientIdIsAssigned_ThenErrorShouldThrow()
        {
            Consultation consultation = new Consultation();

            Exception ex = Assert.Throws<Exception>(() => consultation.AssignPatient(Guid.Empty));
               
             Assert.Equal("Patient Id is null", ex.Message);
        }

        [Fact]
        public void GivenAPatientIdIsAssigned_ConsultationShouldHaveValidReference()
        {
      
            Consultation consultation = new Consultation();
            Guid patientId = Guid.NewGuid();

            consultation.AssignPatient(patientId);

            Assert.Equal(consultation.PatientId, patientId);
        }

        [Fact]
        public void CreateConsultationRequest_ThrowsErrorIfNullDTOs()
        {
           
            Exception ex = Assert.Throws<Exception>(() => new CreateConsultationRequest(null, null, null));

            Assert.Equal(ex.GetType(), typeof(Exception));
        }
    }
}
