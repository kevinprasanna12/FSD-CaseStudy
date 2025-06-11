CREATE DATABASE EmployeeCase4

USE EmployeeCase4

CREATE TABLE Employees (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(100),
    Department VARCHAR(50),
    Salary DECIMAL(10, 2)
);

CREATE TABLE EmployeeAuditLog (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    EmpID INT,
    EmpName VARCHAR(100),
    Department VARCHAR(50),
    Salary DECIMAL(10,2),
    ActionType VARCHAR(10),
    ActionDate DATETIME DEFAULT GETDATE()
);

CREATE TRIGGER trg_AfterInsert_Employees
ON Employees
AFTER INSERT
AS
BEGIN
    INSERT INTO EmployeeAuditLog (EmpID, EmpName, Department, Salary, ActionType)
    SELECT EmpID, EmpName, Department, Salary, 'INSERT'
    FROM INSERTED;
END;

CREATE TRIGGER trg_AfterDelete_Employees
ON Employees
AFTER DELETE
AS
BEGIN
    INSERT INTO EmployeeAuditLog (EmpID, EmpName, Department, Salary, ActionType)
    SELECT EmpID, EmpName, Department, Salary, 'DELETE'
    FROM DELETED;
END;

INSERT INTO Employees (EmpID, EmpName, Department, Salary)
VALUES 
(101, 'Alice', 'HR', 55000.00),
(102, 'Bob', 'IT', 72000.00);

DELETE FROM Employees
WHERE EmpID = 101;


SELECT * FROM EmployeeAuditLog;
