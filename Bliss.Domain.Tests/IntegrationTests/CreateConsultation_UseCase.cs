using Bliss.Application.Consultations.Commands;
using Bliss.Application.DTO;
using Bliss.Application.Repositories;
using Bliss.Infrastructure.DataAccess.InMemory.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bliss.Domain.Tests.Integration.Servicers.Intake
{
    public class CreateConsultation_UseCase
    {
        [Fact]
        public void CreateConsultation_Returns_CreateConsultationResult()
        {
            ////Create the use case
            IConsultationWriteOnlyRepository consultationWriteOnlyRepository = null;
            IPatientReadOnlyRepository patientReadOnlyRepository = null;
            IPatientWriteOnlyRepository patientWriteOnlyRepository = null;
            IClinicianGroupReadOnlyRepository providerReadOnlyRepository = null;
            ISupplierReadOnlyRepository supplierReadOnlyRepository = null;

            ICreateConsultation createConsultation = new CreateConsultation(consultationWriteOnlyRepository
                , patientWriteOnlyRepository, patientReadOnlyRepository
                , providerReadOnlyRepository, supplierReadOnlyRepository);

            PatientDTO patientDTO = new PatientDTO("Calvin", "Mann", "7105 Hurricane Way", "", "Las Vegas", "NV", 98002, "702-3338-0362", "", "male", "539-04-0830");

            PatientInsuranceCompanyDTO patientInsuranceCompanyDTO = new PatientInsuranceCompanyDTO("Aetna", "555 Aetna St", "P.O. Box 31", "New york", "NY", 89001, "1-800-Customer");

            PatientInsurancePolicyDTO patientInformationDTO = new PatientInsurancePolicyDTO();

            CreateConsultationRequest createConsultationRequest = new CreateConsultationRequest(patientDTO, patientInsuranceCompanyDTO, patientInformationDTO);

            Task<CreateConsultationResult> createConsultationResult = createConsultation.ExecuteAsync(createConsultationRequest);

            Assert.NotNull(createConsultationResult);
        }

        [Fact]
        public void WhenDTOsAreAssignedToCreateConsultation_Returns_CreateConsultationResult()
        {
            ////Create the use case
            IConsultationWriteOnlyRepository consultationWriteOnlyRepository = null;
            IPatientReadOnlyRepository patientReadOnlyRepository = null;
            IPatientWriteOnlyRepository patientWriteOnlyRepository = null;
            IClinicianGroupReadOnlyRepository providerReadOnlyRepository = null;
            ISupplierReadOnlyRepository supplierReadOnlyRepository = null;

            ICreateConsultation createConsultation = new CreateConsultation(consultationWriteOnlyRepository
                , patientWriteOnlyRepository, patientReadOnlyRepository
                , providerReadOnlyRepository, supplierReadOnlyRepository);

            PatientDTO patientDTO = new PatientDTO("Calvin", "Mann", "7105 Hurricane Way", "", "Las Vegas", "NV", 98002, "702-3338-0362", "", "male", "539-04-0830");

            PatientInsuranceCompanyDTO patientInsuranceCompanyDTO = new PatientInsuranceCompanyDTO("Aetna", "555 Aetna St", "P.O. Box 31", "New york", "NY", 89001, "1-800-Customer");

            PatientInsurancePolicyDTO patientInsurancePolicyDTO = new PatientInsurancePolicyDTO();

            CreateConsultationRequest createConsultationRequest = new CreateConsultationRequest(patientDTO, patientInsuranceCompanyDTO, patientInsurancePolicyDTO);

       

            Assert.Equal(createConsultationRequest.PatientDTO, patientDTO);
            Assert.Equal(createConsultationRequest.PatientInsuranceCompanyDTO, patientInsuranceCompanyDTO);
            Assert.Equal(createConsultationRequest.PatientInsurancePolicyDTO, patientInsurancePolicyDTO);
        }

        [Fact]
        public void Given_ANullCreateConsultation_CreateConsultationThrowsError()
        {
            ////Create the use case
            IConsultationWriteOnlyRepository consultationWriteOnlyRepository = null;
            IPatientReadOnlyRepository patientReadOnlyRepository = null;
            IPatientWriteOnlyRepository patientWriteOnlyRepository = null;
            IClinicianGroupReadOnlyRepository providerReadOnlyRepository = null;
            ISupplierReadOnlyRepository supplierReadOnlyRepository = null;

            ICreateConsultation createConsultation = new CreateConsultation(consultationWriteOnlyRepository
                , patientWriteOnlyRepository, patientReadOnlyRepository
                , providerReadOnlyRepository, supplierReadOnlyRepository);

            CreateConsultationRequest createConsultationRequest = null;

            Task<Exception> ex = Assert.ThrowsAsync<Exception>(() => createConsultation.ExecuteAsync(createConsultationRequest));

            Assert.Equal("CreateConsultationRequest is null", ex.Result.Message);
        }
    }
}
