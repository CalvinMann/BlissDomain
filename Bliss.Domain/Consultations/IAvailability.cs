using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Consultations
{
    public interface IAvailability
    {

        DateTime Day { get; }

        TimeSpan TimeSpan { get; }
    }
}
