--SET 1--
--1. List all employees whose name begins with 'A'. --
SELECT * FROM EMP WHERE ENAME LIKE 'A%';

--2. Select all those employees who don't have a manager. --
SELECT * FROM EMP WHERE MGR_ID IS NULL;

--3. List employee name, number and salary for those employees who earn in the range 1200 to 1400. --
SELECT ENAME, EMPNO, SAL FROM EMP WHERE SAL > 1200 AND SAL < 1400;

/*4. Give all the employees in the RESEARCH department a 10% pay rise. 
Verify that this has been done by listing all their details before and after the rise.*/
SELECT ENAME, SAL AS 'ORIGINAL_SAL', SAL * 1.10 AS 'INCREASED_SAL'
FROM EMP
JOIN DEPT ON EMP.DEPTNO = DEPT.DEPTNO
WHERE DEPT.DNAME = 'RESEARCH'

--5. Find the number of CLERKS employed. Give it a descriptive heading. --
SELECT COUNT(*) AS NUM_CLERKS FROM EMP WHERE JOB = 'CLERK';

--6. Find the average salary for each job type and the number of people employed in each job. --
SELECT JOB, AVG(SAL) AS AVG_SALARY, COUNT(*) AS NUM_EMPLOYEES FROM EMP GROUP BY JOB;

--7. List the employees with the lowest and highest salary. --
SELECT MIN(SAL) AS 'MIN_SAL', MAX(SAL) 'MAX_SAL' FROM EMP; 

--8. List full details of departments that don't have any employees. --
SELECT * FROM DEPT  
WHERE DEPTNO NOT IN (SELECT DISTINCT DEPTNO FROM EMP);

/*9. Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. 
Sort the answer by ascending order of name.*/
SELECT ENAME, SAL FROM EMP WHERE JOB = 'ANALYST' AND SAL > 1200 AND DEPTNO = 20 ORDER BY ENAME ASC;

--10. For each department, list its name and number together with the total salary paid to employees in that department. --
SELECT DNAME, DEPT.DEPTNO, SUM(SAL) AS 'TOTAL_SAL' FROM EMP
JOIN DEPT ON EMP.DEPTNO = DEPT.DEPTNO
GROUP BY DNAME, DEPT.DEPTNO

--11. Find out salary of both MILLER and SMITH.--
SELECT ENAME, SAL FROM EMP WHERE ENAME IN ('MILLER','SMITH');

--12. Find out the names of the employees whose name begin with ‘A’ or ‘M’. --
SELECT ENAME FROM EMP WHERE ENAME LIKE 'A%' OR ENAME LIKE 'M%';

--13. Compute yearly salary of SMITH. --
SELECT ENAME, SAL * 12 AS 'YEARLY_SAL' FROM EMP WHERE ENAME = 'SMITH';

--14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850. --
SELECT ENAME, SAL FROM EMP WHERE SAL  < 1500 OR SAL > 2850;

--15. Find all managers who have more than 2 employees reporting to them--
SELECT MGR_ID, COUNT(EMPNO) AS 'Total_Emps' FROM EMP GROUP BY MGR_ID
HAVING COUNT(EMPNO) > 2