﻿IF OBJECT_ID('SP_INC_COMENTARIO') IS NOT NULL
	DROP PROCEDURE SP_INC_COMENTARIO
GO

CREATE PROCEDURE SP_INC_COMENTARIO
	@COMARTIGO INT,
	@COMNOME VARCHAR(40),
	@COMEMAIL VARCHAR(120),
	@COMCOMENTARIO VARCHAR(1000)
AS

INSERT INTO COMENTARIOS(COMARTIGO, COMNOME, COMEMAIL, COMCOMENTARIO, COMDATA)
VALUES(@COMARTIGO, @COMNOME, @COMEMAIL, @COMCOMENTARIO, GETDATE())

SELECT @@IDENTITY AS COMCODIGO