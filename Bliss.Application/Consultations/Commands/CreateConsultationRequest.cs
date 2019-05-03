using Bliss.Application.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bliss.Application.Consultations.Commands
{
    public class CreateConsultationRequest
    {
        public CreateConsultationRequest(PatientDTO patientDTO
            , PatientInsurancePolicyDTO patientInsurancePolicyDTO)
        {
            if (patientDTO == null)
                throw new Exception("Patient information needs to be assigned to the request");

         
            if (patientInsurancePolicyDTO == null)
                throw new Exception("Patient Insurance Policy information needs to be assigned to the request");

            PatientDTO = patientDTO;
            PatientInsurancePolicyDTO = patientInsurancePolicyDTO;
        }

        [Required]
        public PatientDTO PatientDTO { get; private set; }

        [Required]
        public PatientInsurancePolicyDTO PatientInsurancePolicyDTO { get; private set; }
    }
}