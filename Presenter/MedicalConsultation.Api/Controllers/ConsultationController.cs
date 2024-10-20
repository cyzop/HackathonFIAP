using MedicalConsultation.Api.Converter;
using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MedicalConsultation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultationController : ControllerBase
    {
        private readonly ILogger<ConsultationController> _logger;
        private readonly IConsultationController _consultationController;
        private readonly IDaoConverter<ConsultationDao, ConsultationEntity> _daoConverter;
        private readonly IEntityConverter<ConsultationEntity, ConsultationDao> _entityConverter;

        public ConsultationController(ILogger<ConsultationController> logger, IConsultationController consultationController, IDaoConverter<ConsultationDao, ConsultationEntity> daoConverter, IEntityConverter<ConsultationEntity, ConsultationDao> entityConverter)
        {
            _logger = logger;
            _consultationController = consultationController;
            _daoConverter = daoConverter;
            _entityConverter = entityConverter;
        }

        [HttpGet("ListarPorMedico/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConsultationDao>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetConsultasMedico(int id)
        {
            try
            {
                var ativos = _consultationController.ListarPorMedicoAPartirDe(id, DateTime.Now);
                var quantidade = ativos?.Count() ?? 0;

                _logger.LogInformation("Get Consultas p/ Medico length {quantidade}", quantidade);

                if (ativos?.Count() > 0)
                    return Ok(ativos);
                else
                    return StatusCode(StatusCodes.Status204NoContent);//NoContent
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ListarPorPaciente/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConsultationDao>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetConsultasPaciente(int id)
        {
            try
            {
                var ativos = _consultationController.ListarPorPacienteAPartirDe(id, DateTime.Now);
                var quantidade = ativos?.Count() ?? 0;

                _logger.LogInformation("Get Consultas p/ Paciente length {quantidade}", quantidade);

                if (ativos?.Count() > 0)
                    return Ok(ativos.Select(e=>_entityConverter.Convert(e)).ToList());
                else
                    return StatusCode(StatusCodes.Status204NoContent);//NoContent
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Cadastrar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultationDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastrarConsulta(ConsultationDao consulta)
        {
            ConsultationEntity entity = _daoConverter.Convert(consulta);
            var result = _consultationController.Incluir(entity);
            return Ok(consulta);
        }

        [HttpPost("Alterar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultationDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AlterarConsulta(ConsultationDao consulta)
        {
            ConsultationEntity entity = _daoConverter.Convert(consulta);
            var result = _consultationController.Alterar(entity);
            return Ok(consulta);
        }
    }
}
