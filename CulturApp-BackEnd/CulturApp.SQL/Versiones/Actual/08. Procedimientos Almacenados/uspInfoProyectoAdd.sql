-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-13
-- Descripción: InfoProyecto
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoProyectoAdd')
  DROP PROCEDURE [dbo].[uspInfoProyectoAdd]
GO

CREATE PROCEDURE [dbo].[uspInfoProyectoAdd]
	@InfoProyectoID					BIGINT OUTPUT, 
	@EmpresaID						BIGINT, 
	@InscripcionID					BIGINT, 
	@Titulo							VARCHAR(MAX), 
	@LineaID						BIGINT, 
	@ProyectoUrl					VARCHAR(MAX), 
	@CurriculumUrl					VARCHAR(MAX), 
	@CedulaUrl						VARCHAR(MAX), 
	@ServiciosPublicosUrl			VARCHAR(MAX), 
	@RutUrl							VARCHAR(MAX), 
	@CertificadoVencindadUrl		VARCHAR(MAX), 
	@AutorizacionMenoresUrl			VARCHAR(MAX), 
	@DeclaracionJuramentadaUrl		VARCHAR(MAX), 
	@MaquetaUrl						VARCHAR(MAX), 
	@CamaraDeComercioUrl			VARCHAR(MAX)

AS
BEGIN
	INSERT INTO [dbo].[InfoProyecto]
		 ([EmpresaID], [InscripcionID], [Titulo], [LineaID], [ProyectoUrl], [CurriculumUrl], [CedulaUrl], [ServiciosPublicosUrl], [RutUrl], [CertificadoVencindadUrl], [AutorizacionMenoresUrl], [DeclaracionJuramentadaUrl], [MaquetaUrl], [CamaraDeComercioUrl])
	VALUES
		 (@EmpresaID, @InscripcionID, @Titulo, @LineaID, @ProyectoUrl, @CurriculumUrl, @CedulaUrl, @ServiciosPublicosUrl, @RutUrl, @CertificadoVencindadUrl, @AutorizacionMenoresUrl, @DeclaracionJuramentadaUrl, @MaquetaUrl, @CamaraDeComercioUrl)

		 SET @InfoProyectoID = SCOPE_IDENTITY()
END
GO
