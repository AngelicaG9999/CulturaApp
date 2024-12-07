-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: InfoIntegrante
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoIntegranteDelete')
  DROP PROCEDURE [dbo].[uspInfoIntegranteDelete]
GO

CREATE PROCEDURE [dbo].[uspInfoIntegranteDelete]
@InfoIntegranteID	bigint
AS
BEGIN

	DELETE [II] 
	FROM [dbo].[InfoIntegrante] AS [II] 
	WHERE [II].[InfoIntegranteID] = @InfoIntegranteID

END
GO
