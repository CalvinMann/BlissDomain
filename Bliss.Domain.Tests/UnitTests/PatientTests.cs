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


            Patient patient = new Patient(firstName, lastName, ssn);
            Address address = new Address("111 street", "", "Las Vegas", "NV", "98002");

            patient.AddAddress(address);

            Assert.Equal(1, patient.Addresses.Count);

            //Assert.Equal(street1, address.Street1);
            //Assert.Equal(street2, address.Street2);
            //Assert.Equal(city, address.City);
            //Assert.Equal(state, address.State);
            //Assert.Equal(zip, address.ZipCode);
        }


        [Fact]
        public void AfterAddingInsurancePolicy_ThePoliciesCOllectionShouldBeOne()
        {
            string firstName = "Calvin";
            string lastName = "Mann";
            string ssn = "539-04-0830";


            string companyName = "Aetna";
            string policyNumber ="12W67N350112";


            Patient patient = new Patient(firstName, lastName, ssn);
            Address address = new Address("111 street", "", "Las Vegas", "NV", "98002");

            patient.AddInsurancePolicy(companyName, policyNumber, address);

            Assert.Equal(1, patient.InsurancePolicies.Count);

        }

        [Fact]
        public void AfterAddingDuplicateInsurancePolicy_ThePoliciesCOllectionShouldBeOne()
        {
            string firstName = "Calvin";
            string lastName = "Mann";
            string ssn = "539-04-0830";


            string companyName = "Aetna";
            string policyNumber = "12W67N350112";


            Patient patient = new Patient(firstName, lastName, ssn);
            Address address = new Address("111 street", "", "Las Vegas", "NV", "98002");

            patient.AddInsurancePolicy(companyName, policyNumber, address);
            patient.AddInsurancePolicy(companyName, policyNumber, address);

            Assert.Equal(1, patient.InsurancePolicies.Count);

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

        [Fact]
        public void GivenPatientInsuranceIsIncomplete_ValidationShouldReturnValidationError()
        {
            string companyName = "Aetna";
            string policyNumber = ""; //error here

            Address address = new Address("111 street", "", "Las Vegas", "NV", "98002");
            
            InsurancePolicy insurancePolicy = new InsurancePolicy(companyName, policyNumber, address);

            Assert.Single(insurancePolicy.Validate());

        }
    }
}
