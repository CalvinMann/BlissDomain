using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Patients
{
    public interface IInsurancePolicy
    {
         Name CompanyName { get;  }
         PolicyNumber PolicyNumber { get;  }
         Address Address { get;  }
    }
}
