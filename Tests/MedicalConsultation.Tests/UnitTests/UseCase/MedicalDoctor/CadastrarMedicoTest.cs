using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Messages.UseCaseValidationMessages;
using MedicalConsultation.Tests.Fixture;
using MedicalConsultation.UseCases.MedicalDoctor;

namespace MedicalConsultation.Tests.UnitTests.UseCase.MedicalDoctor
{
    public class CadastrarMedicoTest
    {
        private readonly MedicalDoctorTestFixture _fixture;

        public CadastrarMedicoTest()
        {
            _fixture = new MedicalDoctorTestFixture();
        }

        [Fact(DisplayName = "Teste de validacao da regra para cadastrar um Médico")]
        [Trait("UseCase.MedicalDoctor.Include", "Teste de validação de cadastro de Médico")]
        public async Task ValidateUseCase_Should_NotException_VerifyMethod()
        {
            //Arrange
            var medico = _fixture.GenerateEntity();
            MedicalDoctorEntity medicoMesmoEmail = null;
            //Act
            var useCase = new IncludeMedicalDoctorUseCase(medico, medicoMesmoEmail);
            var medicoIncluir = useCase.VerificarExistente();

            //Assert
            Assert.Equal(medico.Especialidade, medicoIncluir.Especialidade);
            Assert.Equal(medico.CRM, medicoIncluir.CRM);
            Assert.Equal(medico.Usuario.Name, medico.Usuario.Name);
            Assert.Equal(medico.Usuario.Email, medicoIncluir.Usuario.Email);

            await Task.Delay(1);
        }

        [Fact(DisplayName = "Teste de validacao da regra para cadastrar um Médico com email já existente")]
        [Trait("UseCase.MedicalDoctor.Include", "Teste de validaçãopara cadastrar um Médico com email já existente")]
        public async Task ValidateUseCase_Should_AssertException_When_MedicalDoctorAlreadyExistingWithSameEmail()
        {
            //Arrange
            var medico = _fixture.GenerateEntity();
            var medicoMesmoEmail = _fixture.GenerateEntity(null, medico.Usuario.Email, null);
            medico.SetAtivo(true);
            medicoMesmoEmail.SetAtivo(true);


            //Act
            var useCase = new IncludeMedicalDoctorUseCase(medico, medicoMesmoEmail);
            var result = Assert.Throws<ArgumentException>(() => useCase.VerificarExistente());

            //Assert
            Assert.Equal(MedicalDoctorValidationMessages.MedicalDoctorAlreadyExistingWithSameEmail, result.Message);

            await Task.Delay(1);
        }
    }
}
