﻿CREATE PROC [dbo].[FI_SP_VerificaBenef]
	@CPF		VARCHAR(14),
	@ID			BIGINT,
	@IDCLIENTE	BIGINT
AS
BEGIN
	SELECT 1 FROM BENEFICIARIOS WHERE IDCLIENTE = @IDCLIENTE AND REPLACE(REPLACE(CPF, '.', ''), '-', '') = @CPF AND ID != @ID
END