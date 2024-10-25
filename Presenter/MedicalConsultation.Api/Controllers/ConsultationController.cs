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

        [HttpGet("ListarPorMedico/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConsultationDao>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetConsultasMedico(string email)
        {
            try
            {
                var ativos = _consultationController.ListarPorMedicoAPartirDe(email, DateTime.Now);
                var quantidade = ativos?.Count() ?? 0;

                _logger.LogInformation("Get Consultas p/ Medico length {quantidade}", quantidade);

                if (ativos?.Count() > 0)
                {
                    var result = ativos.Select(e => _entityConverter.Convert(e)).ToList();
                    return Ok(result);
                }
                else
                    return StatusCode(StatusCodes.Status204NoContent);//NoContent
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ListarPorPaciente/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConsultationDao>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetConsultasPaciente(string email)
        {
            try
            {
                var ativos = _consultationController.ListarPorPacienteAPartirDe(email, DateTime.Now);
                var quantidade = ativos?.Count() ?? 0;

                _logger.LogInformation("Get Consultas p/ Paciente length {quantidade}", quantidade);

                if (ativos?.Count() > 0)
                {
                    var result = ativos.Select(e => _entityConverter.Convert(e)).ToList();  
                    return Ok(result);
                }
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

        [HttpPost("Cancelar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CancelarConsulta(int idConsulta)
        {
            bool result = _consultationController.Cancelar(idConsulta);
            if (result)
                return Ok();
            else
                return BadRequest();
        }
        [HttpGet("Consultar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultationDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetConsulta(int id)
        {
            _logger.LogInformation("Get Consulta {id}" , id);
            var consulta = _consultationController.ListarPorId(id);
            if (consulta!=null)
            {
                var result =  _entityConverter.Convert(consulta);
                return Ok(result);
            }
            else
                return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
