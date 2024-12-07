
USE [CulturApp]
GO

/*

*/
if exists (select * from sys.procedures where name = 'uspAreaAdd')
  DROP PROCEDURE [dbo].[uspAreaAdd]
GO

CREATE PROCEDURE [dbo].[uspAreaAdd]
	@AreaID	BIGINT OUTPUT, 
	@EmpresaID		BIGINT,
	@ModalidadID		BIGINT, 
	@Nombre			VARCHAR(250), 
	@Descripcion	VARCHAR(MAX)

AS
BEGIN

	INSERT INTO [dbo].[Area]
		 ([EmpresaID], [ModalidadID], [Nombre], [Descripcion])
	VALUES
		 (@EmpresaID, @ModalidadID, @Nombre, @Descripcion)

		 SET @AreaID = SCOPE_IDENTITY()
END
GO
