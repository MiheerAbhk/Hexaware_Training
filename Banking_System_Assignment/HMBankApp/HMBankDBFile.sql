CREATE DATABASE HMBankDB;

USE HMBankDB;

CREATE TABLE Customers (
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Phone NVARCHAR(15) UNIQUE NOT NULL,
    Address NVARCHAR(255) NOT NULL
);

CREATE TABLE Accounts (
    AccountNumber INT IDENTITY(1001,1) PRIMARY KEY,
    AccountType NVARCHAR(50) NOT NULL,
    Balance FLOAT NOT NULL,
    InterestRate FLOAT,
    OverdraftLimit FLOAT,
    CustomerId INT NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);

CREATE TABLE Transactions (
    TransactionId INT IDENTITY(1,1) PRIMARY KEY,
    AccountNumber INT NOT NULL,
    Description NVARCHAR(255),
    TransactionDateTime DATETIME NOT NULL DEFAULT GETDATE(),
    TransactionType NVARCHAR(50) NOT NULL,
    TransactionAmount FLOAT NOT NULL,
    FOREIGN KEY (AccountNumber) REFERENCES Accounts(AccountNumber)
);



--drop database HMBankDB
Select * from Accounts;
Select * from Customers;

