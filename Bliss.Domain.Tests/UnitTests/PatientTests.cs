using Bliss.Domain.Patients;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Bliss.Domain.Tests.UnitTests
{
    public class PatientTests
    {
        [Fact]
        public void CreatedPatientsShouldHaveAnId()
        {
            string firstName = "Calvin";
            string lastName = "Mann";
            string ssn = "539-04-0830";
            string gender = "Male";

            Patient patient = new Patient(firstName, lastName, ssn, gender);

            Assert.NotEqual(patient.Id, Guid.Empty);
        }

        [Fact]
        public void CreatedPatientsShouldHave_FirstAndLastName_SSN_Gender()
        {

            string firstName = "Calvin";
            string lastName = "Mann";
            string ssn = "539-04-0830";
            string gender = "Male";

            Patient patient = new Patient(firstName, lastName, ssn, gender);

            Assert.NotEqual(patient.Id, Guid.Empty);

            Assert.Equal(patient.FirstName, firstName);
            Assert.Equal(patient.LastName, lastName);
            Assert.Equal(patient.SSN, ssn);
            Assert.Equal(patient.Gender, gender);
        }

        [Fact]
        public void AfterAddingAnAddressTheInformationShouldBeTheSame()
        {
            string firstName = "Calvin";
            string lastName = "Mann";
            string ssn = "539-04-0830";
            string gender = "Male";

            string street1 = "Street1";
            string street2 = "Street2";
            string city = "Las Vegas";
            string state = "NV";
            int zip = 89145;

            Patient patient = new Patient(firstName, lastName, ssn, gender);

            Address address = patient.AddAddress(street1, street2, city, state, zip);

            Assert.Equal(1, patient.Addresses.GetAddresses().Count);

            Assert.Equal(street1, address.Street1);
            Assert.Equal(street2, address.Street2);
            Assert.Equal(city, address.City);
            Assert.Equal(state, address.State);
            Assert.Equal(zip, address.ZipCode);
        }
    }
}
