﻿CREATE PROC [dbo].[FI_SP_IncBenef]
    @CPF		   VARCHAR (14),
	@NOME          VARCHAR (255),
    @IDCLIENTE    BIGINT
AS
BEGIN
	INSERT INTO BENEFICIARIOS(CPF, NOME, IDCLIENTE)
	VALUES (@CPF, @NOME, @IDCLIENTE)

	SELECT SCOPE_IDENTITY()
END