/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Person 
VALUES ('First1', 'Last1');

INSERT INTO Address 
VALUES ('Street1', 'City1', 'State1', '1111');
INSERT INTO Address 
VALUES ('Street2', 'City2', 'State2', '2222');

INSERT INTO Company 
VALUES ('Google', 1);

INSERT INTO Employee 
VALUES (2, 1, 'Google', 'Position1', 'Employee1');