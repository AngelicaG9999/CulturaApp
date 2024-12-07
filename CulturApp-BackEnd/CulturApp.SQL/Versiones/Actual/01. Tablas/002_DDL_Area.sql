
USE [CulturApp]
GO

IF OBJECT_ID('Area', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[Area]
END
GO

CREATE TABLE [dbo].[Area] (
    [AreaID]		BIGINT	IDENTITY (1, 1) NOT NULL,
	[EmpresaID]		BIGINT			NOT NULL,
	[ModalidadID]	BIGINT			NOT NULL,
    [Nombre]		VARCHAR (250)	NOT NULL,
	[Descripcion]	VARCHAR (max)	NULL,
    CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED ([AreaID] ASC),
	CONSTRAINT [FK_Area_Empresa]	FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[Empresa] ([EmpresaID]),
	CONSTRAINT [FK_Area_Modalidad]	FOREIGN KEY ([ModalidadID]) REFERENCES [dbo].[Modalidad] ([ModalidadID])
);
