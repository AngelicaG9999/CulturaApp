-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: InfoPersona
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoPersonaFindById')
  DROP PROCEDURE [dbo].[uspInfoPersonaFindById]
GO

CREATE PROCEDURE [dbo].[uspInfoPersonaFindById]
	@InfoPersonaID	BIGINT
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
	WHERE [IP].[InfoPersonaID] = @InfoPersonaID

END
GO
