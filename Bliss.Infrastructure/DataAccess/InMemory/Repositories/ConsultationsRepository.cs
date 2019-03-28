using Bliss.Application.Servicers.Intake.Repositories;
using Bliss.Domain.Servicers.Intake.Consultations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Infrastructure.DataAccess.InMemory.Repositories
{
    public class ConsultationsRepository : IConsultationWriteOnlyRepository
    {
        public Task Create(Consultation consultation)
        {
            throw new NotImplementedException();
        }

       
    }
}
