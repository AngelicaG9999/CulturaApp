
USE [CulturApp]
GO

/*

*/
if exists (select * from sys.procedures where name = 'uspModalidadFindAll')
  DROP PROCEDURE [dbo].[uspModalidadFindAll]
GO

CREATE PROCEDURE [dbo].[uspModalidadFindAll]
	@EmpresaID			BIGINT, 
	@Nombre				VARCHAR(60) = NULL
AS
BEGIN
	
	SELECT 
		[D].[ModalidadID], 
		[D].[EmpresaID], 
		[D].[Nombre], 
		[D].[Descripcion]
	FROM [dbo].[Modalidad] as [D]
		INNER JOIN [dbo].[Empresa] AS [E] ON [D].[EmpresaID] = [E].[EmpresaID]
	WHERE 
		([D].[EmpresaID] = @EmpresaID)
	AND (@Nombre IS NULL OR [D].[Nombre] LIKE @Nombre)

END
GO
