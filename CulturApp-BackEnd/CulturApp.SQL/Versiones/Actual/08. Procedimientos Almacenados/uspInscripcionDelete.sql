-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: Inscripcion
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInscripcionDelete')
  DROP PROCEDURE [dbo].[uspInscripcionDelete]
GO

CREATE PROCEDURE [dbo].[uspInscripcionDelete]
	@InscripcionID	bigint
AS
BEGIN

	DELETE [D] 
	FROM [dbo].[Inscripcion] AS [D] 
	WHERE [D].[InscripcionID] = @InscripcionID

END
GO
