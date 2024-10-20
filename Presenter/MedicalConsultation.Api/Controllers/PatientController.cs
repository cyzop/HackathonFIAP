using MedicalConsultation.Api.Converter;
using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MedicalConsultation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientController _controller;
        private readonly IDaoConverter<PatientDao, PatientEntity> _daoConverter;

        public PatientController(ILogger<PatientController> logger, IPatientController controller, IDaoConverter<PatientDao, PatientEntity> daoConverter)
        {
            _logger = logger;
            _controller = controller;
            _daoConverter = daoConverter;
        }

        [HttpGet("Listar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PatientDao>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPacientesAtivos()
        {
            try
            {
                var ativos = _controller.ListarAtivos();
                var quantidade = ativos?.Count() ?? 0;

                _logger.LogInformation("Get Pacientes length {quantidade}", quantidade);

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

        [HttpPost("Cadastrar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastrarPaciente(PatientDao paciente)
        {
            PatientEntity entity = _daoConverter.Convert(paciente);
            var result = _controller.Incluir(entity);
            return Ok(paciente);
        }

        [HttpPost("Alterar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AlterarPaciente(PatientDao paciente)
        {
            PatientEntity entity = _daoConverter.Convert(paciente);
            var result = _controller.Alterar(entity);
            return Ok(paciente);
        }

        [HttpPut("remover/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ExcluirPaciente(int id)
        {
            var result = _controller.Excluir(id);
            if (result)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet("{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPaciente(string email)
        {
            var result = _controller.ObterUsuarioPorEmail(email);
            if (result!=null)
                return Ok(result);
            else
                return NoContent();
        }
    }
}
