-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: InfoPersona
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoPersonaDelete')
  DROP PROCEDURE [dbo].[uspInfoPersonaDelete]
GO

CREATE PROCEDURE [dbo].[uspInfoPersonaDelete]
@InfoPersonaID	bigint
AS
BEGIN

	DELETE [D] 
	FROM [dbo].[InfoPersona] AS [D] 
	WHERE [D].[InfoPersonaID] = @InfoPersonaID

END
GO
