﻿IF OBJECT_ID('SP_INC_ARTIGO') IS NOT NULL
	DROP PROCEDURE SP_INC_ARTIGO
GO

CREATE PROCEDURE SP_INC_ARTIGO
	@ARTTITULO VARCHAR(100),
	@ARTAUTOR INT,
	@ARTASSUNTO INT,
	@ARTCONTEUDO TEXT
AS

INSERT INTO ARTIGOS(ARTTITULO, ARTAUTOR, ARTASSUNTO, ARTCONTEUDO, ARTDATACRIACAO)
VALUES(@ARTTITULO, @ARTAUTOR, @ARTASSUNTO, @ARTCONTEUDO, GETDATE())

SELECT @@IDENTITY AS ARTCODIGO 