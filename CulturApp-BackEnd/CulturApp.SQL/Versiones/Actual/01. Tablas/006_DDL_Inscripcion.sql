
USE [CulturApp]
GO

IF OBJECT_ID('Inscripcion', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[Inscripcion]
END
GO

CREATE TABLE [dbo].[Inscripcion] (
    [InscripcionID]		BIGINT	IDENTITY (1, 1) NOT NULL,
	[EmpresaID]			BIGINT			NOT NULL,
	[EstimuloID]		BIGINT			NOT NULL,
	[Radicado]			VARCHAR (60)	NOT NULL,
	[TipoID]			BIGINT			NOT NULL,
	[NumRepresentantes]	BIGINT			NULL,
	[FechaHora]			DATETIME		NOT NULL DEFAULT(GETDATE())
    CONSTRAINT [PK_Inscripcion] PRIMARY KEY CLUSTERED ([InscripcionID] ASC),
	CONSTRAINT [FK_Inscripcion_Empresa]	FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[Empresa] ([EmpresaID]),
	CONSTRAINT [FK_Inscripcion_Tipo]	FOREIGN KEY ([TipoID]) REFERENCES [dbo].[Tipo] ([TipoID])
);
