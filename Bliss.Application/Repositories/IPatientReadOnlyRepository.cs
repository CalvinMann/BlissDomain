using Bliss.Domain.Patients;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Application.Repositories
{
    public interface IPatientReadOnlyRepository
    {
        Task<Patient> GetPatient(SSN socialSecurityNumber, Name firstName, Name lastName);
    }
}
