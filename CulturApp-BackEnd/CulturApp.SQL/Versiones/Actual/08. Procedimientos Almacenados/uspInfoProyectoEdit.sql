-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-13
-- Descripción: InfoProyecto
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInfoProyectoEdit')
  DROP PROCEDURE [dbo].[uspInfoProyectoEdit]
GO

CREATE PROCEDURE [dbo].[uspInfoProyectoEdit]
	@InfoProyectoID					BIGINT, 
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
	UPDATE [dbo].[InfoProyecto]
	SET 
		[EmpresaID]						= @EmpresaID, 
		[InscripcionID]					= @InscripcionID, 
		[Titulo]						= @Titulo, 
		[LineaID]						= @LineaID, 
		[ProyectoUrl]					= @ProyectoUrl, 
		[CurriculumUrl]					= @CurriculumUrl, 
		[CedulaUrl]						= @CedulaUrl, 
		[ServiciosPublicosUrl]			= @ServiciosPublicosUrl, 
		[RutUrl]						= @RutUrl, 
		[CertificadoVencindadUrl]		= @CertificadoVencindadUrl, 
		[AutorizacionMenoresUrl]		= @AutorizacionMenoresUrl, 
		[DeclaracionJuramentadaUrl]		= @DeclaracionJuramentadaUrl, 
		[MaquetaUrl]					= @MaquetaUrl, 
		[CamaraDeComercioUrl]			= @CamaraDeComercioUrl
	WHERE InfoProyectoID				= @InfoProyectoID
END
GO
