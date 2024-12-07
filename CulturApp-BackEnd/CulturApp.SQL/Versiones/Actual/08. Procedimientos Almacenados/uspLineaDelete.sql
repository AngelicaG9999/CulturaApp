
USE [CulturApp]
GO

/*

*/
if exists (select * from sys.procedures where name = 'uspLineaDelete')
  DROP PROCEDURE [dbo].[uspLineaDelete]
GO

CREATE PROCEDURE [dbo].[uspLineaDelete]
	@LineaID	bigint
AS
BEGIN

	DELETE [L] 
	FROM [dbo].[Linea] AS [L] 
	WHERE [L].[LineaID] = @LineaID

END
GO
