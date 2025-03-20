--TASK 1--

CREATE DATABASE HMBank
USE HMBank

CREATE TABLE CUSTOMERS(
	customer_id INT PRIMARY KEY IDENTITY(1,1),
	first_name VARCHAR(30) NOT NULL,
	last_name VARCHAR(30),
	DOB DATE NOT NULL,
	email VARCHAR(50) UNIQUE NOT NULL,
	phone_number VARCHAR(15) UNIQUE NOT NULL,
	address VARCHAR(150) NOT NULL
)

CREATE TABLE ACCOUNTS(
	account_id INT PRIMARY KEY IDENTITY(1,1),
	customer_id INT NOT NULL,
	account_type VARCHAR(20) CHECK (account_type IN ('savings', 'current', 'zero_balance')) NOT NULL,
	balance DECIMAL(15,2) CHECK (balance >= 0) NOT NULL,
	FOREIGN KEY (customer_id) REFERENCES CUSTOMERS(customer_id)
)

CREATE TABLE TRANSACTIONS(
	transaction_id INT PRIMARY KEY IDENTITY(1,1),
	account_id INT NOT NULL,
	transaction_type VARCHAR(20) CHECK (transaction_type IN ('deposit', 'withdrawal', 'transfer')) NOT NULL,
	amount DECIMAL(15,2) CHECK (amount > 0) NOT NULL,
	transaction_date DATETIME DEFAULT GETDATE(),
	FOREIGN KEY (account_id) REFERENCES ACCOUNTS(account_id)
)


INSERT INTO CUSTOMERS(first_name, last_name, DOB, email, phone_number, address) VALUES
('Amit', 'Kumar', '1990-05-10', 'amit.kumar@example.com', '1234567890', 'New Delhi'),
('Rajesh', 'Patil', '1985-08-15', 'rajesh.patil@example.com', '9876543210', 'Mumbai'),
('Abhishek', 'Limaye', '1992-03-25', 'abhishek.limaye@example.com', '1122334455', 'Pune'),
('Pratik', 'Shah', '1988-12-12', 'pratik.shah@example.com', '9988776655', 'Nagpur'),
('Priya', 'Verma', '1993-06-22', 'priya.verma@example.com', '8765432109', 'Ahmedabad'), 
('Rahul', 'Patel', '1990-11-05', 'rahul.patel@example.com', '7654321098', 'Bengaluru'), 
('Sneha', 'Iyer', '1995-09-18', 'sneha.iyer@example.com', '6543210987', 'Chennai'), 
('Vikram', 'Singh', '1989-04-30', 'vikram.singh@example.com', '5432109876', 'Kolkata'),
('Ananya', 'Nair', '1997-08-10', 'ananya.nair@example.com', '4321098765', 'Hyderabad'),
('Yash', 'Dere', '1995-03-13', 'yash.dere@example.com', '2963826578', 'Indore');


SELECT * FROM CUSTOMERS;

INSERT INTO ACCOUNTS(customer_id, account_type, balance) VALUES
(1, 'savings', 5000.00),
(2, 'current', 2000.00),
(3, 'savings', 3000.00),
(4, 'zero_balance', 0.00),
(5, 'current', 1500.00),
(6, 'savings', 5700.00),
(7, 'current', 2200.00),
(8, 'savings', 4000.00),
(9, 'zero_balance', 0.00),
(10, 'current', 4500.00);

SELECT * FROM ACCOUNTS;

INSERT INTO TRANSACTIONS(account_id, transaction_type, amount) VALUES
(1, 'deposit', 1000.00),
(2, 'withdrawal', 500.00),
(3, 'transfer', 150.00),
(4, 'deposit', 1200.00),
(5, 'deposit', 2000.00),
(6, 'transfer', 700.00),
(7, 'withdrawal', 200.00),
(8, 'withdrawal', 1000.00),
(9, 'deposit', 300.00),
(10, 'transfer', 1200.00);

SELECT * FROM TRANSACTIONS;