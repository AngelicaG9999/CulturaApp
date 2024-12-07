-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-13
-- Descripción: InfoProyecto
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoProyectoFindAll')
  DROP PROCEDURE [dbo].[uspInfoProyectoFindAll]
GO

CREATE PROCEDURE [dbo].[uspInfoProyectoFindAll]
	@EmpresaID	BIGINT,
	@InscripcionID	BIGINT
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
	WHERE [IP].[EmpresaID] = @EmpresaID AND [IP].[InscripcionID] = @InscripcionID
END
GO
