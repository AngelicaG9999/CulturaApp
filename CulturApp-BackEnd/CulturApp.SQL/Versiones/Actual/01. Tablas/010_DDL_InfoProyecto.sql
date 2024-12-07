

USE [CulturApp]
GO

IF OBJECT_ID('InfoProyecto', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[InfoProyecto]
END
GO

CREATE TABLE [dbo].[InfoProyecto] (
    [InfoProyectoID]			BIGINT	IDENTITY (1, 1) NOT NULL,
	[EmpresaID]					BIGINT			NOT NULL,
	[InscripcionID]				BIGINT			NOT NULL,
	[Titulo]					VARCHAR (MAX)	NOT NULL,
	[LineaID]					BIGINT			NOT NULL,
	[ProyectoUrl]				VARCHAR (MAX)	NOT NULL,
	[CurriculumUrl]				VARCHAR (MAX)	NULL,
	[CedulaUrl]					VARCHAR (MAX)	NULL,
	[ServiciosPublicosUrl]		VARCHAR (MAX)	NULL,
	[RutUrl]					VARCHAR (MAX)	NULL,
	[CertificadoVencindadUrl]	VARCHAR (MAX)	NULL,
	[AutorizacionMenoresUrl]	VARCHAR (MAX)	NULL,
	[DeclaracionJuramentadaUrl]	VARCHAR (MAX)	NULL,
	[MaquetaUrl]				VARCHAR (MAX)	NULL,
	[CamaraDeComercioUrl]		VARCHAR (MAX)	NULL
    CONSTRAINT [PK_InfoProyecto]				PRIMARY KEY CLUSTERED ([InfoProyectoID] ASC),
	CONSTRAINT [FK_InfoProyecto_Empresa]		FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[Empresa] ([EmpresaID]),
	CONSTRAINT [FK_InfoProyecto_Inscripcion]	FOREIGN KEY ([InscripcionID]) REFERENCES [dbo].[Inscripcion] ([InscripcionID])
);
