using MedicalConsultation.Interfaces.Controller;
using Microsoft.AspNetCore.Mvc;

namespace MedicalConsultationNotification.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly INotificationController _controller;

        public NotificationController(ILogger<NotificationController> logger, INotificationController controller)
        {
            _logger = logger;
            _controller = controller;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> GetNotificacoesConsulta()
        {
            try
            {
                var notificacoes = _controller.GerarNotificacoesConsulta();

                var quantidade = notificacoes?.Count() ?? 0;

                _logger.LogInformation("GetNotificacoesConsulta length {quantidade}", quantidade);

                if (notificacoes?.Count() > 0)
                {
                    return Ok(notificacoes
                            .Select(p => p.Consulta.Id)?
                            .ToList());
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
    }
}
