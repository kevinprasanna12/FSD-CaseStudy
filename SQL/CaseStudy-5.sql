CREATE DATABASE OrderCase5
USE OrderCase5

CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100),
    OrderDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE OrderItems (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductName VARCHAR(100),
    Quantity INT,
    UnitPrice DECIMAL(10,2)
);

BEGIN TRY
    BEGIN TRANSACTION;

    INSERT INTO Orders (CustomerName)
    VALUES ('Kevin Prasanna');

    DECLARE @OrderID INT = SCOPE_IDENTITY();

    INSERT INTO OrderItems (OrderID, ProductName, Quantity, UnitPrice)
    VALUES 
        (@OrderID, 'Keyboard', 2, 850.00),
        (@OrderID, 'Mouse', 1, 450.00),
        (@OrderID, 'Monitor', 1, 7000.00);

    COMMIT TRANSACTION;
    PRINT 'Transaction committed successfully.';
END TRY
BEGIN CATCH

    ROLLBACK TRANSACTION;
    PRINT 'Transaction failed. Rolled back.';
    PRINT ERROR_MESSAGE();
END CATCH;
