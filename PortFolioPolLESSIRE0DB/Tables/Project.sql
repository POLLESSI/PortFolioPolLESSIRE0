CREATE TABLE [dbo].[Project]
(
	[Id] INT IDENTITY,
	[Name] NVARCHAR(64) NOT NULL,
	[Description] NVARCHAR(256),
	[Url] NVARCHAR(MAX),
	[StartDate] DATETIME NOT NULL,
	[EndDate] DATETIME,
	[Active] BIT DEFAULT 1

	CONSTRAINT [PK_Project] PRIMARY KEY ([Id])
)
