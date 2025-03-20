--SET 3--
--1. List unique departments of the EMP table.--

SELECT DISTINCT EMP.DEPTNO, DEPT.DNAME FROM EMP
JOIN DEPT ON EMP.DEPTNO = DEPT.DEPTNO

/*2. List the name and salary of employees who earn more than 1500 and are in department 10 or 30.
Label the columns Employee and Monthly Salary respectively.*/

SELECT ENAME AS EMPLOYEE, SAL AS 'Monthly Salary' FROM EMP WHERE SAL > 1500 AND DEPTNO IN (10,30)

/*3.Display the name, job, and salary of all the employees whose job is MANAGER or 
ANALYST and their salary is not equal to 1000, 3000, or 5000. */

SELECT ENAME, JOB, SAL FROM EMP WHERE JOB IN ('MANAGER', 'ANALYST') AND SAL NOT IN ('1000', '3000', '5000')

/*4.Display the name, salary and commission for all employees whose commission 
amount is greater than their salary increased by 10%. */

SELECT ENAME, SAL, COMM FROM EMP WHERE COMM > (SAL * 1.10);

/*5.Display the name of all employees who have two Ls in their name and are in 
department 30 or their manager is 7782. */

SELECT ENAME FROM EMP WHERE (ENAME LIKE '%L%L%' AND DEPTNO = 30) OR MGR_ID = 7782

/*6. Display the names of employees with experience of over 30 years and under 40 yrs.
 Count the total number of employees. */

SELECT ENAME FROM EMP WHERE DATEDIFF(YEAR, HIREDATE, GETDATE()) BETWEEN 30 AND 40;
SELECT COUNT(*) AS Total_Employees FROM EMP WHERE DATEDIFF(YEAR, HIREDATE, GETDATE()) BETWEEN 30 AND 40;

/* 7. Retrieve the names of departments in ascending order and their employees in 
descending order*/

SELECT DNAME, ENAME FROM EMP JOIN DEPT ON EMP.DEPTNO = DEPT.DEPTNO ORDER BY DNAME ASC, ENAME DESC

-- 8. Find out experience of MILLER. --

SELECT ENAME , DATEDIFF(YEAR,HIREDATE,GETDATE()) as EXPERIENCE FROM EMP 
WHERE ENAME = 'MILLER'


-- 9. Write a query to display all employee information where ename contains 5 or more characters--

SELECT * FROM EMP
WHERE LEN(ENAME) >= 5

--10. Copy empno, ename of all employees from emp table who work for dept 10 into a new table called emp10
SELECT EMPNO, ENAME INTO EMP10 FROM EMP WHERE DEPTNO = 10;
SELECT * FROM EMP10