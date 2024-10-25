using MedicalConsultation.Api.Converter;
using MedicalConsultation.Entity;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MedicalConsultation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IUserController _controller;
        private readonly IDaoConverter<UserDao, UserEntity> _daoConverter;
        private readonly IEntityConverter<UserEntity, UserDao> _entityConverter;
        private readonly IMedicalDoctorController _medicalDoctorController;

        public UserController(ILogger<PatientController> logger,
            IUserController controller,
            IDaoConverter<UserDao, UserEntity> daoConverter,
            IEntityConverter<UserEntity, UserDao> entityConverter,
            IMedicalDoctorController medicalDoctorController)
        {
            _logger = logger;
            _controller = controller;
            _daoConverter = daoConverter;
            _entityConverter = entityConverter;
            _medicalDoctorController = medicalDoctorController;
        }

        [HttpPost("Alterar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AlterarPaciente(UserDao usuario)
        {
            UserEntity entity = _daoConverter.Convert(usuario);
            var result = _controller.Alterar(entity);
            return Ok(usuario);
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
        public async Task<IActionResult> GetUsuario(string email)
        {
            var patient = _controller.ObterUsuarioPorEmail(email);
            var medico = patient!=null && _medicalDoctorController.ObterUsuarioPorEmail(email) != null;
            //se nao existir cadastrar
            if (patient == null)
                patient = new UserEntity(email);
            
            var result = _entityConverter.Convert(patient);
            result.EhMedico = medico;
            
            return Ok(result);
        }
    }
}
