CREATE TABLE [dbo].[Education]
(
	[Id] INT IDENTITY,
	[School] NVARCHAR(64) NOT NULL,	
	[Degree] NVARCHAR(64) NOT NULL,
	[FieldOfStudy] NVARCHAR(64) NOT NULL,
	[StartDate] DATETIME NOT NULL,	
	[EndDate] DATETIME,
	[Description] NVARCHAR(256),
	[Active] BIT DEFAULT 1,

	CONSTRAINT [PK_Education] PRIMARY KEY ([Id])
)

GO

CREATE TRIGGER [dbo].[OnDeleteEducation]
	ON [dbo].[Education]
	INSTEAD OF DELETE
	AS 
	BEGIN
		UPDATE Education SET Active = 0
		WHERE Id = (SELECT Id FROM deleted)
	END








































	--Copyrite https://github.com/POLLESSI