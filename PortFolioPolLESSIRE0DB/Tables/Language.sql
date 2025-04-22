CREATE TABLE [dbo].[Language]
(
	[Id] INT IDENTITY,
	[Name] NVARCHAR(64) NOT NULL,
	[Level] NVARCHAR(64) NOT NULL,
	[Active] BIT DEFAULT 1

	CONSTRAINT [PK_Language] PRIMARY KEY ([Id])
)

GO

CREATE TRIGGER [dbo].[OnDeleteLanguage]
	ON [dbo].[Language]
	INSTEAD OF DELETE
	AS 
	BEGIN
		UPDATE Language SET Active = 0
		WHERE Id = (SELECT Id FROM deleted)
	END





































--Copyrite https://github.com/POLLESSI