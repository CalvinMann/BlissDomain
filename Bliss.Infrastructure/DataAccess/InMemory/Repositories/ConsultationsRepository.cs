using Bliss.Application.Repositories;
using Bliss.Domain.Consultations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Infrastructure.DataAccess.InMemory.Repositories
{
    public class ConsultationsRepository : IConsultationWriteOnlyRepository, IConsultationReadOnlyRepository
    {
        public Task Create(Consultation consultation)
        {
            throw new NotImplementedException();
        }

        public Task Update(Consultation consultation)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Consultation consultation)
        {
            throw new NotImplementedException();
        }

    }
}
