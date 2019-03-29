using Bliss.Application.Servicers.Intake.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Application.Servicers.Intake.Consultations.Commands
{
    public sealed class CreateConsultation : ICreateConsultation
    {
        private readonly IConsultationWriteOnlyRepository _consultationWriteOnlyRepository;
        private readonly IPatientWriteOnlyRepository _patientWriteOnlyRepository;

        private readonly IPatientReadOnlyRepository _patientReadOnlyRepository;
        private readonly IProviderReadOnlyRepository _providerReadOnlyRepository;
        private readonly ISupplierReadOnlyRepository _supplierReadOnlyRepository;

        //DI - Commands repositories only
        public CreateConsultation(IConsultationWriteOnlyRepository consultationWriteOnlyRepository, IPatientWriteOnlyRepository patientWriteOnlyRepository
            , IPatientReadOnlyRepository patientReadOnlyRepository, IProviderReadOnlyRepository providerReadOnlyRepository
            , ISupplierReadOnlyRepository supplierReadOnlyRepository)
        {
            _consultationWriteOnlyRepository = consultationWriteOnlyRepository;
            _patientWriteOnlyRepository = patientWriteOnlyRepository;

            _patientReadOnlyRepository = patientReadOnlyRepository;
            _providerReadOnlyRepository = providerReadOnlyRepository;
            _supplierReadOnlyRepository = supplierReadOnlyRepository;
        }

        public Task<CreateConsultationResult> Execute(CreateConsultationRequest createConsultationRequest)
        {
            //Check for patient 
            throw new NotImplementedException();

        }
    }
}
