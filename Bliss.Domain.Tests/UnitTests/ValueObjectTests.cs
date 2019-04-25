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
        [Fact]
        public void CreatedAddressShouldHave_CompanyName_PolicyNumber_Address()
        {
            string street1 = "Street1";
            string street2 = "Street2";
            string city = "Las Vegas";
            string state = "NV";
            string zip = "89145";

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
        public void Date_shouldthrowerror_ifmonthgreaterthan12()
        {
            int month = 13; //error here
            int day = 12;
            int year = 2019;

            Exception ex = Assert.Throws<Exception>(() => new Date(day, month, year));

            Assert.Equal(ex.GetType(), typeof(Exception));
        }

        [Fact]
        public void Date_shouldthrowerror_ifdaygreaterthan31()
        {
            int month = 10;
            int day = 32; //error here
            int year = 2019;

            Exception ex = Assert.Throws<Exception>(() => new Date(day, month, year));

            Assert.Equal(ex.GetType(), typeof(Exception));
        }

        [Fact]
        public void Availability_shouldhave_date_zone_timespan()
        {
            int month = 4;
            int day = 12;
            int year = 2019;

            Date date = new Date(day, month, year);
            Zone zone = new Zone("America/Los_Angeles");
            TimeSpan 

            Availability availability = new Availability(date, zone, );

            Assert.Equal(date.Day, day);
            Assert.Equal(date.Month, month);
            Assert.Equal(date.Year, year);


        }

    }
}
