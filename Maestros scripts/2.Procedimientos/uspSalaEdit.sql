

DROP PROCEDURE IF EXISTS [dbo].[uspSalaEdit];
GO

CREATE PROCEDURE [dbo].[uspSalaEdit]
	@SalaID        BIGINT,
    @EmpresaID     BIGINT,
	@EdificioID    BIGINT,
    @Nombre        VARCHAR(80),
	@Capacidad     INT,
    @Descripcion   VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Sala]
    SET 
        EmpresaID   = @EmpresaID,
		EdificioID  = @EdificioID,
        Nombre      = @Nombre,
		Capacidad   = @Capacidad,
        Descripcion = @Descripcion
    WHERE 
        SalaID = @SalaID;
END
GO
