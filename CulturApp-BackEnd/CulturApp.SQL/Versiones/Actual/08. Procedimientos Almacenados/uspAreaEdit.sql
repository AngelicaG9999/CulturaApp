
USE [CulturApp]
GO

/*

*/
if exists (select * from sys.procedures where name = 'uspAreaEdit')
  DROP PROCEDURE [dbo].[uspAreaEdit]
GO

CREATE PROCEDURE [dbo].[uspAreaEdit]
	@AreaID	BIGINT, 
	@EmpresaID		BIGINT, 
	@ModalidadID		BIGINT, 
	@Nombre			VARCHAR(250), 
	@Descripcion	VARCHAR(MAX)

AS
BEGIN

	UPDATE [dbo].[Area]
	SET 
		[EmpresaID]		= @EmpresaID,
		[ModalidadID]		= @ModalidadID, 
		[Nombre]		= @Nombre, 
		[Descripcion]	= @Descripcion
	WHERE AreaID = @AreaID

END
GO
