CREATE VIEW [dbo].[EmployeeInfo]
	AS 
	SELECT e.Id as EmployeeId,
		   p.LastName + ' ' + p.FirstName as EmployeeFullName,
		   a.ZipCode + ' ' + a.State + ' ' + a.City + ' ' + a.Street as EmployeeFullAddress, 
		   e.CompanyName + ' ' + e.Position as EmployeeCompanyInfo
	From dbo.Employee e
	Left Join dbo.Person p ON e.PersonId = p.Id
	Left Join dbo.Address a ON e.AddressId = a.Id
