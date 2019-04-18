using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Application.Consultations.Commands
{
    public interface ICreateConsultation
    {
        Task<CreateConsultationResult> ExecuteAsync(CreateConsultationRequest createConsultationRequest);
    }
}
