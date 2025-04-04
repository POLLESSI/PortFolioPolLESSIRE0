CREATE TABLE [dbo].[Skill]
(
	[Id] INT IDENTITY,
	[Name] NVARCHAR(64) NOT NULL,
	[Level] NVARCHAR(64) NOT NULL,
	[Description] NVARCHAR(256),
	[Active] BIT DEFAULT 1

	CONSTRAINT [PK_Skill] PRIMARY KEY ([Id])
)

GO

CREATE TRIGGER [dbo].[OnDeleteSkill]
	ON [dbo].[Skill]
	INSTEAD OF DELETE
	AS 
	BEGIN
		UPDATE Skill SET Active = 0
		WHERE Id = (SELECT Id FROM deleted)
	END
