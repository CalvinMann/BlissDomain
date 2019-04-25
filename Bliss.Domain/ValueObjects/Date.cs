using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public sealed class Date : ValueObject
    {
        public int Day { get; }
        public int Month { get; }
        public int Year { get; }


        public Date(int day, int month, int year)
        {
            if (day > 31)
                throw new Exception("Day cannot be greater than 31");

            if (month > 12)
                throw new Exception("Day cannot be greater than 12");

            Day = day;
            Month = month;
            Year = year;
        }

        //these are the fields we use to test equality
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Day;
            yield return Month;
            yield return Year;
        }
    }
}
