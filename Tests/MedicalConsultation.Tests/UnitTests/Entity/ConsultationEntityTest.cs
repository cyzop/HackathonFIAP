using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Messages.EntityValidationMessages;
using MedicalConsultation.Tests.Fixture;

namespace MedicalConsultation.Tests.UnitTests.Entity
{
    public class ConsultationEntityTest
    {
        private readonly ConsultationTestFixture _fixture;

        public ConsultationEntityTest()
        {
            _fixture = new ConsultationTestFixture(
                new MedicalDoctorTestFixture(), 
                new PatientTestFixture());
        }

        [Fact(DisplayName = "Teste unitario de validacao de Consulta")]
        [Trait("Entity.Consultation", "Teste unitario de validacao de Consulta")]
        public async Task ValidateEntity_Should_Create_ConsultationEntity()
        {
            //Arrange
            var entidade = _fixture.GenerateEntity();

            //Act
            var act = entidade != null;

            Assert.True(act);
            Assert.Equal(typeof(ConsultationEntity), entidade.GetType());
            await Task.Delay(1);
        }

        [Fact(DisplayName = "Teste unitario de validacao de Consulta sem Paciente informado")]
        [Trait("Entity.Consultation", "Teste unitario de validacao de Consulta sem Paciente informado")]
        public async Task ValidateEntity_Should_AssertException_When_PatientIsEmpty()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _fixture.GenerateEntityWithEmptyPatient());

            //Assert
            Assert.Equal(ConsultationValidationMessages.PatientCannotBeNullOrEmpty, result.Message);

            await Task.Delay(1);
        }

        [Fact(DisplayName = "Teste unitario de validacao de Consulta sem Medico informado")]
        [Trait("Entity.Consultation", "Teste unitario de validacao de Consulta sem Medico informado")]
        public async Task ValidateEntity_Should_AssertException_When_MedicalDoctorIsEmpty()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _fixture.GenerateEntityWithEmptyMedicalDoctor());

            //Assert
            Assert.Equal(ConsultationValidationMessages.MedicalDoctorCannotBeNullOrEmpty, result.Message);

            await Task.Delay(1);
        }

        [Fact(DisplayName = "Teste unitario de validacao de Consulta sem Data informada")]
        [Trait("Entity.Consultation", "Teste unitario de validacao de Consulta sem Data informada")]
        public async Task ValidateEntity_Should_AssertException_When_DateIsMinValue()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _fixture.GenerateEntityWithInvalidDate());

            //Assert
            Assert.Equal(ConsultationValidationMessages.DateCannotBeNullOrEmpty, result.Message);

            await Task.Delay(1);
        }
    }
}
