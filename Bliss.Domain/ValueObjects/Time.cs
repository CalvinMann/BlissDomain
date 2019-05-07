using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public sealed class Time : ValueObject, ISubmitConsultationValidation
    {
        public int Hour { get; }
        public int Minute { get; }
        public int Second { get; }

        public Time(int hour, int min, int second)
        {

            Hour = hour;
            Minute = min;
            Second = second;
        }

        //these are the fields we use to test equality
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Hour;
            yield return Minute;
            yield return Second;
        }

        public List<ValidationError> Validate()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            if (Hour < 0)
                validationErrors.Add(new ValidationError("Hour cannot be less than 0", nameof(Hour)));

            if (Hour > 23)
                validationErrors.Add(new ValidationError("Hour cannot be greater than 23", nameof(Hour)));

            if (Minute < 0)
                validationErrors.Add(new ValidationError("Min cannot be less than 0", nameof(Minute)));

            if (Minute > 59)
                validationErrors.Add(new ValidationError("Min cannot be greater than 59", nameof(Minute)));

            if (Second < 0)
                validationErrors.Add(new ValidationError("Sec cannot be less than 0", nameof(Second)));

            if (Second > 59)
                validationErrors.Add(new ValidationError("Sec cannot be greater than 59", nameof(Second)));


            return validationErrors;
        }
    }
}
