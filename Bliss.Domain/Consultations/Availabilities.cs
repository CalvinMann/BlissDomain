using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bliss.Domain.Consultations
{
    public sealed class Availabilities
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

        public void AddRangeAvailability(TimeSpan timeSpan)
        {
            //Create availabilities here
            throw new NotImplementedException();
        }

        public void AddSpecificAvailability(DateTime dateTime)
        {
            //Create availabilities here
            throw new NotImplementedException();
        }
    }
}
