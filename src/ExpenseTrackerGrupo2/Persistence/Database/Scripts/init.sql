CREATE TABLE IF NOT EXISTS Users (
    Id UUID PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS Expenses (
    Id UUID PRIMARY KEY,
    UserId INT NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    Description VARCHAR(255),
    Source VARCHAR(100),
    Month INT NOT NULL,
    GoalAmount DECIMAL(10, 2),
    Category VARCHAR(100),
    Date DATE NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE IF NOT EXISTS Incomes (
    Id UUID PRIMARY KEY,
    UserId INT NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    Date DATE NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE IF NOT EXISTS Budgets (
    Id UUID PRIMARY KEY,
    UserId INT NOT NULL,
    BudgetAmount DECIMAL(10, 2) NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE IF NOT EXISTS Goals (
    Id UUID PRIMARY KEY,
    UserId INT NOT NULL,
    Deadline DATE NOT NULL,
    CurrentAmount DECIMAL(10, 2) NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

INSERT INTO Users (Name, Email, PasswordHash, CreatedAt) 
VALUES 
('Juan Pérez', 'juan.perez@gmail.com', 'hashed_password_juan', CURRENT_TIMESTAMP),
('Ana Gómez', 'ana.gomez@gmail.com', 'hashed_password_ana', CURRENT_TIMESTAMP),
('Luis Martínez', 'luis.martinez@gmail.com', 'hashed_password_luis', CURRENT_TIMESTAMP);

INSERT INTO Expenses (UserId, Amount, Description, Source, Month, GoalAmount, Category, Date, CreatedAt) 
VALUES 
(1, 100.50, 'Compra de supermercado', 'Tarjeta de crédito', 9, 200.00, 'Comida', '2024-09-15', CURRENT_TIMESTAMP),
(2, 50.00, 'Pago de servicios públicos', 'Transferencia bancaria', 9, 100.00, 'Servicios', '2024-09-14', CURRENT_TIMESTAMP),
(3, 200.00, 'Compra de ropa', 'Efectivo', 9, 300.00, 'Ropa', '2024-09-13', CURRENT_TIMESTAMP);

INSERT INTO Incomes (UserId, Amount, Date, CreatedAt) 
VALUES 
(1, 1500.00, '2024-09-01', CURRENT_TIMESTAMP),
(2, 1800.00, '2024-09-05', CURRENT_TIMESTAMP),
(3, 1200.00, '2024-09-10', CURRENT_TIMESTAMP);

INSERT INTO Budgets (UserId, BudgetAmount, CreatedAt) 
VALUES 
(1, 1200.00, CURRENT_TIMESTAMP),
(2, 1500.00, CURRENT_TIMESTAMP),
(3, 1000.00, CURRENT_TIMESTAMP);

INSERT INTO Goals (UserId, Deadline, CurrentAmount, CreatedAt) 
VALUES 
(1, '2024-12-31', 500.00, CURRENT_TIMESTAMP),
(2, '2025-06-30', 300.00, CURRENT_TIMESTAMP),
(3, '2025-03-31', 700.00, CURRENT_TIMESTAMP);
