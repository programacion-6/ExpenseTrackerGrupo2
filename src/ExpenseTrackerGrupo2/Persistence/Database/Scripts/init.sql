CREATE TABLE IF NOT EXISTS users (
    user_id UUID PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(100) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS expense (
    expense_id UUID PRIMARY KEY,
    user_id UUID NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    description VARCHAR(255),
    category VARCHAR(100),
    expense_date DATE NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS income (
    income_id UUID PRIMARY KEY,
    user_id UUID NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    source VARCHAR(100),
    income_date DATE NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS budget (
    budget_id UUID PRIMARY KEY,
    user_id UUID NOT NULL,
    month VARCHAR(7) NOT NULL,
    budget_amount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS goal (
    goal_id UUID PRIMARY KEY,
    user_id UUID NOT NULL,
    goal_amount DECIMAL(10, 2),
    deadline DATE NOT NULL,
    current_amount DECIMAL(10, 2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
);

INSERT INTO users (user_id, name, email, password_hash, created_at) 
VALUES 
('550e8400-e29b-41d4-a716-446655440000', 'Juan Pérez', 'juan.perez@gmail.com', 'hashed_password_juan', CURRENT_TIMESTAMP),
('550e8400-e29b-41d4-a716-446655440001', 'Ana Gómez', 'ana.gomez@gmail.com', 'hashed_password_ana', CURRENT_TIMESTAMP),
('550e8400-e29b-41d4-a716-446655440002', 'Luis Martínez', 'luis.martinez@gmail.com', 'hashed_password_luis', CURRENT_TIMESTAMP);

INSERT INTO expense (expense_id, user_id, amount, description, category, expense_date, created_at) 
VALUES 
('650e8400-e29b-41d4-a716-446655440003', '550e8400-e29b-41d4-a716-446655440000', 100.50, 'Compra de supermercado', 'Comida', '2024-09-15', CURRENT_TIMESTAMP),
('650e8400-e29b-41d4-a716-446655440004', '550e8400-e29b-41d4-a716-446655440001', 50.00, 'Pago de servicios públicos', 'Servicios', '2024-09-14', CURRENT_TIMESTAMP),
('650e8400-e29b-41d4-a716-446655440005', '550e8400-e29b-41d4-a716-446655440002', 200.00, 'Compra de ropa', 'Ropa', '2024-09-13', CURRENT_TIMESTAMP);

INSERT INTO income (income_id, user_id, amount, source, income_date, created_at) 
VALUES 
('750e8400-e29b-41d4-a716-446655440006', '550e8400-e29b-41d4-a716-446655440000', 1500.00, 'Salario', '2024-09-01', CURRENT_TIMESTAMP),
('750e8400-e29b-41d4-a716-446655440007', '550e8400-e29b-41d4-a716-446655440001', 1800.00, 'Salario', '2024-09-05', CURRENT_TIMESTAMP),
('750e8400-e29b-41d4-a716-446655440008', '550e8400-e29b-41d4-a716-446655440002', 1200.00, 'Salario', '2024-09-10', CURRENT_TIMESTAMP);

INSERT INTO budget (budget_id, user_id, month, budget_amount) 
VALUES 
('850e8400-e29b-41d4-a716-446655440009', '550e8400-e29b-41d4-a716-446655440000', '2024-09', 1200.00),
('850e8400-e29b-41d4-a716-446655440010', '550e8400-e29b-41d4-a716-446655440001', '2024-09', 1500.00),
('850e8400-e29b-41d4-a716-446655440011', '550e8400-e29b-41d4-a716-446655440002', '2024-09', 1000.00);

INSERT INTO goal (goal_id, user_id, goal_amount, deadline, current_amount, created_at) 
VALUES 
('950e8400-e29b-41d4-a716-446655440012', '550e8400-e29b-41d4-a716-446655440000', 1000.00, '2024-12-31', 500.00, CURRENT_TIMESTAMP),
('950e8400-e29b-41d4-a716-446655440013', '550e8400-e29b-41d4-a716-446655440001', 2000.00, '2025-06-30', 300.00, CURRENT_TIMESTAMP),
('950e8400-e29b-41d4-a716-446655440014', '550e8400-e29b-41d4-a716-446655440002', 1500.00, '2025-03-31', 700.00, CURRENT_TIMESTAMP);
