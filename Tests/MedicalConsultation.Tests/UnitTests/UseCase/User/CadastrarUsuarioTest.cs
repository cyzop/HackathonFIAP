using MedicalConsultation.Entity;
using MedicalConsultation.Messages.UseCaseValidationMessages;
using MedicalConsultation.Tests.Fixture;
using MedicalConsultation.UseCases.MedicalDoctor;
using MedicalConsultation.UseCases.Patient;

namespace MedicalConsultation.Tests.UnitTests.UseCase.User
{
    public class CadastrarUsuarioTest
    {
        private readonly PatientTestFixture _fixture;
        public CadastrarUsuarioTest()
        {
            _fixture = new PatientTestFixture();
        }

        [Fact(DisplayName = "Teste de validacao da regra para cadastrar um Usuário (paciente)")]
        [Trait("UseCase.Patient.Include", "Teste de validação para cadastrar um Usuário (paciente)")]
        public void ValidateUseCase_Should_NotException_VerifyMethod()
        {
            //Arrange
            var novoPaciente = (UserEntity)_fixture.GenerateEntity();
            UserEntity pacienteMesmoEmail = null;
            
            //Act
            var useCase = new IncludePatientUseCase(novoPaciente, pacienteMesmoEmail);
            var incluir = useCase.VerificarExistente();

            //Assert
            Assert.Equal(incluir.Name, novoPaciente.Name);
            Assert.Equal(incluir.Email, novoPaciente.Email);
            Assert.Equal(incluir.CPF, novoPaciente.CPF);
        }

        [Fact(DisplayName = "Teste de validacao da regra para cadastrar um Usuário com email já existente")]
        [Trait("UseCase.Patient.Include", "Teste de validação para cadastrar um Usuário com email já existente")]
        public void ValidateUseCase_Should_AssertException_When_PatientAlreadyExistingWithSameEmail()
        {
            //Arrange
            var novoPaciente = (UserEntity)_fixture.GenerateEntity();
            var pacienteMesmoEmail = (UserEntity) _fixture.GenerateEntity(null, novoPaciente.Email, null);
            novoPaciente.SetAtivo(true);
            pacienteMesmoEmail.SetAtivo(true);

            //Act
            var useCase = new IncludePatientUseCase(novoPaciente, pacienteMesmoEmail);
            var result = Assert.Throws<ArgumentException>(() => useCase.VerificarExistente());

            //Assert
            Assert.Equal(PatientValidationMessages.PatientAlreadyExistingWithSameEmail, result.Message);
        }
    }
}
