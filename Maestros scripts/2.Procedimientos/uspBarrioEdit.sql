

DROP PROCEDURE IF EXISTS [dbo].[uspBarrioEdit];
GO

CREATE PROCEDURE [dbo].[uspBarrioEdit]
	@BarrioID      BIGINT,
    @EmpresaID     BIGINT,
	@ComunaID      BIGINT,
    @Nombre        VARCHAR(80),
    @Descripcion   VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Barrio]

    SET 
        EmpresaID   = @EmpresaID,
		ComunaID    = @ComunaID,
        Nombre      = @Nombre,
        Descripcion = @Descripcion

    WHERE 

        BarrioID = @BarrioID;
END
GO
