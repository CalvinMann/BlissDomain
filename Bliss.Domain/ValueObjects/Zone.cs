using Bliss.Domain.Core;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public sealed class Zone 
    {
        private string _zone;

        public Zone(string zoneId)
        {
            _zone = zoneId;


            var provider = DateTimeZoneProviders.Tzdb;

            DateTimeZone = provider.GetZoneOrNull(zoneId);

            if (DateTimeZone == null)
                throw new Exception("ZoneId is incorrect");

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
    }
}


