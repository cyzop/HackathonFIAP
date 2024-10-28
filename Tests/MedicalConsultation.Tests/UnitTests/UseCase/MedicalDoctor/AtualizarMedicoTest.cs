using MedicalConsultation.Tests.Fixture;
using MedicalConsultation.UseCases.MedicalDoctor;

namespace MedicalConsultation.Tests.UnitTests.UseCase.MedicalDoctor
{
    public class AtualizarMedicoTest
    {
        private readonly MedicalDoctorTestFixture _fixture;
        public AtualizarMedicoTest()
        {
            _fixture = new MedicalDoctorTestFixture();
        }

        [Fact(DisplayName = "Teste de validacao da regra para alterar as informação de um Médico")]
        [Trait("UseCase.MedicalDoctor.Include", "Teste de validação para alterar as informação de um Médico")]
        public async Task ValidateUseCase_Should_NotException_VerifyMethod()
        {
            //Arrange
            var medicoExistente = _fixture.GenerateEntity();
            var medicoAtualizado = medicoExistente;
            medicoAtualizado.SetCrm("123456RJ");
            medicoAtualizado.SetEspecialidade("Ortopedista");

            //Act
            var useCase = new UpdateMedicalDoctorUseCase(medicoAtualizado, medicoExistente, medicoExistente);
            var medicoAtualizar = useCase.VerificarExistente();

            //Assert
            Assert.Equal(medicoAtualizar.Especialidade, medicoAtualizado.Especialidade);
            Assert.Equal(medicoAtualizar.CRM, medicoAtualizado.CRM);
            Assert.Equal(medicoAtualizar.Usuario.Name, medicoAtualizado.Usuario.Name);
            Assert.Equal(medicoAtualizar.Usuario.Email, medicoAtualizado.Usuario.Email);

            await Task.Delay(1);
        }
    }
}
