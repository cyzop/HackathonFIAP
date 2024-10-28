using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Messages.Entity;
using MedicalConsultation.Tests.Fixture;

namespace MedicalConsultation.Tests.UnitTests.Entity
{
    public class PatientEntityTest
    {
        private readonly PatientTestFixture _fixture;
        public PatientEntityTest()
        {
            _fixture = new PatientTestFixture();
        }

        [Fact(DisplayName = "Teste unitario de validacao de Paciente")]
        [Trait("Entity.Patient", "Teste unitario de validacao de Paciente")]
        public async Task ValidateEntity_Should_Create_PatientEntity()
        {
            //Arrange
            var entidade = _fixture.GenerateEntity();

            //Act
            var act = entidade != null;

            Assert.True(act);
            Assert.Equal(typeof(PatientEntity), entidade.GetType());

            await Task.Delay(1);
        }

        [Fact(DisplayName = "Teste unitario de validacao de Paciente com Nome vazio")]
        [Trait("Entity.Patient", "Teste unitario de validacao de Paciente com Nome vazio")]
        public async Task ValidateEntity_Should_AssertException_When_InvalidName()
        {
            //Arrange
            
            //Act
            var result = Assert.Throws<ArgumentException>(() => _fixture.GenerateWithEmptyName());

            //Assert
            Assert.Equal(PatientValidationMessages.NameCannotBeNullOrEmpty, result.Message);

            await Task.Delay(1);
        }

        [Fact(DisplayName = "Teste unitario de validacao de Paciente com Nome muito grande")]
        [Trait("Entity.Patient", "Teste unitario de validacao de Paciente com Nome muito grande")]
        public async Task ValidateEntity_Should_AssertException_When_NameIsGreatThen150()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _fixture.GenerateWithNameGreatThen150());

            //Assert
            Assert.Equal(PatientValidationMessages.NameGreaterThanLimit(150), result.Message);

            await Task.Delay(1);
        }

        [Fact(DisplayName = "Teste unitario de validacao de Paciente com Email vazio")]
        [Trait("Entity.Patient", "Teste unitario de validacao de Paciente com Email vazio")]
        public async Task ValidateEntity_Should_AssertException_When_InvalidMail()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _fixture.GenerateWithEmptyMail());

            //Assert
            Assert.Equal(PatientValidationMessages.EmailCannotBeNullOrEmpty, result.Message);

            await Task.Delay(1);
        }
    }
}
