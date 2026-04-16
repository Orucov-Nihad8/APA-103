-- DATABASE
CREATE DATABASE Company;
USE Company;

-- COUNTRIES
CREATE TABLE Countries (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50)
);

-- CITIES
CREATE TABLE Cities (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50),
    CountryId INT,
    FOREIGN KEY (CountryId) REFERENCES Countries(Id)
);

-- EMPLOYEES
CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50),
    Surname NVARCHAR(50),
    Age INT,
    Salary DECIMAL(10,2),
    Position NVARCHAR(50),
    IsDeleted BIT,
    CityId INT,
    FOREIGN KEY (CityId) REFERENCES Cities(Id)
);

-- SAMPLE DATA
INSERT INTO Countries (Name) VALUES
('Azerbaijan'),
('Turkey');

INSERT INTO Cities (Name, CountryId) VALUES
('Baku', 1),
('Ganja', 1),
('Istanbul', 2);

INSERT INTO Employees (Name, Surname, Age, Salary, Position, IsDeleted, CityId) VALUES
('Ali', 'Aliyev', 25, 2500, 'Developer', 0, 1),
('Veli', 'Veliev', 30, 1800, 'Reseption', 0, 2),
('Ayse', 'Demir', 28, 3000, 'Manager', 1, 3);

-- 1. Employees + City + Country
SELECT e.Name, e.Surname, c.Name AS City, co.Name AS Country
FROM Employees e
JOIN Cities c ON e.CityId = c.Id
JOIN Countries co ON c.CountryId = co.Id;

-- 2. Salary > 2000
SELECT e.Name, co.Name AS Country
FROM Employees e
JOIN Cities c ON e.CityId = c.Id
JOIN Countries co ON c.CountryId = co.Id
WHERE e.Salary > 2000;

-- 3. City -> Country
SELECT c.Name AS City, co.Name AS Country
FROM Cities c
JOIN Countries co ON c.CountryId = co.Id;

-- 4. Reseption (without Id)
SELECT Name, Surname, Age, Salary, Position, IsDeleted
FROM Employees
WHERE Position = 'Reseption';

-- 5. Deleted employees
SELECT e.Name, e.Surname, c.Name AS City, co.Name AS Country
FROM Employees e
JOIN Cities c ON e.CityId = c.Id
JOIN Countries co ON c.CountryId = co.Id
WHERE e.IsDeleted = 1;
