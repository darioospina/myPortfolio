/*******************************************************************************  
Description: Project phase 2 implementation 
DB Server: SQLServer  
Author: Dario Ospina, Carl Ocsan, Jody Boston, Michael Boddy
*********************************************************************************/  

/*******************************************************************************  
	STEP 1. Implementing different functionalities using stored procedure and user defined function. (15 points)
*********************************************************************************/  
--STORE PROCEDURE 
USE sksbank
GO
CREATE PROC dbo.sp_FindCity (@City VARCHAR(30))
AS
BEGIN
	SELECT *
	FROM Locations
	WHERE [City Name] = @City
END
GO
--Testing
DECLARE @City VARCHAR(30);
EXEC DBO.sp_FindCity @City = 'Calgary'

--USER DEFINED FUNCTION 
USE sksbank;
GO
CREATE FUNCTION FN_ViewCustomersByLocation (@LocationValue INT)
 RETURNS TABLE
 AS
 RETURN (SELECT * FROM Customers
 WHERE Location_ID = @LocationValue)
--Testing
SELECT * FROM FN_ViewCustomersByLocation(1)
SELECT * FROM FN_ViewCustomersByLocation(2)
SELECT * FROM FN_ViewCustomersByLocation(3)

/*******************************************************************************  
	STEP 2. Create different set of triggers (minimum 2 numbers) to monitor the different DML and DDL activates in the database (10 point)
*********************************************************************************/  

--DDL TRIGGER 
USE sksbank
DROP TRIGGER IF EXISTS dbo.trigger_audit_table_events
GO
DROP TABLE IF EXISTS dbo.TableLog
GO
CREATE TABLE TableLog (Log_ID INT IDENTITY(1,1) PRIMARY KEY , EventValue XML, EventDate DATETIME NOT NULL, LoginName NVARCHAR(100))
GO
ALTER TRIGGER trigger_audit_table_events
ON DATABASE
FOR DDL_TABLE_EVENTS /*CREATE, ALTER, DROP*/
AS
BEGIN
	INSERT INTO TableLog (EventValue, EventDate, LoginName)
		VALUES (EVENTDATA(), GETDATE(), CONVERT(NVARCHAR(100), CURRENT_USER));
END;
--Testing
DROP TABLE IF EXISTS dbo.Test;
GO
CREATE TABLE Test2 (TestID INT PRIMARY KEY, Test_Description VARCHAR(100));
SELECT * FROM TableLog


--DML TRIGGER 
CREATE TRIGGER tg_LoanPayment
ON Loan_Transactions
AFTER INSERT
AS
BEGIN
	DECLARE @loanTransId AS INT,
	@amount AS MONEY;
	SELECT @loanTransId = LoanTran_ID, @amount = Payment FROM Loan_Transactions;PRINT 'A payment was made, Transaction ID:' +Convert(varchar,@loanTransId) + ' Payment: ' + Convert(varchar,@amount) + ' Date: ' + Convert(varchar,GETDATE());
END;
--Testing
INSERT INTO Loan_Transactions(LoanTran_ID, Payment, Date)
VALUES (420000010, 2000, GETDATE());


--DML TRIGGER 
USE sksbank
GO
-- creating new table to copy archive data into.
CREATE TABLE Accounts_Backup 
([Id] INT NOT NULL,[Account Type] VARCHAR (30) NOT NULL,[Interest Rate] FLOAT NULL,[Is Joint Account] VARCHAR (15) NULL, [Backup Date] DATE NOT NULL)
-- see we created a new col to store date processed.)
-- Create trigger to store updates.
USE sksbank
GO
CREATE TRIGGER dbo.TG_AccountsInsert 
   ON Accounts AFTER UPDATE
AS 
BEGIN
	INSERT INTO Accounts_Backup
	(Id, [Account Type], [Interest Rate],[Is Joint Account],[Backup Date])
	SELECT Account_ID, [Type], Interest_Rate, Joint_Account, GETDATE() 
	FROM DELETED
END
GO
--Testing
UPDATE Accounts SET Joint_Account = 'RECENT CHANGE' WHERE Account_ID = 500830;
-- The data in the Accounts table will be updated
-- and the archive data is copied to the Accounts Backup.
SELECT * FROM Accounts_Backup;
SELECT * FROM Accounts WHERE Account_ID = 500830;

/*******************************************************************************  
	STEP 3. Create index based on frequently used attribute for three of any table (10 point) 
*********************************************************************************/  
--CLUSTERED INDEX 
--TASK - Replace the default cluster index with non-key attribute for one table. 
--If you used GUI please provide details on which table you implemented it */
USE sksbank
GO
CREATE CLUSTERED INDEX IX_defaultClustered ON LastAccess(Account_ID)
-- Notes: Due to the way our DB is constructed, we only have 2 tables that 'maybe' could use this on
-- However, after attempting this, it is not possible without dropping the table and recreating it. 


--CLUSTERED COMPOSITE INDEX 
--Create Composite clustered index for one of the table by removing the default clustered index. 
--If you used GUI please provide details on which table you implemented it 
USE sksbank
GO
DROP INDEX IX_defaultClustered ON LastAccess
GO
USE sksbank
GO
CREATE CLUSTERED INDEX IX_CompositeClustered ON LastAccess(Date, LastAccess_ID)
SELECT Date,LastAccess_ID FROM LastAccess


--NON CLUSTERED COMPOSITE INDEX 
--Create non clustered composite index for one of the table you have. 
--If you used GUI please provide details on which table you implemented it 
USE sksbank
GO
CREATE NONCLUSTERED INDEX IX_CompositeNonClustered ON Customers(FName, Location_ID)
GO
SELECT FName, LName, Location_ID
FROM Customers WHERE FName LIKE 'J%'


/*******************************************************************************  
	STEP 4. Create different level of users and assign appropriate privilege. (10 point)
*********************************************************************************/  
--USER # 1 
--Creating login customer_422787
USE [sksbank]
GO
DROP USER [customer_422787]
GO
USE [master]
GO
DROP LOGIN [customer_422787]
GO
CREATE LOGIN [customer_422787] WITH PASSWORD=N'customer', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
--Creating user customer_422787 for database sksbank
USE [sksbank]
GO
CREATE USER [customer_422787] FOR LOGIN [customer_422787]
ALTER ROLE [db_owner] ADD MEMBER [customer_422787]
GO
--Denying permissions for user customer_422787
USE [sksbank]
GO
DENY SELECT, INSERT, DELETE, UPDATE ON [dbo].[Branches] TO [customer_422787]
DENY SELECT, INSERT, DELETE, UPDATE ON [dbo].[Customers] TO [customer_422787]
DENY SELECT, INSERT, DELETE, UPDATE ON [dbo].[Employees] TO [customer_422787]
DENY SELECT, INSERT, DELETE, UPDATE ON [dbo].[Locations] TO [customer_422787]
GO
--Testing
INSERT INTO Locations VALUES (6,'Edmonton','AB','Canada')
DELETE FROM [dbo].Locations WHERE Location_ID = 6
SELECT * FROM [dbo].Locations

--USER # 2 
--Creating login accountant_422787
USE [sksbank]
GO
DROP USER IF EXISTS [accountant_422787]
GO
USE [master]
GO
DROP LOGIN [accountant_422787]
GO
USE [master]
CREATE LOGIN [accountant_422787] WITH PASSWORD=N'accountant', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
--Creating user accountant_422787 for database sksbank
USE [sksbank]
GO
CREATE USER [accountant_422787] FOR LOGIN [accountant_422787]
ALTER ROLE [db_owner] ADD MEMBER [accountant_422787]
GO
--Denying permissions for user accountant_422787
USE [sksbank]
GO
DENY UPDATE ON [dbo].[Accounts] TO [accountant_422787]
DENY UPDATE ON [dbo].[Customer_Accounts] TO [accountant_422787]
DENY UPDATE ON [dbo].[Loans] TO [accountant_422787]
DENY UPDATE ON [dbo].[Loan_Customer] TO [accountant_422787]
DENY UPDATE ON [dbo].[Loan_Transactions] TO [accountant_422787]
GO
--Testing
UPDATE [dbo].Loans SET Initial_principal = 0 WHERE Loan_ID = 90000001
SELECT * FROM Loans


/*******************************************************************************  
	STEP 5. Recovery Model and Backup    ( 5 point)
*********************************************************************************/  
USE [master]
BACKUP DATABASE [sksbank] 
TO DISK ='C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup\sksbank15122022.bak'
GO

USE [master]
RESTORE DATABASE [sksbank] FROM  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup\sksbank15122022.bak'
GO





