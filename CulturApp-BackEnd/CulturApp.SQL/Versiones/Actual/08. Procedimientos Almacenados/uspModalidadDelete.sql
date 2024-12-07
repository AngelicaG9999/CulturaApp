
USE [CulturApp]
GO

/*

*/
if exists (select * from sys.procedures where name = 'uspModalidadDelete')
  DROP PROCEDURE [dbo].[uspModalidadDelete]
GO

CREATE PROCEDURE [dbo].[uspModalidadDelete]
	@ModalidadID	bigint
AS
BEGIN

	DELETE [D] 
	FROM [dbo].[Modalidad] AS [D] 
	WHERE [D].[ModalidadID] = @ModalidadID

END
GO
