-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: InfoIntegrante
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoIntegranteFindAll')
  DROP PROCEDURE [dbo].[uspInfoIntegranteFindAll]
GO

CREATE PROCEDURE [dbo].[uspInfoIntegranteFindAll]
	@EmpresaID	BIGINT, 
	@Nombre		VARCHAR(60) = NULL
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
	WHERE 
		([II].[EmpresaID] = @EmpresaID)
	AND (@Nombre IS NULL OR [II].[Nombre] LIKE @Nombre)
	ORDER BY [II].[Nombre]

END
GO

