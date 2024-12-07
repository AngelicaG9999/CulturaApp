
USE [CulturApp]
GO

IF OBJECT_ID('Estimulo', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[Estimulo]
END
GO

CREATE TABLE [dbo].[Estimulo] (
    [EstimuloID]	BIGINT	IDENTITY (1, 1) NOT NULL,
	[EmpresaID]		BIGINT			NOT NULL,
	[Codigo]		VARCHAR (25)	NOT NULL,
    [Nombre]		VARCHAR (250)	NOT NULL,
	[FechaApertura]	DATETIME		NOT NULL,
	[FechaCierre]	DATETIME		NOT NULL,
	[Descripcion]	VARCHAR (max)	NULL,
	[Cerrado]		BIT				NOT NULL DEFAULT(0),
    CONSTRAINT [PK_Estimulo] PRIMARY KEY CLUSTERED ([EstimuloID] ASC),
	CONSTRAINT [FK_Estimulo_Empresa]	FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[Empresa] ([EmpresaID])
);
