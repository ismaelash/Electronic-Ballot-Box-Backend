USE [HubCountDatabase]
GO

/****** Object:  Table [dbo].[Candidatos]    Script Date: 12/02/2021 17:58:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Candidatos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeCandidato] [varchar](255) NOT NULL,
	[NomeVice] [varchar](255) NOT NULL,
	[DataRegistro] [datetime] NOT NULL,
	[Legenda] [int] NOT NULL,
 CONSTRAINT [PK_Candidatos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


