USE [Culturapp]
GO

/****** Object:  StoredProcedure [dbo].[uspEventoEdit]    Script Date: 7/11/2024 14:29:33 ******/
DROP PROCEDURE [dbo].[uspEventoEdit]
GO

/****** Object:  StoredProcedure [dbo].[uspEventoEdit]    Script Date: 7/11/2024 14:29:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspEventoEdit]
	@EventoID      BIGINT,
    @EmpresaID     BIGINT,
	@SalaID		   BIGINT,
    @Nombre        VARCHAR(80),
	@FechaHora	   DATETIME,
	@Lugar		   VARCHAR(80),
	@Direccion     VARCHAR(80)

AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Evento]
    SET 
        EmpresaID   = @EmpresaID,
		SalaID		= @SalaID,
        Nombre      = @Nombre,
		FechaHora   = @FechaHora,
		Lugar		= @Lugar,
        Direccion   = @Direccion
    WHERE 
        EventoID = @EventoID;
END
GO


