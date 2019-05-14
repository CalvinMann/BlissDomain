using Bliss.Application.Consultations.Commands;
using Bliss.Domain.Consultations;
using Bliss.Domain.ValueObjects;
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

            Consultation consultation = Consultation.New();
            consultation.AssignPatient(patientId);


            Assert.NotEqual(consultation.Id, Guid.Empty);

            Assert.NotEqual(consultation.PatientId, Guid.Empty);
            Assert.Equal(consultation.PatientId, patientId);
        }

        [Fact]
        public void GivenANullPatientIdIsAssigned_ThenErrorShouldThrow()
        {
            Consultation consultation = Consultation.New();

            Exception ex = Assert.Throws<Exception>(() => consultation.AssignPatient(Guid.Empty));
               
             Assert.Equal("Patient Id is null", ex.Message);
        }

        [Fact]
        public void GivenAPatientIdIsAssigned_ConsultationShouldHaveValidReference()
        {

            Consultation consultation = Consultation.New();
            Guid patientId = Guid.NewGuid();

            consultation.AssignPatient(patientId);

            Assert.Equal(consultation.PatientId, patientId);
        }

        [Fact]
        public void CreateConsultationRequest_ThrowsErrorIfNullDTOs()
        {
           
            Exception ex = Assert.Throws<Exception>(() => new CreateConsultationRequest(null, null));

            Assert.Equal(ex.GetType(), typeof(Exception));
        }

        [Fact]
        public void AfterAddingAvailability_ConsultationAvailabilitiesShouldHaveCount()
        {

            Consultation consultation = Consultation.New();

            Date date = new Date(4, 12, 1987);
            Zone zone = new Zone("America/Los_Angeles");
            Time startTime = new Time(9, 0, 0); //9am
            Duration duration = new Duration(0, 0, 0, 0, 1, 0, 0);

            consultation.AddAvailability(date, zone, startTime, duration);

            Assert.Equal(1, consultation.Availabilities.Count);

        }

        [Fact]
        public void AfterAddingSameAvailability_ConsultationAvailabilitiesShouldNotAddAvailability()
        {

            Consultation consultation = Consultation.New();

            Date date = new Date(4, 12, 1987);
            Zone zone = new Zone("America/Los_Angeles");
            Time startTime = new Time(9, 0, 0); //9am
            Duration duration = new Duration(0, 0, 0, 0, 1, 0, 0);

            consultation.AddAvailability(date, zone, startTime, duration);
            consultation.AddAvailability(date, zone, startTime, duration);


            Assert.Equal(1, consultation.Availabilities.Count);

        }

      
    }
}
