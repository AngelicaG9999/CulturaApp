
DROP PROCEDURE IF EXISTS [dbo].[uspBarrioFindById];
GO

CREATE PROCEDURE [dbo].[uspBarrioFindById]
    @BarrioID BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        [B].[BarrioID],
        [B].[EmpresaID],
        [B].[ComunaID],
        [B].[Nombre],
        [B].[Descripcion]

    FROM 
        [dbo].[Barrio] AS [B]

    WHERE 
        [B].[BarrioID] = @BarrioID;  
END
GO
