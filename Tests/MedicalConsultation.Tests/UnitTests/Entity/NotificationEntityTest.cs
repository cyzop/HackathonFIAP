using MedicalConsultation.Entity.Notify;
using MedicalConsultation.Messages.EntityValidationMessages;
using MedicalConsultation.Tests.Fixture;

namespace MedicalConsultation.Tests.UnitTests.Entity
{
    public class NotificationEntityTest
    {
        private readonly NotificationTestFixture _fixture;

        public NotificationEntityTest()
        {
            _fixture = new NotificationTestFixture(
                new ConsultationTestFixture(
                    new MedicalDoctorTestFixture(),
                    new PatientTestFixture()
                    )
                );
        }

        [Fact(DisplayName = "Teste unitario de validacao de Notificação")]
        [Trait("Entity.Notificatication","Teste unitario de validacao de Notificação")]
        public async void ValidateEntity_Should_Create_NotificationEntity()
        {
            //Arrange
            var entidade = _fixture.GenerateEntity();

            //Act
            var act = entidade != null;

            Assert.True(act);
            Assert.Equal(typeof(ConsultationNotificationEntity), entidade.GetType());
        }

        [Fact(DisplayName = "Teste unitario de validacao de Notificação sem Consulta informada")]
        [Trait("Entity.Notification", "Teste unitario de validacao de Notificação sem Consulta informada")]
        public async void ValidateEntity_Should_AssertException_When_ConsultationIsEmpty()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _fixture.GenerateEntityWithEmptyConsultation());

            //Assert
            Assert.Equal(NotificationValidationMessages.ConsultationCannotBeNullOrEmpty, result.Message);
        }

    }
}
