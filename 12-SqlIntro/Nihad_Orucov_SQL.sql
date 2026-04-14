
CREATE DATABASE Company;
GO

USE Company;
GO

-- TABLE yaratmaq
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    HireDate DATE,
    JobTitle NVARCHAR(50),
    Salary DECIMAL(10,2),
    Department NVARCHAR(50)
);
GO

-- DATA əlavə etmək
INSERT INTO Employees VALUES
(1, 'Leyla', 'Həsənova', 'leyla@company.az', '0501234567', '2021-05-10', 'HR Specialist', 2500, 'HR'),
(2, 'Rauf', 'Məmmədov', 'rauf@company.az', '0512345678', '2019-03-15', 'Developer', 3000, 'IT'),
(3, 'Aysel', 'Əliyeva', 'aysel@company.az', '0553456789', '2022-07-01', 'Accountant', 1800, 'Finance'),
(4, 'Kamal', 'Quliyev', 'kamal@company.az', '0704567890', '2018-11-20', 'System Admin', 2700, 'IT'),
(5, 'Nigar', 'İbrahimova', 'nigar@gmail.com', '0775678901', '2023-01-05', 'Assistant', 1400, 'Admin');
GO

--------------------------------------------------
-- SELECT

SELECT * FROM Employees;
GO

SELECT * FROM Employees WHERE Salary > 2000;
GO

SELECT * FROM Employees WHERE Department = 'IT';
GO

SELECT * FROM Employees ORDER BY Salary DESC;
GO

SELECT FirstName, Salary FROM Employees;
GO

SELECT * FROM Employees WHERE HireDate > '2020-01-01';
GO

SELECT * FROM Employees WHERE Email LIKE '%company.az%';
GO

--------------------------------------------------
-- AGGREGATE

SELECT MAX(Salary) AS MaxSalary FROM Employees;
GO

SELECT MIN(Salary) AS MinSalary FROM Employees;
GO

SELECT AVG(Salary) AS AvgSalary FROM Employees;
GO

SELECT COUNT(*) AS TotalEmployees FROM Employees;
GO

SELECT SUM(Salary) AS TotalSalary FROM Employees;
GO

--------------------------------------------------
-- GROUP BY

SELECT Department, COUNT(*) AS EmployeeCount
FROM Employees
GROUP BY Department;
GO

SELECT Department, AVG(Salary) AS AvgSalary
FROM Employees
GROUP BY Department;
GO

SELECT Department, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY Department;
GO

--------------------------------------------------
-- UPDATE

UPDATE Employees
SET Salary = 2800
WHERE EmployeeID = 1;
GO

UPDATE Employees
SET Salary = Salary * 1.10
WHERE Department = 'IT';
GO

UPDATE Employees
SET JobTitle = N'HR Meneceri'
WHERE FirstName = 'Leyla' AND LastName = 'Həsənova';
GO

--------------------------------------------------
-- DELETE

DELETE FROM Employees
WHERE EmployeeID = 5;
GO

-- aşağı maaşlı işçi əlavə edirik
INSERT INTO Employees VALUES
(6, 'Elvin', 'Səfərov', 'elvin@company.az', '0991234567', '2024-02-01', 'Intern', 1200, 'IT');
GO

DELETE FROM Employees
WHERE Salary < 1500;
GO

--------------------------------------------------
-- ƏLAVƏ

SELECT * FROM Employees
WHERE FirstName LIKE '%a%';
GO

SELECT * FROM Employees
WHERE Salary BETWEEN 2000 AND 2500;
GO

SELECT * FROM Employees
WHERE Department IN ('Finance', 'IT');
GO