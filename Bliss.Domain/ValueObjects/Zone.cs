using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public sealed class Zone : ISubmitConsultationValidation
    {
        private string _zone;

        public Zone(string zoneId)
        {
            _zone = zoneId;


            var provider = DateTimeZoneProviders.Tzdb;

            DateTimeZone = provider.GetZoneOrNull(zoneId);
        }

        public static implicit operator Zone(string zone)
        {
            return new Zone(zone);
        }

        public static implicit operator string(Zone zone)
        {
            return zone._zone;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is string)
            {
                return obj.ToString() == _zone;
            }

            return ((Zone)obj)._zone == _zone;
        }

        public DateTimeZone DateTimeZone { get; private set; }

        public List<ValidationError> Validate()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            if (string.IsNullOrEmpty(_zone))
            {
                validationErrors.Add(new ValidationError("ZoneId cannot be empty", nameof(ZipCode)));
                return validationErrors;
            }

            if (DateTimeZone == null)
                validationErrors.Add(new ValidationError("ZoneId is incorrect", nameof(Zone)));

         
            return validationErrors;
        }
    }
}


