CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AddressId] INT NOT NULL ,
    [PersonId] INT NOT NULL , 
    [CompanyName] NVARCHAR(50) NOT NULL, 
    [Position] NVARCHAR(50) NULL, 
    [Employee] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Employee_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id]), 
    CONSTRAINT [FK_Employee_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])
)

GO

CREATE TRIGGER [dbo].[Trigger_Employee_CreateCompany]
    ON [dbo].[Employee]
    After INSERT
    AS
    set NOCOUNT on;
    BEGIN
        Insert into Company (Name, AddressId)
		Values (
        (Select CompanyName from inserted),
        (Select AddressId from inserted));
    END