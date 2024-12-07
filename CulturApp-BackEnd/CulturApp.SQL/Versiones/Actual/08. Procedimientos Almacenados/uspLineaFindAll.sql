
USE [CulturApp]
GO

/*

*/
if exists (select * from sys.procedures where name = 'uspLineaFindAll')
  DROP PROCEDURE [dbo].[uspLineaFindAll]
GO

CREATE PROCEDURE [dbo].[uspLineaFindAll]
	@EmpresaID	BIGINT, 
	@Nombre		VARCHAR(60) = NULL,
	@AreaID	BIGINT = NULL
AS
BEGIN
	
	SELECT 
		[L].[LineaID], 
		[L].[EmpresaID], 
		[M].[ModalidadID],
		[M].[Nombre] AS [Modalidad],
		[L].[AreaID], 
		[A].[Nombre] AS [Area],
		[L].[Nombre], 
		[L].[Descripcion]
	FROM [dbo].[Linea] as [L]
		INNER JOIN [dbo].[Empresa] AS [E] ON [L].[EmpresaID] = [E].[EmpresaID]
		INNER JOIN [dbo].[Area] AS [A] ON [L].[AreaID] = [A].[AreaID]
		INNER JOIN [dbo].[Modalidad] AS [M] ON [A].[ModalidadID] = [M].[ModalidadID]
	WHERE 
		([L].[EmpresaID] = @EmpresaID)
	AND (@Nombre IS NULL OR [L].[Nombre] LIKE @Nombre)
	AND (@AreaID IS NULL OR [L].[AreaID] = @AreaID)

END
GO
