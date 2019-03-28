using Bliss.Domain.Servicers.Intake.Consultations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Application.Servicers.Intake.Repositories
{
    public interface IConsultationWriteOnlyRepository
    {
        Task Create(Consultation consultation);
    }
}
