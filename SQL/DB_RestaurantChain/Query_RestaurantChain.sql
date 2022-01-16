/*******************************************************************************  

TPP Query

   Script: Query_RestaurantChain.sql  
   Description: Presents some queries from TPP database.  
   DB Server: SqlServer  
   Author: Connor Pittman, Dario Ospina  

********************************************************************************/ 


--1. WHERE clause 
/** Return the ID and Full Name (First Name and Last Name) of employees that work at restaurants
with ID numbers 500 and 510.
--Order by First Name, then by Last Name **/
USE TPP
SELECT Employee_ID, EmployeeFName + ' ' + EmployeeLName AS FullName
FROM Employee
WHERE Restaurant_ID = '500' OR Restaurant_ID = '510'
ORDER BY EmployeeFName, EmployeeLName;


--2. CASE clause
/** Use a CASE statement to determine whether a CustomerAddress contains "Street" or "Road",
then only return non-null values **/
USE TPP
SELECT CustomerRoadOrStreet =
	CASE 
		WHEN CustomerAddress LIKE '%Street%' 
			THEN 'Street'  
		WHEN CustomerAddress LIKE '%Road%'
			THEN 'Road'
		WHEN CustomerAddress NOT LIKE ('%Street%' + '%Road%')
			THEN 'Neither'
		ELSE NULL
	END
FROM Customer
WHERE CustomerAddress IS NOT NULL
ORDER BY CustomerRoadOrStreet ASC;


--3. ALTER TABLE
/** Write an ALTER TABLE statement that adds a new column, CustomerEmail to Customer table.
--Use the varchar data type, disallow null values and assign 'Not provided' as default value **/
USE TPP
ALTER TABLE Customer
ADD CustomerEmail varchar(100) NOT NULL DEFAULT 'Not provided';
--TEST STATEMENT
SELECT * FROM Customer


--4. SUBQUERY
/** Write a SELECT statement that returns the Supplier_ID and SupplierName of suppliers
located in the same city as a restaurant' **/
USE TPP
SELECT Supplier_ID, SupplierName
FROM Supplier
WHERE Location_ID IN
	(SELECT Location_ID FROM Restaurant)
ORDER BY SupplierName;


--5. INNER JOIN
/** Write a statements that returns the following columns:
----Bill_ID (use the DISTINCT clause to return unique values)
----CustomerFullName (First Name and Last Name)
----DishName
----Only return the values for 'Spaghetti' **/
USE TPP
SELECT DISTINCT BD.Bill_ID, C.CustomerFName + ' ' + C.CustomerLName AS CustomerFullName, D.DishName
FROM Bill_Dish BD 
JOIN Bill B ON BD.Bill_ID = B.Bill_ID 
JOIN Customer C ON B.Customer_ID = C.Customer_ID 
JOIN Dish D ON BD.Dish_ID = D.Dish_ID
WHERE BD.Dish_ID = '600';


--6. GROUP BY and HAVING
/** Write a SELECT statement that utilizes the GROUP BY and HAVING clauses to group locations by Province
then return onloy those not in Alberta **/
USE TPP
SELECT CityName, ProvinceName
FROM Location
GROUP BY ProvinceName, CityName
HAVING ProvinceName <> 'AB'
ORDER BY ProvinceName, CityName;


--7. INSERT
/** Write an INSERT statement that adds the following rows to the Dish table:
------Dish_ID: 650, 660
------Dish Name: Penne, Meatballs
------Cost: CAD 3, CAD 4
------Price: CAD 8.5, CAD 8.5
------Use a column list for this statement. **/
USE TPP
INSERT INTO Dish (Dish_ID,DishName,DishCost,DishPrice)
VALUES (650,'Penne',3,8.5), (660,'Meatballs',4,8.5);
--TEST STATEMENT
SELECT * FROM Dish


--8. UNION
/** Use the UNION operator to return the Full Name (First Name and Last Name in a single column)
of all Employees, Managers and Customers in the Database **/
	USE TPP
	SELECT EmployeeFName + ' ' + EmployeeLName AS [Full Name]
	FROM Employee
UNION 
	SELECT ManagerFName + ' ' + ManagerLName
	FROM Manager
UNION
	SELECT CustomerFName + ' ' + CustomerLName
	FROM Customer
ORDER BY [Full Name];


--9. INTERSECT
/** Use the INTERSECT operator to check if there are any employees that are also customers.
Write a condition stating whether or not that there are employees that are also customers **/
IF EXISTS(SELECT EmployeeFName, EmployeeLName
	FROM Employee
	INTERSECT
	SELECT CustomerFName, CustomerLName
	FROM Customer)
BEGIN
	PRINT 'There are employees that are also customers'
END
ELSE
	PRINT 'There are no employees that are also customers';


--10. UPDATE
/** Write an UPDATE statement that changes the name of employee 3030 to "Demi Moore".
This can be used to show other possible output of query #9 **/
USE TPP
UPDATE Employee
SET EmployeeFName = 'Demi', EmployeeLName = 'Moore'
WHERE Employee_ID = 3030;
--TEST STATEMENT
SELECT * FROM Employee