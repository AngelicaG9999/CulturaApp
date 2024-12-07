
USE [CulturApp]
GO

IF OBJECT_ID('Tipo', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[Tipo]
END
GO

CREATE TABLE [dbo].[Tipo] (
    [TipoID]		BIGINT	IDENTITY (1, 1) NOT NULL,
	[EmpresaID]		BIGINT			NOT NULL,
    [Nombre]		VARCHAR (250)	NOT NULL,
	[Descripcion]	VARCHAR (max)	NULL
    CONSTRAINT [PK_Tipo] PRIMARY KEY CLUSTERED ([TipoID] ASC),
	CONSTRAINT [FK_Tipo_Empresa]	FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[Empresa] ([EmpresaID])
);
