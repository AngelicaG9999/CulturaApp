
USE [CulturApp]
GO

/*

*/
if exists (select * from sys.procedures where name = 'uspModalidadFindById')
  DROP PROCEDURE [dbo].[uspModalidadFindById]
GO

CREATE PROCEDURE [dbo].[uspModalidadFindById]
	@ModalidadID	BIGINT
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
		([D].[ModalidadID] = @ModalidadID)

END
GO
