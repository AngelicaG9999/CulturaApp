-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-12
-- Descripción: InfoRepresentante
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoRepresentanteDelete')
  DROP PROCEDURE [dbo].[uspInfoRepresentanteDelete]
GO

CREATE PROCEDURE [dbo].[uspInfoRepresentanteDelete]
	@InfoRepresentanteID	bigint
AS
BEGIN

	DELETE [D] 
	FROM [dbo].[InfoRepresentante] AS [D] 
	WHERE [D].[InfoRepresentanteID] = @InfoRepresentanteID

END
GO
