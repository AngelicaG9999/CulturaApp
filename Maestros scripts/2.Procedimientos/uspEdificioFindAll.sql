
DROP PROCEDURE IF EXISTS [dbo].[uspEdificioFindAll];
GO

CREATE PROCEDURE [dbo].[uspEdificioFindAll]
    @EmpresaID BIGINT = NULL,
    @BarrioID BIGINT = NULL,  
    @Nombre VARCHAR(80) = NULL
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
        (@EmpresaID IS NULL OR [E].[EmpresaID] = @EmpresaID) AND
        (@BarrioID IS NULL OR [E].[BarrioID] = @BarrioID) AND
        (@Nombre IS NULL OR [E].[Nombre] LIKE '%' + @Nombre + '%');
END
GO
