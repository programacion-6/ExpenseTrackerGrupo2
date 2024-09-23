CREATE TABLE IF NOT EXISTS users (
    user_id UUID PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(100) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS expenses (
    expense_id UUID PRIMARY KEY,
    user_id UUID NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    description VARCHAR(255),
    source VARCHAR(100),
    month INT NOT NULL,
    goal_amount DECIMAL(10, 2),
    category VARCHAR(100),
    expense_date DATE NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE IF NOT EXISTS incomes (
    income_id UUID PRIMARY KEY,
    user_id UUID NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    income_date DATE NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE IF NOT EXISTS budgets (
    budget_id UUID PRIMARY KEY,
    user_id UUID NOT NULL,
    budget_amount DECIMAL(10, 2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE IF NOT EXISTS goals (
    goal_id UUID PRIMARY KEY,
    user_id UUID NOT NULL,
    deadline DATE NOT NULL,
    current_amount DECIMAL(10, 2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

INSERT INTO users (name, email, password_hash, created_at) 
VALUES 
('Juan Pérez', 'juan.perez@gmail.com', 'hashed_password_juan', CURRENT_TIMESTAMP),
('Ana Gómez', 'ana.gomez@gmail.com', 'hashed_password_ana', CURRENT_TIMESTAMP),
('Luis Martínez', 'luis.martinez@gmail.com', 'hashed_password_luis', CURRENT_TIMESTAMP);

INSERT INTO expenses (user_id, amount, description, source, month, goal_amount, category, expense_date, created_at) 
VALUES 
('1', 100.50, 'Compra de supermercado', 'Tarjeta de crédito', 9, 200.00, 'Comida', '2024-09-15', CURRENT_TIMESTAMP),
('2', 50.00, 'Pago de servicios públicos', 'Transferencia bancaria', 9, 100.00, 'Servicios', '2024-09-14', CURRENT_TIMESTAMP),
('3', 200.00, 'Compra de ropa', 'Efectivo', 9, 300.00, 'Ropa', '2024-09-13', CURRENT_TIMESTAMP);

INSERT INTO incomes (user_id, amount, income_date, created_at) 
VALUES 
('1', 1500.00, '2024-09-01', CURRENT_TIMESTAMP),
('2', 1800.00, '2024-09-05', CURRENT_TIMESTAMP),
('3', 1200.00, '2024-09-10', CURRENT_TIMESTAMP);

INSERT INTO budgets (user_id, budget_amount, created_at) 
VALUES 
('1', 1200.00, CURRENT_TIMESTAMP),
('2', 1500.00, CURRENT_TIMESTAMP),
('3', 1000.00, CURRENT_TIMESTAMP);

INSERT INTO goals (user_id, deadline, current_amount, created_at) 
VALUES 
('1', '2024-12-31', 500.00, CURRENT_TIMESTAMP),
('2', '2025-06-30', 300.00, CURRENT_TIMESTAMP),
('3', '2025-03-31', 700.00, CURRENT_TIMESTAMP);
