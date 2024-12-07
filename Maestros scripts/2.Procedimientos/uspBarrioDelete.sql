

DROP PROCEDURE IF EXISTS [dbo].[uspBarrioDelete]
GO

CREATE PROCEDURE [dbo].[uspBarrioDelete]
    @BarrioID BIGINT
AS
BEGIN

    DELETE FROM [dbo].[Barrio]

    WHERE BarrioID = @BarrioID;
END
GO
