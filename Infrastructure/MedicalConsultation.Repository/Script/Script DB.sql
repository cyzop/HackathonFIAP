
CREATE TABLE [dbo].[Consulta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PacienteId] [int] NOT NULL,
	[MedicoId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[DataStatus] [datetime] NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medico]    Script Date: 27/10/2024 17:24:20 ******/

CREATE TABLE [dbo].[Medico](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[CRM] [varchar](20) NOT NULL,
	[Especialidade] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Medico] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notificacao]    Script Date: 27/10/2024 17:24:20 ******/
CREATE TABLE [dbo].[Notificacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [varchar](500) NOT NULL,
	[Data] [datetime] NOT NULL,
	[ConsultaId] [int] NOT NULL,
	[Ativo] [bit] NOT NULL,
	[StatusConsulta] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Notificacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 27/10/2024 17:24:20 ******/
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CPF] [varchar](14) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Notificacao] ADD  DEFAULT (N'') FOR [StatusConsulta]
GO
ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Medico_MedicoId] FOREIGN KEY([MedicoId])
REFERENCES [dbo].[Medico] ([Id])
GO
ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Medico_MedicoId]
GO
ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Usuario_PacienteId] FOREIGN KEY([PacienteId])
REFERENCES [dbo].[Usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Usuario_PacienteId]
GO
ALTER TABLE [dbo].[Medico]  WITH CHECK ADD  CONSTRAINT [FK_Medico_Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Medico] CHECK CONSTRAINT [FK_Medico_Usuario_UsuarioId]
GO
ALTER TABLE [dbo].[Notificacao]  WITH CHECK ADD  CONSTRAINT [FK_Notificacao_Consulta_ConsultaId] FOREIGN KEY([ConsultaId])
REFERENCES [dbo].[Consulta] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notificacao] CHECK CONSTRAINT [FK_Notificacao_Consulta_ConsultaId]
GO
