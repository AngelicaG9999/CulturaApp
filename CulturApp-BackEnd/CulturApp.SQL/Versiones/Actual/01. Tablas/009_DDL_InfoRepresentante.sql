

USE [CulturApp]
GO

IF OBJECT_ID('InfoRepresentante', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[InfoRepresentante]
END
GO

CREATE TABLE [dbo].[InfoRepresentante] (
    [InfoRepresentanteID]	BIGINT	IDENTITY (1, 1) NOT NULL,
	[EmpresaID]				BIGINT			NOT NULL,
	[InscripcionID]			BIGINT			NOT NULL,
	[Nombre]				VARCHAR (160)	NOT NULL,
	[Apellido]				VARCHAR (160)	NULL,
	[TipoDocId]				VARCHAR (20)	NOT NULL,
	[DocId]					VARCHAR (20)	NOT NULL,
	[FechaNacimiento]		VARCHAR (30)	NULL,
	[TelefonoFijo]			VARCHAR (30)	NULL,
	[TelefonoMovil]			VARCHAR (30)	NULL,
	[Ciudad]				VARCHAR (30)	NULL,
	[Comuna]				VARCHAR (30)	NULL,
	[Barrio]				VARCHAR (30)	NULL,
	[Direccion]				VARCHAR (30)	NULL,
	[Genero]				VARCHAR (250)	NULL,
	[Sector]				VARCHAR (250)	NULL,
	[GrupoPoblacional]		VARCHAR (250)	NULL,
	[Discapacidades]		VARCHAR (MAX)	NULL,
	[CorreoElectronico]		VARCHAR (250)	NULL,
	[RedesSociales]			VARCHAR (MAX)	NULL,

	[NivelEducativo]		VARCHAR (250)	NULL,
	[NivelFormacionAC]		VARCHAR (250)	NULL,
	[AreasAC]				VARCHAR (250)	NULL,
	[LineaMasTrayectoria]	VARCHAR (250)	NULL,
	[AniosExperiencia]		VARCHAR (250)	NULL,
	[ActividadEconomica]	VARCHAR (250)	NULL,
	[LaboraActualmente]		VARCHAR (250)	NULL,
	[DepencenciaEconomica]	VARCHAR (250)	NULL,
	[RangoSalarial]			VARCHAR (250)	NULL,
	
	[PoseeRut]				VARCHAR (5)		NULL,
	[AfiliadoSegSocial]		VARCHAR (5)		NULL,
	[Eps]					VARCHAR (80)	NULL,
	[ProgramaEstado]		VARCHAR (80)	NULL,
    CONSTRAINT [PK_InfoRepresentante] PRIMARY KEY CLUSTERED ([InfoRepresentanteID] ASC),
	CONSTRAINT [FK_InfoRepresentante_Empresa]	FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[Empresa] ([EmpresaID]),
	CONSTRAINT [FK_InfoRepresentante_Inscripcion]	FOREIGN KEY ([InscripcionID]) REFERENCES [dbo].[Inscripcion] ([InscripcionID])
);
