﻿CREATE SCHEMA [Bot]
    AUTHORIZATION [dbo];
GO

CREATE LOGIN [Bot] WITH PASSWORD = 'invalidPassword';
GO

CREATE USER [Bot] FOR LOGIN [Bot];
GO

GRANT SELECT
    ON SCHEMA::[Bot] TO [Bot];
GO

GRANT EXECUTE
    ON SCHEMA::[Bot] TO [Bot];