using FluentAssertions;
using MedicalConsultation.Entity;
using MedicalConsultation.Tests.Fixture;
using MedicalConsultation.UseCases.Consultation;

namespace MedicalConsultation.Tests.UnitTests.UseCase.Consulta
{
    public class AgendarConsultaTest
    {
        private readonly ConsultationTestFixture _fixture;
        private readonly MedicalDoctorTestFixture _medicalFixture;
        private readonly PatientTestFixture _patientFixture;

        public AgendarConsultaTest()
        {
            _medicalFixture = new MedicalDoctorTestFixture();
            _patientFixture = new PatientTestFixture();
            _fixture = new ConsultationTestFixture(_medicalFixture, _patientFixture);
        }

        [Fact(DisplayName = "Teste de validacao da regra para Agendar uma Consulta")]
        [Trait("UseCase.Consultation.Incluir", "Teste de validação de agendamento de Consulta")]
        public void ValidateUseCase_Should_NotException_VerifyMethod()
        {
            //Arrange
            var medico = _medicalFixture.GenerateEntity();
            var paciente = _patientFixture.GenerateEntity();
            var consulta = _fixture.GenerateEntity(paciente, medico);

            var usuario = (UserEntity)paciente;

            //Act
            var useCase = new IncludeConsultationUseCase(medico, usuario, null, null, consulta);
            var resultado = useCase.VerificarExistente();

            //Assert
            Assert.True(resultado != null);
            Assert.Equal(resultado.Medico.Id, consulta.Medico.Id);
            Assert.Equal(resultado.Paciente.Id, consulta.Paciente.Id);
            Assert.Equal(resultado.Date, consulta.Date);
            Assert.Equal(resultado.Status, consulta.Status);
        }

        [Fact(DisplayName = "Teste de validacao da regra para Agendar uma Consulta sem informação do Medico")]
        [Trait("UseCase.Consultation.Incluir", "Teste de validação de agendamento de Consulta sem informação do Medico")]
        public void ValidateUseCase_Should_AssertException_When_MedicalDoctorIsNull()
        {
            //Arrange
            var consulta = _fixture.GenerateEntity();
            var usuario = (UserEntity)consulta.Paciente;

            //Act
            var useCase = new IncludeConsultationUseCase(null, usuario, null, null, consulta);
            var result = Assert.Throws<ArgumentException>(() => useCase.VerificarExistente());

            //Assert
            Assert.Equal(Messages.UseCaseValidationMessages.MedicalDoctorValidationMessages.MedicalDoctorNotFound, result.Message);
        }

        [Fact(DisplayName = "Teste de validacao da regra para Agendar uma Consulta sem informação de Paciente")]
        [Trait("UseCase.Consultation.Incluir", "Teste de validação de agendamento de Consulta sem informação de Paciente")]
        public void ValidateUseCase_Should_AssertException_When_PatientDoctorIsNull()
        {
            //Arrange
            var paciente = _patientFixture.GenerateEntity();
            var consulta = _fixture.GenerateEntity(paciente, null);
            var usuario = (UserEntity)consulta?.Paciente;

            //Act
            var useCase = new IncludeConsultationUseCase(consulta.Medico, null, null, null, consulta);
            var result = Assert.Throws<ArgumentException>(() => useCase.VerificarExistente());

            //Assert
            Assert.Equal(Messages.UseCaseValidationMessages.PatientValidationMessages.PatientNotFound, result.Message);
        }

        [Fact(DisplayName = "Teste de validacao da regra para Agendar uma Consulta em horário já ocupado")]
        [Trait("UseCase.Consultation.Incluir", "Teste de validação de agendamento de Consulta em horário já ocupado")]
        public void ValidateUseCase_Should_AssertException_When_MedicalHasAnotherAppointmentAtTheSameTime()
        {
            //Arrange
            var paciente = _patientFixture.GenerateEntity();
            var consulta = _fixture.GenerateEntity(paciente, null);
            var consultaMesmoHorario = _fixture.GenerateEntity(_patientFixture.GenerateEntity(), consulta.Medico, consulta.Date);
            var usuario = (UserEntity)consulta?.Paciente;

            //Act
            var useCase = new IncludeConsultationUseCase(consulta.Medico, usuario, consultaMesmoHorario, null, consulta);
            var result = Assert.Throws<ArgumentException>(() => useCase.VerificarExistente());

            //Assert
            Assert.Equal(Messages.UseCaseValidationMessages.ConsultationValidationMessages.MedicalDoctorWithConsultationAtTheSameTime, result.Message);
        }

        [Fact(DisplayName = "Teste de validacao da regra para Agendar uma Consulta em horário que Paciente já tem consulta agendada")]
        [Trait("UseCase.Consultation.Incluir", "Teste de validação de agendamento de Consulta em horário que Paciente já tem consulta agendada")]
        public void ValidateUseCase_Should_AssertException_When_PatientHasAnotherAppointmentAtTheSameTime()
        {
            //Arrange
            var paciente = _patientFixture.GenerateEntity();
            var consulta = _fixture.GenerateEntity(paciente, null);
            var medico = _medicalFixture.GenerateEntity();
            var consultaMesmoHorario = _fixture.GenerateEntity(paciente, medico, consulta.Date);
            var usuario = (UserEntity)consulta?.Paciente;

            //Act
            var useCase = new IncludeConsultationUseCase(consulta.Medico, usuario, null, consultaMesmoHorario, consulta);
            var result = Assert.Throws<ArgumentException>(() => useCase.VerificarExistente());

            //Assert
            Assert.Equal(Messages.UseCaseValidationMessages.ConsultationValidationMessages.PatientWithConsultationAtTheSameTime, result.Message);
        }
    }
}
