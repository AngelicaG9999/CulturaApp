
DROP PROCEDURE [dbo].[uspEdificioAdd]
GO

CREATE PROCEDURE [dbo].[uspEdificioAdd]
	@EdificioID			BIGINT OUTPUT, 
	@EmpresaID			BIGINT,
	@BarrioID			BIGINT,
	@Nombre				VARCHAR(80) NULL,
	@Direccion			VARCHAR(80) NULL

AS
BEGIN
	INSERT INTO [dbo].[Edificio]
		 (EmpresaID, BarrioID, Nombre, Direccion)
	VALUES
		 (@EmpresaID, @BarrioID, @Nombre, @Direccion)

	SET @EdificioID = SCOPE_IDENTITY ()

END
GO
