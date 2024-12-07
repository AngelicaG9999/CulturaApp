-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: Inscripcion
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInscripcionEdit')
  DROP PROCEDURE [dbo].[uspInscripcionEdit]
GO

CREATE PROCEDURE [dbo].[uspInscripcionEdit]
	@InscripcionID	BIGINT, 
	@EmpresaID		BIGINT, 
	@EstimuloID		BIGINT, 
	@Radicado		VARCHAR(60), 
	@TipoID			BIGINT, 
	@NumIntegrantes	BIGINT, 
	@FechaHora		DATETIME

AS
BEGIN
	UPDATE [dbo].[Inscripcion]
	SET 
		[EmpresaID]			= @EmpresaID, 
		[EstimuloID]		= @EstimuloID, 
		[Radicado]			= @Radicado, 
		[TipoID]			= @TipoID, 
		[NumIntegrantes]	= @NumIntegrantes, 
		[FechaHora]			= @FechaHora
	WHERE InscripcionID = @InscripcionID
END
GO
