-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: Estimulo
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspEstimuloEdit')
  DROP PROCEDURE [dbo].[uspEstimuloEdit]
GO

CREATE PROCEDURE [dbo].[uspEstimuloEdit]
	@EstimuloID		BIGINT, 
	@EmpresaID		BIGINT, 
	@Codigo			VARCHAR(25), 
	@Nombre			VARCHAR(250), 
	@FechaApertura	DATETIME, 
	@FechaCierre	DATETIME, 
	@Descripcion	VARCHAR(MAX), 
	@Cerrado		BIT

AS
BEGIN
	UPDATE [dbo].[Estimulo]
	SET 
		[EmpresaID]		= @EmpresaID, 
		[Codigo]		= @Codigo, 
		[Nombre]		= @Nombre, 
		[FechaApertura] = @FechaApertura, 
		[FechaCierre]	= @FechaCierre, 
		[Descripcion]	= @Descripcion, 
		[Cerrado]		= @Cerrado
	WHERE EstimuloID	= @EstimuloID
END
GO
