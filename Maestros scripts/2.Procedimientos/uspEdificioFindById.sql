

DROP PROCEDURE IF EXISTS [dbo].[uspEdificioFindById];
GO

CREATE PROCEDURE [dbo].[uspEdificioFindById]
    @EdificioID BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        [E].[EdificioID],
        [E].[EmpresaID],
        [E].[BarrioID],
        [E].[Nombre],
        [E].[Direccion]

    FROM 
        [dbo].[Edificio] AS [E]

    WHERE 
        [E].[EdificioID] = @EdificioID;  
END
GO
