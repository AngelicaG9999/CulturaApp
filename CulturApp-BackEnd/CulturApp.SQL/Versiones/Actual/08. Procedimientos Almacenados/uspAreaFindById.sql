
USE [CulturApp]
GO

/*

*/
if exists (select * from sys.procedures where name = 'uspAreaFindById')
  DROP PROCEDURE [dbo].[uspAreaFindById]
GO

CREATE PROCEDURE [dbo].[uspAreaFindById]
	@AreaID	BIGINT
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
		([B].[AreaID] = @AreaID)

END
GO
