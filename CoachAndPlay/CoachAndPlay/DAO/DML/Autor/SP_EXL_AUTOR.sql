﻿IF OBJECT_ID('SP_EXL_AUTOR') IS NOT NULL
	DROP PROCEDURE SP_EXL_AUTOR
GO

CREATE PROCEDURE SP_EXL_AUTOR
	@AUTCODIGO INT
AS

DELETE FROM AUTORES
WHERE AUTCODIGO = @AUTCODIGO