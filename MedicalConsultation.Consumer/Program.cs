using MedicalConsultation.Consumer;
using MedicalConsultation.Consumer.Extensions;
using MedicalConsultation.Repository;
using Microsoft.EntityFrameworkCore;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("ConnectionString"));
    //options.UseLazyLoadingProxies();
}, ServiceLifetime.Scoped);

builder.Services.AddHostedService<Worker>();
builder.Services.AddDependencies(config);

var host = builder.Build();
host.Run();
