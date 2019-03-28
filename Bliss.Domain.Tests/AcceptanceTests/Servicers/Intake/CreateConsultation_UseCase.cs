using Bliss.Application.Servicers.Intake.Consultations.Commands;
using Bliss.Application.Servicers.Intake.Repositories;
using Bliss.Infrastructure.DataAccess.InMemory.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bliss.Domain.Tests.AcceptanceTests.Servicers.Intake
{
    public class CreateConsultation_UseCase
    {
        [Fact]
        public void Test1()
        {
            //Create the use case
            IConsultationWriteOnlyRepository consultationWriteOnlyRepository = new ConsultationsRepository();//In Memory

            ICreateConsultation createConsultation = new CreateConsultation(consultationWriteOnlyRepository);

            CreateConsultationRequest createConsultationRequest = new CreateConsultationRequest();

            Task<CreateConsultationResult> createConsultationResult = createConsultation.Execute(createConsultationRequest);

        }
    }
}
