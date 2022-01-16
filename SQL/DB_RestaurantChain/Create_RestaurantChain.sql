/*******************************************************************************  

TPP Database

   Script: Create_RestaurantChain.sql  
   Description: Creates and populates the TPP database.  
   DB Server: SqlServer  
   Author: Connor Pittman, Dario Ospina  

********************************************************************************/  

USE master;

/*******************************************************************************  
   Drop Database if it exists  
********************************************************************************/  

IF DB_ID('TPP') IS NOT NULL
	DROP DATABASE TPP;

/*******************************************************************************  
   Create Database  
********************************************************************************/  

IF DB_ID('TPP') IS NULL
	CREATE DATABASE TPP
	USE TPP;

/*******************************************************************************  
   Create Tables  
********************************************************************************/  

CREATE TABLE Location
	(Location_ID int PRIMARY KEY,   
	CityName varchar(100) NULL,  
	ProvinceName varchar(100) NULL); 
CREATE TABLE Manager  
	(Manager_ID int PRIMARY KEY,  
	ManagerFName varchar(50) NULL,  
	ManagerLName varchar(50) NULL); 
CREATE TABLE Restaurant  
	(Restaurant_ID int PRIMARY KEY,  
	RestaurantName varchar(100) NULL,  
	Location_ID int REFERENCES Location(Location_ID),  
	Manager_ID int REFERENCES Manager(Manager_ID));  
CREATE TABLE Employee  
	(Employee_ID int PRIMARY KEY,  
	EmployeeFName varchar(50) NULL,  
	EmployeeLName varchar(50) NULL,  
	Restaurant_ID int REFERENCES Restaurant(Restaurant_ID));  
CREATE TABLE Supplier  
	(Supplier_ID int PRIMARY KEY,  
	SupplierName varchar(100),  
	Location_ID int REFERENCES Location(Location_ID));  
CREATE TABLE Customer  
	(Customer_ID int PRIMARY KEY,  
	CustomerFName varchar(50) NULL,  
	CustomerLName varchar(50) NULL,  
	CustomerAddress varchar(100) NULL);  
CREATE TABLE Ingredient  
	(Ingredient_ID int PRIMARY KEY,  
	IngredientCost money NOT NULL);  
CREATE TABLE Dish  
	(Dish_ID int PRIMARY KEY,  
	DishName varchar(50) NULL,  
	DishCost money NOT NULL,  
	DishPrice money NOT NULL);  
CREATE TABLE Bill 
	(Bill_ID int PRIMARY KEY,  
	[DateTime] DateTime NOT NULL,  
	Customer_ID int REFERENCES Customer(Customer_ID),  
	Employee_ID int REFERENCES Employee(Employee_ID));  
CREATE TABLE Supplier_Ingredient  
	(Supplier_ID int REFERENCES Supplier(Supplier_ID),  
	Ingredient_ID int REFERENCES Ingredient(Ingredient_ID),
	PRIMARY KEY (Supplier_ID, Ingredient_ID));  
CREATE TABLE Dish_Ingredient  
	(Ingredient_ID int REFERENCES Ingredient(Ingredient_ID),  
	Dish_ID int REFERENCES Dish(Dish_ID),
	PRIMARY KEY (Ingredient_ID, Dish_ID));  
CREATE TABLE Bill_Dish  
	(Bill_ID int REFERENCES Bill(Bill_ID),  
	Dish_ID int REFERENCES Dish(Dish_ID),
	PRIMARY KEY (Bill_ID, Dish_ID)); 

/*******************************************************************************  
   Populate Tables 
********************************************************************************/ 

INSERT INTO Location (Location_ID, CityName, ProvinceName) VALUES (100, 'Calgary', 'AB');
INSERT INTO Location (Location_ID, CityName, ProvinceName) VALUES (110, 'Edmonton', 'AB');
INSERT INTO Location (Location_ID, CityName, ProvinceName) VALUES (120, 'Toronto', 'ON');
INSERT INTO Location (Location_ID, CityName, ProvinceName) VALUES (130, 'Montreal', 'QC');
INSERT INTO Location (Location_ID, CityName, ProvinceName) VALUES (140, 'Ottawa', 'ON');

INSERT INTO Manager (Manager_ID, ManagerFName, ManagerLName) VALUES (200, 'Connor', 'Pittman');
INSERT INTO Manager (Manager_ID, ManagerFName, ManagerLName) VALUES (210, 'Dario', 'Ospina');
INSERT INTO Manager (Manager_ID, ManagerFName, ManagerLName) VALUES (220, 'Nisha', 'Radhamoni');
INSERT INTO Manager (Manager_ID, ManagerFName, ManagerLName) VALUES (230, 'Pasquale', 'Laporta');
INSERT INTO Manager (Manager_ID, ManagerFName, ManagerLName) VALUES (240, 'Sean', 'Lynch');

INSERT INTO Restaurant (Restaurant_ID, RestaurantName, Location_ID, Manager_ID) VALUES (500, 'Excellent Experience', 100, 200);
INSERT INTO Restaurant (Restaurant_ID, RestaurantName, Location_ID, Manager_ID) VALUES (510, 'Dine Fine', 110, 210);
INSERT INTO Restaurant (Restaurant_ID, RestaurantName, Location_ID, Manager_ID) VALUES (520, 'Dinner Club', 100, 220);
INSERT INTO Restaurant (Restaurant_ID, RestaurantName, Location_ID, Manager_ID) VALUES (530, 'Dine Dime', 130, 230);
INSERT INTO Restaurant (Restaurant_ID, RestaurantName, Location_ID, Manager_ID) VALUES (540, 'Finest Dining', 140, 240);
INSERT INTO Restaurant (Restaurant_ID, RestaurantName, Location_ID, Manager_ID) VALUES (550, 'Cassis Bistro', 100, 200);

INSERT INTO Employee (Employee_ID, EmployeeFName, EmployeeLName, Restaurant_ID) VALUES (3000, 'Ralph', 'Lauren', 500);
INSERT INTO Employee (Employee_ID, EmployeeFName, EmployeeLName, Restaurant_ID) VALUES (3010, 'William', 'Born', 500);
INSERT INTO Employee (Employee_ID, EmployeeFName, EmployeeLName, Restaurant_ID) VALUES (3020, 'Peter', 'Peterson', 510);
INSERT INTO Employee (Employee_ID, EmployeeFName, EmployeeLName, Restaurant_ID) VALUES (3030, 'Laura', 'Wins', 510);
INSERT INTO Employee (Employee_ID, EmployeeFName, EmployeeLName, Restaurant_ID) VALUES (3040, 'Pedro', 'Pérez', 540);
INSERT INTO Employee (Employee_ID, EmployeeFName, EmployeeLName, Restaurant_ID) VALUES (3050, 'Lucas', 'Villa', 520);
INSERT INTO Employee (Employee_ID, EmployeeFName, EmployeeLName, Restaurant_ID) VALUES (3060, 'Amy', 'Rose', 540);
INSERT INTO Employee (Employee_ID, EmployeeFName, EmployeeLName, Restaurant_ID) VALUES (3070, 'Lola', 'Van Wagner', 530);
INSERT INTO Employee (Employee_ID, EmployeeFName, EmployeeLName, Restaurant_ID) VALUES (3080, 'Pablo', 'Trujillo', 510);
INSERT INTO Employee (Employee_ID, EmployeeFName, EmployeeLName, Restaurant_ID) VALUES (3090, 'Steven', 'Yeun', 520);
INSERT INTO Employee (Employee_ID, EmployeeFName, EmployeeLName, Restaurant_ID) VALUES (3100, 'Rachel', 'Taylor-Ferguson', 550);

INSERT INTO Supplier (Supplier_ID, SupplierName, Location_ID) VALUES (400, 'Wholesale Dinnerware Suppliers', 140);
INSERT INTO Supplier (Supplier_ID, SupplierName, Location_ID) VALUES (410, 'Kraft Foods Inc.', 140);
INSERT INTO Supplier (Supplier_ID, SupplierName, Location_ID) VALUES (440, 'Catelli Pasta', 100);
INSERT INTO Supplier (Supplier_ID, SupplierName, Location_ID) VALUES (420, 'The Kraft Heinz Company', 120);
INSERT INTO Supplier (Supplier_ID, SupplierName, Location_ID) VALUES (430, 'Dandy Brewing Company', 120);

INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11001, 'Demi', 'Moore', '3933 Nelson Street');
INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11002, 'Jason', 'Lee', NULL);
INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11003, 'Whoopi', 'Goldberg', '4066 Cordova Street');
INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11004, 'Calvin', 'Harris', '92 Auburn Ave');
INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11005, 'Vin', 'Diesel', NULL);
INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11006, 'Brad', 'Pitt', NULL);
INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11007, 'Angelina', 'Jolie', NULL);
INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11008, 'Emma', 'Stone', '2844 Harrison Street');
INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11009, 'Johnny', 'Depp', '2873 Dola Mine Road');
INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11010, 'Julia', 'Roberts', NULL);
INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11011, 'Will', 'Smith', NULL);
INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11012, 'Paul', 'Rudd', '760 Ford Street');
INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11013, 'Leonardo', 'DiCaprio', NULL);
INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11014, 'Nicole', 'Kidman', '1221 Long Street');
INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11015, 'Meryl', 'Streep', NULL);
INSERT INTO Customer (Customer_ID, CustomerFName, CustomerLName, CustomerAddress) VALUES (11016, 'Keanu', 'Reeves', NULL);

INSERT INTO Ingredient (Ingredient_ID, IngredientCost) VALUES (9000, 2.00);
INSERT INTO Ingredient (Ingredient_ID, IngredientCost) VALUES (9001, 3.00);
INSERT INTO Ingredient (Ingredient_ID, IngredientCost) VALUES (9002, 1.00);
INSERT INTO Ingredient (Ingredient_ID, IngredientCost) VALUES (9003, 0.50);
INSERT INTO Ingredient (Ingredient_ID, IngredientCost) VALUES (9004, 4.10);
INSERT INTO Ingredient (Ingredient_ID, IngredientCost) VALUES (9005, 0.70);
INSERT INTO Ingredient (Ingredient_ID, IngredientCost) VALUES (9007, 1.50);
INSERT INTO Ingredient (Ingredient_ID, IngredientCost) VALUES (9009, 0.90);
INSERT INTO Ingredient (Ingredient_ID, IngredientCost) VALUES (9012, 1.20);
INSERT INTO Ingredient (Ingredient_ID, IngredientCost) VALUES (9013, 0.30);
INSERT INTO Ingredient (Ingredient_ID, IngredientCost) VALUES (9015, 2.50);

INSERT INTO Dish (Dish_ID, DishName, DishCost, DishPrice) VALUES (600, 'Spaghetti', 4.20, 13.50);
INSERT INTO Dish (Dish_ID, DishName, DishCost, DishPrice) VALUES (610, 'Tortellini', 6.50, 12.00);
INSERT INTO Dish (Dish_ID, DishName, DishCost, DishPrice) VALUES (620, 'Roast Beef', 5.60, 15.00);
INSERT INTO Dish (Dish_ID, DishName, DishCost, DishPrice) VALUES (630, 'Pizza', 1.90, 7.00);
INSERT INTO Dish (Dish_ID, DishName, DishCost, DishPrice) VALUES (640, 'Penne', 2.50, 8.50);

INSERT INTO Bill (Bill_ID, Customer_ID, Employee_ID, [DateTime]) VALUES (20001, 11012, 3060, '2021-05-28 12:05:01');
INSERT INTO Bill (Bill_ID, Customer_ID, Employee_ID, [DateTime]) VALUES (20002, 11015, 3010, '2021-05-28 13:10:12');
INSERT INTO Bill (Bill_ID, Customer_ID, Employee_ID, [DateTime]) VALUES (20003, 11015, 3070, '2021-05-28 13:25:00');
INSERT INTO Bill (Bill_ID, Customer_ID, Employee_ID, [DateTime]) VALUES (20004, 11005, 3020, '2021-05-28 14:20:02');
INSERT INTO Bill (Bill_ID, Customer_ID, Employee_ID, [DateTime]) VALUES (20005, 11010, 3080, '2021-05-28 14:25:00');
INSERT INTO Bill (Bill_ID, Customer_ID, Employee_ID, [DateTime]) VALUES (20006, 11001, 3050, '2021-05-28 14:42:07');
INSERT INTO Bill (Bill_ID, Customer_ID, Employee_ID, [DateTime]) VALUES (20007, 11009, 3010, '2021-05-28 15:05:32');
	
INSERT INTO Supplier_Ingredient (Supplier_ID, Ingredient_ID) VALUES (400, 9000);
INSERT INTO Supplier_Ingredient (Supplier_ID, Ingredient_ID) VALUES (410, 9001);
INSERT INTO Supplier_Ingredient (Supplier_ID, Ingredient_ID) VALUES (410, 9002);
INSERT INTO Supplier_Ingredient (Supplier_ID, Ingredient_ID) VALUES (400, 9003);
INSERT INTO Supplier_Ingredient (Supplier_ID, Ingredient_ID) VALUES (440, 9004);
INSERT INTO Supplier_Ingredient (Supplier_ID, Ingredient_ID) VALUES (420, 9005);
INSERT INTO Supplier_Ingredient (Supplier_ID, Ingredient_ID) VALUES (400, 9007);
INSERT INTO Supplier_Ingredient (Supplier_ID, Ingredient_ID) VALUES (440, 9009);
INSERT INTO Supplier_Ingredient (Supplier_ID, Ingredient_ID) VALUES (410, 9012);
INSERT INTO Supplier_Ingredient (Supplier_ID, Ingredient_ID) VALUES (430, 9013);
INSERT INTO Supplier_Ingredient (Supplier_ID, Ingredient_ID) VALUES (430, 9015);
INSERT INTO Supplier_Ingredient (Supplier_ID, Ingredient_ID) VALUES (420, 9000);
INSERT INTO Supplier_Ingredient (Supplier_ID, Ingredient_ID) VALUES (440, 9000);

INSERT INTO Dish_Ingredient (Ingredient_ID, Dish_ID) VALUES (9000, 600);
INSERT INTO Dish_Ingredient (Ingredient_ID, Dish_ID) VALUES (9001, 610);
INSERT INTO Dish_Ingredient (Ingredient_ID, Dish_ID) VALUES (9002, 610);
INSERT INTO Dish_Ingredient (Ingredient_ID, Dish_ID) VALUES (9002, 620);
INSERT INTO Dish_Ingredient (Ingredient_ID, Dish_ID) VALUES (9002, 630);
INSERT INTO Dish_Ingredient (Ingredient_ID, Dish_ID) VALUES (9002, 640);
INSERT INTO Dish_Ingredient (Ingredient_ID, Dish_ID) VALUES (9003, 620);
INSERT INTO Dish_Ingredient (Ingredient_ID, Dish_ID) VALUES (9004, 620);
INSERT INTO Dish_Ingredient (Ingredient_ID, Dish_ID) VALUES (9005, 600);
INSERT INTO Dish_Ingredient (Ingredient_ID, Dish_ID) VALUES (9007, 600);
INSERT INTO Dish_Ingredient (Ingredient_ID, Dish_ID) VALUES (9009, 630);
INSERT INTO Dish_Ingredient (Ingredient_ID, Dish_ID) VALUES (9012, 640);
INSERT INTO Dish_Ingredient (Ingredient_ID, Dish_ID) VALUES (9013, 640);
INSERT INTO Dish_Ingredient (Ingredient_ID, Dish_ID) VALUES (9015, 610);

INSERT INTO Bill_Dish (Bill_ID, Dish_ID) VALUES (20001, 620);
INSERT INTO Bill_Dish (Bill_ID, Dish_ID) VALUES (20002, 600);
INSERT INTO Bill_Dish (Bill_ID, Dish_ID) VALUES (20003, 620);
INSERT INTO Bill_Dish (Bill_ID, Dish_ID) VALUES (20004, 640);
INSERT INTO Bill_Dish (Bill_ID, Dish_ID) VALUES (20004, 610);
INSERT INTO Bill_Dish (Bill_ID, Dish_ID) VALUES (20004, 620);
INSERT INTO Bill_Dish (Bill_ID, Dish_ID) VALUES (20005, 610);
INSERT INTO Bill_Dish (Bill_ID, Dish_ID) VALUES (20005, 600);
INSERT INTO Bill_Dish (Bill_ID, Dish_ID) VALUES (20006, 630);
INSERT INTO Bill_Dish (Bill_ID, Dish_ID) VALUES (20007, 640);
