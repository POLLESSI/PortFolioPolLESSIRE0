﻿--CREATE FUNCTION [dbo].[fHasher]
--(
--	@Pwd VARCHAR(128),
--	@SecurityStamp UNIQUEIDENTIFIER
--)
--RETURNS BINARY(64)
--AS
--BEGIN
--	DECLARE @hashedValue VARBINARY(64) = CONVERT(BINARY(64), CONCAT(HASHBYTES('SHA_512', (@Pwd + CAST(@SecurityStamp AS VARCHAR(36)))), @SecurityStamp))
--	RETURN @hashedValue
--END


































--Copyrite https://github.com/POLLESSI