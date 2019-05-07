using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Consultations
{
    public interface IAvailability
    {
         Date Date { get;  }

         Zone Zone { get;  }

         Time StartTime { get;  }

         Duration Duration { get;  }
    }
}
