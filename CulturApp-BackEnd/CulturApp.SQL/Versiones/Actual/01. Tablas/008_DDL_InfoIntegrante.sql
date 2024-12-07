

USE [CulturApp]
GO

IF OBJECT_ID('InfoIntegrante', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[InfoIntegrante]
END
GO

CREATE TABLE [dbo].[InfoIntegrante] (
    [InfoIntegranteID]	BIGINT	IDENTITY (1, 1) NOT NULL,
	[EmpresaID]				BIGINT			NOT NULL,
	[InscripcionID]			BIGINT			NOT NULL,
	[Numero]				INT				NOT NULL DEFAULT(0),
	[Nombre]				VARCHAR (160)	NOT NULL,
	[Apellido]				VARCHAR (160)	NULL,
	[TipoDocId]				VARCHAR (20)	NOT NULL,
	[DocId]					VARCHAR (20)	NOT NULL,
	[TelefonoMovil]			VARCHAR (30)	NULL,
	[CorreoElectronico]		VARCHAR (250)	NULL,
	[Genero]				VARCHAR (250)	NULL
    CONSTRAINT [PK_InfoIntegrante] PRIMARY KEY CLUSTERED ([InfoIntegranteID] ASC),
	CONSTRAINT [FK_InfoIntegrante_Empresa]	FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[Empresa] ([EmpresaID]),
	CONSTRAINT [FK_InfoIntegrante_Inscripcion]	FOREIGN KEY ([InscripcionID]) REFERENCES [dbo].[Inscripcion] ([InscripcionID])
);
