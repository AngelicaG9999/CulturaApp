DROP PROCEDURE IF EXISTS [dbo].[uspBarrioFindAll];
GO

CREATE PROCEDURE [dbo].[uspBarrioFindAll]
    @EmpresaID BIGINT = NULL,
    @ComunaID BIGINT = NULL,  
    @Nombre    VARCHAR(80) = NULL 
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
        (@EmpresaID IS NULL OR [B].[EmpresaID] = @EmpresaID) AND
        (@ComunaID IS NULL OR [B].[ComunaID] = @ComunaID) AND
        (@Nombre IS NULL OR [B].[Nombre] LIKE '%' + @Nombre + '%');
END
GO
