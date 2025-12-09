-- =============================================
-- BASE DE DATOS SISTEMA OPTIVEN - VERSIÓN PRO (10/10)
-- Sistema de Gestión Óptica y Oftalmológica
-- Incluye: Lotes, Trazabilidad, Cotizaciones, RBAC y Correcciones Lógicas
-- =============================================
CREATE DATABASE OptivenDB_Pro;
GO
USE OptivenDB_Pro;
GO

-- =============================================
-- 1. SEGURIDAD Y ROLES (RBAC)
-- =============================================
CREATE TABLE Roles (
    RolID INT IDENTITY(1,1) PRIMARY KEY,
    NombreRol VARCHAR(50) NOT NULL UNIQUE, -- Admin, Optometrista, Vendedor, Gerente
    Descripcion VARCHAR(200),
    Activo BIT DEFAULT 1
);
GO

CREATE TABLE Permisos (
    PermisoID INT IDENTITY(1,1) PRIMARY KEY,
    NombrePermiso VARCHAR(100) NOT NULL UNIQUE, -- Ej: VENTA_CREAR, INVENTARIO_VER
    Modulo VARCHAR(50)
);
GO

CREATE TABLE RolesPermisos (
    RolID INT NOT NULL,
    PermisoID INT NOT NULL,
    PRIMARY KEY (RolID, PermisoID),
    FOREIGN KEY (RolID) REFERENCES Roles(RolID),
    FOREIGN KEY (PermisoID) REFERENCES Permisos(PermisoID)
);
GO

-- =============================================
-- 2. ESTRUCTURA ORGANIZACIONAL
-- =============================================
CREATE TABLE Sucursales (
    SucursalID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    Nombre VARCHAR(200) NOT NULL,
    EsPrincipal BIT DEFAULT 0,
    Direccion VARCHAR(500),
    Ciudad VARCHAR(100),
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    Activa BIT DEFAULT 1,
    ConfiguracionJSON NVARCHAR(MAX) -- Para guardar configs específicas (impresora, logo)
);
GO

CREATE TABLE Empleados (
    EmpleadoID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    Cedula VARCHAR(20) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Cargo VARCHAR(100),
    Especialidad VARCHAR(100), -- Para Optometristas
    NumeroLicencia VARCHAR(50), -- Vital para recetas
    Email VARCHAR(100),
    SucursalID INT,
    Activo BIT DEFAULT 1,
    FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID)
);
GO

CREATE TABLE Usuarios (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
    EmpleadoID INT NOT NULL UNIQUE,
    NombreUsuario VARCHAR(50) UNIQUE NOT NULL,
    PasswordHash VARBINARY(64) NOT NULL, -- Seguridad mejorada (SHA2_512)
    Salt UNIQUEIDENTIFIER DEFAULT NEWID(),
    RolID INT NOT NULL,
    UltimoAcceso DATETIME,
    Activo BIT DEFAULT 1,
    FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID),
    FOREIGN KEY (RolID) REFERENCES Roles(RolID)
);
GO

-- =============================================
-- 3. CLIENTES Y CLÍNICA (CORE)
-- =============================================
CREATE TABLE Clientes (
    ClienteID INT IDENTITY(1,1) PRIMARY KEY,
    CodigoInterno VARCHAR(20) UNIQUE, -- Generado autom.
    CedulaRif VARCHAR(20) UNIQUE NOT NULL,
    TipoCliente CHAR(1) CHECK (TipoCliente IN ('N', 'J')),
    NombreRazonSocial VARCHAR(200) NOT NULL,
    FechaNacimiento DATE,
    Sexo CHAR(1),
    TelefonoCelular VARCHAR(20),
    Email VARCHAR(100),
    Direccion VARCHAR(500),
    EmpresaAfiliadaID INT, -- Para seguros o convenios
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE ExamenesOptometricos (
    ExamenID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID INT NOT NULL,
    OptometristaID INT NOT NULL,
    SucursalID INT NOT NULL,
    FechaExamen DATETIME DEFAULT GETDATE(),
    
    -- RX LEJOS
    OD_Esfera DECIMAL(5,2), OD_Cilindro DECIMAL(5,2), OD_Eje INT, OD_AV VARCHAR(10),
    OI_Esfera DECIMAL(5,2), OI_Cilindro DECIMAL(5,2), OI_Eje INT, OI_AV VARCHAR(10),
    
    -- RX CERCA / ADICION
    Adicion DECIMAL(5,2),
    
    -- DATOS TÉCNICOS
    DNP_Lejos DECIMAL(5,2), DNP_Cerca DECIMAL(5,2),
    AlturaFocal DECIMAL(5,2),
    
    Diagnostico NVARCHAR(MAX),
    Observaciones NVARCHAR(MAX),
    EsRecetaExterna BIT DEFAULT 0, -- Si trajo la receta de otro lado
    ArchivoAdjuntoPath VARCHAR(500), -- Para PDF de receta externa
    
    FechaVencimiento DATE,
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
    FOREIGN KEY (OptometristaID) REFERENCES Empleados(EmpleadoID),
    FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID)
);
GO

-- =============================================
-- 4. INVENTARIO ROBUSTO (LOTES Y PRODUCTOS)
-- =============================================
CREATE TABLE Marcas (MarcaID INT IDENTITY(1,1) PRIMARY KEY, Nombre VARCHAR(100));
CREATE TABLE Familias (FamiliaID INT IDENTITY(1,1) PRIMARY KEY, Nombre VARCHAR(100)); -- Ej: Monturas, Lentes Contacto

CREATE TABLE Productos (
    ProductoID INT IDENTITY(1,1) PRIMARY KEY,
    CodigoSKU VARCHAR(50) UNIQUE NOT NULL,
    CodigoBarras VARCHAR(50),
    Nombre VARCHAR(200) NOT NULL,
    FamiliaID INT,
    MarcaID INT,
    ManejaLotes BIT DEFAULT 0, -- IMPORTANTE: 1 para Lentes de Contacto/Líquidos
    ManejaImpuesto BIT DEFAULT 1,
    CostoPromedio DECIMAL(19,4) DEFAULT 0,
    PrecioVenta DECIMAL(19,2) DEFAULT 0,
    PrecioVentaUSD DECIMAL(19,2) DEFAULT 0,
    StockMinimoGlobal INT DEFAULT 1,
    Activo BIT DEFAULT 1,
    FOREIGN KEY (FamiliaID) REFERENCES Familias(FamiliaID),
    FOREIGN KEY (MarcaID) REFERENCES Marcas(MarcaID)
);
GO

-- Tabla para controlar Lotes y Vencimientos (Requerimiento Sanitario)
CREATE TABLE LotesProducto (
    LoteID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL,
    NumeroLote VARCHAR(50) NOT NULL,
    FechaFabricacion DATE,
    FechaVencimiento DATE NOT NULL,
    Activo BIT DEFAULT 1,
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID),
    CONSTRAINT UQ_Lote_Producto UNIQUE (ProductoID, NumeroLote)
);
GO

-- Inventario Agregado (Cantidad total por sucursal)
CREATE TABLE InventarioSucursal (
    InvID INT IDENTITY(1,1) PRIMARY KEY,
    SucursalID INT NOT NULL,
    ProductoID INT NOT NULL,
    Existencia DECIMAL(12,2) DEFAULT 0, -- Decimal por si vendes líquidos a granel o similar
    UbicacionFisica VARCHAR(50), -- Pasillo A, Gaveta 1
    FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID),
    CONSTRAINT UQ_Inv_Sucursal_Prod UNIQUE (SucursalID, ProductoID)
);
GO

-- Inventario Detallado por Lote (Para lo que maneja lotes)
CREATE TABLE ExistenciaLotes (
    ExistenciaLoteID INT IDENTITY(1,1) PRIMARY KEY,
    SucursalID INT NOT NULL,
    LoteID INT NOT NULL,
    Cantidad DECIMAL(12,2) DEFAULT 0,
    FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID),
    FOREIGN KEY (LoteID) REFERENCES LotesProducto(LoteID)
);
GO

-- =============================================
-- 5. CICLO DE VENTAS (COTIZACIÓN -> ORDEN -> FACTURA)
-- =============================================

-- Nueva tabla: Presupuestos antes de la venta
CREATE TABLE Cotizaciones (
    CotizacionID INT IDENTITY(1,1) PRIMARY KEY,
    NumeroCotizacion VARCHAR(20) UNIQUE,
    ClienteID INT,
    SucursalID INT,
    EmpleadoID INT,
    FechaEmision DATETIME DEFAULT GETDATE(),
    FechaVencimiento DATE,
    TotalGeneral DECIMAL(19,2),
    Estado VARCHAR(20) DEFAULT 'Pendiente', -- Pendiente, Aprobada, Vencida
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID)
);
GO

CREATE TABLE OrdenesTrabajo (
    OrdenID INT IDENTITY(1,1) PRIMARY KEY,
    NumeroOrden VARCHAR(20) UNIQUE NOT NULL,
    ClienteID INT NOT NULL,
    ExamenID INT, -- Puede ser NULL si es venta de sol o solo montura
    SucursalID INT NOT NULL,
    EmpleadoID INT NOT NULL, -- Quien vendió
    CotizacionOrigenID INT, -- Trazabilidad de venta
    
    FechaRecepcion DATETIME DEFAULT GETDATE(),
    FechaPromesaEntrega DATE,
    FechaEntregaReal DATETIME,
    
    -- ESTADOS CONSTRAINTS
    EstadoActual VARCHAR(20) CHECK (EstadoActual IN ('Pendiente', 'Laboratorio', 'Montaje', 'Calidad', 'ParaEntregar', 'Entregado', 'Anulado')),
    
    -- LABORATORIO
    LaboratorioAsignadoID INT, -- Tabla Laboratorios (omitida por brevedad)
    CostoLaboratorio DECIMAL(19,2),
    
    TotalVenta DECIMAL(19,2),
    AbonoInicial DECIMAL(19,2),
    SaldoPendiente DECIMAL(19,2),
    
    ObservacionesTaller NVARCHAR(500),
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
    FOREIGN KEY (ExamenID) REFERENCES ExamenesOptometricos(ExamenID),
    FOREIGN KEY (CotizacionOrigenID) REFERENCES Cotizaciones(CotizacionID)
);
GO

-- Trazabilidad: Historia de la Orden (Mejora nivel 10)
CREATE TABLE TrazabilidadOT (
    TrazaID INT IDENTITY(1,1) PRIMARY KEY,
    OrdenID INT NOT NULL,
    EstadoAnterior VARCHAR(20),
    EstadoNuevo VARCHAR(20),
    FechaCambio DATETIME DEFAULT GETDATE(),
    UsuarioID INT, -- Quien cambió el estado
    Comentario VARCHAR(200),
    FOREIGN KEY (OrdenID) REFERENCES OrdenesTrabajo(OrdenID)
);
GO

CREATE TABLE DetalleOrden (
    DetalleID INT IDENTITY(1,1) PRIMARY KEY,
    OrdenID INT NOT NULL,
    ProductoID INT NOT NULL,
    LoteID INT, -- Si aplica
    Cantidad DECIMAL(10,2),
    PrecioUnitario DECIMAL(19,2),
    Descuento DECIMAL(19,2),
    Subtotal DECIMAL(19,2),
    OjoAsignado CHAR(2) CHECK (OjoAsignado IN ('OD', 'OI', 'AM', 'NA')), -- Derecho, Izquierdo, Ambos, No Aplica
    FOREIGN KEY (OrdenID) REFERENCES OrdenesTrabajo(OrdenID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);
GO

-- =============================================
-- 6. CAJA Y FINANZAS (SESIONES)
-- =============================================
CREATE TABLE SesionesCaja (
    SesionID INT IDENTITY(1,1) PRIMARY KEY,
    SucursalID INT NOT NULL,
    UsuarioCajeroID INT NOT NULL,
    FechaApertura DATETIME DEFAULT GETDATE(),
    FechaCierre DATETIME,
    MontoInicial DECIMAL(19,2) NOT NULL, -- Fondo de caja
    MontoFinalDeclarado DECIMAL(19,2),
    MontoFinalSistema DECIMAL(19,2),
    Diferencia DECIMAL(19,2),
    Estado VARCHAR(20) DEFAULT 'Abierta', -- Abierta, Cerrada, Arqueada
    FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID),
    FOREIGN KEY (UsuarioCajeroID) REFERENCES Usuarios(UsuarioID)
);
GO

CREATE TABLE MovimientosCaja (
    MovimientoID INT IDENTITY(1,1) PRIMARY KEY,
    SesionID INT NOT NULL,
    TipoMovimiento VARCHAR(20) CHECK (TipoMovimiento IN ('IngresoVenta', 'AbonoOrden', 'EgresoGasto', 'RetiroBanco')),
    Monto DECIMAL(19,2) NOT NULL,
    FormaPago VARCHAR(20), -- Efectivo, Tarjeta, Zelle, etc.
    ReferenciaDocumento VARCHAR(50), -- Nro Factura o Recibo
    OrdenID INT, -- Si es un abono a una OT
    FechaMovimiento DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (SesionID) REFERENCES SesionesCaja(SesionID),
    FOREIGN KEY (OrdenID) REFERENCES OrdenesTrabajo(OrdenID)
);
GO

-- =============================================
-- 7. TRANSFERENCIAS Y TRIGGER CORREGIDO
-- =============================================
CREATE TABLE Transferencias (
    TransferenciaID INT IDENTITY(1,1) PRIMARY KEY,
    NumeroGuia VARCHAR(20) UNIQUE,
    SucursalOrigenID INT NOT NULL,
    SucursalDestinoID INT NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    UsuarioID INT NOT NULL,
    Confirmada BIT DEFAULT 0,
    FechaConfirmacion DATETIME,
    UsuarioConfirmaID INT,
    FOREIGN KEY (SucursalOrigenID) REFERENCES Sucursales(SucursalID),
    FOREIGN KEY (SucursalDestinoID) REFERENCES Sucursales(SucursalID)
);
GO

CREATE TABLE DetalleTransferencias (
    DetalleTransID INT IDENTITY(1,1) PRIMARY KEY,
    TransferenciaID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    FOREIGN KEY (TransferenciaID) REFERENCES Transferencias(TransferenciaID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);
GO

-- TRIGGER OPTIMIZADO PARA INVENTARIO (Lógica 10/10)
CREATE OR ALTER TRIGGER TR_ConfirmarTransferencia_V2
ON Transferencias
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Solo actuar si se marca como confirmada y antes no lo estaba
    IF UPDATE(Confirmada)
    BEGIN
        IF EXISTS (SELECT 1 FROM inserted WHERE Confirmada = 1) AND 
           EXISTS (SELECT 1 FROM deleted WHERE Confirmada = 0)
        BEGIN
            DECLARE @TransID INT;
            SELECT @TransID = TransferenciaID FROM inserted;

            -- 1. Restar del Origen
            UPDATE inv
            SET inv.Existencia = inv.Existencia - dt.Cantidad
            FROM InventarioSucursal inv
            JOIN DetalleTransferencias dt ON inv.ProductoID = dt.ProductoID
            JOIN inserted i ON i.TransferenciaID = dt.TransferenciaID
            WHERE inv.SucursalID = i.SucursalOrigenID 
              AND dt.TransferenciaID = @TransID;

            -- 2. Asegurar existencia en Destino (UPSERT MANUAL)
            INSERT INTO InventarioSucursal (SucursalID, ProductoID, Existencia, UbicacionFisica)
            SELECT i.SucursalDestinoID, dt.ProductoID, 0, 'Recepción'
            FROM DetalleTransferencias dt
            JOIN inserted i ON dt.TransferenciaID = i.TransferenciaID
            WHERE dt.TransferenciaID = @TransID
            AND NOT EXISTS (
                SELECT 1 FROM InventarioSucursal invDest 
                WHERE invDest.SucursalID = i.SucursalDestinoID 
                  AND invDest.ProductoID = dt.ProductoID
            );

            -- 3. Sumar al Destino
            UPDATE inv
            SET inv.Existencia = inv.Existencia + dt.Cantidad
            FROM InventarioSucursal inv
            JOIN DetalleTransferencias dt ON inv.ProductoID = dt.ProductoID
            JOIN inserted i ON i.TransferenciaID = dt.TransferenciaID
            WHERE inv.SucursalID = i.SucursalDestinoID 
              AND dt.TransferenciaID = @TransID;
        END
    END
END;
GO

-- =============================================
-- 8. VISTAS ÚTILES (REPORTING)
-- =============================================
CREATE VIEW vw_InventarioGlobal AS
SELECT 
    p.CodigoSKU, 
    p.Nombre AS Producto, 
    s.Nombre AS Sucursal, 
    i.Existencia
FROM InventarioSucursal i
JOIN Productos p ON i.ProductoID = p.ProductoID
JOIN Sucursales s ON i.SucursalID = s.SucursalID;
GO

-- Datos Semilla Básicos
INSERT INTO Roles (NombreRol, Descripcion) VALUES ('Administrador', 'Acceso Total'), ('Optometrista', 'Acceso Clínico'), ('Cajero', 'Acceso Ventas');
INSERT INTO Sucursales (Codigo, Nombre, EsPrincipal) VALUES ('MATRIZ', 'Sede Central', 1);
GO