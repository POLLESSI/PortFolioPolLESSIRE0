CREATE TABLE [dbo].[Interest]
(
	[Id] INT IDENTITY,
	[Name] NVARCHAR(64) NOT NULL,
	[Description] NVARCHAR(256),
	[Active] BIT DEFAULT 1

	CONSTRAINT [PK_Interest] PRIMARY KEY ([Id])
)

GO

CREATE TRIGGER [dbo].[OnDeleteInterest]
	ON [dbo].[Interest]
	INSTEAD OF DELETE
	AS 
	BEGIN
		UPDATE Interest SET Active = 0
		WHERE Id = (SELECT Id FROM deleted)
	END


































	--Copyrite https://github.com/POLLESSI