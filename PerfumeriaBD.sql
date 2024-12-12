CREATE DATABASE PerfumeriaBD;
GO
USE PerfumeriaBD;
GO
-- Crear la tabla Tamaño
CREATE TABLE Tamaño (
    Id_Tamaño INT PRIMARY KEY,
    Tamaño_ml VARCHAR(20) 
);
-- Crear la tabla Aroma
CREATE TABLE Aroma (
    Id_Aroma INT PRIMARY KEY,
    Aroma VARCHAR(50) 
);
-- Crear la tabla Envase
CREATE TABLE Envase (
    Id_Envase INT PRIMARY KEY,
    Tipo_Envase VARCHAR(50) 
);
-- Crear tabla MetodoPago
CREATE TABLE MetodoPago (
    Id_MetodoP INT PRIMARY KEY,
    Metodo_pago VARCHAR(50)
);
-- Crear tabla Domicilio
CREATE TABLE Domicilio (
    Id_Domicilio INT PRIMARY KEY,
    Domicilio VARCHAR(100),
    Numero INT,
    Codigo_postal INT
);
-- Crear la tabla Producto con claves foráneas
CREATE TABLE Producto (
    Id_Producto INT PRIMARY KEY,
    Nombre_Perfume VARCHAR(50),
    Marca VARCHAR(50),
    Precio DECIMAL(10, 2),
    Clasificacion VARCHAR(50),
    Id_Tamaño INT, -- Clave foránea a la tabla Tamaño
    Id_Aroma INT, -- Clave foránea a la tabla Aroma
    Id_Envase INT, -- Clave foránea a la tabla Envase
    FOREIGN KEY (Id_Tamaño) REFERENCES Tamaño(Id_Tamaño),
    FOREIGN KEY (Id_Aroma) REFERENCES Aroma(Id_Aroma),
    FOREIGN KEY (Id_Envase) REFERENCES Envase(Id_Envase)
);
-- Crear tabla Cliente con claves foráneas a MetodoPago y Domicilio
CREATE TABLE Cliente (
    Id_Cliente INT PRIMARY KEY,
    Nombre VARCHAR(50),
    Correo VARCHAR(50) UNIQUE, -- Agregar restricción para que el correo sea único
    Telefono VARCHAR(15),
    Id_MetodoP INT, -- Clave foránea
    Id_Domicilio INT, -- Clave foránea
    FOREIGN KEY (Id_MetodoP) REFERENCES MetodoPago(Id_MetodoP),
    FOREIGN KEY (Id_Domicilio) REFERENCES Domicilio(Id_Domicilio)
);
-- Tabla Ticket
CREATE TABLE Ticket (
    Id_Ticket INT PRIMARY KEY,
	NumeroOrden VARCHAR(20) UNIQUE NOT NULL,
    Fecha DATE,
    Total DECIMAL(10, 2),
    Id_Cliente INT,
    FOREIGN KEY (Id_Cliente) REFERENCES Cliente(Id_Cliente)
);
-- Tabla DetalleTicket
CREATE TABLE DetalleTicket (
    Id_DetalleTicket INT PRIMARY KEY,
    Id_Ticket INT,
    Id_Producto INT,
    Cantidad INT,
    Subtotal DECIMAL(10, 2), -- Subtotal: Cantidad * PrecioUnitario
    PrecioUnitario DECIMAL(10, 2), 
    FOREIGN KEY (Id_Ticket) REFERENCES Ticket(Id_Ticket) ON DELETE CASCADE, -- Eliminar Detalles cuando se elimina el Ticket
    FOREIGN KEY (Id_Producto) REFERENCES Producto(Id_Producto) ON DELETE CASCADE -- Eliminar Detalles si se elimina un Producto
);
-- Insertar datos en la tabla Tamaño
INSERT INTO Tamaño (Id_Tamaño, Tamaño_ml) 
VALUES 
(7011, '30 ml'),
(7012, '45 ml'),
(7013, '50 ml'),
(7014, '60 ml');
-- Insertar datos en la tabla Aroma
INSERT INTO Aroma (Id_Aroma, Aroma) 
VALUES 
(1111, 'Floral'),
(2112, 'Oriental'),
(3113, 'Woody'),
(4114, 'Fresh');
-- Insertar datos en la tabla Envase
INSERT INTO Envase (Id_Envase, Tipo_Envase) 
VALUES 
(7712, 'Dosificador'),
(7713, 'Tarro de plastico'),
(7714, 'Roll-on'),
(7715, 'Tubo');
-- Insertar datos en la tabla Producto
INSERT INTO Producto (Id_Producto, Nombre_Perfume, Marca, Precio, Clasificacion, Id_Tamaño, Id_Aroma, Id_Envase) 
VALUES 
(1, 'Rose Goldea', 'Bvlgari', 3250.00, 'Perfume', 7011, 1111, 7712),
(2, 'Eternity', 'Calvin Klein', 3099.00, 'Crema', 7012, 2112, 7713),
(3, 'Goodgirl', 'Carolina Herrera', 2285.00, 'Body', 7013, 3113, 7714),
(4, 'Sauvage', 'Cristian Dior', 4980.00, 'Perfume', 7014, 4114, 7715);
-- Insertar datos en la tabla MetodoPago
INSERT INTO MetodoPago (Id_MetodoP, Metodo_pago) 
VALUES 
(5202, 'Tarjeta de credito'),
(5309, 'Tarjeta de debito'),
(5416, 'PayPal'),
(5523, 'Transferencia');
-- Insertar datos en la tabla Domicilio
INSERT INTO Domicilio (Id_Domicilio, Domicilio, Numero, Codigo_postal) 
VALUES 
(6329, 'Martires de rio blanco', 109, 22385),
(6320, 'Avenida Francisco mujica', 2034, 22393),
(6311, 'Articulo 123', 567, 22233),
(6302, 'Calle Pasteje', 5900, 23309);
-- Insertar datos en la tabla Cliente
INSERT INTO Cliente (Id_Cliente, Nombre, Correo, Telefono, Id_MetodoP, Id_Domicilio) 
VALUES 
(1, 'María', 'ask@gmail.com', '6647895203', 5202, 6329),
(2, 'Jose', 'jak@gmail.com', '6638794889', 5309, 6320),
(3, 'Juan', 'opp@gmail.com', '6642011455', 5416, 6311),
(4, 'Carmen', 'att@gmail.com', '6638792003', 5523, 6302);
-- Insertar datos en la tabla Ticket
INSERT INTO Ticket (Id_Ticket, NumeroOrden, Fecha, Total, Id_Cliente) 
VALUES 
(1, 'ORD-20241110-33345', '2024-11-10', 3250.00, 1),
(2, 'ORD-20240923-33346', '2024-09-23', 3099.00, 2);
-- Insertar datos en la tabla DetalleTicket
INSERT INTO DetalleTicket (Id_DetalleTicket, Id_Ticket, Id_Producto, Cantidad, Subtotal, PrecioUnitario) 
VALUES 
(1, 1, 1, 2, 6500.00, 3250.00),
(2, 1, 2, 1, 3099.00, 3099.00),
(3, 2, 3, 1, 2285.00, 2285.00);
-- Verificar Producto
SELECT * FROM Producto;
-- Verificar Tamaño
SELECT * FROM Tamaño;
-- Verificar Aroma
SELECT * FROM Aroma;
-- Verificar Envase
SELECT * FROM Envase;
-- Verificar Cliente
SELECT * FROM Cliente;
-- Verificar Ticket
SELECT * FROM Ticket;
-- Verificar DetalleTicket
SELECT * FROM DetalleTicket;