CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(32) NOT NULL, 
    [Email] NVARCHAR(64) NULL, 
    [CompanyID] INT NULL REFERENCES Companies(ID)
)
