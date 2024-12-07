
USE [CulturApp]
GO

/*

*/
if exists (select * from sys.procedures where name = 'uspLineaFindById')
  DROP PROCEDURE [dbo].[uspLineaFindById]
GO

CREATE PROCEDURE [dbo].[uspLineaFindById]
	@LineaID	BIGINT
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
		([L].[LineaID] = @LineaID)

END
GO
