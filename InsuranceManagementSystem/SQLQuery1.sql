CREATE DATABASE InsuranceDB

USE InsuranceDB

CREATE TABLE Policy (
    PolicyId INT PRIMARY KEY,
    PolicyName NVARCHAR(100) NOT NULL
);

CREATE TABLE [User] (
    UserId INT PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    [Password] NVARCHAR(50) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);

CREATE TABLE Client (
    ClientId INT PRIMARY KEY,
    ClientName NVARCHAR(100),
    ContactInfo NVARCHAR(100),
    PolicyId INT FOREIGN KEY REFERENCES Policy(PolicyId)
);

CREATE TABLE Claim (
    ClaimId INT PRIMARY KEY,
    ClaimNumber NVARCHAR(50),
    DateFiled DATE,
    ClaimAmount DECIMAL(18,2),
    Status NVARCHAR(50),
    PolicyId INT FOREIGN KEY REFERENCES Policy(PolicyId),
    ClientId INT FOREIGN KEY REFERENCES Client(ClientId)
);

CREATE TABLE Payment (
    PaymentId INT PRIMARY KEY,
    PaymentDate DATE,
    PaymentAmount DECIMAL(18,2),
    ClientId INT FOREIGN KEY REFERENCES Client(ClientId)
);

SELECT * FROM Policy
SELECT * FROM Payment
SELECT * FROM Client
SELECT * FROM Claim