using Bliss.Application.Repositories;
using Bliss.Domain.Patients;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Infrastructure.DataAccess.InMemory.Repositories
{
    public class PatientRepository : IPatientReadOnlyRepository, IPatientWriteOnlyRepository
    {
        private readonly Context _context;

        public PatientRepository(Context context)
        {
            _context = context;
        }

        public Task Create(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Task Update(Patient patient)
        {
            throw new NotImplementedException();
        }


        #region Reads
        //Reads
        public Patient Get(Guid id)
        {
            Patient patient =  _context.Patients
                .Where(e => e.Id == id)
                .SingleOrDefault();

            return  patient;
        }

        public Task<Patient> GetPatient(SSN socialSecurityNumber, Name firstName, Name lastName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
