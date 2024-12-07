
DROP PROCEDURE IF EXISTS [dbo].[uspSalaDelete]
GO

CREATE PROCEDURE [dbo].[uspSalaDelete]
    @SalaID BIGINT

AS
BEGIN

    DELETE FROM [dbo].[Sala]

    WHERE SalaID = @SalaID;
END
GO
