CREATE TABLE [dbo].[Experience]
(
	[Id] INT IDENTITY,
	[Company] NVARCHAR(64) NOT NULL,
	[Position] NVARCHAR(64) NOT NULL,
	[Description] NVARCHAR(256),
	[StartDate] DATETIME NOT NULL,
	[EndDate] DATETIME,
	[Active] BIT DEFAULT 1

	CONSTRAINT [PK_Experience] PRIMARY KEY ([Id])
)

GO

CREATE TRIGGER [dbo].[OnDeleteExperience]
	ON [dbo].[Experience]
	INSTEAD OF DELETE
	AS 
	BEGIN
		UPDATE Experience SET Active = 0
		WHERE Id = (SELECT Id FROM deleted)
	END