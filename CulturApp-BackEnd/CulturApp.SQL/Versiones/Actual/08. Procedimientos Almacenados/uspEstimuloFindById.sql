-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: Estimulo
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspEstimuloFindById')
  DROP PROCEDURE [dbo].[uspEstimuloFindById]
GO

CREATE PROCEDURE [dbo].[uspEstimuloFindById]
	@EstimuloID	BIGINT
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
	WHERE [E].[EstimuloID] = @EstimuloID

END
GO
