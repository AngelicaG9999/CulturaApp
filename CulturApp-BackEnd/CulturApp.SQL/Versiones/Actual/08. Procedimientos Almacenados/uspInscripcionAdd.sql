-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: Inscripcion
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspInscripcionAdd')
  DROP PROCEDURE [dbo].[uspInscripcionAdd]
GO

CREATE PROCEDURE [dbo].[uspInscripcionAdd]
	@InscripcionID	BIGINT OUTPUT, 
	@EmpresaID		BIGINT, 
	@EstimuloID		BIGINT, 
	@Radicado		VARCHAR(60), 
	@TipoID			BIGINT, 
	@NumIntegrantes	BIGINT, 
	@FechaHora		DATETIME

AS
BEGIN

	SET @NumIntegrantes = ISNULL(@NumIntegrantes, 0)
	SET @FechaHora = GETDATE()

	INSERT INTO [dbo].[Inscripcion]
		 ([EmpresaID], [EstimuloID], [Radicado], [TipoID], [NumIntegrantes], [FechaHora])
	VALUES
		 (@EmpresaID, @EstimuloID, @Radicado, @TipoID, @NumIntegrantes, @FechaHora)

		 SET @InscripcionID = SCOPE_IDENTITY()
END
GO
