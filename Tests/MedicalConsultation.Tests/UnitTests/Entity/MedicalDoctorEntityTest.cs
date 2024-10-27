using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Messages.EntityValidationMessages;
using MedicalConsultation.Tests.Fixture;

namespace MedicalConsultation.Tests.UnitTests.Entity
{
    public class MedicalDoctorEntityTest
    {
        private readonly MedicalDoctorTestFixture _fixture;
        public MedicalDoctorEntityTest()
        {
            _fixture = new MedicalDoctorTestFixture();
        }

        [Fact(DisplayName = "Teste unitario de validacao de Medico")]
        [Trait("Entity.MedicalDoctor", "Teste unitario de validacao de Medico")]
        public async void ValidateEntity_Should_Create_MedicalDoctorEntity()
        {
            //Arrange
            var entidade = _fixture.GenerateEntity();

            //Act
            var act = entidade != null;

            Assert.True(act);
            Assert.Equal(typeof(MedicalDoctorEntity), entidade.GetType());
        }

        [Fact(DisplayName = "Teste unitario de validacao de Medico com Nome vazio")]
        [Trait("Entity.MedicalDoctor", "Teste unitario de validacao de Medico com Nome vazio")]
        public async void ValidateEntity_Should_AssertException_When_InvalidName()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _fixture.GenerateWithEmptyName());

            //Assert
            Assert.Equal(MedicalDoctorValidationMessages.NameCannotBeNullOrEmpty, result.Message);
        }

        [Fact(DisplayName = "Teste unitario de validacao de Medico com CRM vazio")]
        [Trait("Entity.MedicalDoctor", "Teste unitario de validacao de Medico com CRM vazio")]
        public async void ValidateEntity_Should_AssertException_When_CRMIsEmpty()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _fixture.GenerateWithEmptyCRM());

            //Assert
            Assert.Equal(MedicalDoctorValidationMessages.CRMCannotBeNullOrEmpty, result.Message);
        }

        [Fact(DisplayName = "Teste unitario de validacao de Medico com Email vazio")]
        [Trait("Entity.MedicalDoctor", "Teste unitario de validacao de Medico com Email vazio")]
        public async void ValidateEntity_Should_AssertException_When_InvalidMail()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _fixture.GenerateWithEmptyMail());

            //Assert
            Assert.Equal(MedicalDoctorValidationMessages.EmailCannotBeNullOrEmpty, result.Message);
        }
    }
}
