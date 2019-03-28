using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Application.Servicers.Intake.Consultations.Commands
{
    public interface ICreateConsultation
    {
        Task<CreateConsultationResult> Execute(CreateConsultationRequest createConsultationRequest);
    }
}
