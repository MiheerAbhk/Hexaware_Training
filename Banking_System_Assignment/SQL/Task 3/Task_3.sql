--TASK 3--

--1. Write a SQL query to Find the average account balance for all customers. --
SELECT avg(balance) from ACCOUNTS

--2. Write a SQL query to Retrieve the top 10 highest account balances.  --
SELECT TOP 10 customer_id, balance FROM ACCOUNTS
ORDER BY balance DESC

--3. Write a SQL query to Calculate Total Deposits for All Customers in specific date. --
SELECT sum(amount) AS total_deposits 
FROM Transactions
WHERE transaction_type = 'deposit' 
AND CONVERT(DATE, transaction_date) = '2025-03-19' -- Converting DATETIME to DATE

--4. Write a SQL query to Find the Oldest and Newest Customers. --

ALTER TABLE ACCOUNTS
ADD acc_opening_date DATE -- Schema didn't mention acc_opening_date as an attribute, added the same as it was required for this query


SELECT TOP 1 c.customer_id, c.first_name, c.last_name, a.acc_opening_date 
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id
ORDER BY a.acc_opening_date ASC; -- Oldest Customer

SELECT TOP 1 c.customer_id, c.first_name, c.last_name, a.acc_opening_date 
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id
ORDER BY a.acc_opening_date DESC; -- Newest Customer

-- 5. Write a SQL query to Retrieve transaction details along with the account type. --

SELECT t.transaction_id, t.account_id, t.transaction_type, t.amount, t.transaction_date, a.account_type 
FROM Transactions t 
JOIN Accounts a ON t.account_id = a.account_id;

-- 6. Write a SQL query to Get a list of customers along with their account details. 
SELECT c.customer_id, c.first_name, c.last_name, a.account_id, a.account_type, a.balance 
FROM Customers c 
JOIN Accounts a ON c.customer_id = a.customer_id;

-- 7. Write a SQL query to Retrieve transaction details along with customer information for a specific account.
SELECT t.transaction_id, t.transaction_type, t.amount, t.transaction_date, 
c.customer_id, c.first_name, c.last_name, c.email 
FROM Transactions t 
JOIN Accounts a ON t.account_id = a.account_id 
JOIN Customers c ON a.customer_id = c.customer_id 
WHERE t.account_id = 4

--8. Write a SQL query to Identify customers who have more than one account. 
SELECT customer_id, COUNT(account_id) AS account_count 
FROM Accounts 
GROUP BY customer_id 
HAVING COUNT(account_id) > 1;

--9. Write a SQL query to Calculate the difference in transaction amounts between deposits and withdrawals. 
SELECT  SUM(CASE WHEN transaction_type = 'deposit' THEN amount ELSE 0 END) - 
        SUM(CASE WHEN transaction_type = 'withdrawal' THEN amount ELSE 0 END) AS balance_difference 
FROM Transactions 

--10. Write a SQL query to Calculate the average daily balance for each account over a specified period. --
SELECT account_id, AVG(balance) AS avg_daily_balance 
FROM Accounts 
WHERE account_id IN (
    SELECT DISTINCT account_id FROM Transactions 
    WHERE transaction_date BETWEEN '2025-03-19' AND '2025-03-24'
) 
GROUP BY account_id;

--11. Calculate the total balance for each account type. --
SELECT account_type, SUM(balance) AS total_balance 
FROM Accounts 
GROUP BY account_type;

--12. Identify accounts with the highest number of transactions order by descending order. --
SELECT account_id, COUNT(transaction_id) AS transaction_count 
FROM Transactions 
GROUP BY account_id 
ORDER BY transaction_count DESC;


--13. List customers with high aggregate account balances, along with their account types. --
SELECT c.customer_id, c.first_name, c.last_name, a.account_type, SUM(a.balance) AS total_balance 
FROM Customers c 
JOIN Accounts a ON c.customer_id = a.customer_id 
GROUP BY c.customer_id, c.first_name, c.last_name, a.account_type 
HAVING SUM(a.balance) > 2000

--14. Identify and list duplicate transactions based on transaction amount, date, and account.  --
SELECT account_id, transaction_date, amount, COUNT(*) AS duplicate_count
FROM Transactions
GROUP BY account_id, transaction_date, amount
HAVING COUNT(*) > 1;


