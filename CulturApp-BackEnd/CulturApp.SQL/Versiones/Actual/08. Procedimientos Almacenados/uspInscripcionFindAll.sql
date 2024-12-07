-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: Inscripcion
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInscripcionFindAll')
  DROP PROCEDURE [dbo].[uspInscripcionFindAll]
GO

CREATE PROCEDURE [dbo].[uspInscripcionFindAll]
	@EmpresaID	BIGINT, 
	@Radicado	VARCHAR(60) = NULL
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
	WHERE 
		([I].[EmpresaID] = @EmpresaID)
	AND (@Radicado IS NULL OR [I].[Radicado] LIKE @Radicado)
	ORDER BY [I].[Radicado]

END
GO

