using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
    public class TimePeriod : ValueObject
    {
        public TimePeriod(Date startDate, Date endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public Date StartDate { private set; get; }

        public Date EndDate { private set; get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StartDate;
            yield return EndDate;
        }
    }
}
