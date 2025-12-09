/*
  Diseño_Tablas_OO_Optimizado.sql
  Script de migración/optimización completo (SQL Server T-SQL)
  - Llaves surrogate (IDENTITY)
  - Constraints (PK, FK, UNIQUE, CHECK)
  - Índices recomendados
  - Triggers para auditoría y control de inventario
  - Tablas de auditoría y log
  - Uso de DATETIME2 y DECIMAL(18,2)
  - Ejemplos de particionamiento comentado
*/

SET NOCOUNT ON;
GO

/* ========================
   1. Esquema
   ======================== */
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'ventas')
    EXEC('CREATE SCHEMA ventas');
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'inventario')
    EXEC('CREATE SCHEMA inventario');
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'contabilidad')
    EXEC('CREATE SCHEMA contabilidad');
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'config')
    EXEC('CREATE SCHEMA config');
GO

/* ========================
   2. Tablas maestras
   ======================== */
-- Usuarios
CREATE TABLE ventas.Usuarios (
    IDUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    NombreUsuario NVARCHAR(100) NOT NULL UNIQUE,
    ContrasenaHash VARBINARY(256) NULL,
    Email NVARCHAR(200) NULL,
    Telefono NVARCHAR(20) NULL,
    Rol NVARCHAR(50) NOT NULL,
    Estatus CHAR(1) NOT NULL DEFAULT 'A' CHECK (Estatus IN ('A','I')),
    FechaCreacion DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    UsuarioCreacion NVARCHAR(100) NULL,
    FechaModificacion DATETIME2(0) NULL,
    UsuarioModificacion NVARCHAR(100) NULL
);
CREATE INDEX IX_Usuarios_Nombre ON ventas.Usuarios(Nombre);
GO

-- Clientes
CREATE TABLE ventas.Clientes (
    IDCliente INT IDENTITY(1,1) PRIMARY KEY,
    CodigoCliente NVARCHAR(50) NOT NULL UNIQUE,
    Cedula NVARCHAR(50) NULL,
    Nombre NVARCHAR(250) NOT NULL,
    Direccion NVARCHAR(500) NULL,
    Telefono NVARCHAR(50) NULL,
    Email NVARCHAR(200) NULL,
    Estatus CHAR(1) NOT NULL DEFAULT 'A' CHECK (Estatus IN ('A','I')),
    FechaCreacion DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    UsuarioCreacion NVARCHAR(100) NULL
);
CREATE INDEX IX_Clientes_Cedula ON ventas.Clientes(Cedula);
CREATE INDEX IX_Clientes_Nombre ON ventas.Clientes(Nombre);
GO

-- Productos
CREATE TABLE inventario.Productos (
    IDProducto INT IDENTITY(1,1) PRIMARY KEY,
    CodigoProducto NVARCHAR(100) NOT NULL,
    CodigoBarra NVARCHAR(100) NULL,
    Nombre NVARCHAR(250) NOT NULL,
    Descripcion NVARCHAR(1000) NULL,
    IDCategoria INT NULL,
    UnidadMedida NVARCHAR(50) NULL,
    PrecioVenta DECIMAL(18,2) NOT NULL DEFAULT 0.00 CHECK (PrecioVenta >= 0),
    PrecioCosto DECIMAL(18,2) NOT NULL DEFAULT 0.00 CHECK (PrecioCosto >= 0),
    StockActual DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (StockActual >= 0),
    Reorden DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (Reorden >= 0),
    Estatus CHAR(1) NOT NULL DEFAULT 'A' CHECK (Estatus IN ('A','I')),
    FechaCreacion DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    UsuarioCreacion NVARCHAR(100) NULL
);
ALTER TABLE inventario.Productos ADD CONSTRAINT UQ_Productos_Codigo UNIQUE (CodigoProducto);
ALTER TABLE inventario.Productos ADD CONSTRAINT UQ_Productos_CodigoBarra UNIQUE (CodigoBarra);
CREATE INDEX IX_Productos_Nombre ON inventario.Productos(Nombre);
CREATE INDEX IX_Productos_StockActual ON inventario.Productos(StockActual);
GO

-- Bancos
CREATE TABLE contabilidad.Bancos (
    IDBanco INT IDENTITY(1,1) PRIMARY KEY,
    CodigoBanco NVARCHAR(50) NULL,
    Nombre NVARCHAR(200) NOT NULL UNIQUE,
    NumeroCuenta NVARCHAR(100) NULL,
    Moneda NVARCHAR(10) NULL,
    Estatus CHAR(1) NOT NULL DEFAULT 'A' CHECK (Estatus IN ('A','I'))
);
GO

-- Empresas / Sucursales
CREATE TABLE config.Empresas (
    IDEmpresa INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(250) NOT NULL,
    RIF NVARCHAR(100) NULL,
    Direccion NVARCHAR(500) NULL,
    Telefono NVARCHAR(50) NULL,
    Email NVARCHAR(200) NULL,
    FechaCreacion DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME()
);
CREATE INDEX IX_Empresas_RIF ON config.Empresas(RIF);
GO

/* ========================
   3. Ventas / facturación
   ======================== */
-- Facturas (Cabecera)
CREATE TABLE ventas.Facturas (
    IDFactura BIGINT IDENTITY(1,1) PRIMARY KEY,
    CodigoFactura NVARCHAR(50) NOT NULL UNIQUE,
    IDEmpresa INT NOT NULL,
    IDCliente INT NOT NULL,
    FechaFactura DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    VendedorID INT NULL,
    Subtotal DECIMAL(18,2) NOT NULL CHECK (Subtotal >= 0),
    IVA DECIMAL(18,2) NOT NULL CHECK (IVA >= 0),
    Descuento DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (Descuento >= 0),
    Total DECIMAL(18,2) NOT NULL CHECK (Total >= 0),
    Estatus CHAR(1) NOT NULL DEFAULT 'A' CHECK (Estatus IN ('A','C','X')),
    FechaCreacion DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    UsuarioCreacion NVARCHAR(100) NULL,
    CONSTRAINT FK_Facturas_Empresa FOREIGN KEY (IDEmpresa) REFERENCES config.Empresas(IDEmpresa),
    CONSTRAINT FK_Facturas_Cliente FOREIGN KEY (IDCliente) REFERENCES ventas.Clientes(IDCliente),
    CONSTRAINT CHK_Facturas_Total CHECK (Total = Subtotal + IVA - Descuento)
);
CREATE INDEX IX_Facturas_Fecha ON ventas.Facturas(FechaFactura);
CREATE INDEX IX_Facturas_IDCliente ON ventas.Facturas(IDCliente);
GO

-- Detalle de Factura
CREATE TABLE ventas.FacturaDetalle (
    IDFacturaDetalle BIGINT IDENTITY(1,1) PRIMARY KEY,
    IDFactura BIGINT NOT NULL,
    IDProducto INT NOT NULL,
    Cantidad DECIMAL(18,4) NOT NULL CHECK (Cantidad > 0),
    PrecioUnitario DECIMAL(18,6) NOT NULL CHECK (PrecioUnitario >= 0),
    Subtotal DECIMAL(18,2) NOT NULL CHECK (Subtotal >= 0),
    IVA DECIMAL(18,2) NOT NULL CHECK (IVA >= 0),
    TotalLinea DECIMAL(18,2) NOT NULL CHECK (TotalLinea >= 0),
    CONSTRAINT FK_FacturaDetalle_Factura FOREIGN KEY (IDFactura) REFERENCES ventas.Facturas(IDFactura) ON DELETE CASCADE,
    CONSTRAINT FK_FacturaDetalle_Producto FOREIGN KEY (IDProducto) REFERENCES inventario.Productos(IDProducto)
);
CREATE INDEX IX_FacturaDetalle_IDFactura ON ventas.FacturaDetalle(IDFactura);
CREATE INDEX IX_FacturaDetalle_IDProducto ON ventas.FacturaDetalle(IDProducto);
GO

/* ========================
   4. Pagos y cuentas por cobrar
   ======================== */
CREATE TABLE contabilidad.Pagos (
    IDPago BIGINT IDENTITY(1,1) PRIMARY KEY,
    IDFactura BIGINT NOT NULL,
    FechaPago DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    Monto DECIMAL(18,2) NOT NULL CHECK (Monto > 0),
    MetodoPago NVARCHAR(50) NOT NULL,
    Referencia NVARCHAR(200) NULL,
    IDBanco INT NULL,
    UsuarioRegistro NVARCHAR(100) NULL,
    CONSTRAINT FK_Pagos_Factura FOREIGN KEY (IDFactura) REFERENCES ventas.Facturas(IDFactura),
    CONSTRAINT FK_Pagos_Banco FOREIGN KEY (IDBanco) REFERENCES contabilidad.Bancos(IDBanco)
);
CREATE INDEX IX_Pagos_IDFactura ON contabilidad.Pagos(IDFactura);
CREATE INDEX IX_Pagos_FechaPago ON contabilidad.Pagos(FechaPago);
GO

/* ========================
   5. Inventario / Kardex
   ======================== */
CREATE TABLE inventario.Movimientos (
    IDMovimiento BIGINT IDENTITY(1,1) PRIMARY KEY,
    IDProducto INT NOT NULL,
    FechaMovimiento DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    TipoMovimiento CHAR(10) NOT NULL CHECK (TipoMovimiento IN ('ENTRADA','SALIDA','AJUSTE')),
    Cantidad DECIMAL(18,4) NOT NULL CHECK (Cantidad > 0),
    PrecioUnitario DECIMAL(18,6) NOT NULL CHECK (PrecioUnitario >= 0),
    Referencia NVARCHAR(250) NULL,
    IDDocumentoRelacionado NVARCHAR(100) NULL,
    UsuarioRegistro NVARCHAR(100) NULL,
    StockAntes DECIMAL(18,4) NULL,
    StockDespues DECIMAL(18,4) NULL,
    CONSTRAINT FK_Movimientos_Producto FOREIGN KEY (IDProducto) REFERENCES inventario.Productos(IDProducto)
);
CREATE INDEX IX_Movimientos_Producto_Fecha ON inventario.Movimientos(IDProducto, FechaMovimiento);
GO

/* Trigger para evitar stock negativo y actualizar stock en Productos */
CREATE OR ALTER TRIGGER inventario.trg_Movimientos_UpdateStock
ON inventario.Movimientos
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IDProducto INT;

    -- Update stock for each inserted movement row
    UPDATE p
    SET p.StockActual = CASE
            WHEN m.TipoMovimiento = 'ENTRADA' THEN p.StockActual + m.Cantidad
            WHEN m.TipoMovimiento IN ('SALIDA') THEN p.StockActual - m.Cantidad
            WHEN m.TipoMovimiento = 'AJUSTE' THEN m.StockDespues
            ELSE p.StockActual
        END
    FROM inventario.Productos p
    INNER JOIN inserted m ON p.IDProducto = m.IDProducto;

    -- Verify no negative stocks
    IF EXISTS (SELECT 1 FROM inventario.Productos WHERE StockActual < 0)
    BEGIN
        RAISERROR('Movimiento invalido: Stock resultante negativo.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

/* ========================
   6. Ordenes de Trabajo (OT)
   ======================== */
CREATE TABLE ventas.OrdenesTrabajo (
    IDOrden BIGINT IDENTITY(1,1) PRIMARY KEY,
    NumeroOrden NVARCHAR(50) NOT NULL UNIQUE,
    IDEmpresa INT NOT NULL,
    IDCliente INT NOT NULL,
    FechaRecepcion DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    FechaEntregaEstimada DATETIME2(0) NULL,
    FechaEntregaReal DATETIME2(0) NULL,
    Estado CHAR(1) NOT NULL DEFAULT 'R' CHECK (Estado IN ('R','A','T','F','E')),
    Observaciones NVARCHAR(1000) NULL,
    UsuarioAsignado NVARCHAR(100) NULL,
    FechaCreacion DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME()
);
CREATE INDEX IX_OrdenesTrabajo_IDCliente ON ventas.OrdenesTrabajo(IDCliente);
CREATE INDEX IX_OrdenesTrabajo_Estado ON ventas.OrdenesTrabajo(Estado);
GO

/* Validación simple: FechaEntregaReal no puede ser anterior a FechaRecepcion */
ALTER TABLE ventas.OrdenesTrabajo ADD CONSTRAINT CHK_Ordenes_Fechas CHECK (FechaEntregaReal IS NULL OR FechaEntregaReal >= FechaRecepcion);
GO

/* ========================
   7. Caja y movimientos de caja
   ======================== */
CREATE TABLE contabilidad.Caja (
    IDCaja INT IDENTITY(1,1) PRIMARY KEY,
    CodigoCaja NVARCHAR(50) NOT NULL UNIQUE,
    Descripcion NVARCHAR(250) NULL,
    Estatus CHAR(1) NOT NULL DEFAULT 'A' CHECK (Estatus IN ('A','C'))
);

CREATE TABLE contabilidad.CajaMovimientos (
    IDCajaMovimiento BIGINT IDENTITY(1,1) PRIMARY KEY,
    IDCaja INT NOT NULL,
    FechaMovimiento DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    TipoMovimiento CHAR(1) NOT NULL CHECK (TipoMovimiento IN ('I','E')), -- I: Ingreso, E: Egreso
    Monto DECIMAL(18,2) NOT NULL CHECK (Monto > 0),
    Descripcion NVARCHAR(500) NULL,
    UsuarioRegistro NVARCHAR(100) NULL,
    IDDocumentoRelacionado NVARCHAR(100) NULL,
    CONSTRAINT FK_CajaMovimientos_Caja FOREIGN KEY (IDCaja) REFERENCES contabilidad.Caja(IDCaja)
);
CREATE INDEX IX_CajaMovimientos_IDCaja ON contabilidad.CajaMovimientos(IDCaja);
CREATE INDEX IX_CajaMovimientos_Fecha ON contabilidad.CajaMovimientos(FechaMovimiento);
GO

/* ========================
   8. Auditoría y logs
   ======================== */
CREATE TABLE config.Auditoria (
    IDAuditoria BIGINT IDENTITY(1,1) PRIMARY KEY,
    NombreTabla NVARCHAR(200) NOT NULL,
    TipoOperacion CHAR(1) NOT NULL CHECK (TipoOperacion IN ('I','U','D')),
    FechaOperacion DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    Usuario NVARCHAR(200) NULL,
    RegistroPK NVARCHAR(500) NULL,
    ValoresPrevios NVARCHAR(MAX) NULL,
    ValoresNuevos NVARCHAR(MAX) NULL,
    Observaciones NVARCHAR(1000) NULL
);
GO

CREATE TABLE config.LogErrores (
    IDLog BIGINT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME2(0) NOT NULL DEFAULT SYSUTCDATETIME(),
    Nivel NVARCHAR(50) NOT NULL,
    Mensaje NVARCHAR(MAX) NOT NULL,
    Procedimiento NVARCHAR(500) NULL,
    Datos NVARCHAR(MAX) NULL
);
GO

/* Trigger genérico de auditoría (ejemplo para Clientes) */
CREATE OR ALTER TRIGGER ventas.trg_Clientes_Auditoria
ON ventas.Clientes
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @usuario NVARCHAR(200) = SUSER_SNAME();

    IF EXISTS(SELECT 1 FROM inserted) AND EXISTS(SELECT 1 FROM deleted)
    BEGIN
        -- UPDATE
        INSERT INTO config.Auditoria (NombreTabla, TipoOperacion, FechaOperacion, Usuario, RegistroPK, ValoresPrevios, ValoresNuevos)
        SELECT 'ventas.Clientes', 'U', SYSUTCDATETIME(), @usuario,
               CONVERT(NVARCHAR(500), d.IDCliente),
               (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
               (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM inserted i
        INNER JOIN deleted d ON i.IDCliente = d.IDCliente;
    END
    ELSE IF EXISTS(SELECT 1 FROM inserted)
    BEGIN
        -- INSERT
        INSERT INTO config.Auditoria (NombreTabla, TipoOperacion, FechaOperacion, Usuario, RegistroPK, ValoresNuevos)
        SELECT 'ventas.Clientes', 'I', SYSUTCDATETIME(), @usuario, CONVERT(NVARCHAR(500), IDCliente), (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM inserted i;
    END
    ELSE IF EXISTS(SELECT 1 FROM deleted)
    BEGIN
        -- DELETE
        INSERT INTO config.Auditoria (NombreTabla, TipoOperacion, FechaOperacion, Usuario, RegistroPK, ValoresPrevios)
        SELECT 'ventas.Clientes', 'D', SYSUTCDATETIME(), @usuario, CONVERT(NVARCHAR(500), IDCliente), (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM deleted d;
    END
END;
GO

/* ========================
   9. Vistas útiles y procedimientos almacenados de apoyo
   ======================== */
-- Vista: Saldos por cliente
CREATE OR ALTER VIEW ventas.vw_SaldoClientes AS
SELECT c.IDCliente, c.Nombre, SUM(f.Total) - ISNULL(SUM(p.Monto),0) AS Saldo
FROM ventas.Clientes c
LEFT JOIN ventas.Facturas f ON f.IDCliente = c.IDCliente AND f.Estatus <> 'X'
LEFT JOIN contabilidad.Pagos p ON p.IDFactura = f.IDFactura
GROUP BY c.IDCliente, c.Nombre;
GO

-- Procedimiento para registrar un pago (ejemplo con validaciones)
CREATE OR ALTER PROCEDURE contabilidad.usp_RegistraPago
    @IDFactura BIGINT,
    @Monto DECIMAL(18,2),
    @Metodo NVARCHAR(50),
    @IDBanco INT = NULL,
    @Usuario NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM ventas.Facturas WHERE IDFactura = @IDFactura)
            THROW 51000, 'Factura no existe.', 1;

        DECLARE @TotalFactura DECIMAL(18,2) = (SELECT Total FROM ventas.Facturas WHERE IDFactura = @IDFactura);
        DECLARE @TotalPagado DECIMAL(18,2) = (SELECT ISNULL(SUM(Monto),0) FROM contabilidad.Pagos WHERE IDFactura = @IDFactura);

        IF @Monto <= 0
            THROW 51001, 'Monto de pago debe ser mayor que cero.', 1;

        IF @TotalPagado + @Monto > @TotalFactura
            THROW 51002, 'Pago excede el saldo de la factura.', 1;

        INSERT INTO contabilidad.Pagos (IDFactura, FechaPago, Monto, MetodoPago, IDBanco, UsuarioRegistro)
        VALUES (@IDFactura, SYSUTCDATETIME(), @Monto, @Metodo, @IDBanco, @Usuario);

        -- Si desea marcar factura como pagada
        IF (@TotalPagado + @Monto) = @TotalFactura
            UPDATE ventas.Facturas SET Estatus = 'C' WHERE IDFactura = @IDFactura;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        INSERT INTO config.LogErrores (Nivel, Mensaje, Procedimiento, Datos) VALUES ('ERROR', @ErrMsg, 'contabilidad.usp_RegistraPago', CONCAT('IDFactura=', @IDFactura, '; Monto=', @Monto));
        THROW;
    END CATCH
END;
GO

/* ========================
   10. Ejemplos de índices compuestos y recomendaciones
   ======================== */
CREATE INDEX IX_Facturas_Fecha_Total_IDCliente ON ventas.Facturas(FechaFactura, Total, IDCliente);
CREATE INDEX IX_Movimientos_Tipo_Fecha ON inventario.Movimientos(TipoMovimiento, FechaMovimiento);
GO

/* ========================
   11. Particionamiento (ejemplo comentado)
   ======================== */
/*
-- Ejemplo: particionar la tabla Facturas por año (requiere planificación y filegroups)
-- 1) Crear function de particion
CREATE PARTITION FUNCTION pf_Facturas_Anio (int) AS RANGE LEFT FOR VALUES (2019,2020,2021,2022,2023,2024);
-- 2) Crear esquema de partición (partition scheme) y mover la tabla.
-- Nota: Solo SQL Server Enterprise o versiones con particionado soportado.
*/

/* ========================
   12. Mantenimiento y recomendaciones finales
   ======================== */
/*
  - Agregar trabajos SQL Agent para: index rebuild/reorganize, statistics update y limpieza de tablas de log/archivos.
  - Implementar backup diario/incremental y pruebas de restore.
  - Monitorizar consultas con Extended Events, Query Store y revisar índices no usados.
  - Revisar permisos: usar roles y principios de mínimo privilegio (no usar cuentas sa para acceso de aplicación).
  - Considerar separación de lectura/escritura mediante réplicas si la carga lo requiere.
*/

PRINT 'Script de diseño optimizado generado.';
GO
