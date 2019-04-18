using Bliss.Domain.Consultations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Application.Repositories
{
    public interface IConsultationWriteOnlyRepository
    {
        Task Create(Consultation consultation);

        Task Update(Consultation consultation);

         Task Delete(Consultation consultation);

    }
}
