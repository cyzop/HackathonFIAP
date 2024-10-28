using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Messages.UseCaseValidationMessages;
using MedicalConsultation.Tests.Fixture;
using MedicalConsultation.UseCases.Consultation;

namespace MedicalConsultation.Tests.UnitTests.UseCase.Consulta
{
    public class ReagendarConsultaTest
    {
        private readonly ConsultationTestFixture _fixture;
        private readonly MedicalDoctorTestFixture _medicalFixture;
        private readonly PatientTestFixture _patientFixture;

        public ReagendarConsultaTest()
        {
            _medicalFixture = new MedicalDoctorTestFixture();
            _patientFixture = new PatientTestFixture();
            _fixture = new ConsultationTestFixture(_medicalFixture, _patientFixture);
        }

        [Fact(DisplayName = "Teste de validacao da regra para Reagendar uma Consulta sem informação da Consulta")]
        [Trait("UseCase.Consultation.ChangeDate", "Teste de validação de reagendamento de Consulta sem informar a Consulta")]
        public async Task ValidateUseCase_Should_AssertException_When_ConsultationIsNull()
        {
            //Arrange
            ConsultationEntity consultaMarcada = _fixture.GenerateEntity();
            ConsultationEntity consultaNova = null;

            //Act
            var useCase = new UpdateConsultationUseCase(consultaMarcada, consultaNova);
            var result = Assert.Throws<ArgumentException>(() => useCase.VerificarAlteracao());

            //Assert
            Assert.Equal(ConsultationValidationMessages.ConsultationNotFound, result.Message);

            await Task.Delay(1);
        }

        [Fact(DisplayName = "Teste de validacao da regra para Reagendar uma Consulta para data que já passou")]
        [Trait("UseCase.Consultation.ChangeDate", "Teste de validação de reagendamento de Consulta para data que já passou")]
        public async Task ValidateUseCase_Should_AssertException_When_ConsultationDateIsInvalid()
        {
            //Arrange
            DateTime dataPassada = DateTime.Now.AddDays(-1);
            var paciente = _patientFixture.GenerateEntity();
            var medico = _medicalFixture.GenerateEntity();
            ConsultationEntity consultaMarcada = _fixture.GenerateEntity(paciente, medico);
            ConsultationEntity consultaNova = consultaMarcada;
            consultaNova.Date = dataPassada;

            //Act
            var useCase = new UpdateConsultationUseCase(consultaMarcada, consultaNova);
            var result = Assert.Throws<ArgumentException>(() => useCase.VerificarAlteracao());

            //Assert
            Assert.Equal(ConsultationValidationMessages.ConsultationDateHasPasses, result.Message);

            await Task.Delay(1);
        }
    }
}
