-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: InfoIntegrante
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoIntegranteEdit')
  DROP PROCEDURE [dbo].[uspInfoIntegranteEdit]
GO

CREATE PROCEDURE [dbo].[uspInfoIntegranteEdit]
	@InfoIntegranteID	BIGINT OUTPUT, 
	@EmpresaID			BIGINT, 
	@InscripcionID		BIGINT,
	@Numero				INT,
	@Nombre				VARCHAR(80), 
	@Apellido			VARCHAR(80), 
	@TipoDocId			VARCHAR(20), 
	@DocId				VARCHAR(20), 
	@TelefonoMovil		VARCHAR(30), 
	@CorreoElectronico	VARCHAR(250), 
	@Genero				VARCHAR(250)

AS
BEGIN
	UPDATE [dbo].[InfoIntegrante]
	SET 
		[EmpresaID]			= @EmpresaID, 
		[InscripcionID]		= @InscripcionID, 
		[Numero]			= @Numero,
		[Nombre]			= @Nombre,
		[Apellido]			= @Apellido, 
		[TipoDocId]			= @TipoDocId, 
		[DocId]				= @DocId, 
		[TelefonoMovil]		= @TelefonoMovil, 
		[CorreoElectronico]	= @CorreoElectronico, 
		[Genero]			= @Genero
	WHERE InfoIntegranteID = @InfoIntegranteID
END
GO
