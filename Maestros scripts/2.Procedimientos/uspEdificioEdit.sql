


DROP PROCEDURE IF EXISTS [dbo].[uspEdificioEdit];
GO

CREATE PROCEDURE [dbo].[uspEdificioEdit]
	@EdificioID    BIGINT,
    @EmpresaID     BIGINT,
	@BarrioID      BIGINT,
    @Nombre        VARCHAR(80),
    @Direccion	   VARCHAR(80)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Edificio]
    SET 
        EmpresaID   = @EmpresaID,
		BarrioID    = @BarrioID,
        Nombre      = @Nombre,
        Direccion	= @Direccion
    WHERE 
        EdificioID = @EdificioID;
END
GO
