using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bliss.Domain.Consultations
{
    public class Availabilities
    {
        private readonly IList<IAvailability> _availabilities;

        public Availabilities()
        {
            _availabilities = new List<IAvailability>();
        }

        public IReadOnlyCollection<IAvailability> GetAvailabilities()
        {
            IReadOnlyCollection<IAvailability> availabilities = new ReadOnlyCollection<IAvailability>(_availabilities);
            return availabilities;
        }

        public void AddAvailability(Date date, Zone zone, Time startTime, Duration duration)
        {
            IAvailability availability = new Availability(date, zone, startTime, duration);

            IAvailability existingAvailability = Find(availability);

            if (existingAvailability == null)
                _availabilities.Add(availability);
            //else
            //    return existingAvailability;

            //return availability;
        }

        public void RemoveAvailability(Guid id)
        {
            throw new NotImplementedException();
        }

        private IAvailability Find(IAvailability availability)
        {
            foreach (Availability availabilityInList in _availabilities)
            {
                if (availabilityInList.Equals(availability))
                    return availabilityInList;
            }

            return null;
        }
    }
}
