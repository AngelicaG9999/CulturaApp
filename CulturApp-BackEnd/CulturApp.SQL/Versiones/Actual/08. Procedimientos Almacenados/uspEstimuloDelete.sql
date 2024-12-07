-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: Estimulo
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspEstimuloDelete')
  DROP PROCEDURE [dbo].[uspEstimuloDelete]
GO

CREATE PROCEDURE [dbo].[uspEstimuloDelete]
	@EstimuloID	bigint
AS
BEGIN

	DELETE [D] 
	FROM [dbo].[Estimulo] AS [D] 
	WHERE [D].[EstimuloID] = @EstimuloID

END
GO
