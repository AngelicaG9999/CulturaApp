-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: InfoIntegrante
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoIntegranteFindById')
  DROP PROCEDURE [dbo].[uspInfoIntegranteFindById]
GO

CREATE PROCEDURE [dbo].[uspInfoIntegranteFindById]
	@InfoIntegranteID	BIGINT
AS
BEGIN
	
	SELECT
		[II].[InfoIntegranteID],
		[II].[EmpresaID],
		[II].[InscripcionID],
		[II].[Numero],
		[II].[Nombre],
		[II].[Apellido],
		[II].[TipoDocId],
		[II].[DocId],
		[II].[TelefonoMovil],
		[II].[CorreoElectronico],
		[II].[Genero]
	FROM [dbo].[InfoIntegrante] AS [II]
		INNER JOIN [dbo].[Empresa] AS [E] ON [II].[EmpresaID] = [E].[EmpresaID]
	WHERE [II].[InfoIntegranteID] = @InfoIntegranteID

END
GO
