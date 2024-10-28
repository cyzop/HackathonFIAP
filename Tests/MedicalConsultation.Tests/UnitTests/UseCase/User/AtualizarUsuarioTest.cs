using MedicalConsultation.Entity;
using MedicalConsultation.Messages.UseCaseValidationMessages;
using MedicalConsultation.Tests.Fixture;
using MedicalConsultation.UseCases.Patient;

namespace MedicalConsultation.Tests.UnitTests.UseCase.User
{
    public class AtualizarUsuarioTest
    {
        private readonly PatientTestFixture _fixture;
        public AtualizarUsuarioTest()
        {
            _fixture = new PatientTestFixture();    
        }

        [Fact(DisplayName = "Teste de validacao da regra para alterar as informação de um Usuuário (paciente)")]
        [Trait("UseCase.Patient.Update", "Teste de validação para alterar as informação de um Usuário (paciente)")]
        public async Task ValidateUseCase_Should_NotException_VerifyMethod()
        {
            //Arrange
            var paciente = (UserEntity)_fixture.GenerateEntity();
            var pacienteMesmoId = (UserEntity)paciente;
            UserEntity pacienteMesmoEmail = pacienteMesmoId;

            paciente.SetName("Nome Alterado");
            
            //Act
            var useCase = new UpdatePatientUseCase(paciente, pacienteMesmoId, pacienteMesmoEmail);
            var atualizar = useCase.VerificarExistente();

            //Assert
            Assert.Equal(paciente.CPF, atualizar.CPF);
            Assert.Equal(paciente.Name, atualizar.Name);
            Assert.Equal(paciente.Email, atualizar.Email);

            await Task.Delay(1);
        }

        [Fact(DisplayName = "Teste de validacao da regra para alterar um Usuário com email já existente")]
        [Trait("UseCase.Patient.Update", "Teste de validação para alterar um Usuário com email já existente")]
        public async Task ValidateUseCase_Should_AssertException_When_PatientAlreadyExistingWithSameEmail()
        {
            //Arrange
            var paciente = (UserEntity)_fixture.GenerateEntity();
            var pacienteMesmoId = (UserEntity)paciente;
            var pacienteMesmoEmail = (UserEntity)_fixture.GenerateEntity(null, paciente.Email, null);
            paciente.SetAtivo(true);
            pacienteMesmoEmail.SetAtivo(true);

            //Act
            var useCase = new UpdatePatientUseCase(paciente, pacienteMesmoId, pacienteMesmoEmail);
            var result = Assert.Throws<ArgumentException>(() => useCase.VerificarExistente());

            //Assert
            Assert.Equal(PatientValidationMessages.PatientAlreadyExistingWithSameEmail, result.Message);

            await Task.Delay(1);
        }
    }
}
