﻿CREATE PROC [dbo].[FI_SP_ConsBenef]
	@IDCLIENTE BIGINT
AS
BEGIN
	SELECT ID, CPF, NOME, IDCLIENTE FROM BENEFICIARIOS WHERE IDCLIENTE = @IDCLIENTE ORDER BY NOME
END