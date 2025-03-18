--TASK 2--

--1.Write a SQL query to retrieve the name, account type and email of all customers.--

SELECT CUSTOMERS.first_name, CUSTOMERS.last_name, ACCOUNTS.account_type, CUSTOMERS.email
FROM CUSTOMERS
JOIN ACCOUNTS ON CUSTOMERS.customer_id = ACCOUNTS.customer_id;

--2.Write a SQL query to list all transaction corresponding customer.--

SELECT CUSTOMERS.first_name, CUSTOMERS.last_name, TRANSACTIONS.transaction_type, TRANSACTIONS.amount, TRANSACTIONS.transaction_date
FROM CUSTOMERS
JOIN ACCOUNTS ON CUSTOMERS.customer_id = ACCOUNTS.customer_id
JOIN TRANSACTIONS ON ACCOUNTS.account_id = TRANSACTIONS.account_id
ORDER BY CUSTOMERS.customer_id, TRANSACTIONS.transaction_date;

--3.Write a SQL query to increase the balance of a specific account by a certain amount.--

UPDATE ACCOUNTS
SET balance = balance + 500
WHERE account_id = 1;

--4.Write a SQL query to Combine first and last names of customers as a full_name.--

SELECT CONCAT(first_name, ' ', last_name) AS full_name
FROM CUSTOMERS;

/*5. Write a SQL query to remove accounts with a balance of zero where the account
type is savings.*/

DELETE FROM ACCOUNTS
WHERE balance = 0 AND account_type = 'savings';

--6.Write a SQL query to Find customers living in a specific city.--

SELECT * FROM CUSTOMERS WHERE address LIKE '%Pune%';

--7.Write a SQL query to Get the account balance for a specific account.--

SELECT balance FROM ACCOUNTS WHERE account_id = 3;

--8. Write a SQL query to List all current accounts with a balance greater than $1,000.--

SELECT * FROM ACCOUNTS WHERE account_type = 'current' AND balance > 1000;

--9. Write a SQL query to Retrieve all transactions for a specific account. --

SELECT * FROM TRANSACTIONS WHERE account_id = 2;