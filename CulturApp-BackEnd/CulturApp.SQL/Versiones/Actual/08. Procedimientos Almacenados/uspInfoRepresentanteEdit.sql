-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-12
-- Descripción: InfoRepresentante
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoRepresentanteEdit')
  DROP PROCEDURE [dbo].[uspInfoRepresentanteEdit]
GO

CREATE PROCEDURE [dbo].[uspInfoRepresentanteEdit]
	@InfoRepresentanteID	BIGINT, 
	@EmpresaID				BIGINT, 
	@InscripcionID			BIGINT, 
	@Nombre					VARCHAR(160), 
	@Apellido				VARCHAR(160), 
	@TipoDocId				VARCHAR(20), 
	@DocId					VARCHAR(20), 
	@FechaNacimiento		VARCHAR(30), 
	@TelefonoFijo			VARCHAR(30), 
	@TelefonoMovil			VARCHAR(30), 
	@Ciudad					VARCHAR(30), 
	@Comuna					VARCHAR(30), 
	@Barrio					VARCHAR(30), 
	@Direccion				VARCHAR(30), 
	@Genero					VARCHAR(250), 
	@Sector					VARCHAR(250), 
	@GrupoPoblacional		VARCHAR(250), 
	@Discapacidades			VARCHAR(MAX), 
	@CorreoElectronico		VARCHAR(250), 
	@RedesSociales			VARCHAR(MAX), 
	@NivelEducativo			VARCHAR(250), 
	@NivelFormacionAC		VARCHAR(250), 
	@AreasAC				VARCHAR(250), 
	@LineaMasTrayectoria	VARCHAR(250), 
	@AniosExperiencia		VARCHAR(250), 
	@ActividadEconomica		VARCHAR(250), 
	@LaboraActualmente		VARCHAR(250), 
	@DepencenciaEconomica	VARCHAR(250), 
	@RangoSalarial			VARCHAR(250), 
	@PoseeRut				VARCHAR(5), 
	@AfiliadoSegSocial		VARCHAR(5), 
	@Eps					VARCHAR(80), 
	@ProgramaEstado			VARCHAR(80)

AS
BEGIN
	UPDATE [dbo].[InfoRepresentante]
	SET 
		[EmpresaID]				= @EmpresaID, 
		[InscripcionID]			= @InscripcionID, 
		[Nombre]				= @Nombre, 
		[Apellido]				= @Apellido, 
		[TipoDocId]				= @TipoDocId, 
		[DocId]					= @DocId, 
		[FechaNacimiento]		= @FechaNacimiento, 
		[TelefonoFijo]			= @TelefonoFijo, 
		[TelefonoMovil]			= @TelefonoMovil, 
		[Ciudad]				= @Ciudad, 
		[Comuna]				= @Comuna, 
		[Barrio]				= @Barrio, 
		[Direccion]				= @Direccion, 
		[Genero]				= @Genero, 
		[Sector]				= @Sector, 
		[GrupoPoblacional]		= @GrupoPoblacional, 
		[Discapacidades]		= @Discapacidades, 
		[CorreoElectronico]		= @CorreoElectronico, 
		[RedesSociales]			= @RedesSociales, 
		[NivelEducativo]		= @NivelEducativo, 
		[NivelFormacionAC]		= @NivelFormacionAC, 
		[AreasAC]				= @AreasAC, 
		[LineaMasTrayectoria]	= @LineaMasTrayectoria, 
		[AniosExperiencia]		= @AniosExperiencia, 
		[ActividadEconomica]	= @ActividadEconomica, 
		[LaboraActualmente]		= @LaboraActualmente, 
		[DepencenciaEconomica]	= @DepencenciaEconomica, 
		[RangoSalarial]			= @RangoSalarial, 
		[PoseeRut]				= @PoseeRut, 
		[AfiliadoSegSocial]		= @AfiliadoSegSocial, 
		[Eps]					= @Eps, 
		[ProgramaEstado]		= @ProgramaEstado
	WHERE InfoRepresentanteID	= @InfoRepresentanteID
END
GO
