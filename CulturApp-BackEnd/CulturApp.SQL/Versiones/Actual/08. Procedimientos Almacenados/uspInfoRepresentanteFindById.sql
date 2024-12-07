-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-12
-- Descripción: InfoRepresentante
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoRepresentanteFindById')
  DROP PROCEDURE [dbo].[uspInfoRepresentanteFindById]
GO

CREATE PROCEDURE [dbo].[uspInfoRepresentanteFindById]
	@InfoRepresentanteID	BIGINT
AS
BEGIN
	
	SELECT
		[IR].[InfoRepresentanteID],
		[IR].[EmpresaID],
		[IR].[InscripcionID],
		[IR].[Nombre],
		[IR].[Apellido],
		[IR].[TipoDocId],
		[IR].[DocId],
		[IR].[FechaNacimiento],
		[IR].[TelefonoFijo],
		[IR].[TelefonoMovil],
		[IR].[Ciudad],
		[IR].[Comuna],
		[IR].[Barrio],
		[IR].[Direccion],
		[IR].[Genero],
		[IR].[Sector],
		[IR].[GrupoPoblacional],
		[IR].[Discapacidades],
		[IR].[CorreoElectronico],
		[IR].[RedesSociales],
		[IR].[NivelEducativo],
		[IR].[NivelFormacionAC],
		[IR].[AreasAC],
		[IR].[LineaMasTrayectoria],
		[IR].[AniosExperiencia],
		[IR].[ActividadEconomica],
		[IR].[LaboraActualmente],
		[IR].[DepencenciaEconomica],
		[IR].[RangoSalarial],
		[IR].[PoseeRut],
		[IR].[AfiliadoSegSocial],
		[IR].[Eps],
		[IR].[ProgramaEstado]
	FROM [dbo].[InfoRepresentante] AS [IR]
		INNER JOIN [dbo].[Empresa] AS [E] ON [IR].[EmpresaID] = [E].[EmpresaID]
	WHERE 
		[IR].[InfoRepresentanteID] = @InfoRepresentanteID

END
GO
