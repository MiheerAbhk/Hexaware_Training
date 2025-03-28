--Code Challege - Car Rental System --

CREATE DATABASE CarRentalSystem
USE CarRentalSystem

CREATE TABLE Vehicle(
vehicleID INT PRIMARY KEY,
make VARCHAR(30) NOT NULL,
model VARCHAR(30) NOT NULL,
year INT NOT NULL,
dailyRate DECIMAL(10,2) NOT NULL,
status VARCHAR(20) CHECK (status IN ('available', 'notAvailable')),
passangerCapacity INT NOT NULL,
engineCapacity INT NOT NULL
)


CREATE TABLE Customer (
customerID INT PRIMARY KEY,
firstName VARCHAR(30) NOT NULL,
lastName VARCHAR(30) NOT NULL, 
email VARCHAR(30) UNIQUE NOT NULL,
phoneNumber VARCHAR(20) UNIQUE NOT NULL
)

CREATE TABLE Lease(
leaseID INT PRIMARY KEY,
vehicleID INT FOREIGN KEY REFERENCES Vehicle(vehicleID),
customerID INT FOREIGN KEY REFERENCES Customer(customerID),
startDate DATE NOT NULL,
endDate DATE NOT NULL,
leaseType VARCHAR(20) CHECK (leaseType IN ('Daily', 'Monthly')) NOT NULL
)


CREATE TABLE Payment(
paymentID INT PRIMARY KEY,
leaseID INT FOREIGN KEY REFERENCES Lease(leaseID) NOT NULL,
paymentDate DATE NOT NULL,
amount DECIMAL(10,2) NOT NULL
)


INSERT INTO Vehicle VALUES
(1, 'Toyota', 'Camry', 2022, 50.00, 'available', 4, 1450),
(2, 'Honda', 'Civic', 2023, 45.00, 'available', 7, 1500),
(3, 'Ford', 'Focus', 2022, 48.00, 'notAvailable', 4, 1400),
(4, 'Nissan', 'Altima', 2023, 52.00, 'available', 7, 1200),
(5, 'Chevrolet', 'Malibu', 2022, 47.00, 'available', 4,1800),
(6, 'Hyundai', 'Sonata', 2023, 49.00, 'notAvailable', 7, 1400),
(7, 'BMW', '3 Series', 2023, 60.00, 'available', 7, 2499),
(8, 'Mercedes', 'C-Class', 2022, 58.00, 'available', 8, 2599),
(9, 'Audi', 'A4', 2022, 55.00, 'notAvailable', 4, 2500),
(10, 'Lexus', 'ES', 2023, 54.00, 'available', 4, 2500)

SELECT * FROM Vehicle

INSERT INTO Customer VALUES
(1,'John', 'Doe', 'johndoe@example.com', '555-555-5555'),
(2, 'Jane', 'Smith', 'janesmith@example.com', '555-123-4567'),
(3, 'Robert', 'Johnson', 'robert@example.com', '555-789-1234'),
(4, 'Sarah', 'Brown', 'sarah@example.com', '555-456-7890'),
(5, 'David', 'Lee', 'david@example.com', '555-987-6543'),
(6, 'Laura', 'Hall', 'laura@example.com', '555-234-5678'),
(7, 'Michael', 'Davis', 'michael@example.com', '555-876-5432'),
(8, 'Emma', 'Wilson', 'emma@example.com', '555-432-1098'),
(9, 'William', 'Taylor', 'william@example.com', '555-321-6547'),
(10, 'Olivia', 'Adams', 'olivia@example.com', '555-765-4321')

SELECT * FROM Customer

INSERT INTO Lease VALUES
(1, 1, 1, '2023-01-01', '2023-01-05', 'Daily'),
(2, 2, 2, '2023-02-15', '2023-02-28', 'Monthly'),
(3, 3, 3, '2023-03-10', '2023-03-15', 'Daily'),
(4, 4, 4, '2023-04-20', '2023-04-30', 'Monthly'),
(5, 5, 5, '2023-05-05', '2023-05-10', 'Daily'),
(6, 4, 3, '2023-06-15', '2023-06-30', 'Monthly'),
(7, 7, 7, '2023-07-01', '2023-07-10', 'Daily'),
(8, 8, 8, '2023-08-12', '2023-08-15', 'Monthly'),
(9, 3, 3, '2023-09-07', '2023-09-10', 'Daily'),
(10, 10, 10, '2023-10-10', '2023-10-31', 'Monthly')

INSERT INTO Lease VALUES 
(12, 7, 3, '2025-03-01' , '2025-04-01', 'Monthly') -- added explicitly to get a result in further query

SELECT * FROM Lease

INSERT INTO Payment VALUES
(1, 1, '2023-01-03', 200.00),
(2, 2, '2023-02-20', 1000.00),
(3, 3, '2023-03-12', 75.00),
(4, 4, '2023-04-25', 900.00),
(5, 5, '2023-05-07', 60.00),
(6, 6, '2023-06-18', 1200.00),
(7, 7, '2023-07-03', 40.00),
(8, 8, '2023-08-14', 1100.00),
(9, 9, '2023-09-09', 80.00),
(10, 10, '2023-10-25', 1500.00)

SELECT * FROM Payment


--QUERIES--

--1. Update the daily rate for a Mercedes car to 68. -- 
UPDATE Vehicle
SET dailyRate = 68
WHERE make = 'Mercedes'

SELECT vehicleID, make, model, dailyRate FROM Vehicle
WHERE make = 'Mercedes'

--2. Delete a specific customer and all associated leases and payments. --
-- DECLARE @customerID INT
-- SET @customerID = 2              -- Tried setting a variable but it didn't work

DELETE FROM Payment
WHERE leaseID IN (SELECT leaseID FROM Lease WHERE customerID = 2)

DELETE FROM Lease
WHERE customerID = 2

DELETE FROM Customer
WHERE customerID = 2

SELECT * from Customer where customerID = 2

SELECT * FROM Lease WHERE customerID = 2

--3. Rename the "paymentDate" column in the Payment table to "transactionDate". --
EXEC sp_rename 'Payment.paymentDate', 'transactionDate', 'COLUMN'
SELECT transactionDate FROM Payment

--4. Find a specific customer by email. --
SELECT * FROM Customer
WHERE email = 'sarah@example.com'

--5. Get active leases for a specific customer. --
SELECT * FROM Lease
WHERE customerID = 3 AND endDate >= GETDATE()

--6 Find all payments made by a customer with a specific phone number. --
SELECT Payment.* FROM Payment
JOIN Lease ON Payment.leaseID = Lease.leaseID
JOIN Customer ON Lease.customerID = Customer.customerID
WHERE Customer.phoneNumber = '555-555-5555'

--7. Calculate the average daily rate of all available cars. --
SELECT AVG(dailyRate) as Avg_Daily_Rate
FROM Vehicle
WHERE status = 'available'

--8. Find the car with the highest daily rate. --
SELECT TOP 1 * FROM Vehicle
ORDER BY dailyRate DESC

--9. Retrieve all cars leased by a specific customer. --
SELECT Vehicle.* FROM Vehicle
JOIN Lease ON Lease.vehicleID = Vehicle.vehicleID
WHERE customerID = 7

--10. Find the details of the most recent lease. --
SELECT TOP 1 * FROM Lease
ORDER BY startDate DESC

--11. List all payments made in the year 2023. --
SELECT * FROM Payment
WHERE YEAR(transactionDate) = '2023'

--12. Retrieve customers who have not made any payments. --
SELECT * FROM Customer
WHERE NOT EXISTS (
SELECT 1 FROM Lease
JOIN Payment ON Lease.leaseID = Payment.leaseID
WHERE Customer.customerID = Lease.customerID
)

--13. Retrieve Car Details and Their Total Payments. --
SELECT Vehicle.vehicleID, make, model, SUM(Payment.amount) as total_payment FROM Vehicle
JOIN Lease ON Vehicle.vehicleID = Lease.vehicleID
JOIN Payment ON Lease.leaseID = Payment.leaseID
GROUP BY Vehicle.vehicleID, Vehicle.make, Vehicle.model

--14. Calculate Total Payments for Each Customer. --
SELECT C.customerID, c.firstName, c.lastName, SUM(Payment.amount) as Total_Spend FROM Customer c
JOIN Lease ON Lease.customerID = c.customerID
JOIN Payment ON Payment.leaseID = Lease.leaseID
GROUP BY c.customerID, c.firstName, c.lastName

--15. List Car Details for Each Lease. --
SELECT L.leaseID, v.vehicleID, make, model, c.firstName, c.lastName, L.startDate, L.endDate, L.leaseType
FROM Lease L
JOIN Vehicle v ON L.vehicleID = v.vehicleID
JOIN Customer c ON L.customerID = c.customerID

--16. Retrieve Details of Active Leases with Customer and Car Information. --
SELECT L.leaseID, C.firstName, C.lastName, V.make, V.model, L.startDate, L.endDate, L.leasetype
FROM Lease L
JOIN Customer C ON L.customerID = C.customerID
JOIN Vehicle V ON L.vehicleID = V.vehicleID
WHERE L.endDate >= GETDATE()

--17. Find the Customer Who Has Spent the Most on Leases. --
SELECT TOP 1 C.customerID, C.firstName, C.lastName, SUM(P.amount) as Total_Spent
FROM Customer C
JOIN Lease L ON C.customerID = L.customerID
JOIN Payment P ON L.leaseID = P.leaseID
GROUP BY C.customerID, C.firstName, C.lastName
ORDER BY Total_Spent DESC

--18. List All Cars with Their Current Lease Information --
SELECT  V.vehicleID, V.make, V.model, L.leaseID, L.leasetype, C.firstName, C.lastName, L.startDate, L.endDate
FROM Vehicle V
JOIN  Lease L ON V.vehicleID = L.vehicleID
JOIN Customer C ON C.customerID = L.customerID
