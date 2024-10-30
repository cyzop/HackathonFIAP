# Hackathon - 2NETT - 2024 : Sistema de Agendamento de Consultas
[![License](https://img.shields.io/badge/license-MIT-green)](./LICENSE)

# Sobre o Projeto

O Sistema de Agendamento de Consultas foi desenvolvido em .Net Core (8) para atender ao Hackathon do curso ARQUITETURA DE SISTEMAS .NET COM AZURE da FIAP - Turma 2NETT.

Este sistema tem o intuito de permitir o usuário, no papel de Paciente, agendar, reagendar ou cancelar consultas. Neste sistema o usuário logado também poderá ser um Médico onde além da gestão com Paciente ele terá a gestão dos agendamentos para atendimento médico. 
No sistema o usuário pode se cadastrar, como Paciente, definido uma senha que atenda aos critérios de senha forte, verificar seu e-mail e acessar a aplicação.

A aplicação apresenta um menu com acesso aos agendamento já realizados, onde também é possível realizar novos agendamentos, reagendar ou cancelar algum já existente. No caso do usuário logado também ser um Médico existirá o acesso, na tela principal, para a agenda dos atendimentos.

O cadastro de Médicos não está junto das telas do sistema pois fui pensado para ser um módulo à parte. As rotas para a gestão do médico estão dispostas na api da aplicação onde o swagger está ligado permitindo o cadatro dos mesmos.

Para utilizar o sistema é exigido que o usuário esteja logado.

Este repositório se refere tanto ao Front-end (Blazor) quanto ao Back-end da aplicação onde pode-se utilizar o Swagger para acesso aos endpoints disponíveis a nível de validação/teste. 

# Requisitos

O documento com o levanto de requisitos do software e seus critérios de aceite podem ser encontradas no arquivo "AgendamentosMedicos.pdf" na raiz do projeto ou por [aqui](https://github.com/cyzop/HackathonFIAP/blob/main/AgendamentosMedicos.pdf)


# 📋 Tecnologias utilizadas

- Microsoft Azure 
- Microsoft .Net Core 8 WebApi (Back-end)
- Microsoft .Net Blazor WebAsssembly (Front-end)
- Messageria (Azure Service Bus)
- Email (Azure Communication Services)
- EF Core (SQLServer)
- XUnit 
- SqlServer (Azure DBaaS)


## Banco de Dados

Em função do propósito da aplicação representar uma associação entre diferentes entidades, foi utilizado banco de dados relacional onde foi escolhido o Sql Server, solução também utilizada para fluxo de autenticação de usuários (Blazor WebAssembly with Individual Accounts).

## Framework de Testes

Como solução de testes foi adotada a framework xUnit oferecendo cobertura de teste para as regras de negócios e principais parte do sistema. 

A execução do testes está automatizada no GitHub Actions.

## Arquitetura do Projeto

Visando refletir em arquitetura limpa e para melhorar organização do código, adotamos o uso de subdiretórios, na solution do sistema, onde estão dentro de cada um os projetos pertinentes. 
Estes diretórios e projetos estão organizados da seguinta maneira:

📁Application
   - Consumer   
   - Controller 
   - Interfaces
   - Messages
   - Validations
   - UseCases
   
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

Para criação do banco de dados da aplicação, utilizar o Script que está no projeto MedicalConsultation.Repository.

Para a criação do banco de autenticação, pode-se utilizar a Migration existente no projeto MedicalConsultation.WebApp ou ao acessar a aplicação pela primeira vez será apresentada uma mensagem de erro onde existe a possibilidade de aplicar a migration através de uma opção na tela.

## Envio de Email

Foi adotada solução do Services Communication no Azure para o envio de email e seu acesso fica configurado no projeto MedicalConsultation.Consumer.

O Consumer é um WorkProcess que fica monitorando a fila e assim que chega mensagem ele realiza o envio. 

A geração da mensagem de e-mail, que é colocada na fila para ser enviada, é feita os momentos de alteração de um agendamento, como Agendar, Reagendar ou Cancelar a consulta e também através de um processo de verificação e disparo por uma rota na api de monitoramento.
Esta api de monitoramento foi feita com o intuido de permitir que um Schedule possa chamá-la onde ela irá notificar as consultas agendadas para o dia seguinte. Esta rotina deve ser schedulada para ser executada diária, a fim de servir como lembrete da consulta do usuário.

## Utilizando o Visual Studio Community 2022 para rodar o projeto localmente

- Abrir a solução do projeto no VS
- Definir a opção "vários projetos de inicialização" e colocar ação de "Iniciar" em:
     - MedicalConsultation.Api
     - MedicalConsultationNotification.Api
     - MedicalConsultation.Consumer
     - MedicalConsultation.WebApp
- Ajustar as informações em cada projeto, no appsettings ou em variáveis de ambiente com:
     - String de Conexao com o banco de dados
     - Url do Azure Bus
     - Endereço para envio do Email
- Iniciar o projeto com Depuração apertando o F5, para executar o projeto utilizando o Swagger

# Docker

Os projetos também podem ser utilizados através do docker. Em cada projeto envolvido existe o arquivo Dockerfile assim com Docker-compose na solution.

# Testes

Por possuir uma abordagem mais moderna e facilitando nosso trabalho com a descoberta de testes sem a necessidade de classes especiais, adotamos o framework xUnit que é uma das mais populares para realização de testes em .NET

Utilizamos o xUnit para realizar os testes unitários em nossas projetos, onde cada método é testado isoladamente para garantir que funcione como esperado, independente do restante do sistema.

Abrindo a solução do projeto pelo Visual Studio, os projetos de teste unitários estão dentro da pasta Tests, separados em dois subdiretório. 

## Integrantes do Grupo de Trabalho (Grupo 36)
- Ricardo Moreira RM351064 
