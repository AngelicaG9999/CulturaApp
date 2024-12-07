
DROP PROCEDURE [dbo].[uspBarrioAdd]
GO

CREATE PROCEDURE [dbo].[uspBarrioAdd]
	@BarrioID			BIGINT OUTPUT, 
	@EmpresaID			BIGINT,
	@ComunaID			BIGINT,
	@Nombre				VARCHAR(80) NULL,
	@Descripcion		VARCHAR(MAX) NULL

AS
BEGIN
	INSERT INTO [dbo].[Barrio]
		 (EmpresaID, ComunaID, Nombre, Descripcion)
	VALUES
		 (@EmpresaID, @ComunaID, @Nombre, @Descripcion)

	SET @BarrioID = SCOPE_IDENTITY ()

END
GO
