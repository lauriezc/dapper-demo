CREATE DATABASE test
GO

USE TEST
GO

CREATE TABLE [dbo].[t] (
    [id]   INT           IDENTITY (1, 1) NOT NULL,
    [name] VARCHAR (100) NOT NULL,
    [Time] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)
GO


create view all_t
as 
select * from t

GO