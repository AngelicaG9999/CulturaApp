-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-13
-- Descripción: InfoProyecto
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoProyectoDelete')
  DROP PROCEDURE [dbo].[uspInfoProyectoDelete]
GO

CREATE PROCEDURE [dbo].[uspInfoProyectoDelete]
	@InfoProyectoID	bigint
AS
BEGIN

	DELETE [D] 
	FROM [dbo].[InfoProyecto] AS [D] 
	WHERE [D].[InfoProyectoID] = @InfoProyectoID

END
GO
