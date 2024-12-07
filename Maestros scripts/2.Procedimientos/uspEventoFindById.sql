USE [Culturapp]
GO

/****** Object:  StoredProcedure [dbo].[uspEventoFindById]    Script Date: 7/11/2024 14:31:25 ******/
DROP PROCEDURE [dbo].[uspEventoFindById]
GO

/****** Object:  StoredProcedure [dbo].[uspEventoFindById]    Script Date: 7/11/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspEventoFindById]
    @EventoID BIGINT
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
        [EV].[EventoID] = @EventoID;  
END
GO


