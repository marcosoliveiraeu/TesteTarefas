USE [DB_TesteTarefas]
GO

/****** Object:  Table [dbo].[StatusTarefas]    Script Date: 12/07/2024 17:28:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StatusTarefas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_StatusTarefas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Tarefas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](100) NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[StatusId] [int] NOT NULL,
	[DtAbertura] [datetime2](7) NOT NULL,
	[DtConclusao] [datetime2](7) NULL,
 CONSTRAINT [PK_Tarefas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tarefas]  WITH CHECK ADD  CONSTRAINT [FK_Tarefas_StatusTarefas_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[StatusTarefas] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Tarefas] CHECK CONSTRAINT [FK_Tarefas_StatusTarefas_StatusId]
GO

INSERT INTO [dbo].[StatusTarefas]
           ([Descricao])
     VALUES
           ('Pendente')
GO

INSERT INTO [dbo].[StatusTarefas]
           ([Descricao])
     VALUES
           ('Concluída')
GO


INSERT INTO [dbo].[Tarefas]
           ([Titulo]
           ,[Descricao]
           ,[StatusId]
           ,[DtAbertura]
           ,[DtConclusao])
     VALUES
           ('Primeira tarefa'
           ,'blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla '
           ,1
           ,GETDATE()
           ,null)
GO

INSERT INTO [dbo].[Tarefas]
           ([Titulo]
           ,[Descricao]
           ,[StatusId]
           ,[DtAbertura]
           ,[DtConclusao])
     VALUES
           ('Segunda tarefa'
           ,'blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla '
           ,1
           ,GETDATE()
           ,null)
GO

INSERT INTO [dbo].[Tarefas]
           ([Titulo]
           ,[Descricao]
           ,[StatusId]
           ,[DtAbertura]
           ,[DtConclusao])
     VALUES
           ('Terceira tarefa'
           ,'blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla '
           ,2
           ,GETDATE()
           ,GETDATE())
GO

INSERT INTO [dbo].[Tarefas]
           ([Titulo]
           ,[Descricao]
           ,[StatusId]
           ,[DtAbertura]
           ,[DtConclusao])
     VALUES
           ('Quarta tarefa'
           ,'blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla '
           ,2
           ,GETDATE()
           ,GETDATE())
GO



select * from [dbo].[StatusTarefas]
select * from [dbo].[Tarefas]