-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: Estimulo
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspEstimuloFindAll')
  DROP PROCEDURE [dbo].[uspEstimuloFindAll]
GO

CREATE PROCEDURE [dbo].[uspEstimuloFindAll]
	@EmpresaID	BIGINT,
	@Nombre		VARCHAR(250)
AS
BEGIN
	
	SELECT
		[E].[EstimuloID],
		[E].[EmpresaID],
		[E].[Codigo],
		[E].[Nombre],
		[E].[FechaApertura],
		[E].[FechaCierre],
		[E].[Descripcion],
		[E].[Cerrado]
	FROM [dbo].[Estimulo] AS [E]
		INNER JOIN [dbo].[Empresa] AS [E2] ON [E].[EmpresaID] = [E2].[EmpresaID]
	WHERE 
		([E].[EmpresaID] = @EmpresaID)
	AND (@Nombre IS NULL OR [E].[Nombre] LIKE @Nombre)
	ORDER BY [E].[Nombre]

END
GO
