using MedicalConsultation.Interfaces.Controller;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace MedicalConsultation.Consumer
{
    public class ConsumerQueue : IHostedService
    {
        static IQueueClient queueClient;
        private readonly IConfiguration _config;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly string _queueName;

        public ConsumerQueue(IConfiguration config,IServiceScopeFactory scopeFactory)
        {
            _config = config;
            var serviceBusConnection = _config["masstransit:azurebus"] ?? string.Empty;
            _queueName = _config["masstransit:queuename"] ?? string.Empty;
            queueClient = new QueueClient(serviceBusConnection, _queueName);
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"############## INICIANDO CONSUMER DA FILA {_queueName} ####################");
            ProcessMessageHandler();
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"############## DESLIGANDO CONSUMER DA FILA {_queueName} ####################");
            await queueClient.CloseAsync();
            await Task.CompletedTask;
        }

        private void ProcessMessageHandler()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            Console.WriteLine($"### PROCESSANDO MENSAGEM FILA {DateTime.Now} ### =========>");
            Console.WriteLine("");
            Console.WriteLine($"Received: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
            
            string body = Encoding.UTF8.GetString(message.Body);
            var mensagem = JsonConvert.DeserializeObject<MessageRoot>(body);

            using (var scope = _scopeFactory.CreateScope())
            {
                var _notificationController = scope.ServiceProvider.GetRequiredService<INotificationProcessController>();
                _notificationController.ProcessMessage(mensagem.Message);
            }

            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"!!!! Message handler Exception {exceptionReceivedEventArgs.Exception} !!!!");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Action: {context.Action}");
            return Task.CompletedTask;
        }
    }
}
