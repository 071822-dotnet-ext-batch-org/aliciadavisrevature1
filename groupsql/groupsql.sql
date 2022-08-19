--create the Customers table
CREATE TABLE Customers(
CustomerId INT PRIMARY KEY IDENTITY(1, 1),--IDENTITY() does not ensure uniqueness so you will have to alter the table to add the PK constraint to this column.
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Notes NTEXT NULL
);
--create the Addresses table
CREATE TABLE Addresses(
AddressId INT PRIMARY KEY IDENTITY(1, 1),-- see above
NumberStreet NVARCHAR(50) NOT NULL,
AptSuite NVARCHAR(7) NULL,
City NVARCHAR(85) NOT NULL,
ZipCode CHAR(5) NULL,  -- assume that every country uses numbers that equate to our zip code.
CountryCode SMALLINT NULL-- between is inclusive so we alter this below
);
--create the orders table
CREATE TABLE Orders(
OrderId INT PRIMARY KEY IDENTITY(1, 1),
OrderDate DATETIME DEFAULT(GETDATE()),
OrderTotal DECIMAL(6,2) NOT NULL,
FK_Customer INT FOREIGN KEY REFERENCES Customers(CustomerId) NOT NULL,
FK_Address INT FOREIGN KEY REFERENCES Addresses(AddressId) NOT NULL
);
--create the Customers/Addresses Junction table
CREATE TABLE CustomerAddressJunction(
Resident_Number_ID INT PRIMARY KEY IDENTITY(1, 1),
FK_Customer INT FOREIGN KEY REFERENCES Customers(CustomerId) ,
FK_Address INT FOREIGN KEY REFERENCES Addresses(AddressId)
);
-- add a new constraint to a table column.
ALTER TABLE Addresses
ADD CONSTRAINT valid_country_code CHECK(CountryCode between 1 and 998);

--alter table to more modern data type
ALTER TABLE [dbo].[Customers] ALTER COLUMN Notes NVARCHAR(max);

--alter table to money data type
ALTER TABLE [dbo].[Orders] ALTER COLUMN OrderTotal SMALLMONEY;

DROP TABLE [dbo].[CustomerAddressJunction];

--DELETE FROM [dbo].[Customers] WHERE CustomerID IN (3, 4);

--DELETE FROM [dbo].[Customers]
--DBCC CHECKIDENT ('dbo.Customers', RESEED, 0);

--DELETE FROM Addresses WHERE AddressID IN (5, 6, 7, 8);

--DELETE FROM Addresses
--DBCC CHECKIDENT ('Addresses', RESEED, 0);

--DELETE FROM [dbo].[Orders]
--DBCC CHECKIDENT ('dbo.Orders', RESEED, 0);


--Query 2 Inserting Data
SELECT *
FROM Customers;

SELECT *
FROM Addresses;

SELECT *
FROM Orders;

SELECT *
FROM CustomerAddressJunction;

INSERT INTO Customers(FirstName, LastName, Notes)
VALUES('John', 'Smith', 'Number 1 guy.');

INSERT INTO Customers(FirstName, LastName, Notes)
VALUES('Jane', 'Doe', 'Number 1 gal.');

INSERT INTO Addresses (NumberStreet, AptSuite, City, ZipCode, CountryCode)
VALUES('098 1st Str', 'Suite 2', 'Chicago', '60652', 1);

INSERT INTO Addresses (NumberStreet, AptSuite, City, ZipCode, CountryCode)
VALUES('123 Sesame Street', '4', 'New York', '10001', 1);

INSERT INTO Addresses(NumberStreet, City, ZipCode)
VALUES('451 Sunset Boulevard', 'Los Angeles', '90210');

INSERT INTO Addresses(NumberStreet, City, ZipCode, CountryCode)
VALUES('777 3rd Ave', 'Houston', '77001', 1);

INSERT INTO Orders(OrderTotal, FK_Customer, FK_Address)
VALUES(100.99, 1, 1);

INSERT INTO Orders(OrderTotal, FK_Customer, FK_Address)
VALUES(99.99, 2, 2);

INSERT INTO Orders(OrderTotal, FK_Customer, FK_Address)
VALUES(777.77, 1, 3);

INSERT INTO Orders(OrderTotal, FK_Customer, FK_Address)
VALUES(123.45, 2, 4);

INSERT INTO [dbo].[CustomerAddressJunction]
SELECT FK_Customer, FK_Address FROM [dbo].[Orders];


--Query 3 Creating Joins 
--Simple Left Join
SELECT FirstName, LastName As "Chick's Last Name", OrderTotal
FROM Customers C 
LEFT JOIN [dbo].[Orders] ON CustomerID = FK_Customer;

--Simple Right Join(Customers <- Orders <- Addresses)
SELECT FirstName, LastName As "Family Name", OrderTotal
FROM Customers C 
RIGHT JOIN [dbo].[Orders] ON CustomerID = FK_Customer;

--Multi Table Left Join
SELECT FirstName, LastName As "Surname", NumberStreet, OrderTotal, City, ZipCode
FROM Customers C 
LEFT JOIN [dbo].[Orders] O ON CustomerID = FK_Customer
LEFT JOIN Addresses A on O.FK_Address = A.AddressId;

--Multi Table RIGHT Join (Customers -> Junction -> Addresses)
SELECT FirstName, LastName As "That Person", NumberStreet, City, ZipCode
FROM Customers C 
RIGHT JOIN [dbo].[CustomerAddressJunction] J ON C.CustomerId = FK_Customer

RIGHT JOIN Addresses A on J.FK_Address = A.AddressId;

RIGHT JOIN Addresses A on J.FK_Address = A.AddressId;

--Query 4 Insertions, Deletions with Unions and Triggers
-- 1) create a table to hold the mending data.
CREATE TABLE Customer_Audit(
ChangeID INT PRIMARY KEY IDENTITY(1,1),
CustomerID INT NOT NULL,
FirstName NVARCHAR(30),
LastName NVARCHAR(30),
UpdatedAt DATETIME DEFAULT(GETDATE()),
OperationType CHAR(3),
CONSTRAINT Opp_Type_Ins_or_Del CHECK(OperationType = 'DEL' OR OperationType = 'INS')
);

--2) Create the AFTER trigger
CREATE TRIGGER CustomerAdded ON Customers
AFTER INSERT, DELETE
AS
	INSERT INTO Customer_Audit(CustomerID, FirstName, LastName, OperationType)
		SELECT CustomerID, FirstName, LastName, 'INS'
		FROM INSERTED
UNION
	SELECT CustomerID, FirstName, LastName, 'DEL'
	FROM DELETED


SELECT *
FROM Customer_Audit;

INSERT INTO Customers(FirstName, LastName)
VALUES ('John', 'Wayne');

--Query 5 Stored Procedures
-- Stored Procedure
CREATE PROCEDURE GetFirstCustomerAsc
AS
	SELECT TOP 1 FirstName 
	FROM Customers 
	ORDER BY FirstName ASC;

EXEC GetFirstCustomerAsc;

--Procedure to get how many addresses there are (with variables)
CREATE PROCEDURE GetNumAddresses(
	@FirstName NVARCHAR(30),
	@NumAddys INT OUTPUT)
AS
BEGIN
	SELECT @NumAddys = Count(*)	FROM Addresses;
	SELECT FirstName FROM Customers 
	WHERE FirstName = @FirstName;
END;

--declare some scalar(single value) variables
DECLARE @myVar INT;
DECLARE @LastNameDesc NVARCHAR(30)

--set the value of the scalar variable
SET @LastNameDesc =(SELECT TOP 1 FirstName FROM Customers ORDER BY FirstName DESC)

--execute the procedure
EXEC GetNumAddresses @LastNameDesc, @myVar OUTPUT;

--print the value of the scalar variable to the screen
SELECT @myVar

--Create a function to calculate revenue of sold units at certain price over a number of days
CREATE FUNCTION dbo.Revenue
(
	@unitsSold INT,
	@unitPrice DEC(20,2),
	@numberDays DEC(20,2)
)
RETURNS DEC(20,2)
AS
BEGIN
	RETURN
	 @unitsSold*@unitPrice*@numberDays;
END


SELECT dbo.Revenue (200, 100, 7)
AS
	Revenue

DROP FUNCTION dbo.Revenue;
