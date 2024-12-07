
DROP PROCEDURE IF EXISTS [dbo].[uspSalaFindAll];
GO

CREATE PROCEDURE [dbo].[uspSalaFindAll]
    @EmpresaID BIGINT = NULL,  
    @EdificioID BIGINT = NULL, 
    @Nombre VARCHAR(80) = NULL  
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        [S].[SalaID],
        [S].[EmpresaID],
        [S].[EdificioID],
        [S].[Nombre],
        [S].[Capacidad],
        [S].[Descripcion]
    FROM 
        [dbo].[Sala] AS [S]
    WHERE
        (@EmpresaID IS NULL OR [S].[EmpresaID] = @EmpresaID) AND
        (@EdificioID IS NULL OR [S].[EdificioID] = @EdificioID) AND
        (@Nombre IS NULL OR [S].[Nombre] LIKE '%' + @Nombre + '%');
END
GO
