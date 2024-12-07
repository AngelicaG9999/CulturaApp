

DROP PROCEDURE [dbo].[uspSalaAdd]
GO

CREATE PROCEDURE [dbo].[uspSalaAdd]
	@SalaID			BIGINT OUTPUT, 
	@EmpresaID		BIGINT,
	@EdificioID		BIGINT,
	@Nombre			VARCHAR(80) NULL,
	@Capacidad		INT,
	@Descripcion	VARCHAR(MAX) NULL

AS
BEGIN
	INSERT INTO [dbo].[Sala]
		 (EmpresaID, EdificioID, Nombre, Capacidad, Descripcion)
	VALUES
		 (@EmpresaID, @EdificioID, @Nombre, @Capacidad, @Descripcion)

	SET @SalaID = SCOPE_IDENTITY ()

END
GO
