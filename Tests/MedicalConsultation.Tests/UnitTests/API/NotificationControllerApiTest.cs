using MedicalConsultation.Entity.Notify;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Tests.Fixture;
using MedicalConsultationNotification.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace MedicalConsultation.Tests.UnitTests.API
{
    public class NotificationControllerApiIntegratedTest
    {
        private readonly Mock<ILogger<NotificationController>> _loggerMock;
        private readonly Mock<INotificationController> _notificationController;
        private readonly NotificationTestFixture _fixture;
        private readonly NotificationController _controllerApi;

        public NotificationControllerApiIntegratedTest()
        {
            _loggerMock = new Mock<ILogger<NotificationController>>();
            _notificationController = new Mock<INotificationController>();
            _controllerApi = new NotificationController(_loggerMock.Object, _notificationController.Object);
            _fixture =
                new NotificationTestFixture(
                    new ConsultationTestFixture(
                        new MedicalDoctorTestFixture(),
                        new PatientTestFixture()
                        )
                    );
        }

        [Fact(DisplayName = "Teste unitário de geração de notificações de consulta")]
        [Trait("Api.NotificationController", "Teste unitário de geração de notificações de consulta")]
        public async void Get_ReturnsOkResultWithData()
        {
            //Arrange
            var notificacoes = new List<ConsultationNotificationEntity>
            {
                _fixture.GenerateEntity(),
                _fixture.GenerateEntity()
            };

            var idsConsulta = notificacoes.Select(n => n.Consulta.Id).ToList();

            _notificationController.Setup(ctx => ctx.GerarNotificacoesConsulta()).Returns(notificacoes);

            //Act
            var result = _controllerApi.GetNotificacoesConsulta();

            //Assert
            Assert.IsType<OkObjectResult>(result?.Result);
            var okResult = (OkObjectResult)result.Result;
            Assert.Equal(idsConsulta, okResult.Value);
        }
    }
}
