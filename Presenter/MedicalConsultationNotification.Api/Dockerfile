# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presenter/MedicalConsultationNotification.Api/MedicalConsultationNotification.Api.csproj", "Presenter/MedicalConsultationNotification.Api/"]
COPY ["Application/MedicalConsultation.Controller/MedicalConsultation.Controller.csproj", "Application/MedicalConsultation.Controller/"]
COPY ["Usecase/MedicalConsultation.UseCases/MedicalConsultation.UseCases.csproj", "Usecase/MedicalConsultation.UseCases/"]
COPY ["Application/MedicalConsultation.Messages/MedicalConsultation.Messages.csproj", "Application/MedicalConsultation.Messages/"]
COPY ["Application/MedicalConsultation.Validations/MedicalConsultation.Validations.csproj", "Application/MedicalConsultation.Validations/"]
COPY ["Domain/MedicalConsultation.Entity/MedicalConsultation.Entity.csproj", "Domain/MedicalConsultation.Entity/"]
COPY ["Application/MedicalConsultation.Interfaces/MedicalConsultation.Interfaces.csproj", "Application/MedicalConsultation.Interfaces/"]
COPY ["Presenter/MedicalConsultation.Shared/MedicalConsultation.Shared.csproj", "Presenter/MedicalConsultation.Shared/"]
COPY ["Gateway/MedicalConsultation.Gateways/MedicalConsultation.Gateways.csproj", "Gateway/MedicalConsultation.Gateways/"]
COPY ["Infrastructure/MedicalConsultation.MassTransit/MedicalConsultation.MassTransit.csproj", "Infrastructure/MedicalConsultation.MassTransit/"]
COPY ["Infrastructure/MedicalConsultation.Repository/MedicalConsultation.Repository.csproj", "Infrastructure/MedicalConsultation.Repository/"]
RUN dotnet restore "./Presenter/MedicalConsultationNotification.Api/MedicalConsultationNotification.Api.csproj"
COPY . .
WORKDIR "/src/Presenter/MedicalConsultationNotification.Api"
RUN dotnet build "./MedicalConsultationNotification.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MedicalConsultationNotification.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MedicalConsultationNotification.Api.dll"]