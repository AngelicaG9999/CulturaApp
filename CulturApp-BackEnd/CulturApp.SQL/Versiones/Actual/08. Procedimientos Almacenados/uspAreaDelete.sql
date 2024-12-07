
USE [CulturApp]
GO

/*

*/
if exists (select * from sys.procedures where name = 'uspAreaDelete')
  DROP PROCEDURE [dbo].[uspAreaDelete]
GO

CREATE PROCEDURE [dbo].[uspAreaDelete]
	@AreaID	bigint
AS
BEGIN

	DELETE [B] 
	FROM [dbo].[Area] AS [B] 
	WHERE [B].[AreaID] = @AreaID

END
GO
