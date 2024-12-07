
USE [CulturApp]
GO

IF OBJECT_ID('Modalidad', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[Modalidad]
END
GO

CREATE TABLE [dbo].[Modalidad] (
    [ModalidadID]	BIGINT	IDENTITY (1, 1) NOT NULL,
	[EmpresaID]		BIGINT			NOT NULL,
    [Nombre]		VARCHAR (250)	NOT NULL,
	[Descripcion]	VARCHAR (max)	NULL,
    CONSTRAINT [PK_Modalidad] PRIMARY KEY CLUSTERED ([ModalidadID] ASC),
	CONSTRAINT [FK_Modalidad_Empresa]	FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[Empresa] ([EmpresaID])
);
