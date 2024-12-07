
USE [CulturApp]
GO

IF OBJECT_ID('Linea', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[Linea]
END
GO

CREATE TABLE [dbo].[Linea] (
    [LineaID]		BIGINT	IDENTITY (1, 1) NOT NULL,
	[EmpresaID]		BIGINT			NOT NULL,
	[AreaID]		BIGINT			NOT NULL,
    [Nombre]		VARCHAR (250)	NOT NULL,
	[Descripcion]	VARCHAR (max)	NULL,
    CONSTRAINT [PK_Linea] PRIMARY KEY CLUSTERED ([LineaID] ASC),
	CONSTRAINT [FK_Linea_Empresa]	FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[Empresa] ([EmpresaID]),
	CONSTRAINT [FK_Linea_Area]	FOREIGN KEY ([AreaID]) REFERENCES [dbo].[Area] ([AreaID])
);
