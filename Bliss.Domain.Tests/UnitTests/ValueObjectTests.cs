using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Bliss.Domain.Tests.UnitTests
{
    public class ValueObjectTests
    {
        [Fact]
        public void CreatedAddressShouldHave_CompanyName_PolicyNumber_Address()
        {

          
            Address address = new Address("111 street", "", "Las Vegas", "NV", 98002);

        
            //Test for nulls
            Assert.Equal(insurancePolicy.Address, address);
        }

        [Fact]
        public void CreatedInsurancePolicyShouldHave_CompanyName_PolicyNumber_Address()
        {

            string companyName = "Aetna";
            PolicyNumber policyNumber = new PolicyNumber("12W67N350112");
            Address address = new Address("111 street", "", "Las Vegas", "NV", 98002);

            InsurancePolicy insurancePolicy = new InsurancePolicy(companyName, policyNumber, address);


            Assert.Equal(insurancePolicy.CompanyName, companyName);
            Assert.Equal(insurancePolicy.PolicyNumber, policyNumber);
            Assert.Equal(insurancePolicy.Address, address);
        }
    }
}
