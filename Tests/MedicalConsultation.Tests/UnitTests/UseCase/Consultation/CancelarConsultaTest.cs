using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Messages.UseCaseValidationMessages;
using MedicalConsultation.Tests.Fixture;
using MedicalConsultation.UseCases.Consultation;

namespace MedicalConsultation.Tests.UnitTests.UseCase.Consulta
{
    public class CancelarConsultaTest
    {
        private readonly ConsultationTestFixture _fixture;
        private readonly MedicalDoctorTestFixture _medicalFixture;
        private readonly PatientTestFixture _patientFixture;

        public CancelarConsultaTest()
        {
            _medicalFixture = new MedicalDoctorTestFixture();
            _patientFixture = new PatientTestFixture();
            _fixture = new ConsultationTestFixture(_medicalFixture, _patientFixture);
        }

        [Fact(DisplayName = "Teste de validacao da regra para Cancelar uma Consulta sem informação da Consulta")]
        [Trait("UseCase.Consultation.Cancel", "Teste de validação de cancelamento de Consulta sem informar a Consulta")]
        public async Task ValidateUseCase_Should_AssertException_When_ConsultationIsNull()
        {
            //Arrange
            ConsultationEntity consulta = null;

            //Act
            var useCase = new CancelConsultationUseCase(null);
            var result = Assert.Throws<ArgumentException>(() => useCase.VerificarCancelamento());

            //Assert
            Assert.Equal(ConsultationValidationMessages.ConsultationNotFound, result.Message);

            await Task.Delay(1);
        }
    }
}
