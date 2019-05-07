using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public sealed class Date : ValueObject, ISubmitConsultationValidation
    {
        public int Day { get; }
        public int Month { get; }
        public int Year { get; }

        public Date(DateTime dateTime)
        {
            Day = dateTime.Day;
            Month = dateTime.Month;
            Year = dateTime.Year;
        }

        public Date(int day, int month, int year)
        {
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

        public List<ValidationError> Validate()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            if (Day < 1)
                validationErrors.Add(new ValidationError("Day cannot be less than 1", nameof(Day)));

            if (Day > 31)
                validationErrors.Add(new ValidationError("Day cannot be greater than 31", nameof(Day)));


            if (Month < 1)
                validationErrors.Add(new ValidationError("Day cannot be less than 1", nameof(Month)));

            if (Month > 12)
                validationErrors.Add(new ValidationError("Day cannot be greater than 12", nameof(Month)));

            if (Year.ToString().Length != 4)
                validationErrors.Add(new ValidationError("Year must be four digits", nameof(Year)));

            return validationErrors;
        }
    }
}
