using MedicalConsultation.Consumer;
using MedicalConsultation.Consumer.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();
builder.Services.AddDependencies(builder.Configuration);

var host = builder.Build();
host.Run();
