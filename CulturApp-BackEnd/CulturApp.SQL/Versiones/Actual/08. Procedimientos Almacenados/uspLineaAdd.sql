
USE [CulturApp]
GO

/*

*/
if exists (select * from sys.procedures where name = 'uspLineaAdd')
  DROP PROCEDURE [dbo].[uspLineaAdd]
GO

CREATE PROCEDURE [dbo].[uspLineaAdd]
	@LineaID		BIGINT OUTPUT, 
	@EmpresaID		BIGINT,
	@AreaID			BIGINT, 
	@Nombre			VARCHAR(250), 
	@Descripcion	VARCHAR(MAX)

AS
BEGIN

	INSERT INTO [dbo].[Linea]
		 ([EmpresaID], [AreaID], [Nombre], [Descripcion])
	VALUES
		 (@EmpresaID, @AreaID, @Nombre, @Descripcion)

		 SET @LineaID = SCOPE_IDENTITY()
END
GO
