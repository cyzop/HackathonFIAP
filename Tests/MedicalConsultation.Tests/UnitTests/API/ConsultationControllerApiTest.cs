using Castle.Core.Logging;
using FluentAssertions;
using MedicalConsultation.Api.Converter;
using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Shared;
using MedicalConsultation.Tests.Fixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Runtime.CompilerServices;

namespace MedicalConsultation.Tests.UnitTests.API
{
    public class ConsultationControllerApiTest
    {

        /*
         *  private readonly Mock<ILogger<MedicalConsultation.Api.Controllers.MedicalDoctorController>> _loggerMock;
        private readonly Mock<IMedicalDoctorController> _medicalController;
        private readonly MedicalDoctorTestFixture _fixture;
        private readonly MedicalConsultation.Api.Controllers.MedicalDoctorController _controllerApi;
        private readonly IDaoConverter<MedicalDoctorDao, MedicalDoctorEntity> _daoConverter;
        private readonly IEntityConverter<MedicalDoctorEntity, MedicalDoctorDao> _entityConverter;

         */

        private readonly Mock<ILogger<MedicalConsultation.Api.Controllers.ConsultationController>> _loggerMock;
        private readonly MedicalConsultation.Api.Controllers.ConsultationController _controllerApi;
        private readonly Mock<IConsultationController> _consultationController;
        private readonly IDaoConverter<ConsultationDao, ConsultationEntity> _daoConverter;
        private readonly IEntityConverter<ConsultationEntity, ConsultationDao> _entityConverter;
        private readonly ConsultationTestFixture _fixture;
        private readonly PatientTestFixture _patientTestFixture;
        private readonly MedicalDoctorTestFixture _medicalDoctorTestFixture;

        public ConsultationControllerApiTest()
        {
            _patientTestFixture = new PatientTestFixture();
            _medicalDoctorTestFixture = new MedicalDoctorTestFixture();
            _fixture = new ConsultationTestFixture( _medicalDoctorTestFixture,
                                                    _patientTestFixture);

            _loggerMock = new Mock<ILogger<Api.Controllers.ConsultationController>>();
            
            _consultationController = new Mock<IConsultationController>();
            
            _daoConverter = new ConsultationDaoConverter();
            _entityConverter = new ConsultationEntityConverter(
                new MedicalDoctorEntityConverter(),
                new UserEntityConverter());

            _controllerApi = 
                new Api.Controllers.ConsultationController(_loggerMock.Object, 
                                                        _consultationController.Object, 
                                                        _daoConverter, 
                                                        _entityConverter);
        }

        [Fact(DisplayName = "Teste unitário de listagem de consultas agendadas para um medico")]
        [Trait("Api.ConsultationController", "Teste unitário de listagem de consultas agendadas medico")]
        public async void Get_ReturnsOkResultWithDataByMedicalDoctor()
        {
            //Arrange
            var medico = _medicalDoctorTestFixture.GenerateEntity();

            var consultas = new List<ConsultationEntity>
            {
                _fixture.GenerateEntity(null, medico),
                _fixture.GenerateEntity(null, medico)
            };

            DateTime data = DateTime.Now;

            _consultationController.Setup(ctx => ctx.ListarPorMedicoAPartirDe(medico.Usuario.Email, data)).Returns(consultas);

            var consultasDao = consultas.Select(e => _entityConverter.Convert(e)).ToList();

            //Act
            var result = _controllerApi.GetConsultasMedicoApartir(medico.Usuario.Email, data);

            //Assert
            Assert.IsType<OkObjectResult>(result?.Result);
            var okResult = (OkObjectResult)result.Result;
            List<ConsultationDao> consultasRetorno = (List<ConsultationDao>)okResult.Value;
            Assert.Equal(consultasDao.Count, consultasRetorno.Count);

            for (int i = 0; i < consultasDao.Count; i++)
                consultasDao[i].Should().BeEquivalentTo(consultasRetorno[i]);

        }

        [Fact(DisplayName = "Teste unitário de listagem de consultas agendadas de um paciente")]
        [Trait("Api.ConsultationController", "Teste unitário de listagem de consultas agendadas de um paciente")]
        public async void Get_ReturnsOkResultWithDataByPatient()
        {
            //Arrange
            var paciente = _patientTestFixture.GenerateEntity();

            var consultas = new List<ConsultationEntity>
            {
                _fixture.GenerateEntity(paciente, null),
                _fixture.GenerateEntity(paciente, null)
            };

            DateTime data = DateTime.Now;

            _consultationController.Setup(ctx => ctx.ListarPorPacienteAPartirDe(paciente.Email, data)).Returns(consultas);

            var consultasDao = consultas.Select(e => _entityConverter.Convert(e)).ToList();

            //ActListarPorPacienteAPartirDe
            var result = _controllerApi.GetConsultasPacienteAPartir(paciente.Email, data);

            //Assert
            Assert.IsType<OkObjectResult>(result?.Result);
            var okResult = (OkObjectResult)result.Result;
            List<ConsultationDao> consultasRetorno = (List<ConsultationDao>)okResult.Value;
            Assert.Equal(consultasDao.Count, consultasRetorno.Count);

            for (int i = 0; i < consultasDao.Count; i++)
                consultasDao[i].Should().BeEquivalentTo(consultasRetorno[i]);

        }

    }
}
