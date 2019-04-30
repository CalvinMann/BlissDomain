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

            Patient patient = new Patient(firstName, lastName, ssn);

            Assert.NotEqual(patient.Id, Guid.Empty);
        }

        [Fact]
        public void CreatedPatientsShouldHave_FirstAndLastName_SSN_Gender()
        {

            string firstName = "Calvin";
            string lastName = "Mann";
            string ssn = "539-04-0830";

            Patient patient = new Patient(firstName, lastName, ssn);

            Assert.NotEqual(patient.Id, Guid.Empty);

            Assert.Equal(patient.FirstName, firstName);
            Assert.Equal(patient.LastName, lastName);
            Assert.Equal(patient.SSN, ssn);
        }

        [Fact]
        public void AfterAddingAnAddressTheInformationShouldBeTheSame()
        {
            string firstName = "Calvin";
            string lastName = "Mann";
            string ssn = "539-04-0830";

            string street1 = "Street1";
            string street2 = "Street2";
            string city = "Las Vegas";
            string state = "NV";
            string zip = "89145";

            Patient patient = new Patient(firstName, lastName, ssn);

            Address address = patient.AddAddress(street1, street2, city, state, zip);

            Assert.Equal(1, patient.Addresses.GetAddresses().Count);

            Assert.Equal(street1, address.Street1);
            Assert.Equal(street2, address.Street2);
            Assert.Equal(city, address.City);
            Assert.Equal(state, address.State);
            Assert.Equal(zip, address.ZipCode);
        }

        [Fact]
        public void AfterAddingInsurancePolicyTheInformationShouldBeTheSame()
        {
            string firstName = "Calvin";
            string lastName = "Mann";
            string ssn = "539-04-0830";


            string companyName = "Aetna";
            string policyNumber ="12W67N350112";
            string street1 = "Street1";
            string street2 = "Street2";
            string city = "Las Vegas";
            string state = "NV";
            string zip = "89145";

            Patient patient = new Patient(firstName, lastName, ssn);

            InsurancePolicy insurancePolicy = patient.AddInsurancePolicy(companyName, policyNumber, street1, street2, city, state, zip);

            Assert.Equal(1, patient.InsurancePolicies.GetInsurancePolicies().Count);

            Assert.Equal(companyName, insurancePolicy.CompanyName);
            Assert.Equal(policyNumber, insurancePolicy.PolicyNumber);
            Assert.Equal(street1, insurancePolicy.Address.Street1);
            Assert.Equal(street2, insurancePolicy.Address.Street2);
            Assert.Equal(city, insurancePolicy.Address.City);
            Assert.Equal(state, insurancePolicy.Address.State);
            Assert.Equal(zip, insurancePolicy.Address.ZipCode);
        }


        [Fact]
        public void CreatedInsurancePolicyShouldHave_CompanyName_PolicyNumber_Address_Id()
        {

            string companyName = "Aetna";
            PolicyNumber policyNumber = new PolicyNumber("12W67N350112");
            Address address = new Address("111 street", "", "Las Vegas", "NV", "98002");

            InsurancePolicy insurancePolicy = new InsurancePolicy(companyName, policyNumber, address);

            Assert.NotEqual(insurancePolicy.Id, Guid.Empty);

            Assert.Equal(insurancePolicy.CompanyName, companyName);
            Assert.Equal(insurancePolicy.PolicyNumber, policyNumber);
            Assert.Equal(insurancePolicy.Address, address);
        }
    }
}
