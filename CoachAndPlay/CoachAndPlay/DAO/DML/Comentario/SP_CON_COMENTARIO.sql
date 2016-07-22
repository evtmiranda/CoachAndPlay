﻿IF OBJECT_ID('SP_CON_COMENTARIO') IS NOT NULL
	DROP PROCEDURE SP_CON_COMENTARIO
GO

CREATE PROCEDURE SP_CON_COMENTARIO
	@COMARTIGO INT,
	@INDEX INT,
	@QTDMAXIMA INT
AS

SELECT COMCODIGO, COMNOME, COMEMAIL, COMCOMENTARIO, COMDATA
FROM (
		SELECT
			ROW_NUMBER() OVER(ORDER BY COMDATA DESC) AS LINHA,
			COMCODIGO, COMNOME, COMEMAIL, COMCOMENTARIO, COMDATA
		FROM COMENTARIOS
		WHERE COMARTIGO = @COMARTIGO
	 )AS B
WHERE LINHA BETWEEN @INDEX AND @INDEX + @QTDMAXIMA - 1