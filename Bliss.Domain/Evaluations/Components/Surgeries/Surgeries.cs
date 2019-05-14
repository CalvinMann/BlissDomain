using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Surgeries
{
    public sealed class Surgeries
    {
        private readonly IList<ISurgery> _surgeries;

        public Surgeries()
        {
            _surgeries = new List<ISurgery>();
        }

        public IReadOnlyCollection<ISurgery> GetSurgeries()
        {
            IReadOnlyCollection<ISurgery> surgeries = new ReadOnlyCollection<ISurgery>(_surgeries);
            return surgeries;
        }

        public ISurgery AddSurgery()
        {
            throw new NotImplementedException();

        }

        public void RemoveSurgery(Guid id)
        {
            throw new NotImplementedException();
        }

        private ISurgery Find(ISurgery surgeries)
        {
            foreach (ISurgery surgeriesInList in _surgeries)
            {
                if (surgeriesInList.Equals(surgeries))
                    return surgeriesInList;
            }

            return null;
        }
    }
}
