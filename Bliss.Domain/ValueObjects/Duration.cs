using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{


    public sealed class Duration : ValueObject
    {
        public int Years { get; }
        public int Months { get; }
        public int Weeks { get; }
        public int Days { get; }
        public int Hour { get; }
        public int Min { get; }
        public int Sec { get; }

        public Duration(int years, int months, int weeks, int days, int hours, int mins, int seconds)
        {
            Years = years;
            Months = months;
            Weeks = weeks;
            Days = days;
            Hour = hours;
            Min = mins;
            Sec = seconds;
        }

        //these are the fields we use to test equality
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Hour;
            yield return Min;
            yield return Sec;
        }
    }
}
