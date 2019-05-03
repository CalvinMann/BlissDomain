using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bliss.Domain.Consultations
{
    public sealed class Availabilities
    {
        private readonly IList<Availability> _availabilities;

        public Availabilities()
        {
            _availabilities = new List<Availability>();
        }

        public IReadOnlyCollection<Availability> GetAvailabilities()
        {
            IReadOnlyCollection<Availability> availabilities = new ReadOnlyCollection<Availability>(_availabilities);
            return availabilities;
        }

        public Availability AddAvailability(Date date, Zone zone, Time startTime, Duration duration)
        {
            Availability availability = new Availability(date, zone, startTime, duration);

            return availability;
        }

        public void RemoveAvailability(Guid id)
        {
            throw new NotImplementedException();
        }


    }
}
