CREATE TABLE [dbo].[Users]
(
	[Id] INT PRIMARY KEY identity(1,1),
	[FirstName] varchar(50) not null,
	[LastName] varchar(50) not null
)
