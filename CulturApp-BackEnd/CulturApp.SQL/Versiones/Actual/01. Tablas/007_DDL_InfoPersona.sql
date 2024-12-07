
USE [CulturApp]
GO

IF OBJECT_ID('InfoPersona', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[InfoPersona]
END
GO

CREATE TABLE [dbo].[InfoPersona] (
    [InfoPersonaID]		BIGINT	IDENTITY (1, 1) NOT NULL,
	[EmpresaID]			BIGINT			NOT NULL,
	[InscripcionID]		BIGINT			NOT NULL,
	[Nombre]			VARCHAR (80)	NOT NULL,
	[Apellido]			VARCHAR (80)	NULL,
	[TipoDocId]			VARCHAR (20)	NOT NULL,
	[DocId]				VARCHAR (20)	NOT NULL,
	[DigVerificacion]	VARCHAR (5)		NULL,
	[FechaNacimiento]	VARCHAR (30)	NULL,
	[TelefonoFijo]		VARCHAR (30)	NULL,
	[TelefonoMovil]		VARCHAR (30)	NULL,
	[CorreoElectronico]	VARCHAR (250)	NULL,
	[Genero]			VARCHAR (250)	NULL,
	[Sector]			VARCHAR (250)	NULL,
	[Comuna]			VARCHAR (250)	NULL,
	[Direccion]			VARCHAR (250)	NULL
    CONSTRAINT [PK_InfoPersona] PRIMARY KEY CLUSTERED ([InfoPersonaID] ASC),
	CONSTRAINT [FK_InfoPersona_Empresa]	FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[Empresa] ([EmpresaID]),
	CONSTRAINT [FK_InfoPersona_Inscripcion]	FOREIGN KEY ([InscripcionID]) REFERENCES [dbo].[Inscripcion] ([InscripcionID])
);
