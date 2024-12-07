-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: InfoIntegrante
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoIntegranteAdd')
  DROP PROCEDURE [dbo].[uspInfoIntegranteAdd]
GO

CREATE PROCEDURE [dbo].[uspInfoIntegranteAdd]
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

	INSERT INTO [dbo].[InfoIntegrante]
		 ([EmpresaID], [InscripcionID], [Numero], [Nombre], [Apellido], [TipoDocId], [DocId], [TelefonoMovil], [CorreoElectronico], [Genero])
	VALUES
		 (@EmpresaID, @InscripcionID, @Numero, @Nombre, @Apellido, @TipoDocId, @DocId, @TelefonoMovil, @CorreoElectronico, @Genero)


		 SET @InfoIntegranteID =SCOPE_IDENTITY()
END
GO
