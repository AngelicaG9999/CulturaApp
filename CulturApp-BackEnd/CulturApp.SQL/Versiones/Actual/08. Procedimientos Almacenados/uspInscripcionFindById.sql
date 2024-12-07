-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: Inscripcion
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInscripcionFindById')
  DROP PROCEDURE [dbo].[uspInscripcionFindById]
GO

CREATE PROCEDURE [dbo].[uspInscripcionFindById]
	@InscripcionID	BIGINT
AS
BEGIN
	
	SELECT
		[I].[InscripcionID],
		[I].[EmpresaID],
		[I].[EstimuloID],
		[I].[Radicado],
		[I].[TipoID],
		[I].[NumIntegrantes],
		[I].[FechaHora]
	FROM [dbo].[Inscripcion] AS [I]
	WHERE [I].[InscripcionID] = @InscripcionID

END
GO
