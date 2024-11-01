﻿using MedicalConsultation.Api.Converter;
using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MedicalConsultation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalDoctorController : ControllerBase
    {
        private readonly ILogger<MedicalDoctorController> _logger;
        private readonly IMedicalDoctorController _controller;
        private readonly IDaoConverter<MedicalDoctorDao, MedicalDoctorEntity> _daoConverter;
        private readonly IEntityConverter<MedicalDoctorEntity, MedicalDoctorDao> _entityConverter;

        public MedicalDoctorController(ILogger<MedicalDoctorController> logger,
            IMedicalDoctorController controller,
            IDaoConverter<MedicalDoctorDao,
            MedicalDoctorEntity> daoConverter,
            IEntityConverter<MedicalDoctorEntity, MedicalDoctorDao> entityConverter)
        {
            _logger = logger;
            _controller = controller;
            _daoConverter = daoConverter;
            _entityConverter = entityConverter;
        }

        [HttpGet("Listar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MedicalDoctorDao>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetMedicosAtivos()
        {
            try
            {
                var medicos = _controller.ListarAtivos();
                var quantidade = medicos?.Count() ?? 0;

                _logger.LogInformation("Get Medicos Ativos length {quantidade}", quantidade);

                if (medicos?.Count() > 0)
                {
                    var retorno = medicos
                            .Select(p => _entityConverter.Convert(p))?
                            .ToList();

                    return Ok(retorno);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicalDoctorDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastrarMedico(MedicalDoctorDao paciente)
        {
            MedicalDoctorEntity entity = _daoConverter.Convert(paciente);
            var result = _controller.Incluir(entity);
            return Ok(paciente);
        }

        [HttpPost("Alterar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicalDoctorDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AlterarMedico(MedicalDoctorDao paciente)
        {
            MedicalDoctorEntity entity = _daoConverter.Convert(paciente);
            var result = _controller.Alterar(entity);
            return Ok(paciente);
        }

        [HttpPut("remover/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ExcluirMedico(int id)
        {
            var result = _controller.Excluir(id);
            if (result)
                return Ok(result);
            else
                return NotFound();
        }
    }
}
