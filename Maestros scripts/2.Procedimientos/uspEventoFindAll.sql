USE [Culturapp]
GO

/****** Object:  StoredProcedure [dbo].[uspEventoFindAll]    Script Date: 7/11/2024 14:30:25 ******/
DROP PROCEDURE [dbo].[uspEventoFindAll]
GO

/****** Object:  StoredProcedure [dbo].[uspEventoFindAll]    Script Date: 7/11/2024 14:30:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspEventoFindAll]
    @EmpresaID BIGINT = NULL,  
    @SalaID BIGINT = NULL,     
    @Nombre VARCHAR(80) = NULL, 
    @FechaHora DATETIME = NULL    
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        [EV].[EventoID],
        [EV].[EmpresaID],
        [EV].[SalaID],
        [EV].[Nombre],
        [EV].[FechaHora],
        [EV].[Lugar],
        [EV].[Direccion]
    FROM 
        [dbo].[Evento] AS [EV]
    WHERE
        (@EmpresaID IS NULL OR [EV].[EmpresaID] = @EmpresaID) AND
        (@SalaID IS NULL OR [EV].[SalaID] = @SalaID) AND
        (@Nombre IS NULL OR [EV].[Nombre] LIKE '%' + @Nombre + '%') AND
        (@FechaHora IS NULL OR [EV].[FechaHora] = @FechaHora);
END
GO


