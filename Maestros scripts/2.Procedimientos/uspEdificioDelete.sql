

DROP PROCEDURE IF EXISTS [dbo].[uspEdificioDelete]
GO

CREATE PROCEDURE [dbo].[uspEdificioDelete]
    @EdificioID BIGINT

AS
BEGIN

    DELETE FROM [dbo].[Edificio]

    WHERE EdificioID = @EdificioID;
END
GO
