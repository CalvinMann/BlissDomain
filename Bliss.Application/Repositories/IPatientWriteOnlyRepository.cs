using Bliss.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Application.Repositories
{
    public interface IPatientWriteOnlyRepository
    {
        Task Create(Patient patient);

        Task Update(Patient patient);

        Task Delete(Patient patient);

    }
}
