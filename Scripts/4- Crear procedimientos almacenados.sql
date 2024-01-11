USE [Productos]
-- =============================================
-- Author:		Steven Arroyo Porras
-- Create date: 
-- Description:	Inserta información de la categoría
-- =============================================
CREATE PROCEDURE [dbo].[Usp_Ins_Co_Categoria]
	@cNombCateg VARCHAR(200),
	@cEsActiva BIT

AS
BEGIN
	INSERT INTO coCategoria (cNombCateg, cEsActiva) 
	VALUES(@cNombCateg, @cEsActiva)
END

GO

-- =============================================
-- Author:		Steven Arroyo Porras
-- Create date: 
-- Description:	Obtiene información de productos dependiendo de la categoría
-- =============================================
CREATE PROCEDURE [dbo].[Usp_Sel_Co_Productos]
	@CategoriaId INT
AS
BEGIN
	IF @CategoriaId =0
		BEGIN
			SELECT P.nIdProduct,P.cNombProdu,P.nPrecioProd,P.nIdCategori,C.cNombCateg
			FROM coProducto P
			INNER JOIN
			coCategoria C
			ON C.nIdCategori = P.nIdCategori
		END
	ELSE
		BEGIN
			SELECT P.nIdProduct,P.cNombProdu,P.nPrecioProd,P.nIdCategori,C.cNombCateg
			FROM coProducto P
			INNER JOIN
			coCategoria C
			ON C.nIdCategori = P.nIdCategori
			WHERE P.nIdCategori = @CategoriaId

		END
END
