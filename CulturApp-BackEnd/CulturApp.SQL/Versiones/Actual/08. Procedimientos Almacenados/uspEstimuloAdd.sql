-- =============================================
-- Autor: GENERADOR DE CÓDIGO
-- Fecha creación: 2024-05-11
-- Descripción: Estimulo
-- =============================================
/*

*/
if exists (select * from sys.procedures where name = 'uspEstimuloAdd')
  DROP PROCEDURE [dbo].[uspEstimuloAdd]
GO

CREATE PROCEDURE [dbo].[uspEstimuloAdd]
	@EstimuloID		BIGINT OUTPUT, 
	@EmpresaID		BIGINT, 
	@Codigo			VARCHAR(25), 
	@Nombre			VARCHAR(250), 
	@FechaApertura	DATETIME, 
	@FechaCierre	DATETIME, 
	@Descripcion	VARCHAR(MAX), 
	@Cerrado		BIT

AS
BEGIN
	INSERT INTO [dbo].[Estimulo]
		 ([EmpresaID], [Codigo], [Nombre], [FechaApertura], [FechaCierre], [Descripcion], [Cerrado])
	VALUES
		 (@EmpresaID, @Codigo, @Nombre, @FechaApertura, @FechaCierre, @Descripcion, @Cerrado)

		 SET @EstimuloID = SCOPE_IDENTITY()
END
GO
