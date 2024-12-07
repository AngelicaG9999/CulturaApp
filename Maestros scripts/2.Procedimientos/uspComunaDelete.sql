
DROP PROCEDURE IF EXISTS [dbo].[uspComunaDelete]
GO

CREATE PROCEDURE [dbo].[uspComunaDelete]
    @ComunaID BIGINT
AS
BEGIN
    DELETE FROM [dbo].[Comuna]

    WHERE ComunaID = @ComunaID;
END
GO
