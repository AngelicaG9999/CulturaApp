-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: InfoPersona
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoPersonaAdd')
  DROP PROCEDURE [dbo].[uspInfoPersonaAdd]
GO

CREATE PROCEDURE [dbo].[uspInfoPersonaAdd]
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

	INSERT INTO [dbo].[InfoPersona]
		 ([EmpresaID], [InscripcionID], [Nombre], [Apellido], [TipoDocId], [DocId], [DigVerificacion], [FechaNacimiento], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico], [Genero], [Sector], [Comuna], [Direccion])
	VALUES
		 (@EmpresaID, @InscripcionID, @Nombre, @Apellido, @TipoDocId, @DocId, @DigVerificacion, @FechaNacimiento, @TelefonoFijo, @TelefonoMovil, @CorreoElectronico, @Genero, @Sector, @Comuna, @Direccion)


		 SET @InfoPersonaID =SCOPE_IDENTITY()
END
GO
