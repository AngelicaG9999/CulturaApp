
USE [CulturApp]
GO

/*

*/
if exists (select * from sys.procedures where name = 'uspModalidadAdd')
  DROP PROCEDURE [dbo].[uspModalidadAdd]
GO

CREATE PROCEDURE [dbo].[uspModalidadAdd]
	@ModalidadID	BIGINT OUTPUT, 
	@EmpresaID		BIGINT,  
	@Nombre			VARCHAR(250), 
	@Descripcion	VARCHAR(MAX)

AS
BEGIN

	INSERT INTO [dbo].[Modalidad]
		 ([EmpresaID], [Nombre], [Descripcion])
	VALUES
		 (@EmpresaID, @Nombre, @Descripcion)

		 SET @ModalidadID = SCOPE_IDENTITY()
END
GO
