
DROP PROCEDURE IF EXISTS [dbo].[uspComunaFindById];
GO

CREATE PROCEDURE [dbo].[uspComunaFindById]
    @ComunaID BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        [C].[ComunaID],
        [C].[EmpresaID],
        [C].[Nombre],
        [C].[Descripcion]

    FROM 
        [dbo].[Comuna] AS [C]

    WHERE 
        [C].[ComunaID] = @ComunaID;  
END
GO
