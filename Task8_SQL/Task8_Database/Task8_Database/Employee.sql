CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AddressId] INT NOT NULL FOREIGN KEY REFERENCES [Address]([Id]),
    [PersonId] INT NOT NULL FOREIGN KEY REFERENCES [Person]([Id]), 
    [CompanyName] NVARCHAR(50) NOT NULL, 
    [Position] NVARCHAR(50) NULL, 
    [Employee] NVARCHAR(50) NULL
)
