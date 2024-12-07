
DROP PROCEDURE IF EXISTS [dbo].[uspEventoDelete]
GO

CREATE PROCEDURE [dbo].[uspEventoDelete]
    @EventoID BIGINT

AS
BEGIN

    DELETE FROM [dbo].[Evento]

    WHERE EventoID = @EventoID;
END
GO
