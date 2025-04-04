CREATE TABLE [dbo].[Certification]
(
	[Id] INT IDENTITY,
	[Name] NVARCHAR(64) NOT NULL,
	[Authority] NVARCHAR(64) NOT NULL,	
	[LicenceNumber] NVARCHAR(64),
	[Url] NVARCHAR(MAX),
	[LicenceDate] DATE,
	[Active] BIT DEFAULT 1,

	CONSTRAINT [PK_Certification] PRIMARY KEY ([Id])

)

GO

CREATE TRIGGER [dbo].[OnDeleteCertification]
    ON [dbo].[certification]
	INSTEAD OF DELETE
	AS 
	BEGIN
		UPDATE Certification SET Active = 0
		WHERE Id IN (SELECT Id FROM deleted)
	END
