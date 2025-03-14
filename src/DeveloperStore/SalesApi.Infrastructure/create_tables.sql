--pra rodar o escrip abaixo eh necessairo entrar no container e ativar aextensao a seguir:

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";



CREATE TABLE Products (
    Id UUID DEFAULT uuid_generate_v4() PRIMARY KEY,
    title VARCHAR(255),
    price DECIMAL(18, 2),
    description TEXT,
    category VARCHAR(100),
    image VARCHAR(255)
);


CREATE TABLE Sales (
    Id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    SaleDate TIMESTAMP NOT NULL,
    Customer UUID NOT NULL,
    Store UUID,
    SaleNumber VARCHAR(100),
    IsCanceled BOOLEAN DEFAULT FALSE
);

CREATE TABLE SaleItems (
    Id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    SaleId INT NOT NULL,
    ProductId UUID NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    UnitPrice DECIMAL(10,2) NOT NULL CHECK (UnitPrice > 0),
    Discount DECIMAL(10,2) DEFAULT 0 CHECK (Discount >= 0),
    TotalPrice DECIMAL(10,2) CHECK (TotalPrice >= 0),

    CONSTRAINT fk_sale FOREIGN KEY (SaleId) REFERENCES Sales(Id) ON DELETE CASCADE,
    CONSTRAINT fk_product FOREIGN KEY (ProductId) REFERENCES Products(Id) ON DELETE CASCADE
);
