CREATE PROCEDURE [dbo].[spInsertEmployeeInfo]
    @CompanyName nvarchar(50),
    @Street nvarchar(50),
	@EmployeeName nvarchar(50) = Null,
	@FirstName nvarchar(50) = Null,
	@LastName nvarchar(50) = Null,
	@Position nvarchar(50) = Null,
	@City nvarchar(50) = Null,
	@State nvarchar(50) = Null,
	@ZipCode nvarchar(50) = Null
AS
Begin
	If not ((@EmployeeName IS NULL OR @EmployeeName = '') 
		and (@FirstName IS NULL OR @FirstName = '')
		and (@LastName IS NULL OR @LastName = ''))
	Begin
		Insert into Address (Street, City, State, ZipCode)
		Values (@Street, @City, @State, @ZipCode);

		DECLARE @LastIdFromAddress AS int = (SELECT SCOPE_IDENTITY());

		Insert into Person (LastName, FirstName)
		Values (@LastName, @FirstName);

		DECLARE @LastIdFromPerson AS int = (SELECT SCOPE_IDENTITY());

		Insert into Employee (AddressId, PersonId, CompanyName, Position, Employee)
		values (
		@LastIdFromAddress,
		@LastIdFromPerson,
		@CompanyName, @Position, @EmployeeName);
	End
End