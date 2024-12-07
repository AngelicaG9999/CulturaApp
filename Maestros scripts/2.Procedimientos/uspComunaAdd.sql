

DROP PROCEDURE [dbo].[uspComunaAdd]
GO

CREATE PROCEDURE [dbo].[uspComunaAdd]
	@ComunaID			BIGINT OUTPUT, 
	@EmpresaID			BIGINT,
	@Nombre				VARCHAR(80) NULL,
	@Descripcion		VARCHAR(MAX) NULL



AS
BEGIN
	INSERT INTO [dbo].[Comuna]
		 (EmpresaID , Nombre, Descripcion)
	VALUES
		 (@EmpresaID,  @Nombre, @Descripcion)

	SET @ComunaID = SCOPE_IDENTITY ()

END
GO
