using Bliss.Domain.Consultations;
using Bliss.Domain.Patients;
using Bliss.Domain.ValueObjects;
using NodaTime;
using NodaTime.Extensions;
using NodaTime.Text;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Duration = Bliss.Domain.ValueObjects.Duration;

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
        public void Date_LoadedWithDateTime_shouldhave_day_month_year()
        {
            DateTime now = DateTime.Now;

            Date date = new Date(now);

            Assert.Equal(date.Day, now.Day);
            Assert.Equal(date.Month, now.Month);
            Assert.Equal(date.Year, now.Year);


        }

        [Fact]
        public void Date_shouldthrowerror_ifmonthgreaterthan12_OnValidate()
        {
            int month = 13; //error here
            int day = 12;
            int year = 2019;

            Exception ex = Assert.Throws<Exception>(() => new Date(day, month, year));

            Assert.Equal(ex.GetType(), typeof(Exception));

        }

        [Fact]
        public void Date_shouldthrowerror_ifmonthlessthan0_OnValidate()
        {
            int month = 0; //error here
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

            var validationErrors = new Date(day, month, year);
            Exception ex = Assert.Throws<Exception>(() => new Date(day, month, year));

            Assert.Equal(ex.GetType(), typeof(Exception));
        }

        [Fact]
        public void Date_shouldthrowerror_ifdaylessthan1()
        {
            int month = 10;
            int day = 0; //error here
            int year = 2019;

            var validationErrors = new Date(day, month, year);
            Exception ex = Assert.Throws<Exception>(() => new Date(day, month, year));

            Assert.Equal(ex.GetType(), typeof(Exception));
        }

        [Fact]
        public void Date_shouldthrowerror_ifyearlessthanFourDigits()
        {
            int month = 10;
            int day = 1; 
            int year = 19; //error here

            var validationErrors = new Date(day, month, year);
            Exception ex = Assert.Throws<Exception>(() => new Date(day, month, year));

            Assert.Equal(ex.GetType(), typeof(Exception));
        }


        [Fact]
        public void Availability_shouldhave_date_zone_timespanmapping()
        {
            int month = 4;
            int day = 12;
            int year = 2019;

            Date date = new Date(day, month, year);
            Zone zone = new Zone("America/Los_Angeles");
            Time startTime = new Time(9, 0, 0); //9am
            Duration duration = new Duration(0, 0, 0, 0, 1, 0, 0);

            Availability availability = new Availability(date, zone, startTime, duration);

            Assert.Equal(date, availability.Date);
            Assert.Equal(zone, availability.Zone);
            Assert.Equal(startTime, availability.StartTime);
            Assert.Equal(duration, availability.Duration);

            //var zone = DateTimeZoneProviders.Tzdb["Europe/London"];
            //var clock = SystemClock.Instance.InZone(zone);
            //var now = clock.GetCurrentZonedDateTime();
            //var pattern = ZonedDateTimePattern.ExtendedFormatOnlyIso;
            //Console.WriteLine(pattern.Format(now));

        }

        [Fact]
        public void Availability_shouldthrowErrorOnValidationWithMissingData()
        {
            int month = 4;
            int day = 12;
            int year = 2019;

            Date date = new Date(day, month, year);
            Zone zone = new Zone(""); //error here
            Time startTime = new Time(9, 0, 0); 
            Duration duration = new Duration(0, 0, 0, 0, 1, 0, 0);

            Availability availability = new Availability(date, zone, startTime, duration);

            Assert.Single(availability.Validate());

        }

    }
}
