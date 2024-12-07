
USE [CulturApp]
GO

/*

*/
if exists (select * from sys.procedures where name = 'uspAreaFindAll')
  DROP PROCEDURE [dbo].[uspAreaFindAll]
GO

CREATE PROCEDURE [dbo].[uspAreaFindAll]
	@EmpresaID	BIGINT, 
	@Nombre		VARCHAR(60) = NULL,
	@ModalidadID	BIGINT = NULL
AS
BEGIN
	
	SELECT 
		[B].[AreaID], 
		[B].[EmpresaID], 
		[B].[ModalidadID], 
		[M].[Nombre] AS [Modalidad],
		[B].[Nombre], 
		[B].[Descripcion]
	FROM [dbo].[Area] as [B]
		INNER JOIN [dbo].[Empresa] AS [E] ON [B].[EmpresaID] = [E].[EmpresaID]
		INNER JOIN [dbo].[Modalidad] AS [M] ON [B].[ModalidadID] = [M].[ModalidadID]
	WHERE 
		([B].[EmpresaID] = @EmpresaID)
	AND (@Nombre IS NULL OR [B].[Nombre] LIKE @Nombre)
	AND (@ModalidadID IS NULL OR [B].[ModalidadID] = @ModalidadID)

END
GO
