using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Consultations
{
    public sealed class Availability : ValueObject, IAvailability, ISubmitConsultationValidation
    {

        public Availability(Date date, Zone zone, Time startTime, Duration duration)
        {
            this.Date = date;
            this.Zone = zone;
            this.StartTime = startTime;
            this.Duration = duration;
        }

        public Date Date { get; private set; }

        public Zone Zone { get; private set; }

        public Time StartTime { get; private set; }

        public Duration Duration { get; private set; }

        public List<ValidationError> Validate()
        {
                List<ValidationError> validationErrors = new List<ValidationError>();

            if (Date == null)
                validationErrors.Add(new ValidationError("Date must be provided", nameof(Date)));
            else
                validationErrors.AddRange(Date.Validate());

            if (Zone == null)
                validationErrors.Add(new ValidationError("Zone must be provided", nameof(Zone)));
            else
                validationErrors.AddRange(Zone.Validate());

            if (StartTime == null)
                validationErrors.Add(new ValidationError("StartTime must be provided", nameof(StartTime)));
            else
                validationErrors.AddRange(StartTime.Validate());

            if (Duration == null)
                validationErrors.Add(new ValidationError("Duration must be provided", nameof(Duration)));

            return validationErrors;

        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Date;
            yield return Zone;
            yield return StartTime;
            yield return Duration;
        }
    }
}
