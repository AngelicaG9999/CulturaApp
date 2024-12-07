-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-12
-- Descripción: InfoRepresentante
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoRepresentanteAdd')
  DROP PROCEDURE [dbo].[uspInfoRepresentanteAdd]
GO

CREATE PROCEDURE [dbo].[uspInfoRepresentanteAdd]
	@InfoRepresentanteID	BIGINT OUTPUT, 
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
	INSERT INTO [dbo].[InfoRepresentante]
		 ([EmpresaID], [InscripcionID], [Nombre], [Apellido], [TipoDocId], [DocId], [FechaNacimiento], [TelefonoFijo], [TelefonoMovil], [Ciudad], [Comuna], [Barrio], [Direccion], [Genero], [Sector], [GrupoPoblacional], [Discapacidades], [CorreoElectronico], [RedesSociales], [NivelEducativo], [NivelFormacionAC], [AreasAC], [LineaMasTrayectoria], [AniosExperiencia], [ActividadEconomica], [LaboraActualmente], [DepencenciaEconomica], [RangoSalarial], [PoseeRut], [AfiliadoSegSocial], [Eps], [ProgramaEstado])
	VALUES
		 (@EmpresaID, @InscripcionID, @Nombre, @Apellido, @TipoDocId, @DocId, @FechaNacimiento, @TelefonoFijo, @TelefonoMovil, @Ciudad, @Comuna, @Barrio, @Direccion, @Genero, @Sector, @GrupoPoblacional, @Discapacidades, @CorreoElectronico, @RedesSociales, @NivelEducativo, @NivelFormacionAC, @AreasAC, @LineaMasTrayectoria, @AniosExperiencia, @ActividadEconomica, @LaboraActualmente, @DepencenciaEconomica, @RangoSalarial, @PoseeRut, @AfiliadoSegSocial, @Eps, @ProgramaEstado)

		 SET @InfoRepresentanteID = SCOPE_IDENTITY()

END
GO
