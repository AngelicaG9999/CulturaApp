-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-13
-- Descripción: InfoProyecto
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoProyectoFindById')
  DROP PROCEDURE [dbo].[uspInfoProyectoFindById]
GO

CREATE PROCEDURE [dbo].[uspInfoProyectoFindById]
	@InfoProyectoID BIGINT
AS
BEGIN
	
	SELECT [IP].[InfoProyectoID],
           [IP].[EmpresaID],
           [IP].[InscripcionID],
           [IP].[Titulo],
           [IP].[LineaID],
           [IP].[ProyectoUrl],
           [IP].[CurriculumUrl],
           [IP].[CedulaUrl],
           [IP].[ServiciosPublicosUrl],
           [IP].[RutUrl],
           [IP].[CertificadoVencindadUrl],
           [IP].[AutorizacionMenoresUrl],
           [IP].[DeclaracionJuramentadaUrl],
           [IP].[MaquetaUrl],
           [IP].[CamaraDeComercioUrl]
	FROM [dbo].[InfoProyecto] AS [IP]
		INNER JOIN [dbo].[Empresa] AS [E] ON [IP].[EmpresaID] = [E].[EmpresaID]
	WHERE [IP].[InfoProyectoID] = @InfoProyectoID

END
GO
