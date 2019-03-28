using Bliss.Application.Servicers.Intake.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Application.Servicers.Intake.Consultations.Commands
{
    public sealed class CreateConsultation : ICreateConsultation
    {
        private IConsultationWriteOnlyRepository _consultationWriteOnlyRepository;

        //DI - Commands repositories only
        public CreateConsultation(IConsultationWriteOnlyRepository consultationWriteOnlyRepository)
        {
            _consultationWriteOnlyRepository = consultationWriteOnlyRepository;
        }

        public Task<CreateConsultationResult> Execute(CreateConsultationRequest createConsultationRequest)
        {
            throw new NotImplementedException();
        }
    }
}
