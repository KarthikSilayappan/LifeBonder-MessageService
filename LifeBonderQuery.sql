CREATE TABLE [dbo].[UserDetails]
(
UserId INT PRIMARY KEY IDENTITY(1,1),
UserName NVARCHAR(100),
ImageLink NVARCHAR(MAX)
)

CREATE TABLE [dbo].[Contacts]
(
Id INT IDENTITY(1,1),
UserId INT FOREIGN KEY REFERENCES [UserDetails](UserId),
ContactId INT FOREIGN KEY REFERENCES [UserDetails](UserId)
)


CREATE TABLE [dbo].[MessageType]
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Type NVARCHAR(10)
)

CREATE TABLE [dbo].[UserMessage]
(
Id INT IDENTITY(1,1),
UserId INT FOREIGN KEY REFERENCES [UserDetails](UserId),
RecepientId INT FOREIGN KEY REFERENCES [UserDetails](UserId),
SecurityCode NVARCHAR(MAX),
Message NVARCHAR(MAX),
MessageTypeId INT FOREIGN KEY REFERENCES [MessageType](Id),
Link NVARCHAR(MAX),
SentOn DATETIME
)

INSERT INTO [MessageType] (TYPE) VALUES ('TEXT')

INSERT INTO [MessageType] (TYPE) VALUES ('IMAGE')

INSERT INTO [MessageType] (TYPE) VALUES ('VIDEO')

INSERT INTO [MessageType] (TYPE) VALUES ('TEXT&IMAGE')

INSERT INTO [MessageType] (TYPE) VALUES ('TEXT&VIDEO')

CREATE VIEW UserLastMessage
AS
SELECT UM1.* 
FROM UserMessage UM1
	INNER JOIN 
	(SELECT UserId,RecepientId,MAX(SentOn) AS LastMsg 
	FROM UserMessage 
	GROUP BY UserId,RecepientId)UM2
ON UM1.UserId=UM2.UserId 
AND UM1.RecepientId=UM2.RecepientId 
AND UM1.SentOn=UM2.LastMsg

CREATE VIEW UserContact
AS
SELECT 
	CON.UserId AS 'UserId',
	UD.UserId AS 'ContactId',
	UD.UserName AS 'ContactName',
	UD.ImageLink AS 'ContactImageLink',
	UM.Message AS 'Text',
	UM.MessageTypeId AS 'MessageTypeId',
	UM.Link AS 'Link',
	UM.SentOn AS 'LastUpdated',
	'1' AS 'Sent'
FROM [dbo].Contacts AS CON
	INNER JOIN [dbo].UserDetails AS UD
		ON UD.UserId=CON.ContactId
	INNER JOIN UserLastMessage AS UM
		ON UM.UserId=CON.UserId
		AND UM.RecepientId=CON.ContactId