using FluentAssertions;
using MedicalConsultation.Api.Converter;
using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Shared;
using MedicalConsultation.Tests.Fixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace MedicalConsultation.Tests.UnitTests.API
{
    public class MedicalDoctorControllerApiTest
    {
        private readonly Mock<ILogger<MedicalConsultation.Api.Controllers.MedicalDoctorController>> _loggerMock;
        private readonly Mock<IMedicalDoctorController> _medicalController;
        private readonly MedicalDoctorTestFixture _fixture;
        private readonly MedicalConsultation.Api.Controllers.MedicalDoctorController _controllerApi;
        private readonly IDaoConverter<MedicalDoctorDao, MedicalDoctorEntity> _daoConverter;
        private readonly IEntityConverter<MedicalDoctorEntity, MedicalDoctorDao> _entityConverter;


        public MedicalDoctorControllerApiTest()
        {
            _fixture = new MedicalDoctorTestFixture();
            _medicalController = new Mock<IMedicalDoctorController>();
            _daoConverter = new MedicalDoctorDaoConverter();
            _entityConverter = new MedicalDoctorEntityConverter();
            _loggerMock = new Mock<ILogger<Api.Controllers.MedicalDoctorController>>();

            _controllerApi = new MedicalConsultation.Api.Controllers.MedicalDoctorController(
                _loggerMock.Object, 
                _medicalController.Object,
                _daoConverter, 
                _entityConverter);
        }


        [Fact(DisplayName = "Teste unitário de listagem de medicos")]
        [Trait("Api.NotificationController", "Teste unitário de listagem de medicos")]
        public async void Get_ReturnsOkResultWithData()
        {
            //Arrange
            var medicos = new List<MedicalDoctorEntity>
            {
                _fixture.GenerateEntity(),
                _fixture.GenerateEntity()
            };

            _medicalController.Setup(ctx => ctx.ListarAtivos()).Returns(medicos);

            var medicosDao = medicos.Select(e=>_entityConverter.Convert(e)).ToList();

            //Act
            var result = _controllerApi.GetMedicosAtivos();

            //Assert
            Assert.IsType<OkObjectResult>(result?.Result);
            var okResult = (OkObjectResult)result.Result;
            List<MedicalDoctorDao> medicosRetorno = (List<MedicalDoctorDao>) okResult.Value;
            Assert.Equal(medicosDao.Count, medicosRetorno.Count);

            for (int i = 0; i < medicosDao.Count; i++)
                medicosDao[i].Should().BeEquivalentTo(medicosRetorno[i]);

        }
    }
}
