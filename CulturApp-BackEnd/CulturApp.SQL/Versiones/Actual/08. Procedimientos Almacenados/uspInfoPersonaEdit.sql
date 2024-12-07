-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: InfoPersona
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoPersonaEdit')
  DROP PROCEDURE [dbo].[uspInfoPersonaEdit]
GO

CREATE PROCEDURE [dbo].[uspInfoPersonaEdit]
	@InfoPersonaID		BIGINT OUTPUT, 
	@EmpresaID			BIGINT, 
	@InscripcionID		BIGINT, 
	@Nombre				VARCHAR(80), 
	@Apellido			VARCHAR(80), 
	@TipoDocId			VARCHAR(20), 
	@DocId				VARCHAR(20), 
	@DigVerificacion	VARCHAR(5), 
	@FechaNacimiento	VARCHAR(30), 
	@TelefonoFijo		VARCHAR(30), 
	@TelefonoMovil		VARCHAR(30), 
	@CorreoElectronico	VARCHAR(250), 
	@Genero				VARCHAR(250), 
	@Sector				VARCHAR(250), 
	@Comuna				VARCHAR(250), 
	@Direccion			VARCHAR(250)

AS
BEGIN
	UPDATE [dbo].[InfoPersona]
	SET 
		[EmpresaID]			= @EmpresaID, 
		[InscripcionID]		= @InscripcionID, 
		[Nombre]			= @Nombre, 
		[Apellido]			= @Apellido, 
		[TipoDocId]			= @TipoDocId, 
		[DocId]				= @DocId, 
		[DigVerificacion]	= @DigVerificacion, 
		[FechaNacimiento]	= @FechaNacimiento, 
		[TelefonoFijo]		= @TelefonoFijo, 
		[TelefonoMovil]		= @TelefonoMovil, 
		[CorreoElectronico]	= @CorreoElectronico, 
		[Genero]			= @Genero, 
		[Sector]			= @Sector, 
		[Comuna]			= @Comuna, 
		[Direccion]			= @Direccion
	WHERE InfoPersonaID = @InfoPersonaID
END
GO
