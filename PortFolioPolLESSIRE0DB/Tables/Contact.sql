CREATE TABLE [dbo].[Contact]
(
	[Id] INT IDENTITY,
	[Name] NVARCHAR(64) NOT NULL,
	[Email] NVARCHAR(64),
	[Phone] NVARCHAR(64),
	[Active] BIT DEFAULT 1

	CONSTRAINT [PK_Contact] PRIMARY KEY ([Id])	

)

GO

CREATE TRIGGER [dbo].[OnDeleteContact]
	ON [dbo].[Contact]
	INSTEAD OF DELETE
	AS 
	BEGIN
		UPDATE Contact SET Active = 0
		WHERE Id = (SELECT Id FROM deleted)
	END
