--SET 2--

--1. Retrieve a list of MANAGERS. --
SELECT DISTINCT ENAME FROM EMP WHERE JOB = 'MANAGER';

-- 2. Find out the names and salaries of all employees earning more than 1000 per month
SELECT ENAME, SAL FROM EMP WHERE SAL > 1000;

-- 3. Display the names and salaries of all employees except JAMES
SELECT ENAME, SAL FROM EMP WHERE ENAME <> 'JAMES';

-- 4. Find out the details of employees whose names begin with ‘S’
SELECT * FROM EMP WHERE ENAME LIKE 'S%';

-- 5. Find out the names of all employees that have ‘A’ anywhere in their name
SELECT ENAME FROM EMP WHERE ENAME LIKE '%A%';

-- 6. Find out the names of all employees that have ‘L’ as their third character in their name
SELECT ENAME FROM EMP WHERE ENAME LIKE '__L%';

-- 7. Compute daily salary of JONES (assuming 30 days in a month)
SELECT ENAME, SAL / 30 AS Daily_Salary FROM EMP WHERE ENAME = 'JONES';

-- 8. Calculate the total monthly salary of all employees
SELECT SUM(SAL) AS Total_Monthly_Salary FROM EMP;

-- 9. Print the average annual salary
SELECT AVG(SAL) * 12 AS Average_Annual_Salary FROM EMP;

-- 10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30
SELECT ENAME, JOB, SAL, DEPTNO FROM EMP WHERE DEPTNO = 30 AND JOB <> 'SALESMAN';