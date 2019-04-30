using Bliss.Domain.Patients;
using Bliss.Domain.ValueObjects;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Bliss.Domain.Tests.UnitTests
{
    public class ValueObjectTests
    {
        [Theory]
        [InlineData("Street1", "Street2", "Las Vegas", "NV", "89145")]
        [InlineData("", "", "", "", "")]
        public void CreatedAddressShouldHave_CompanyName_PolicyNumber_Address(
            string street1, string street2, string city, string state, string zip)
        {


            Address address = new Address(street1, street2, city, state, zip);


            //Test for nulls
            Assert.Equal(address.Street1, street1);
            Assert.Equal(address.Street2, street2);
            Assert.Equal(address.City, city);
            Assert.Equal(address.State, state);
            Assert.Equal(address.ZipCode, zip);
        }



        [Fact]
        public void Date_shouldhave_day_month_year()
        {
            int month = 4;
            int day = 12;
            int year = 2019;

            Date date = new Date(day, month, year);

            Assert.Equal(date.Day, day);
            Assert.Equal(date.Month, month);
            Assert.Equal(date.Year, year);


        }

        [Fact]
        public void Date_shouldthrowerror_ifmonthgreaterthan12_OnValidate()
        {
            int month = 13; //error here
            int day = 12;
            int year = 2019;

            var validationErrors = new Date(day, month, year).Validate();

            Assert.Single( validationErrors);
        }

        [Fact]
        public void Date_shouldthrowerror_ifdaygreaterthan31()
        {
            int month = 10;
            int day = 32; //error here
            int year = 2019;

            var validationErrors = new Date(day, month, year).Validate();

            Assert.Single(validationErrors);
            Assert.Equal("Day cannot be greater than 31", validationErrors[0].ErrorMessage);
        }

        [Fact]
        public void Availability_shouldhave_date_zone_timespan()
        {
            //int month = 4;
            //int day = 12;
            //int year = 2019;

            //Date date = new Date(day, month, year);
            //Zone zone = new Zone("America/Los_Angeles");
            
            //LocalTime startTime = new LocalTime(10,)

            //Availability availability = new Availability(date, zone, );

            //Assert.Equal(date.Day, day);
            //Assert.Equal(date.Month, month);
            //Assert.Equal(date.Year, year);


        }

    }
}
