/*******************************************************************************  
sksbank database
   Script: Create_sksbank.sql  
   Description: Creates and populates the sksbank database.  
   DB Server: SQLServer  
   Author: Dario Ospina, Carl Ocsan, Jody Boston, Michael Boddy
*********************************************************************************/  

/********************************************************
* This script creates the database named sksbank
*********************************************************/
USE master;
GO

/*Drop DB if exists*/
IF DB_ID('sksbank') IS NOT NULL
    DROP DATABASE sksbank;
GO

IF DB_ID('sksbank') IS NULL
	CREATE DATABASE sksbank;
GO

/********************************************************
* Creating the tables for the database
*********************************************************/
USE sksbank;

CREATE TABLE Locations (
	Location_ID				INT				PRIMARY KEY,
	[City Name]				VARCHAR(30)		NOT NULL,
	[Province Name]			VARCHAR(30)		NOT NULL,
	[Country]				VARCHAR(30)		NOT NULL
);

CREATE TABLE Branches (
	Branch_ID				INT				PRIMARY KEY,
	[Name]					VARCHAR(30)		NOT NULL UNIQUE,
	[Street]				VARCHAR(30)		NOT NULL,
	[Location_ID]			INT				REFERENCES Locations(Location_ID),
	[Phone]					VARCHAR(15)		NOT NULL,		
	[Email]					VARCHAR(30)		NOT NULL,
	[Branch_location]		BIT				NOT NULL
);

--![Total Exposure]	MONEY, /*column to be removed because it's not a fixed value, should be invoked using a query*/
--![Total Deposits]	MONEY /*column to be removed because it's not a fixed value, should be invoked using a query*/

CREATE TABLE Employees (
	Employee_ID				INT				PRIMARY KEY,
	[FName]					VARCHAR(30)		NOT NULL,
	[LName]					VARCHAR(30)		NOT NULL,
	[Job]					VARCHAR(30)		NOT NULL,
	[ReportsTo]				INT				NULL,
	[Start date]			DATE			NOT NULL,
	[Branch_ID]				INT				REFERENCES Branches(Branch_ID)
);

CREATE TABLE Customers (
	Customer_ID				INT				PRIMARY KEY,
	[FName]					VARCHAR(30)		NOT NULL,
	[LName]					VARCHAR(30)		NOT NULL,
	[Branch_ID]				INT				REFERENCES Branches(Branch_ID),
	[Employee_ID]			INT				REFERENCES Employees(Employee_ID),
	[Street]				VARCHAR(30)		NULL,
	[Location_ID]			INT				REFERENCES Locations(Location_ID),
	[Phone]					VARCHAR(15)		NULL,
	[Email]					VARCHAR(30)		NULL
); 

CREATE TABLE Accounts (
	Account_ID				INT				PRIMARY KEY,
	[Type]					VARCHAR(30)		NOT NULL,
	[Interest_Rate]			FLOAT			NULL,
	[Joint_Account]			VARCHAR(15)		NULL
);

CREATE TABLE Transactions (
	Transaction_ID			INT			PRIMARY KEY,
	[Transaction_type]		VARCHAR(20)	NOT NULL,
	[Transaction_amount]	MONEY		NOT NULL,
	[Date]					DATE		NOT NULL,
	[Check_number]			INT			NOT NULL,
	[Account_ID]			INT			REFERENCES Accounts(Account_ID),
	[Branch_ID]				INT			REFERENCES Branches(Branch_ID)
);

CREATE TABLE Loans (
	Loan_ID					INT			PRIMARY KEY,
	[Branch_ID]				INT			REFERENCES Branches(Branch_ID),
	[Initial_principal]		MONEY		NOT NULL,
);
/* REF: Amount Due - column to be removed because this should be invoked using a query*/

CREATE TABLE Loan_Customer (
	[Loan_ID]				INT			REFERENCES Loans(Loan_ID),
	[Customer_ID]			INT			REFERENCES Customers(Customer_ID)
);

CREATE TABLE Loan_Transactions (
	LoanTran_ID				INT			PRIMARY KEY,
	[Date]					DATE		NOT NULL,
	[Payment]				MONEY		NOT NULL,
	[Loan_ID]				INT			REFERENCES Loans(Loan_ID)
);

CREATE TABLE Customer_Accounts (
	[Customer_ID]			INT			REFERENCES Customers(Customer_ID),
	[Account_ID]			INT			REFERENCES Accounts(Account_ID)
);

CREATE TABLE LastAccess (
	LastAccess_ID			INT			PRIMARY KEY,
	[Date]					DATETIME	NOT NULL,
	[Account_ID]			INT			REFERENCES Accounts(Account_ID)
);



/********************************************************
* Inserting data into the tables
*********************************************************/
INSERT INTO Locations (Location_ID,[City Name],[Province Name],[Country])
VALUES
(1,'Vancouver','BC','Canada'),
(2,'Calgary','AB','Canada'),
(3,'Toronto','ON','Canada'),
(4,'Creston','BC','Canada'),
(5,'Whistler','BC','Canada');

INSERT INTO Branches (Branch_ID,[Name],[Street],[Location_ID],[Phone],[Email],[Branch_location]) 
VALUES
(65001,'SKS Bank Vancouver','345 South Frank Street', 1, '(250)456-9845', 'sksvan@sks.com',1),
(65011,'SKS Bank Calgary', '54 Ave West', 2, '(403)403-4565', 'sksyyc@sks.com',1),
(65021,'SKS Bank Toronto','99 Drake Lane', 3, '(606)468-1111', 'skstor@sks.com',1),
(65031,'SKS Bank Creston','Unit 6, 50 High Street', 4, '(250)666-5987', 'skscre@sks.com',1),
(65041,'SKS Bank Whistler','20 Main Street', 5, '(604)9986495', 'skswhi@sks.com',1);

INSERT INTO Employees (Employee_ID,[FName],[LName],[Job],[ReportsTo],[Start date],[Branch_ID])
VALUES
(1001,'Peter','Parker','Regional manager',NULL,'2015-08-05',65011),
(1002,'Tracy','Peterson','Regional manager',NULL,'2002-07-09',65001),
(1003,'Bruce','McMaster','Branch manager',1001,'2012-09-22',65011),
(1004,'Aline','Hernandez','Branch manager',1002,'2014-12-07',65001),
(1005,'Dario','Ospina','Personal Banker Sr',1003,'2019-01-14',65011),
(1006,'Carl','Ocsan','Personal Banker Sr',1003,'2020-12-09',65011),
(1007,'Jody','Boston','Personal Banker Sr',1004,'2009-06-10',65001),
(1008,'Michael','Boddy','Personal Banker Sr',1004,'2017-03-28',65001);

INSERT INTO Customers (Customer_ID,[FName],[LName],[Branch_ID],[Employee_ID],[Street],[Location_ID],[Phone],[Email])
VALUES
(6000001,'John', 'Smith',65001,1005,'1556 Charles St 110',1,'(604) 253-3495','inico@optonline.net'),
(6000002,'Jane', 'Stokes',65011,1006,'62 Scanlon Hill NW',2,'(403) 338-1331','jnolan@yahoo.ca'),
(6000003,'Robin', 'Jackson',65021,1007,'791 Queen St E',3,'(416) 465-9542','rhialto@msn.com'),
(6000004,'Mike', 'Jones',65021,1008,'278 Bloor St E',3,'(416) 924-5870','mikel63@yahoo.com'),
(6000005,'Clare', 'Bishop',65001,1006,'506 1530 8th Ave W',1,'(604) 736-4109',NULL),
(6000006,'Felix', 'Davidson',65011,1007,'15 Lake Placid Hill SE',2,'(403) 225-0514',NULL),
(6000007,'Jonny', 'Potter',65031,1008,'1565 Teetzel Rd',4,'250-402-0055','joyce45@gmail.com'),
(6000008,'Ryan', 'Jack',65001,1005,'1254 8th Ave E 202',1,'(604) 707-6483',NULL),
(6000009,'Jon', 'Boyle',65041,1006,'107 4905 Spearhead Pl',5,'(604) 932-3704','jon_boyle@hotmail.com'),
(6000010,'Phil', 'Boppi',65011,1007,'10731 Mapleshire Cres SE',2,'(403) 271-0060',NULL),
(6000011,'Carlos', 'Smith',65001,1008,'1825 Purcell Way 43 North',1,'(604) 980-8255','carleton7@yahoo.com'),
(6000012,'Mary', 'Poppini',65041,1005,'3232 Peak Dr Whistler',5,'(604) 932-0455',NULL),
(6000013,'Harry', 'Truffle',65011,1006,'19 Coverdale Way NE',2,'403-289-4997','hachi@comcast.net'),
(6000014,'Harriet', 'Jones',65021,1007,'12 Lark St',3,'(416) 694-2011',NULL),
(6000015,'Tyson', 'Fury',65001,1008,'3266 Marine Dr SW',1,'(604) 264-7710','tubesteak@msn.com');

INSERT INTO Accounts (Account_ID,[Type],[Interest_Rate],[Joint_Account])
VALUES
(500812,'Checking',0,'TRUE'),
(800712,'Savings',0.01,'FALSE'),
(500563,'Checking',0,'FALSE'),
(500950,'Checking',0,'FALSE'),
(500894,'Checking',0,'FALSE'),
(800794,'Savings',0.01,'FALSE'),
(500859,'Checking',0,'FALSE'),
(500830,'Checking',0,'FALSE');

INSERT INTO Transactions (Transaction_ID,[Transaction_type],[Transaction_amount],[Date],[Check_number],[Account_ID],[Branch_ID])
VALUES
(10000001,'Deposit',1500,'2021-09-25',30000001,500812,65011),
(10000002,'Withdraw',900,'2021-09-26',30000002,500812,65011),
(10000003,'Deposit',400,'2021-09-26',30000003,500563,65021),
(10000004,'Deposit',70,'2021-09-27',30000004,500950,65001),
(10000005,'Withdraw',100,'2021-09-28',30000005,500563,65021),
(10000006,'Deposit',560,'2021-09-28',30000006,800794,65041),
(10000007,'Deposit',220,'2021-09-28',30000007,500859,65041),
(10000008,'Deposit',150,'2021-09-29',30000008,500830,65031);

INSERT INTO Loans (Loan_ID,[Branch_ID],[Initial_principal])
VALUES
(90000001,65011,150000),
(90000002,65011,22000),
(90000003,65011,2000),
(90000004,65011,70000),
(90000005,65011,200000),
(90000006,65011,25000),
(90000007,65011,19000),
(90000008,65011,52000);

INSERT INTO Loan_transactions (LoanTran_ID,[Date],[Payment],[Loan_ID])
VALUES
(42000001,'2021-09-27',2000,90000001),
(42000002,'2021-09-28',2500,90000002),
(42000003,'2021-09-29',5000,90000001),
(42000004,'2021-10-01',20000,90000004),
(42000005,'2021-10-01',5000,90000005),
(42000006,'2021-10-02',250,90000006),
(42000007,'2021-10-03',1000,90000007),
(42000008,'2021-10-03',2000,90000008);

INSERT INTO LastAccess (LastAccess_ID,[Date],[Account_ID])
VALUES
(89001,'2021-09-27 18:20:59',500812),
(89002,'2021-09-27 18:55:01',500812);

INSERT INTO Loan_Customer([Loan_ID],[Customer_ID])
VALUES
(90000001,6000003),
(90000002,6000004),
(90000003,6000005),
(90000004,6000006),
(90000005,6000007),
(90000006,6000008),
(90000007,6000009),
(90000008,6000010);

INSERT INTO Customer_Accounts ([Customer_ID], [Account_ID])
VALUES
(6000001,500812),
(6000002,500812);