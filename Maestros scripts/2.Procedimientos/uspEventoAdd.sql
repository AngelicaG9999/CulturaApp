USE [Culturapp]
GO

/****** Object:  StoredProcedure [dbo].[uspEventoAdd]    Script Date: 7/11/2024 14:27:41 ******/
DROP PROCEDURE [dbo].[uspEventoAdd]
GO

/****** Object:  StoredProcedure [dbo].[uspEventoAdd]    Script Date: 7/11/2024 14:27:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspEventoAdd]
	@EventoID		BIGINT OUTPUT, 
	@EmpresaID		BIGINT,
	@SalaID			BIGINT,
	@Nombre			VARCHAR(80) NULL,
	@FechaHora		DATETIME NULL,
	@Lugar			VARCHAR (80) NULL,
	@Direccion		VARCHAR(80) NULL

AS
BEGIN
	INSERT INTO [dbo].[Evento]
		 (EmpresaID, SalaID, Nombre, FechaHora, Lugar, Direccion)
	VALUES
		 (@EmpresaID, @SalaID, @Nombre, @FechaHora, @Lugar, @Direccion)

	SET @EventoID = SCOPE_IDENTITY ()

END
GO


