-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: InfoPersona
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoPersonaFindAll')
  DROP PROCEDURE [dbo].[uspInfoPersonaFindAll]
GO

CREATE PROCEDURE [dbo].[uspInfoPersonaFindAll]
	@EmpresaID	BIGINT, 
	@Nombre		VARCHAR(60) = NULL
AS
BEGIN
	
	SELECT
		[IP].[InfoPersonaID],
		[IP].[EmpresaID],
		[IP].[InscripcionID],
		[IP].[Nombre],
		[IP].[Apellido],
		[IP].[TipoDocId],
		[IP].[DocId],
		[IP].[DigVerificacion],
		[IP].[FechaNacimiento],
		[IP].[TelefonoFijo],
		[IP].[TelefonoMovil],
		[IP].[CorreoElectronico],
		[IP].[Genero],
		[IP].[Sector],
		[IP].[Comuna],
		[IP].[Direccion]
	FROM [dbo].[InfoPersona] AS [IP]
		INNER JOIN [dbo].[Empresa] AS [E] ON [IP].[EmpresaID] = [E].[EmpresaID]
	WHERE 
		([IP].[EmpresaID] = @EmpresaID)
	AND (@Nombre IS NULL OR [IP].[Nombre] LIKE @Nombre)
	ORDER BY [IP].[Nombre]

END
GO

