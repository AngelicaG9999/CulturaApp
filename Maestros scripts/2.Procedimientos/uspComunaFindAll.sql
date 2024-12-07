DROP PROCEDURE IF EXISTS [dbo].[uspComunaFindAll];
GO

CREATE PROCEDURE [dbo].[uspComunaFindAll]
    @EmpresaID BIGINT = NULL,  
    @Nombre    VARCHAR(80) = NULL 
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
        (@EmpresaID IS NULL OR [C].[EmpresaID] = @EmpresaID) AND
        (@Nombre IS NULL OR [C].[Nombre] LIKE '%' + @Nombre + '%');
END
GO
