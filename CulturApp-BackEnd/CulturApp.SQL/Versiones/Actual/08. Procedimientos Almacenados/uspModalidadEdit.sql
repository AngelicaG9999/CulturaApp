
USE [CulturApp]
GO

/*

*/
if exists (select * from sys.procedures where name = 'uspModalidadEdit')
  DROP PROCEDURE [dbo].[uspModalidadEdit]
GO

CREATE PROCEDURE [dbo].[uspModalidadEdit]
	@ModalidadID	BIGINT, 
	@EmpresaID		BIGINT, 
	@Nombre			VARCHAR(250), 
	@Descripcion	VARCHAR(MAX)

AS
BEGIN

	UPDATE [dbo].[Modalidad]
	SET 
		[EmpresaID]		= @EmpresaID, 
		[Nombre]		= @Nombre, 
		[Descripcion]	= @Descripcion
	WHERE ModalidadID = @ModalidadID

END
GO
