# Hackathon - 2NETT - 2024 : Sistema de Agendamento de Consultas
[![License](https://img.shields.io/badge/license-MIT-green)](./LICENSE)

# Sobre o Projeto

O Sistema de Agendamento de Consultas foi desenvolvido em .Net Core (8) para atender ao Hackathon do curso ARQUITETURA DE SISTEMAS .NET COM AZURE da FIAP - Turma 2NETT.

Este sistema tem o intuito de permitir o usuário, no papel de Paciente, agendar, reagendar ou cancelar consultas. Neste sistema o usuário logado também poderá ser um Médico onde além da gestão com Paciente ele terá a gestão dos agendamentos para atendimento médico. 
No sistema o usuário pode se cadastrar, como Paciente, definido uma senha que atenda aos critérios de senha fortes, verificar seu e-mail e acessar a aplicação.

A aplicação apresenta um menu com acesso aos agendamento já realizados, onde também é possível realizar novos agendamentos, reagendar ou cancelar algum já existente. No caso do usuário logado também ser um Médico existirá o acesso, na tela principal, para a agenda dos atendimentos.

Para utilizar o sistema é exigido que o usuário esteja logado.

Este repositório se refere tanto ao Front-end e Back-end da aplicação onde pode ser utilizado com o Swagger (disponível em modo Debug) para visualização dos endpoints disponíveis.

# Requisitos

O documento com o levanto de requisitos do software e seus critérios de aceite podem ser encontradas no arquivo "AgendamentosMedicos.pdf" na raiz do projeto ou por [aqui](https://github.com/cyzop/HackathonFIAP/blob/main/AgendamentosMedicos.pdf)


# 📋 Tecnologias utilizadas

- Microsoft Azure 
- Microsoft .Net Core 8 WebApi (Back-end)
- Microsoft .Net Blazor WebAsssembly (Front-end)
- EF Core
- XUnit 
- SqlServer (Azure)


## Banco de Dados

Em função do propósito da aplicação representar uma associação entre diferentes entidades, foi utilizado banco de dados relacional onde foi escolhido o Sql Server.

## Framework de Testes

Para garantir a correta integração e que as diferentes partes do sistema funcionem corretamente é essencial que se utilize os testes de integração.
Em nosso projeto, além dos testes unitários, também realizamos testes de integração com xUnit, desta forma é possível verificar se diferentes componentes do sistema funcionam corretamente juntos.

A execução do testes está automatizada no GitHub Actions.

## Arquitetura do Projeto

Para melhorar organização do código, adotamos o uso de diretórios e dentro de cada um os projetos pertinentes. 
Estes diretórios e projetos estão organizados da seguinta maneira:

📁Application
    - Consumer
    - Controller
    - Interfaces
    - Messages
    - Validations
   
📁Domain
   - Entity
   
📁Gateway
   - Gateways
    
📁Infrastructure
   - Mail
   - MassTransit
   - Repository

📁Presenter
   - Api
   - Shared
   - Notification.Api
   - WebApp
   - WebApp.Client

📁UseCase
   - UseCases
 
📁Tests
   📁IntegratedTests
     - PosTech.PortFolio.IntegratedTests

📁Tests
  - UnitTests
   
    
# 🔧 Como executar o projeto (Back End)

## Baixando o código

```bash
# clonar o repositório
git clone https://github.com/cyzop/HackathonFIAP
```

## Sql Server

Pode utilizar tanto a instalação local do banco de dados (Sql Server Express), quanto a utilização do banco Azure

Ajustar a ConnectionString nos arquivos appsettings.json das apis ou através da variáveis de ambiente (recomendado)

Para criação do banco de dados da aplicação, utilizar a Migration existente no projeto MedicalConsultation.Repository.

Para a criação do banco de autenticação, pode-se utilizar a Migration existente no projeto MedicalConsultation.WebApp ou ao acessar a aplicação pela primeira vez será apresentada uma mensagem de erro onde existe a possibilidade de aplicar a migration através de uma opção na tela.

## Envio de Email

Foi adotada solução do Services Communication no Azure para o envio de email e seu acesso fica configurado no projeto MedicalConsultation.Consumer.

## Utilizando o Visual Studio Community 2022 para rodar o projeto localmente

- Abrir a solução do projeto no VS
- Definir a opção "vários projetos de inicialização" e colocar ação de "Iniciar" em:
     - MedicalConsultation.Api
     - MedicalConsultationNotification.Api
     - MedicalConsultation.Consumer
     - MedicalConsultation.WebApp

- Iniciar o projeto com Depuração apertando o F5, para executar o projeto utilizando o Swagger


# Testes

Por possuir uma abordagem mais moderna e facilitando nosso trabalho com a descoberta de testes sem a necessidade de classes especiais, adotamos o framework xUnit que é uma das mais populares para realização de testes em .NET

Utilizamos o xUnit para realizar os testes unitários em nossas projetos, onde cada método é testado isoladamente para garantir que funcione como esperado, independente do restante do sistema.

Abrindo a solução do projeto pelo Visual Studio, os projetos de teste unitários estão dentro da pasta Tests, separados em dois subdiretório. 

## Integrantes do Grupo de Trabalho (Grupo 36)
- Ricardo Moreira RM351064 
