
DROP PROCEDURE IF EXISTS  [dbo].[uspComunaEdit]
GO

CREATE PROCEDURE [dbo].[uspComunaEdit]

	@ComunaID			BIGINT, 
	@EmpresaID			BIGINT,
	@Nombre				VARCHAR(80),
	@Descripcion		VARCHAR(MAX)

AS
BEGIN

	SET NOCOUNT ON;

	UPDATE [dbo].[Comuna]

	SET 
			EmpresaID   = @EmpresaID,
			Nombre	    = @Nombre,
			Descripcion = @Descripcion

	WHERE	ComunaID = @ComunaID;
END
GO


