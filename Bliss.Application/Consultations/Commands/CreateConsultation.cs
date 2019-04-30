using Bliss.Application.DTO;
using Bliss.Application.Repositories;
using Bliss.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Application.Consultations.Commands
{
    public sealed class CreateConsultation : ICreateConsultation
    {
        private readonly IConsultationWriteOnlyRepository _consultationWriteOnlyRepository;
        private readonly IPatientWriteOnlyRepository _patientWriteOnlyRepository;

        private readonly IPatientReadOnlyRepository _patientReadOnlyRepository;
        private readonly IClinicianGroupReadOnlyRepository _providerReadOnlyRepository;
        private readonly ISupplierReadOnlyRepository _supplierReadOnlyRepository;

        //DI - Commands repositories only
        public CreateConsultation(IConsultationWriteOnlyRepository consultationWriteOnlyRepository, IPatientWriteOnlyRepository patientWriteOnlyRepository
            , IPatientReadOnlyRepository patientReadOnlyRepository, IClinicianGroupReadOnlyRepository providerReadOnlyRepository
            , ISupplierReadOnlyRepository supplierReadOnlyRepository)
        {
            _consultationWriteOnlyRepository = consultationWriteOnlyRepository;
            _patientWriteOnlyRepository = patientWriteOnlyRepository;

            _patientReadOnlyRepository = patientReadOnlyRepository;
            _providerReadOnlyRepository = providerReadOnlyRepository;
            _supplierReadOnlyRepository = supplierReadOnlyRepository;
        }

        public async Task<CreateConsultationResult> ExecuteAsync(CreateConsultationRequest createConsultationRequest)
        {
            Contract.Requires<ArgumentException>(createConsultationRequest != null);

            //We will want to implement a unit of work

            //Check for patient
            Patient patient =  await TryGetPatientAsync(createConsultationRequest.PatientDTO);

            //Create patient record if none exists
            if (patient == null)
            {

            }
            else
            {
                //update
            }

            return new CreateConsultationResult();

        }

        private async Task<Patient> TryGetPatientAsync(PatientDTO patientDTO)
        {
            //Check for patient. 
            Patient patient = await _patientReadOnlyRepository.GetPatient(
                patientDTO.SSN
                ,patientDTO.FirstName
                ,patientDTO.LastName);

            return patient;
        }

        private async Task<Patient> CreatePatient(PatientDTO patientDTO)
        {
            //Create patient
            Patient patient = new Patient(patientDTO.FirstName, patientDTO.LastName, patientDTO.SSN);

            patient.AddGender(patientDTO.Gender);

            patient.AddAddress(patientDTO.Street1, patientDTO.Street2, patientDTO.City, patientDTO.State, patientDTO.Zip);


            //Add patient insurance information
            //patient.AddInsurance()

           await _patientWriteOnlyRepository.Create(patient);



            return patient;
        }
    }
}
