
DROP PROCEDURE IF EXISTS [dbo].[uspSalaFindById];
GO

CREATE PROCEDURE [dbo].[uspSalaFindById]
    @SalaID BIGINT
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
        [S].[SalaID] = @SalaID;  
END
GO
