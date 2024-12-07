

USE [CulturApp]
GO

IF OBJECT_ID('Empresa', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[Empresa]
END
GO

CREATE TABLE [dbo].[Empresa](
	[EmpresaID]		BIGINT NOT NULL,
	[Codigo]		VARCHAR (20) NOT NULL,
	[Nombre]		VARCHAR (80) NOT NULL,
	[Email]			VARCHAR (120) NULL,
	[FechaRegistro]	DATE NOT NULL,
	[Activo]		BIT	NOT NULL,
	CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED ([EmpresaID] ASC)
)
GO





