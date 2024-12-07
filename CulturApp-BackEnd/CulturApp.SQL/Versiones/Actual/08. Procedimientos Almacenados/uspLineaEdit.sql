
USE [CulturApp]
GO

/*

*/
if exists (select * from sys.procedures where name = 'uspLineaEdit')
  DROP PROCEDURE [dbo].[uspLineaEdit]
GO

CREATE PROCEDURE [dbo].[uspLineaEdit]
	@LineaID	BIGINT, 
	@EmpresaID		BIGINT, 
	@AreaID		BIGINT, 
	@Nombre			VARCHAR(250), 
	@Descripcion	VARCHAR(MAX)

AS
BEGIN

	UPDATE [dbo].[Linea]
	SET 
		[EmpresaID]		= @EmpresaID,
		[AreaID]		= @AreaID, 
		[Nombre]		= @Nombre, 
		[Descripcion]	= @Descripcion
	WHERE LineaID = @LineaID

END
GO
