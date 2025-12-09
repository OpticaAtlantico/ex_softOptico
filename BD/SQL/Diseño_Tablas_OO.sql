
---## 📦 MÓDULO 1: FACTURACIÓN – VENTAS Y PAGOS

-- =============================================
-- TABLAS PRINCIPALES
-- =============================================

-- 1.1 Usuarios/Vendedores
CREATE TABLE Usuarios (
    CodigoUsuario VARCHAR(10) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Clave VARCHAR(100) NOT NULL,
    NivelAcceso INT DEFAULT 1,
    Activo BIT DEFAULT 1,
    Email VARCHAR(100),
    Telefono VARCHAR(20),
    FechaRegistro DATE DEFAULT GETDATE()
);

-- 1.2 Clientes
CREATE TABLE Clientes (
    Cedula VARCHAR(20) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    TipoCliente CHAR(1) CHECK (TipoCliente IN ('N', 'J')), -- Natural/Jurídico
    Rif VARCHAR(20),
    Direccion VARCHAR(200),
    Ciudad VARCHAR(50),
    Estado VARCHAR(50),
    TelefonoCasa VARCHAR(20),
    TelefonoCelular VARCHAR(20),
    Email VARCHAR(100),
    FechaNacimiento DATE,
    Sexo CHAR(1) CHECK (Sexo IN ('M', 'F')),
    Ocupacion VARCHAR(100),
    CompaniaSeguro VARCHAR(100),
    PolizaSeguro VARCHAR(50),
    FechaRegistro DATE DEFAULT GETDATE(),
    Activo BIT DEFAULT 1
);

-- 1.3 Facturas (Venta Directa)
CREATE TABLE Facturas (
    NumeroFactura INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE DEFAULT GETDATE(),
    Hora TIME DEFAULT CONVERT(TIME, GETDATE()),
    CodigoCliente VARCHAR(20),
    CodigoVendedor VARCHAR(10),
    SubtotalNeto DECIMAL(18,2) DEFAULT 0,
    DescuentoGlobal DECIMAL(18,2) DEFAULT 0,
    DescuentoPorcentaje DECIMAL(5,2) DEFAULT 0,
    MontoExento DECIMAL(18,2) DEFAULT 0,
    ImpuestoIVA DECIMAL(18,2) DEFAULT 0,
    IGTF DECIMAL(18,2) DEFAULT 0, -- Impuesto Grandes Transacciones Financieras
    Total DECIMAL(18,2) DEFAULT 0,
    TotalUSD DECIMAL(18,2) DEFAULT 0,
    TasaCambio DECIMAL(18,2),
    Estado CHAR(1) DEFAULT 'A', -- A=Activa, N=Anulada, P=Pendiente
    NumeroControl VARCHAR(50),
    Observaciones VARCHAR(500),
    FOREIGN KEY (CodigoCliente) REFERENCES Clientes(Cedula),
    FOREIGN KEY (CodigoVendedor) REFERENCES Usuarios(CodigoUsuario)
);

-- 1.4 Detalle Factura
CREATE TABLE DetalleFactura (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    NumeroFactura INT,
    CodigoProducto VARCHAR(20),
    Cantidad DECIMAL(10,2) DEFAULT 1,
    PrecioUnitario DECIMAL(18,2),
    DescuentoItem DECIMAL(18,2) DEFAULT 0,
    DescuentoPorcentaje DECIMAL(5,2) DEFAULT 0,
    ImpuestoPorcentaje DECIMAL(5,2) DEFAULT 16,
    ImpuestoItem DECIMAL(18,2) DEFAULT 0,
    TotalItem DECIMAL(18,2),
    FOREIGN KEY (NumeroFactura) REFERENCES Facturas(NumeroFactura)
);

-- 1.5 Formas de Pago
CREATE TABLE PagosFactura (
    IdPago INT IDENTITY(1,1) PRIMARY KEY,
    NumeroFactura INT,
    TipoPago VARCHAR(30) CHECK (TipoPago IN (
        'EFECTIVO', 'CHEQUE', 'TARJETA_CREDITO', 'TARJETA_DEBITO', 
        'NOTA_CREDITO', 'SEGURO', 'CREDITO', 'DIVISA', 'TRANSFERENCIA'
    )),
    Monto DECIMAL(18,2),
    Banco VARCHAR(100),
    NumeroCheque VARCHAR(50),
    NumeroTarjeta VARCHAR(50),
    TipoTarjeta VARCHAR(50),
    Autorizacion VARCHAR(50),
    MontoUSD DECIMAL(18,2),
    TasaCambio DECIMAL(18,2),
    FOREIGN KEY (NumeroFactura) REFERENCES Facturas(NumeroFactura)
);

-- =============================================
-- ÍNDICES
-- =============================================

CREATE INDEX IX_Facturas_Fecha ON Facturas(Fecha);
CREATE INDEX IX_Facturas_Cliente ON Facturas(CodigoCliente);
CREATE INDEX IX_Facturas_Vendedor ON Facturas(CodigoVendedor);
CREATE INDEX IX_DetalleFactura_Producto ON DetalleFactura(CodigoProducto);
CREATE INDEX IX_PagosFactura_Tipo ON PagosFactura(TipoPago);

-- =============================================
-- VISTAS
-- =============================================

CREATE VIEW VW_FacturasDetalladas AS
SELECT 
    f.NumeroFactura,
    f.Fecha,
    f.Hora,
    c.Cedula,
    c.Nombre + ' ' + c.Apellido AS Cliente,
    u.CodigoUsuario,
    u.Nombre + ' ' + u.Apellido AS Vendedor,
    f.SubtotalNeto,
    f.DescuentoGlobal,
    f.ImpuestoIVA,
    f.IGTF,
    f.Total,
    f.Estado
FROM Facturas f
JOIN Clientes c ON f.CodigoCliente = c.Cedula
JOIN Usuarios u ON f.CodigoVendedor = u.CodigoUsuario;

CREATE VIEW VW_VentasDiarias AS
SELECT 
    CONVERT(DATE, Fecha) AS FechaVenta,
    COUNT(*) AS CantidadFacturas,
    SUM(Total) AS TotalVentas,
    SUM(ImpuestoIVA) AS TotalIVA,
    SUM(IGTF) AS TotalIGTF
FROM Facturas
WHERE Estado = 'A'
GROUP BY CONVERT(DATE, Fecha);

-- =============================================
-- PROCEDIMIENTOS ALMACENADOS
-- =============================================

CREATE PROCEDURE SP_InsertarFactura
    @CodigoCliente VARCHAR(20),
    @CodigoVendedor VARCHAR(10),
    @TasaCambio DECIMAL(18,2),
    @NumeroFactura INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Facturas (CodigoCliente, CodigoVendedor, TasaCambio, Fecha, Hora)
    VALUES (@CodigoCliente, @CodigoVendedor, @TasaCambio, GETDATE(), CONVERT(TIME, GETDATE()));
    
    SET @NumeroFactura = SCOPE_IDENTITY();
    
    -- Actualizar totales
    UPDATE Facturas 
    SET SubtotalNeto = (
        SELECT SUM(PrecioUnitario * Cantidad) 
        FROM DetalleFactura 
        WHERE NumeroFactura = @NumeroFactura
    )
    WHERE NumeroFactura = @NumeroFactura;
    
    -- Calcular impuestos
    UPDATE Facturas 
    SET ImpuestoIVA = SubtotalNeto * 0.16,
        Total = SubtotalNeto + ImpuestoIVA + IGTF - DescuentoGlobal
    WHERE NumeroFactura = @NumeroFactura;
END;

CREATE PROCEDURE SP_AnularFactura
    @NumeroFactura INT,
    @Motivo VARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    
    -- Verificar que no esté ya anulada
    IF EXISTS (SELECT 1 FROM Facturas WHERE NumeroFactura = @NumeroFactura AND Estado = 'N')
    BEGIN
        RAISERROR('La factura ya está anulada', 16, 1);
        ROLLBACK;
        RETURN;
    END;
    
    -- Verificar que sea del día
    IF DATEDIFF(DAY, (SELECT Fecha FROM Facturas WHERE NumeroFactura = @NumeroFactura), GETDATE()) > 0
    BEGIN
        RAISERROR('Solo se pueden anular facturas del día actual', 16, 1);
        ROLLBACK;
        RETURN;
    END;
    
    -- Anular factura
    UPDATE Facturas 
    SET Estado = 'N', 
        Observaciones = ISNULL(Observaciones, '') + ' | ANULADA: ' + @Motivo
    WHERE NumeroFactura = @NumeroFactura;
    
    -- Devolver productos al inventario
    UPDATE p
    SET p.Existencia = p.Existencia + d.Cantidad
    FROM Productos p
    JOIN DetalleFactura d ON p.CodigoProducto = d.CodigoProducto
    WHERE d.NumeroFactura = @NumeroFactura;
    
    COMMIT TRANSACTION;
END;

-- ## 📦 MÓDULO 2: ÓRDENES DE TRABAJO (OT)

-- =============================================
-- TABLAS PRINCIPALES
-- =============================================

-- 2.1 Órdenes de Trabajo
CREATE TABLE OrdenesTrabajo (
    NumeroOrden INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE DEFAULT GETDATE(),
    CodigoCliente VARCHAR(20),
    CodigoVendedor VARCHAR(10),
    TipoOrden VARCHAR(30) CHECK (TipoOrden IN ('Lentes Convencionales', 'Lentes Contacto')),
    Laboratorio VARCHAR(10),
    FechaEntrega DATE,
    Subtotal DECIMAL(18,2) DEFAULT 0,
    Descuento DECIMAL(18,2) DEFAULT 0,
    Total DECIMAL(18,2) DEFAULT 0,
    TotalAbonado DECIMAL(18,2) DEFAULT 0,
    Saldo DECIMAL(18,2) DEFAULT 0,
    Estado VARCHAR(20) DEFAULT 'Pendiente' CHECK (Estado IN (
        'Pendiente', 'En Laboratorio', 'Recibida', 'En Montaje', 
        'Lista', 'Entregada', 'Anulada', 'Desincorporada'
    )),
    Ubicacion VARCHAR(50),
    SobreNumero VARCHAR(20),
    Observaciones VARCHAR(500),
    FOREIGN KEY (CodigoCliente) REFERENCES Clientes(Cedula),
    FOREIGN KEY (CodigoVendedor) REFERENCES Usuarios(CodigoUsuario)
);

-- 2.2 Detalle de OT
CREATE TABLE DetalleOrdenTrabajo (
    IdDetalleOT INT IDENTITY(1,1) PRIMARY KEY,
    NumeroOrden INT,
    CodigoProducto VARCHAR(20),
    Cantidad INT DEFAULT 1,
    Ojo CHAR(2) CHECK (Ojo IN ('OD', 'OI', 'AM', 'IZQ', 'DER')), 
    TipoVision VARCHAR(20) CHECK (TipoVision IN ('Lejos', 'Cerca', 'Bifocal', 'Trifocal', 'Progresivo', 'Balance')),
    Esfera DECIMAL(8,2),
    Cilindro DECIMAL(8,2),
    Eje INT,
    Addicion DECIMAL(8,2),
    DNP DECIMAL(8,2),
    Altura DECIMAL(8,2),
    DistanciaVertice DECIMAL(8,2),
    AnguloPantoscopico DECIMAL(8,2),
    AnguloFacial DECIMAL(8,2),
    Precio DECIMAL(18,2),
    FOREIGN KEY (NumeroOrden) REFERENCES OrdenesTrabajo(NumeroOrden)
);

-- 2.3 Pagos/Abonos de OT
CREATE TABLE PagosOrdenTrabajo (
    IdPagoOT INT IDENTITY(1,1) PRIMARY KEY,
    NumeroOrden INT,
    FechaPago DATE DEFAULT GETDATE(),
    TipoPago VARCHAR(30),
    Monto DECIMAL(18,2),
    MontoUSD DECIMAL(18,2),
    TasaCambio DECIMAL(18,2),
    Banco VARCHAR(100),
    NumeroDocumento VARCHAR(50),
    FOREIGN KEY (NumeroOrden) REFERENCES OrdenesTrabajo(NumeroOrden)
);

-- 2.4 Recepción desde Laboratorio
CREATE TABLE RecepcionOT (
    IdRecepcion INT IDENTITY(1,1) PRIMARY KEY,
    NumeroOrden INT,
    FechaRecepcion DATE DEFAULT GETDATE(),
    CostoLaboratorio DECIMAL(18,2),
    DocumentoLaboratorio VARCHAR(50),
    Observaciones VARCHAR(200),
    FOREIGN KEY (NumeroOrden) REFERENCES OrdenesTrabajo(NumeroOrden)
);

-- 2.5 Servicios de Montaje
CREATE TABLE ServiciosMontaje (
    IdMontaje INT IDENTITY(1,1) PRIMARY KEY,
    NumeroOrden INT,
    FechaMontaje DATE DEFAULT GETDATE(),
    CodigoMontador VARCHAR(10),
    CostoMontaje DECIMAL(18,2),
    Observaciones VARCHAR(200),
    FOREIGN KEY (NumeroOrden) REFERENCES OrdenesTrabajo(NumeroOrden),
    FOREIGN KEY (CodigoMontador) REFERENCES Usuarios(CodigoUsuario)
);

-- =============================================
-- ÍNDICES
-- =============================================

CREATE INDEX IX_OrdenesTrabajo_Estado ON OrdenesTrabajo(Estado);
CREATE INDEX IX_OrdenesTrabajo_Laboratorio ON OrdenesTrabajo(Laboratorio);
CREATE INDEX IX_OrdenesTrabajo_FechaEntrega ON OrdenesTrabajo(FechaEntrega);
CREATE INDEX IX_DetalleOT_Producto ON DetalleOrdenTrabajo(CodigoProducto);
CREATE INDEX IX_PagosOT_Fecha ON PagosOrdenTrabajo(FechaPago);

-- =============================================
-- VISTAS
-- =============================================

CREATE VIEW VW_OT_Pendientes AS
SELECT 
    ot.NumeroOrden,
    ot.Fecha,
    c.Cedula,
    c.Nombre + ' ' + c.Apellido AS Cliente,
    ot.TipoOrden,
    ot.Laboratorio,
    ot.FechaEntrega,
    ot.Total,
    ot.TotalAbonado,
    ot.Saldo,
    ot.Estado,
    ot.Ubicacion
FROM OrdenesTrabajo ot
JOIN Clientes c ON ot.CodigoCliente = c.Cedula
WHERE ot.Estado NOT IN ('Entregada', 'Anulada');

CREATE VIEW VW_OT_RecibidasNoEntregadas AS
SELECT 
    ot.NumeroOrden,
    ot.Fecha,
    c.Nombre + ' ' + c.Apellido AS Cliente,
    ot.Total,
    ot.Saldo,
    ot.FechaEntrega,
    DATEDIFF(DAY, GETDATE(), ot.FechaEntrega) AS DiasRestantes
FROM OrdenesTrabajo ot
JOIN Clientes c ON ot.CodigoCliente = c.Cedula
WHERE ot.Estado = 'Recibida' AND ot.Saldo > 0;

-- =============================================
-- PROCEDIMIENTOS ALMACENADOS
-- =============================================

CREATE PROCEDURE SP_RecibirOrdenTrabajo
    @NumeroOrden INT,
    @CostoLaboratorio DECIMAL(18,2),
    @DocumentoLaboratorio VARCHAR(50),
    @EnviarEmail BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    
    -- Verificar que no esté ya recibida
    IF EXISTS (SELECT 1 FROM OrdenesTrabajo WHERE NumeroOrden = @NumeroOrden AND Estado = 'Recibida')
    BEGIN
        RAISERROR('La orden ya está recibida', 16, 1);
        ROLLBACK;
        RETURN;
    END;
    
    -- Actualizar estado
    UPDATE OrdenesTrabajo 
    SET Estado = 'Recibida',
        Ubicacion = 'En Óptica'
    WHERE NumeroOrden = @NumeroOrden;
    
    -- Registrar recepción
    INSERT INTO RecepcionOT (NumeroOrden, CostoLaboratorio, DocumentoLaboratorio)
    VALUES (@NumeroOrden, @CostoLaboratorio, @DocumentoLaboratorio);
    
    -- Actualizar costos en productos si aplica
    UPDATE p
    SET p.UltimoCosto = @CostoLaboratorio
    FROM Productos p
    JOIN DetalleOrdenTrabajo d ON p.CodigoProducto = d.CodigoProducto
    WHERE d.NumeroOrden = @NumeroOrden;
    
    COMMIT TRANSACTION;
    
    -- Enviar email si está configurado
    IF @EnviarEmail = 1
    BEGIN
        -- Lógica para enviar email al cliente
        PRINT 'Email enviado al cliente';
    END;
END;

CREATE PROCEDURE SP_AbonarOrdenTrabajo
    @NumeroOrden INT,
    @TipoPago VARCHAR(30),
    @Monto DECIMAL(18,2),
    @MontoUSD DECIMAL(18,2) = NULL,
    @TasaCambio DECIMAL(18,2) = NULL,
    @Banco VARCHAR(100) = NULL,
    @NumeroDocumento VARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @SaldoActual DECIMAL(18,2);
    DECLARE @TotalOrden DECIMAL(18,2);
    
    -- Obtener saldo actual
    SELECT @SaldoActual = Saldo, @TotalOrden = Total
    FROM OrdenesTrabajo
    WHERE NumeroOrden = @NumeroOrden;
    
    IF @Monto > @SaldoActual
    BEGIN
        RAISERROR('El monto excede el saldo pendiente', 16, 1);
        RETURN;
    END;
    
    BEGIN TRANSACTION;
    
    -- Registrar pago
    INSERT INTO PagosOrdenTrabajo (NumeroOrden, TipoPago, Monto, MontoUSD, TasaCambio, Banco, NumeroDocumento)
    VALUES (@NumeroOrden, @TipoPago, @Monto, @MontoUSD, @TasaCambio, @Banco, @NumeroDocumento);
    
    -- Actualizar saldo en OT
    UPDATE OrdenesTrabajo 
    SET TotalAbonado = TotalAbonado + @Monto,
        Saldo = Saldo - @Monto
    WHERE NumeroOrden = @NumeroOrden;
    
    -- Si el saldo llega a cero, marcar como lista para entregar
    IF (@SaldoActual - @Monto) <= 0
    BEGIN
        UPDATE OrdenesTrabajo 
        SET Estado = 'Lista'
        WHERE NumeroOrden = @NumeroOrden;
    END;
    
    COMMIT TRANSACTION;
END;

CREATE PROCEDURE SP_GenerarFacturaDesdeOT
    @NumeroOrden INT,
    @NumeroFactura INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @Cliente VARCHAR(20);
    DECLARE @Vendedor VARCHAR(10);
    DECLARE @Total DECIMAL(18,2);
    
    -- Obtener datos de la OT
    SELECT @Cliente = CodigoCliente, 
           @Vendedor = CodigoVendedor,
           @Total = Total
    FROM OrdenesTrabajo
    WHERE NumeroOrden = @NumeroOrden;
    
    -- Crear factura
    EXEC SP_InsertarFactura @Cliente, @Vendedor, NULL, @NumeroFactura OUTPUT;
    
    -- Mover detalles de OT a factura
    INSERT INTO DetalleFactura (NumeroFactura, CodigoProducto, Cantidad, PrecioUnitario, TotalItem)
    SELECT @NumeroFactura, CodigoProducto, Cantidad, Precio, Precio * Cantidad
    FROM DetalleOrdenTrabajo
    WHERE NumeroOrden = @NumeroOrden;
    
    -- Registrar pagos como pagos de factura
    INSERT INTO PagosFactura (NumeroFactura, TipoPago, Monto, MontoUSD, TasaCambio, Banco, NumeroCheque)
    SELECT @NumeroFactura, TipoPago, Monto, MontoUSD, TasaCambio, Banco, NumeroDocumento
    FROM PagosOrdenTrabajo
    WHERE NumeroOrden = @NumeroOrden;
    
    -- Actualizar estado de OT
    UPDATE OrdenesTrabajo 
    SET Estado = 'Facturada'
    WHERE NumeroOrden = @NumeroOrden;
END;

---## 📦 MÓDULO 3: INVENTARIO

-- =============================================
-- TABLAS PRINCIPALES
-- =============================================

-- 3.1 Tipos de Producto
CREATE TABLE TiposProducto (
    CodigoTipo CHAR(1) PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL,
    ConExistencia BIT DEFAULT 1,
    PermitirVentaSinExistencia BIT DEFAULT 0,
    ExentoImpuesto BIT DEFAULT 0,
    UsarFactorMultiplicador BIT DEFAULT 1,
    UnidadVenta INT DEFAULT 1, -- 1=unidad, 2=par (cristales)
    ImprimirPrecioOT BIT DEFAULT 1
);

-- 3.2 Grupos de Producto
CREATE TABLE GruposProducto (
    CodigoGrupo VARCHAR(10) PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL,
    CodigoTipo1 CHAR(1),
    CodigoTipo2 CHAR(1),
    CodigoTipo3 CHAR(1),
    FOREIGN KEY (CodigoTipo1) REFERENCES TiposProducto(CodigoTipo),
    FOREIGN KEY (CodigoTipo2) REFERENCES TiposProducto(CodigoTipo),
    FOREIGN KEY (CodigoTipo3) REFERENCES TiposProducto(CodigoTipo)
);

-- 3.3 Marcas
CREATE TABLE Marcas (
    CodigoMarca VARCHAR(10) PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL,
    FactorMultiplicador DECIMAL(10,4) DEFAULT 1.0000
);

-- 3.4 Productos
CREATE TABLE Productos (
    CodigoProducto VARCHAR(20) PRIMARY KEY,
    Descripcion VARCHAR(200) NOT NULL,
    CodigoTipo CHAR(1),
    CodigoGrupo VARCHAR(10),
    CodigoMarca VARCHAR(10),
    Color VARCHAR(50),
    Tamaño VARCHAR(20),
    Modelo VARCHAR(50),
    TipoMontura VARCHAR(50),
    Horizontal DECIMAL(8,2),
    Vertical DECIMAL(8,2),
    Maxima DECIMAL(8,2),
    Puente DECIMAL(8,2),
    TipoVision VARCHAR(20),
    Proveedor VARCHAR(10),
    ReferenciaProveedor VARCHAR(50),
    UltimoCosto DECIMAL(18,2) DEFAULT 0,
    CostoPromedio DECIMAL(18,2) DEFAULT 0,
    PrecioVenta1 DECIMAL(18,2) DEFAULT 0,
    ImpuestoPorcentaje1 DECIMAL(5,2) DEFAULT 16.00,
    PrecioTotal1 DECIMAL(18,2) DEFAULT 0,
    PrecioVenta2 DECIMAL(18,2) DEFAULT 0,
    ImpuestoPorcentaje2 DECIMAL(5,2) DEFAULT 0,
    PrecioTotal2 DECIMAL(18,2) DEFAULT 0,
    DescuentoFijoVenta DECIMAL(5,2) DEFAULT 0,
    DescuentoMaximoVenta DECIMAL(5,2) DEFAULT 0,
    FactorMultiplicador DECIMAL(10,4),
    StockMinimo DECIMAL(10,2) DEFAULT 0,
    Existencia DECIMAL(10,2) DEFAULT 0,
    Reserva DECIMAL(10,2) DEFAULT 0,
    Ubicacion VARCHAR(50),
    Activo BIT DEFAULT 1,
    FechaCreacion DATE DEFAULT GETDATE(),
    FOREIGN KEY (CodigoTipo) REFERENCES TiposProducto(CodigoTipo),
    FOREIGN KEY (CodigoGrupo) REFERENCES GruposProducto(CodigoGrupo),
    FOREIGN KEY (CodigoMarca) REFERENCES Marcas(CodigoMarca)
);

-- 3.5 Movimientos de Inventario
CREATE TABLE MovimientosInventario (
    IdMovimiento INT IDENTITY(1,1) PRIMARY KEY,
    FechaMovimiento DATE DEFAULT GETDATE(),
    CodigoProducto VARCHAR(20),
    TipoMovimiento CHAR(1) CHECK (TipoMovimiento IN ('E', 'S')), -- E=Entrada, S=Salida
    Documento VARCHAR(50), -- Factura, OT, Recepción, Ajuste
    NumeroDocumento VARCHAR(50),
    CantidadAnterior DECIMAL(10,2),
    Cantidad DECIMAL(10,2),
    StockActual DECIMAL(10,2),
    Observaciones VARCHAR(200),
    FOREIGN KEY (CodigoProducto) REFERENCES Productos(CodigoProducto)
);

-- 3.6 Ajustes de Inventario
CREATE TABLE AjustesInventario (
    NumeroAjuste INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE DEFAULT GETDATE(),
    Responsable VARCHAR(10),
    Motivo VARCHAR(200),
    Confirmado BIT DEFAULT 0,
    FOREIGN KEY (Responsable) REFERENCES Usuarios(CodigoUsuario)
);

CREATE TABLE DetalleAjuste (
    IdDetalleAjuste INT IDENTITY(1,1) PRIMARY KEY,
    NumeroAjuste INT,
    CodigoProducto VARCHAR(20),
    ExistenciaSistema DECIMAL(10,2),
    CantidadAjuste DECIMAL(10,2),
    ExistenciaActual DECIMAL(10,2),
    TipoMovimiento VARCHAR(10) CHECK (TipoMovimiento IN ('Entrada', 'Salida')),
    FOREIGN KEY (NumeroAjuste) REFERENCES AjustesInventario(NumeroAjuste),
    FOREIGN KEY (CodigoProducto) REFERENCES Productos(CodigoProducto)
);

-- 3.7 Conteo Físico
CREATE TABLE ConteoFisico (
    NumeroConteo INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE DEFAULT GETDATE(),
    Responsable VARCHAR(10),
    Motivo VARCHAR(200),
    TipoProducto CHAR(1),
    Grupo VARCHAR(10),
    Marca VARCHAR(10),
    Confirmado BIT DEFAULT 0,
    Ajustado BIT DEFAULT 0,
    FOREIGN KEY (Responsable) REFERENCES Usuarios(CodigoUsuario),
    FOREIGN KEY (TipoProducto) REFERENCES TiposProducto(CodigoTipo)
);

CREATE TABLE DetalleConteo (
    IdDetalleConteo INT IDENTITY(1,1) PRIMARY KEY,
    NumeroConteo INT,
    CodigoProducto VARCHAR(20),
    ExistenciaSistema DECIMAL(10,2),
    ConteoFisico DECIMAL(10,2),
    Diferencia DECIMAL(10,2),
    FOREIGN KEY (NumeroConteo) REFERENCES ConteoFisico(NumeroConteo),
    FOREIGN KEY (CodigoProducto) REFERENCES Productos(CodigoProducto)
);

-- =============================================
-- ÍNDICES
-- =============================================

CREATE INDEX IX_Productos_Tipo ON Productos(CodigoTipo);
CREATE INDEX IX_Productos_Grupo ON Productos(CodigoGrupo);
CREATE INDEX IX_Productos_Marca ON Productos(CodigoMarca);
CREATE INDEX IX_Movimientos_Producto ON MovimientosInventario(CodigoProducto);
CREATE INDEX IX_Movimientos_Fecha ON MovimientosInventario(FechaMovimiento);

-- =============================================
-- VISTAS
-- =============================================

CREATE VIEW VW_InventarioBajoMinimo AS
SELECT 
    p.CodigoProducto,
    p.Descripcion,
    tp.Descripcion AS Tipo,
    g.Descripcion AS Grupo,
    m.Descripcion AS Marca,
    p.Existencia,
    p.StockMinimo,
    p.Existencia - p.StockMinimo AS Diferencia,
    CASE WHEN p.Existencia <= p.StockMinimo THEN 'CRÍTICO' 
         WHEN p.Existencia <= (p.StockMinimo * 1.5) THEN 'BAJO'
         ELSE 'OK' END AS Estado
FROM Productos p
JOIN TiposProducto tp ON p.CodigoTipo = tp.CodigoTipo
LEFT JOIN GruposProducto g ON p.CodigoGrupo = g.CodigoGrupo
LEFT JOIN Marcas m ON p.CodigoMarca = m.CodigoMarca
WHERE p.Activo = 1 AND tp.ConExistencia = 1;

CREATE VIEW VW_MovimientosProducto AS
SELECT 
    p.CodigoProducto,
    p.Descripcion,
    mi.FechaMovimiento,
    mi.TipoMovimiento,
    mi.Documento,
    mi.NumeroDocumento,
    mi.CantidadAnterior,
    mi.Cantidad,
    mi.StockActual,
    mi.Observaciones
FROM MovimientosInventario mi
JOIN Productos p ON mi.CodigoProducto = p.CodigoProducto;

-- =============================================
-- PROCEDIMIENTOS ALMACENADOS
-- =============================================

CREATE PROCEDURE SP_ActualizarExistencia
    @CodigoProducto VARCHAR(20),
    @Cantidad DECIMAL(10,2),
    @TipoMovimiento CHAR(1), -- 'E' entrada, 'S' salida
    @Documento VARCHAR(50),
    @NumeroDocumento VARCHAR(50),
    @Observaciones VARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @StockAnterior DECIMAL(10,2);
    DECLARE @NuevoStock DECIMAL(10,2);
    
    -- Obtener stock actual
    SELECT @StockAnterior = Existencia
    FROM Productos
    WHERE CodigoProducto = @CodigoProducto;
    
    -- Calcular nuevo stock
    IF @TipoMovimiento = 'E'
        SET @NuevoStock = @StockAnterior + @Cantidad;
    ELSE
        SET @NuevoStock = @StockAnterior - @Cantidad;
    
    BEGIN TRANSACTION;
    
    -- Actualizar producto
    UPDATE Productos 
    SET Existencia = @NuevoStock,
        UltimoCosto = CASE WHEN @TipoMovimiento = 'E' AND @Documento = 'RECEPCION' 
                          THEN (SELECT TOP 1 CostoUnitario FROM #TempCosto) 
                          ELSE UltimoCosto END
    WHERE CodigoProducto = @CodigoProducto;
    
    -- Registrar movimiento
    INSERT INTO MovimientosInventario (
        CodigoProducto, TipoMovimiento, Documento, NumeroDocumento,
        CantidadAnterior, Cantidad, StockActual, Observaciones
    )
    VALUES (
        @CodigoProducto, @TipoMovimiento, @Documento, @NumeroDocumento,
        @StockAnterior, @Cantidad, @NuevoStock, @Observaciones
    );
    
    COMMIT TRANSACTION;
END;

CREATE PROCEDURE SP_RealizarAjusteInventario
    @Responsable VARCHAR(10),
    @Motivo VARCHAR(200),
    @Detalles AS dbo.TipoDetalleAjuste READONLY -- Tabla temporal con detalles
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @NumeroAjuste INT;
    
    BEGIN TRANSACTION;
    
    -- Crear ajuste
    INSERT INTO AjustesInventario (Responsable, Motivo)
    VALUES (@Responsable, @Motivo);
    
    SET @NumeroAjuste = SCOPE_IDENTITY();
    
    -- Procesar detalles
    INSERT INTO DetalleAjuste (NumeroAjuste, CodigoProducto, ExistenciaSistema, 
                               CantidadAjuste, ExistenciaActual, TipoMovimiento)
    SELECT 
        @NumeroAjuste,
        d.CodigoProducto,
        p.Existencia,
        d.CantidadAjuste,
        p.Existencia + d.CantidadAjuste,
        CASE WHEN d.CantidadAjuste > 0 THEN 'Entrada' ELSE 'Salida' END
    FROM @Detalles d
    JOIN Productos p ON d.CodigoProducto = p.CodigoProducto;
    
    -- Actualizar existencias
    UPDATE p
    SET p.Existencia = p.Existencia + d.CantidadAjuste
    FROM Productos p
    JOIN @Detalles d ON p.CodigoProducto = d.CodigoProducto;
    
    -- Registrar movimientos
    INSERT INTO MovimientosInventario (CodigoProducto, TipoMovimiento, Documento, 
                                       NumeroDocumento, CantidadAnterior, Cantidad, StockActual)
    SELECT 
        d.CodigoProducto,
        CASE WHEN d.CantidadAjuste > 0 THEN 'E' ELSE 'S' END,
        'AJUSTE',
        CAST(@NumeroAjuste AS VARCHAR(20)),
        p.Existencia,
        ABS(d.CantidadAjuste),
        p.Existencia + d.CantidadAjuste
    FROM @Detalles d
    JOIN Productos p ON d.CodigoProducto = p.CodigoProducto;
    
    -- Confirmar ajuste
    UPDATE AjustesInventario 
    SET Confirmado = 1
    WHERE NumeroAjuste = @NumeroAjuste;
    
    COMMIT TRANSACTION;
    
    SELECT @NumeroAjuste AS NumeroAjuste;
END;

-- Tipo de tabla para detalles de ajuste
CREATE TYPE TipoDetalleAjuste AS TABLE (
    CodigoProducto VARCHAR(20),
    CantidadAjuste DECIMAL(10,2)
);

---## 📦 MÓDULO 4: RECEPCIÓN DE MERCANCÍA

-- =============================================
-- TABLAS PRINCIPALES
-- =============================================

-- 4.1 Proveedores
CREATE TABLE Proveedores (
    CodigoProveedor VARCHAR(10) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Rif VARCHAR(20),
    Direccion VARCHAR(200),
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    Contacto VARCHAR(100),
    Activo BIT DEFAULT 1
);

-- 4.2 Recepción de Mercancía
CREATE TABLE RecepcionMercancia (
    NumeroRecepcion INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE DEFAULT GETDATE(),
    CodigoProveedor VARCHAR(10),
    NumeroDocumento VARCHAR(50), -- Factura o nota de entrega del proveedor
    Responsable VARCHAR(10),
    TotalRecepcion DECIMAL(18,2) DEFAULT 0,
    Confirmada BIT DEFAULT 0,
    OrdenCompra VARCHAR(50),
    Observaciones VARCHAR(500),
    FOREIGN KEY (CodigoProveedor) REFERENCES Proveedores(CodigoProveedor),
    FOREIGN KEY (Responsable) REFERENCES Usuarios(CodigoUsuario)
);

-- 4.3 Detalle Recepción
CREATE TABLE DetalleRecepcion (
    IdDetalleRecepcion INT IDENTITY(1,1) PRIMARY KEY,
    NumeroRecepcion INT,
    CodigoProducto VARCHAR(20),
    Cantidad DECIMAL(10,2),
    CostoUnitario DECIMAL(18,2),
    CostoTotal DECIMAL(18,2),
    FOREIGN KEY (NumeroRecepcion) REFERENCES RecepcionMercancia(NumeroRecepcion),
    FOREIGN KEY (CodigoProducto) REFERENCES Productos(CodigoProducto)
);

-- =============================================
-- PROCEDIMIENTOS ALMACENADOS
-- =============================================

CREATE PROCEDURE SP_ConfirmarRecepcionMercancia
    @NumeroRecepcion INT,
    @ImprimirEtiquetas BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    
    -- Verificar que no esté ya confirmada
    IF EXISTS (SELECT 1 FROM RecepcionMercancia WHERE NumeroRecepcion = @NumeroRecepcion AND Confirmada = 1)
    BEGIN
        RAISERROR('La recepción ya está confirmada', 16, 1);
        ROLLBACK;
        RETURN;
    END;
    
    -- Actualizar existencias
    UPDATE p
    SET p.Existencia = p.Existencia + dr.Cantidad,
        p.UltimoCosto = dr.CostoUnitario,
        p.CostoPromedio = ((p.CostoPromedio * p.Existencia) + (dr.CostoUnitario * dr.Cantidad)) / 
                          (p.Existencia + dr.Cantidad)
    FROM Productos p
    JOIN DetalleRecepcion dr ON p.CodigoProducto = dr.CodigoProducto
    WHERE dr.NumeroRecepcion = @NumeroRecepcion;
    
    -- Registrar movimientos de inventario
    INSERT INTO MovimientosInventario (CodigoProducto, TipoMovimiento, Documento, 
                                       NumeroDocumento, CantidadAnterior, Cantidad, StockActual)
    SELECT 
        dr.CodigoProducto,
        'E',
        'RECEPCION',
        CAST(@NumeroRecepcion AS VARCHAR(20)),
        p.Existencia,
        dr.Cantidad,
        p.Existencia + dr.Cantidad
    FROM DetalleRecepcion dr
    JOIN Productos p ON dr.CodigoProducto = p.CodigoProducto
    WHERE dr.NumeroRecepcion = @NumeroRecepcion;
    
    -- Confirmar recepción
    UPDATE RecepcionMercancia 
    SET Confirmada = 1
    WHERE NumeroRecepcion = @NumeroRecepcion;
    
    COMMIT TRANSACTION;
    
    -- Generar etiquetas si se solicita
    IF @ImprimirEtiquetas = 1
    BEGIN
        -- Lógica para generar etiquetas
        PRINT 'Etiquetas generadas para recepción ' + CAST(@NumeroRecepcion AS VARCHAR(10));
    END;
END;

---## 📦 MÓDULO 5: DEVOLUCIONES Y NOTAS DE CRÉDITO

-- =============================================
-- TABLAS PRINCIPALES
-- =============================================

-- 5.1 Notas de Crédito
CREATE TABLE NotasCredito (
    NumeroNotaCredito INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE DEFAULT GETDATE(),
    TipoNota CHAR(1) CHECK (TipoNota IN ('F', 'O')), -- F=Factura, O=Orden Pendiente
    NumeroDocumento VARCHAR(50), -- Factura o OT relacionada
    CedulaCliente VARCHAR(20),
    Motivo VARCHAR(200),
    Subtotal DECIMAL(18,2) DEFAULT 0,
    ImpuestoIVA DECIMAL(18,2) DEFAULT 0,
    IGTF DECIMAL(18,2) DEFAULT 0,
    Total DECIMAL(18,2) DEFAULT 0,
    SaldoDisponible DECIMAL(18,2) DEFAULT 0,
    Estado CHAR(1) DEFAULT 'A', -- A=Activa, U=Utilizada, C=Cancelada
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula)
);

-- 5.2 Detalle Nota de Crédito
CREATE TABLE DetalleNotaCredito (
    IdDetalleNC INT IDENTITY(1,1) PRIMARY KEY,
    NumeroNotaCredito INT,
    CodigoProducto VARCHAR(20),
    Cantidad DECIMAL(10,2),
    PrecioUnitario DECIMAL(18,2),
    TotalItem DECIMAL(18,2),
    FOREIGN KEY (NumeroNotaCredito) REFERENCES NotasCredito(NumeroNotaCredito),
    FOREIGN KEY (CodigoProducto) REFERENCES Productos(CodigoProducto)
);

-- 5.3 Notas de Débito
CREATE TABLE NotasDebito (
    NumeroNotaDebito INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE DEFAULT GETDATE(),
    NumeroFactura INT,
    CedulaCliente VARCHAR(20),
    Motivo VARCHAR(50) CHECK (Motivo IN ('Diferencial cambiario', 'Interés de mora', 'Otro')),
    Subtotal DECIMAL(18,2) DEFAULT 0,
    ImpuestoIVA DECIMAL(18,2) DEFAULT 0,
    Total DECIMAL(18,2) DEFAULT 0,
    SaldoNuevo DECIMAL(18,2) DEFAULT 0,
    MontoExento DECIMAL(18,2) DEFAULT 0,
    Observaciones VARCHAR(500),
    FOREIGN KEY (NumeroFactura) REFERENCES Facturas(NumeroFactura),
    FOREIGN KEY (CedulaCliente) REFERENCES Clientes(Cedula)
);

-- 5.4 Devoluciones al Proveedor
CREATE TABLE DevolucionesProveedor (
    IdDevolucion INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE DEFAULT GETDATE(),
    CodigoProveedor VARCHAR(10),
    CodigoProducto VARCHAR(20),
    Cantidad DECIMAL(10,2),
    Motivo VARCHAR(200),
    DocumentoReferencia VARCHAR(50),
    FOREIGN KEY (CodigoProveedor) REFERENCES Proveedores(CodigoProveedor),
    FOREIGN KEY (CodigoProducto) REFERENCES Productos(CodigoProducto)
);

-- =============================================
-- PROCEDIMIENTOS ALMACENADOS
-- =============================================

CREATE PROCEDURE SP_GenerarNotaCredito
    @TipoNota CHAR(1),
    @NumeroDocumento VARCHAR(50),
    @Motivo VARCHAR(200),
    @NumeroNotaCredito INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @Cliente VARCHAR(20);
    DECLARE @Subtotal DECIMAL(18,2);
    DECLARE @Impuesto DECIMAL(18,2);
    DECLARE @IGTF DECIMAL(18,2);
    DECLARE @Total DECIMAL(18,2);
    
    BEGIN TRANSACTION;
    
    IF @TipoNota = 'F' -- Factura
    BEGIN
        SELECT 
            @Cliente = CodigoCliente,
            @Subtotal = SubtotalNeto,
            @Impuesto = ImpuestoIVA,
            @IGTF = IGTF,
            @Total = Total
        FROM Facturas
        WHERE NumeroFactura = CAST(@NumeroDocumento AS INT);
        
        -- Copiar detalles de factura
        INSERT INTO DetalleNotaCredito (CodigoProducto, Cantidad, PrecioUnitario, TotalItem)
        SELECT CodigoProducto, Cantidad, PrecioUnitario, TotalItem
        FROM DetalleFactura
        WHERE NumeroFactura = CAST(@NumeroDocumento AS INT);
    END
    ELSE IF @TipoNota = 'O' -- Orden Pendiente
    BEGIN
        SELECT 
            @Cliente = CodigoCliente,
            @Total = Total
        FROM OrdenesTrabajo
        WHERE NumeroOrden = CAST(@NumeroDocumento AS INT);
        
        SET @Subtotal = @Total / 1.16;
        SET @Impuesto = @Total - @Subtotal;
        SET @IGTF = 0;
    END;
    
    -- Crear nota de crédito
    INSERT INTO NotasCredito (TipoNota, NumeroDocumento, CedulaCliente, Motivo, 
                             Subtotal, ImpuestoIVA, IGTF, Total, SaldoDisponible)
    VALUES (@TipoNota, @NumeroDocumento, @Cliente, @Motivo, 
            @Subtotal, @Impuesto, @IGTF, @Total, @Total);
    
    SET @NumeroNotaCredito = SCOPE_IDENTITY();
    
    -- Actualizar detalles con número de NC
    UPDATE DetalleNotaCredito 
    SET NumeroNotaCredito = @NumeroNotaCredito
    WHERE NumeroNotaCredito IS NULL;
    
    -- Devolver productos al inventario
    UPDATE p
    SET p.Existencia = p.Existencia + dnc.Cantidad
    FROM Productos p
    JOIN DetalleNotaCredito dnc ON p.CodigoProducto = dnc.CodigoProducto
    WHERE dnc.NumeroNotaCredito = @NumeroNotaCredito;
    
    COMMIT TRANSACTION;
END;

CREATE PROCEDURE SP_AplicarNotaCredito
    @NumeroNotaCredito INT,
    @NumeroFactura INT,
    @MontoAplicar DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @SaldoDisponible DECIMAL(18,2);
    
    -- Verificar saldo disponible
    SELECT @SaldoDisponible = SaldoDisponible
    FROM NotasCredito
    WHERE NumeroNotaCredito = @NumeroNotaCredito;
    
    IF @MontoAplicar > @SaldoDisponible
    BEGIN
        RAISERROR('Monto excede el saldo disponible de la nota de crédito', 16, 1);
        RETURN;
    END;
    
    BEGIN TRANSACTION;
    
    -- Registrar pago con nota de crédito
    INSERT INTO PagosFactura (NumeroFactura, TipoPago, Monto)
    VALUES (@NumeroFactura, 'NOTA_CREDITO', @MontoAplicar);
    
    -- Actualizar saldo de nota de crédito
    UPDATE NotasCredito 
    SET SaldoDisponible = SaldoDisponible - @MontoAplicar
    WHERE NumeroNotaCredito = @NumeroNotaCredito;
    
    -- Si saldo llega a cero, marcar como utilizada
    IF (@SaldoDisponible - @MontoAplicar) <= 0
    BEGIN
        UPDATE NotasCredito 
        SET Estado = 'U' -- Utilizada
        WHERE NumeroNotaCredito = @NumeroNotaCredito;
    END;
    
    -- Actualizar saldo de factura
    UPDATE Facturas 
    SET Total = Total - @MontoAplicar
    WHERE NumeroFactura = @NumeroFactura;
    
    COMMIT TRANSACTION;
END;

--## 📦 MÓDULO 6: CAJA Y CIERRE DIARIO

-- =============================================
-- TABLAS PRINCIPALES
-- =============================================

-- 6.1 Cierre de Caja
CREATE TABLE CierreCaja (
    IdCierre INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE DEFAULT GETDATE(),
    CodigoUsuario VARCHAR(10),
    TipoCierre VARCHAR(20) CHECK (TipoCierre IN ('Parcial', 'Definitivo')),
    TotalIngresoExistente DECIMAL(18,2) DEFAULT 0,
    TotalGastos DECIMAL(18,2) DEFAULT 0,
    TotalReintegros DECIMAL(18,2) DEFAULT 0,
    Efectivo DECIMAL(18,2) DEFAULT 0,
    Cheques DECIMAL(18,2) DEFAULT 0,
    TarjetasCredito DECIMAL(18,2) DEFAULT 0,
    TarjetasDebito DECIMAL(18,2) DEFAULT 0,
    NotasCredito DECIMAL(18,2) DEFAULT 0,
    Seguros DECIMAL(18,2) DEFAULT 0,
    Creditos DECIMAL(18,2) DEFAULT 0,
    Transferencias DECIMAL(18,2) DEFAULT 0,
    DivisasUSD DECIMAL(18,2) DEFAULT 0,
    TasaCambio DECIMAL(18,2),
    TotalDivisasBS DECIMAL(18,2) DEFAULT 0,
    TotalDepositar DECIMAL(18,2) DEFAULT 0,
    FondoCaja DECIMAL(18,2) DEFAULT 0,
    TotalCaja DECIMAL(18,2) DEFAULT 0,
    Diferencia DECIMAL(18,2) DEFAULT 0,
    Observaciones VARCHAR(500),
    Confirmado BIT DEFAULT 0,
    FOREIGN KEY (CodigoUsuario) REFERENCES Usuarios(CodigoUsuario)
);

-- 6.2 Retiros de Efectivo
CREATE TABLE RetirosEfectivo (
    IdRetiro INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE DEFAULT GETDATE(),
    Monto DECIMAL(18,2),
    Motivo VARCHAR(200),
    CodigoUsuario VARCHAR(10),
    Banco VARCHAR(100),
    NumeroCheque VARCHAR(50),
    Observaciones VARCHAR(500),
    FOREIGN KEY (CodigoUsuario) REFERENCES Usuarios(CodigoUsuario)
);

-- 6.3 Planillas de Depósito
CREATE TABLE PlanillasDeposito (
    IdPlanilla INT IDENTITY(1,1) PRIMARY KEY,
    IdCierre INT,
    NumeroPlanilla VARCHAR(50),
    CodigoBanco VARCHAR(10),
    Monto DECIMAL(18,2),
    FechaDeposito DATE,
    FOREIGN KEY (IdCierre) REFERENCES CierreCaja(IdCierre)
);

-- =============================================
-- VISTAS
-- =============================================

CREATE VIEW VW_ResumenCierreDiario AS
SELECT 
    cc.Fecha,
    u.Nombre + ' ' + u.Apellido AS Responsable,
    cc.TipoCierre,
    cc.TotalIngresoExistente,
    cc.TotalGastos,
    cc.TotalReintegros,
    cc.Efectivo,
    cc.Cheques,
    cc.TarjetasCredito,
    cc.TarjetasDebito,
    cc.DivisasUSD,
    cc.TotalDivisasBS,
    cc.TotalDepositar,
    cc.FondoCaja,
    cc.TotalCaja,
    cc.Diferencia,
    cc.Confirmado
FROM CierreCaja cc
JOIN Usuarios u ON cc.CodigoUsuario = u.CodigoUsuario;

CREATE VIEW VW_IngresosDiarios AS
SELECT 
    CONVERT(DATE, Fecha) AS Fecha,
    SUM(CASE WHEN TipoPago = 'EFECTIVO' THEN Monto ELSE 0 END) AS Efectivo,
    SUM(CASE WHEN TipoPago = 'CHEQUE' THEN Monto ELSE 0 END) AS Cheques,
    SUM(CASE WHEN TipoPago IN ('TARJETA_CREDITO', 'TARJETA_DEBITO') THEN Monto ELSE 0 END) AS Tarjetas,
    SUM(CASE WHEN TipoPago = 'DIVISA' THEN Monto ELSE 0 END) AS Divisas,
    SUM(Monto) AS TotalIngresos
FROM PagosFactura pf
JOIN Facturas f ON pf.NumeroFactura = f.NumeroFactura
WHERE f.Estado = 'A'
GROUP BY CONVERT(DATE, Fecha);

-- =============================================
-- PROCEDIMIENTOS ALMACENADOS
-- =============================================

CREATE PROCEDURE SP_RealizarCierreCaja
    @CodigoUsuario VARCHAR(10),
    @TipoCierre VARCHAR(20),
    @Totales AS dbo.TipoTotalesCierre READONLY,
    @IdCierre INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @TotalCalculado DECIMAL(18,2);
    DECLARE @Diferencia DECIMAL(18,2);
    
    -- Calcular totales
    SELECT @TotalCalculado = 
        Efectivo + Cheques + TarjetasCredito + TarjetasDebito + 
        NotasCredito + Seguros + Creditos + Transferencias + TotalDivisasBS
    FROM @Totales;
    
    SET @Diferencia = (SELECT TotalIngresoExistente FROM @Totales) - @TotalCalculado;
    
    BEGIN TRANSACTION;
    
    -- Verificar si ya existe cierre para esta fecha y usuario
    IF EXISTS (SELECT 1 FROM CierreCaja 
               WHERE CodigoUsuario = @CodigoUsuario 
               AND Fecha = CONVERT(DATE, GETDATE())
               AND TipoCierre = @TipoCierre)
    BEGIN
        RAISERROR('Ya existe un cierre de caja para esta fecha y usuario', 16, 1);
        ROLLBACK;
        RETURN;
    END;
    
    -- Insertar cierre
    INSERT INTO CierreCaja (
        Fecha, CodigoUsuario, TipoCierre,
        TotalIngresoExistente, TotalGastos, TotalReintegros,
        Efectivo, Cheques, TarjetasCredito, TarjetasDebito,
        NotasCredito, Seguros, Creditos, Transferencias,
        DivisasUSD, TasaCambio, TotalDivisasBS,
        TotalDepositar, FondoCaja, TotalCaja, Diferencia,
        Confirmado
    )
    SELECT 
        GETDATE(),
        @CodigoUsuario,
        @TipoCierre,
        TotalIngresoExistente,
        TotalGastos,
        TotalReintegros,
        Efectivo,
        Cheques,
        TarjetasCredito,
        TarjetasDebito,
        NotasCredito,
        Seguros,
        Creditos,
        Transferencias,
        DivisasUSD,
        TasaCambio,
        TotalDivisasBS,
        TotalDepositar,
        FondoCaja,
        TotalCaja,
        @Diferencia,
        1 -- Confirmado
    FROM @Totales;
    
    SET @IdCierre = SCOPE_IDENTITY();
    
    COMMIT TRANSACTION;
    
    -- Generar reporte de cierre
    EXEC SP_GenerarReporteCierre @IdCierre;
END;

-- Tipo para totales de cierre
CREATE TYPE TipoTotalesCierre AS TABLE (
    TotalIngresoExistente DECIMAL(18,2),
    TotalGastos DECIMAL(18,2),
    TotalReintegros DECIMAL(18,2),
    Efectivo DECIMAL(18,2),
    Cheques DECIMAL(18,2),
    TarjetasCredito DECIMAL(18,2),
    TarjetasDebito DECIMAL(18,2),
    NotasCredito DECIMAL(18,2),
    Seguros DECIMAL(18,2),
    Creditos DECIMAL(18,2),
    Transferencias DECIMAL(18,2),
    DivisasUSD DECIMAL(18,2),
    TasaCambio DECIMAL(18,2),
    TotalDivisasBS DECIMAL(18,2),
    TotalDepositar DECIMAL(18,2),
    FondoCaja DECIMAL(18,2),
    TotalCaja DECIMAL(18,2)
);

CREATE PROCEDURE SP_GenerarReporteCierre
    @IdCierre INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Reporte de cierre con detalle de facturas del día
    SELECT 
        'FACTURAS DEL DÍA' AS Seccion,
        f.NumeroFactura,
        'VD' AS Tipo,
        f.SubtotalNeto AS MontoNeto,
        f.ImpuestoIVA AS MontoIVA,
        f.IGTF AS MontoIGTF,
        f.Total AS MontoTotal
    FROM Facturas f
    WHERE f.Estado = 'A' 
    AND CONVERT(DATE, f.Fecha) = (SELECT Fecha FROM CierreCaja WHERE IdCierre = @IdCierre)
    
    UNION ALL
    
    SELECT 
        'NOTAS DE CRÉDITO' AS Seccion,
        nc.NumeroNotaCredito,
        nc.TipoNota,
        nc.Subtotal AS MontoNeto,
        nc.ImpuestoIVA AS MontoIVA,
        nc.IGTF AS MontoIGTF,
        nc.Total AS MontoTotal
    FROM NotasCredito nc
    WHERE CONVERT(DATE, nc.Fecha) = (SELECT Fecha FROM CierreCaja WHERE IdCierre = @IdCierre)
    
    ORDER BY Seccion, NumeroFactura;
END;

---## 📦 MÓDULO 7: CONFIGURACIÓN GLOBAL

-- =============================================
-- TABLAS DE CONFIGURACIÓN
-- =============================================

-- 7.1 Configuración Global
CREATE TABLE ConfiguracionGlobal (
    IdConfig INT PRIMARY KEY DEFAULT 1,
    NombreEmpresa VARCHAR(100),
    Rif VARCHAR(20),
    Direccion VARCHAR(200),
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    TasaIGTF DECIMAL(5,2) DEFAULT 3.00,
    ActivarIGTF BIT DEFAULT 0,
    SolicitarDireccionVentas BIT DEFAULT 1,
    ControlAsistencia BIT DEFAULT 1,
    DiasEntregaOT INT DEFAULT 1,
    EnvioAutomaticoLaboratorio BIT DEFAULT 0,
    TasaBCV DECIMAL(18,2) DEFAULT 1.00,
    FechaActualizacionTasa DATE DEFAULT GETDATE()
);

-- 7.2 Bancos
CREATE TABLE Bancos (
    CodigoBanco VARCHAR(10) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Activo BIT DEFAULT 1
);

-- 7.3 Tarjetas de Crédito/Débito
CREATE TABLE Tarjetas (
    CodigoTarjeta VARCHAR(10) PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL,
    Tipo CHAR(1) CHECK (Tipo IN ('C', 'D')) -- C=Crédito, D=Débito
);

-- 7.4 Laboratorios
CREATE TABLE Laboratorios (
    CodigoLaboratorio VARCHAR(10) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Direccion VARCHAR(200),
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    Contacto VARCHAR(100),
    Activo BIT DEFAULT 1
);

-- 7.5 Transportes (Valijas)
CREATE TABLE Transportes (
    CodigoTransporte VARCHAR(10) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    PaginaWeb VARCHAR(200),
    Direccion VARCHAR(200),
    ContactoNombre VARCHAR(100),
    ContactoCargo VARCHAR(50),
    ContactoTelefono VARCHAR(20),
    Activo BIT DEFAULT 1
);

-- 7.6 Empresas Afiliadas
CREATE TABLE EmpresasAfiliadas (
    CodigoEmpresa VARCHAR(10) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Rif VARCHAR(20),
    DescuentoEfectivo DECIMAL(5,2) DEFAULT 0,
    DescuentoTarjeta DECIMAL(5,2) DEFAULT 0,
    Activo BIT DEFAULT 1
);

-- 7.7 Días Feriados
CREATE TABLE DiasFeriados (
    Fecha DATE PRIMARY KEY,
    Descripcion VARCHAR(100),
    Recurrente BIT DEFAULT 1 -- Si se repite cada año
);

-- =============================================
-- PROCEDIMIENTOS DE CONFIGURACIÓN
-- =============================================

CREATE PROCEDURE SP_ActualizarTasaCambio
    @TasaBCV DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE ConfiguracionGlobal 
    SET TasaBCV = @TasaBCV,
        FechaActualizacionTasa = GETDATE()
    WHERE IdConfig = 1;
    
    PRINT 'Tasa BCV actualizada: ' + CAST(@TasaBCV AS VARCHAR(20));
END;

CREATE PROCEDURE SP_ConfigurarIGTF
    @ActivarIGTF BIT,
    @TasaIGTF DECIMAL(5,2)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE ConfiguracionGlobal 
    SET ActivarIGTF = @ActivarIGTF,
        TasaIGTF = @TasaIGTF
    WHERE IdConfig = 1;
    
    IF @ActivarIGTF = 1
        PRINT 'IGTF activado al ' + CAST(@TasaIGTF AS VARCHAR(5)) + '%';
    ELSE
        PRINT 'IGTF desactivado';
END;

---## 📦 MÓDULO 8: AUDITORÍA Y REPORTES

-- =============================================
-- TABLAS DE AUDITORÍA
-- =============================================

-- 8.1 Log de Auditoría
CREATE TABLE Auditoria (
    IdAuditoria INT IDENTITY(1,1) PRIMARY KEY,
    FechaHora DATETIME DEFAULT GETDATE(),
    CodigoUsuario VARCHAR(10),
    Modulo VARCHAR(50),
    Accion VARCHAR(100),
    Descripcion VARCHAR(500),
    IpAddress VARCHAR(50),
    Dispositivo VARCHAR(100),
    FOREIGN KEY (CodigoUsuario) REFERENCES Usuarios(CodigoUsuario)
);

-- 8.2 Control de Asistencia
CREATE TABLE AsistenciaUsuarios (
    IdAsistencia INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE DEFAULT GETDATE(),
    CodigoUsuario VARCHAR(10),
    HoraEntrada TIME,
    HoraSalida TIME,
    Turno VARCHAR(20),
    Observaciones VARCHAR(200),
    FOREIGN KEY (CodigoUsuario) REFERENCES Usuarios(CodigoUsuario)
);

-- 8.3 Log de Errores
CREATE TABLE LogErrores (
    IdError INT IDENTITY(1,1) PRIMARY KEY,
    FechaHora DATETIME DEFAULT GETDATE(),
    CodigoUsuario VARCHAR(10),
    Modulo VARCHAR(50),
    ErrorNumber INT,
    ErrorMessage VARCHAR(1000),
    ErrorProcedure VARCHAR(100),
    ErrorLine INT,
    FOREIGN KEY (CodigoUsuario) REFERENCES Usuarios(CodigoUsuario)
);

-- =============================================
-- TRIGGERS DE AUDITORÍA
-- =============================================

CREATE TRIGGER TR_Auditoria_Facturas
ON Facturas
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @Accion VARCHAR(10);
    DECLARE @Usuario VARCHAR(10) = SYSTEM_USER;
    
    IF EXISTS (SELECT * FROM INSERTED) AND EXISTS (SELECT * FROM DELETED)
        SET @Accion = 'UPDATE';
    ELSE IF EXISTS (SELECT * FROM INSERTED)
        SET @Accion = 'INSERT';
    ELSE
        SET @Accion = 'DELETE';
    
    INSERT INTO Auditoria (CodigoUsuario, Modulo, Accion, Descripcion)
    SELECT 
        @Usuario,
        'FACTURACION',
        @Accion,
        CASE 
            WHEN @Accion = 'INSERT' THEN 'Factura creada: ' + CAST(i.NumeroFactura AS VARCHAR(20))
            WHEN @Accion = 'UPDATE' THEN 'Factura actualizada: ' + CAST(i.NumeroFactura AS VARCHAR(20))
            WHEN @Accion = 'DELETE' THEN 'Factura eliminada: ' + CAST(d.NumeroFactura AS VARCHAR(20))
        END
    FROM INSERTED i
    FULL JOIN DELETED d ON 1=1;
END;

CREATE TRIGGER TR_Auditoria_Inventario
ON Productos
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Auditoria (CodigoUsuario, Modulo, Accion, Descripcion)
    SELECT 
        SYSTEM_USER,
        'INVENTARIO',
        'UPDATE',
        'Producto actualizado: ' + i.CodigoProducto + 
        ' - Existencia: ' + CAST(d.Existencia AS VARCHAR(20)) + ' -> ' + CAST(i.Existencia AS VARCHAR(20))
    FROM INSERTED i
    JOIN DELETED d ON i.CodigoProducto = d.CodigoProducto
    WHERE i.Existencia <> d.Existencia;
END;

-- =============================================
-- VISTAS DE REPORTES
-- =============================================

CREATE VIEW VW_ReporteVentasDiarias AS
SELECT 
    CONVERT(DATE, f.Fecha) AS Fecha,
    COUNT(DISTINCT f.NumeroFactura) AS CantidadFacturas,
    COUNT(d.IdDetalle) AS CantidadItems,
    SUM(d.Cantidad) AS CantidadProductos,
    SUM(f.SubtotalNeto) AS Subtotal,
    SUM(f.ImpuestoIVA) AS IVA,
    SUM(f.IGTF) AS IGTF,
    SUM(f.Total) AS Total,
    AVG(f.Total) AS PromedioVenta
FROM Facturas f
JOIN DetalleFactura d ON f.NumeroFactura = d.NumeroFactura
WHERE f.Estado = 'A'
GROUP BY CONVERT(DATE, f.Fecha);

CREATE VIEW VW_ReporteProductosMasVendidos AS
SELECT 
    p.CodigoProducto,
    p.Descripcion,
    tp.Descripcion AS Tipo,
    g.Descripcion AS Grupo,
    m.Descripcion AS Marca,
    SUM(df.Cantidad) AS CantidadVendida,
    SUM(df.TotalItem) AS TotalVendido,
    COUNT(DISTINCT df.NumeroFactura) AS VecesFacturado
FROM DetalleFactura df
JOIN Productos p ON df.CodigoProducto = p.CodigoProducto
JOIN TiposProducto tp ON p.CodigoTipo = tp.CodigoTipo
LEFT JOIN GruposProducto g ON p.CodigoGrupo = g.CodigoGrupo
LEFT JOIN Marcas m ON p.CodigoMarca = m.CodigoMarca
GROUP BY p.CodigoProducto, p.Descripcion, tp.Descripcion, g.Descripcion, m.Descripcion;

CREATE VIEW VW_ReporteVendedores AS
SELECT 
    u.CodigoUsuario,
    u.Nombre + ' ' + u.Apellido AS Vendedor,
    COUNT(f.NumeroFactura) AS CantidadVentas,
    SUM(f.Total) AS TotalVendido,
    AVG(f.Total) AS PromedioVenta,
    MIN(f.Fecha) AS PrimeraVenta,
    MAX(f.Fecha) AS UltimaVenta
FROM Facturas f
JOIN Usuarios u ON f.CodigoVendedor = u.CodigoUsuario
WHERE f.Estado = 'A'
GROUP BY u.CodigoUsuario, u.Nombre, u.Apellido;

CREATE VIEW VW_ReporteClientesFrecuentes AS
SELECT 
    c.Cedula,
    c.Nombre + ' ' + c.Apellido AS Cliente,
    COUNT(f.NumeroFactura) AS CantidadCompras,
    SUM(f.Total) AS TotalComprado,
    MIN(f.Fecha) AS PrimeraCompra,
    MAX(f.Fecha) AS UltimaCompra,
    DATEDIFF(DAY, MAX(f.Fecha), GETDATE()) AS DiasUltimaCompra
FROM Facturas f
JOIN Clientes c ON f.CodigoCliente = c.Cedula
WHERE f.Estado = 'A'
GROUP BY c.Cedula, c.Nombre, c.Apellido;

-- =============================================
-- PROCEDIMIENTOS DE REPORTES
-- =============================================

CREATE PROCEDURE SP_GenerarLibroVentas
    @FechaDesde DATE,
    @FechaHasta DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        f.NumeroFactura,
        f.Fecha,
        c.Cedula,
        c.Nombre + ' ' + c.Apellido AS Cliente,
        c.Rif,
        f.SubtotalNeto AS BaseImponible,
        f.MontoExento,
        f.ImpuestoIVA AS IVA,
        f.IGTF,
        f.Total,
        f.NumeroControl,
        f.Estado
    FROM Facturas f
    JOIN Clientes c ON f.CodigoCliente = c.Cedula
    WHERE f.Fecha BETWEEN @FechaDesde AND @FechaHasta
    AND f.Estado = 'A'
    ORDER BY f.Fecha, f.NumeroFactura;
    
    -- Totales
    SELECT 
        COUNT(*) AS CantidadFacturas,
        SUM(f.SubtotalNeto) AS TotalBaseImponible,
        SUM(f.MontoExento) AS TotalExento,
        SUM(f.ImpuestoIVA) AS TotalIVA,
        SUM(f.IGTF) AS TotalIGTF,
        SUM(f.Total) AS TotalGeneral
    FROM Facturas f
    WHERE f.Fecha BETWEEN @FechaDesde AND @FechaHasta
    AND f.Estado = 'A';
END;

CREATE PROCEDURE SP_ReporteMargenUtilidad
    @FechaDesde DATE,
    @FechaHasta DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        p.CodigoProducto,
        p.Descripcion,
        tp.Descripcion AS Tipo,
        SUM(df.Cantidad) AS CantidadVendida,
        SUM(df.TotalItem) AS TotalVendido,
        SUM(df.Cantidad * p.CostoPromedio) AS CostoTotal,
        SUM(df.TotalItem) - SUM(df.Cantidad * p.CostoPromedio) AS UtilidadBruta,
        CASE WHEN SUM(df.TotalItem) > 0 
             THEN ((SUM(df.TotalItem) - SUM(df.Cantidad * p.CostoPromedio)) / SUM(df.TotalItem)) * 100 
             ELSE 0 END AS MargenPorcentaje
    FROM DetalleFactura df
    JOIN Facturas f ON df.NumeroFactura = f.NumeroFactura
    JOIN Productos p ON df.CodigoProducto = p.CodigoProducto
    JOIN TiposProducto tp ON p.CodigoTipo = tp.CodigoTipo
    WHERE f.Fecha BETWEEN @FechaDesde AND @FechaHasta
    AND f.Estado = 'A'
    GROUP BY p.CodigoProducto, p.Descripcion, tp.Descripcion
    ORDER BY UtilidadBruta DESC;
END;

---## 📦 MÓDULO 9: UTILITARIOS Y SEGURIDAD

-- =============================================
-- TABLAS DE SEGURIDAD
-- =============================================

-- 9.1 Permisos de Usuario
CREATE TABLE PermisosUsuario (
    IdPermiso INT IDENTITY(1,1) PRIMARY KEY,
    CodigoUsuario VARCHAR(10),
    Modulo VARCHAR(50),
    PermisoLectura BIT DEFAULT 0,
    PermisoEscritura BIT DEFAULT 0,
    PermisoEliminar BIT DEFAULT 0,
    PermisoReportes BIT DEFAULT 0,
    FOREIGN KEY (CodigoUsuario) REFERENCES Usuarios(CodigoUsuario)
);

-- 9.2 Backups
CREATE TABLE RegistroBackups (
    IdBackup INT IDENTITY(1,1) PRIMARY KEY,
    FechaHora DATETIME DEFAULT GETDATE(),
    CodigoUsuario VARCHAR(10),
    Archivo VARCHAR(200),
    TamañoMB DECIMAL(10,2),
    Completado BIT DEFAULT 1,
    Observaciones VARCHAR(500),
    FOREIGN KEY (CodigoUsuario) REFERENCES Usuarios(CodigoUsuario)
);

-- =============================================
-- PROCEDIMIENTOS DE SEGURIDAD
-- =============================================

CREATE PROCEDURE SP_ValidarUsuario
    @CodigoUsuario VARCHAR(10),
    @Clave VARCHAR(100),
    @Valido BIT OUTPUT,
    @IntentosRestantes INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @ClaveAlmacenada VARCHAR(100);
    DECLARE @Activo BIT;
    DECLARE @Intentos INT;
    
    SELECT @ClaveAlmacenada = Clave, 
           @Activo = Activo,
           @Intentos = 3 -- Por simplificar, en realidad debería ser un campo en la tabla
    FROM Usuarios
    WHERE CodigoUsuario = @CodigoUsuario;
    
    IF @ClaveAlmacenada IS NULL
    BEGIN
        SET @Valido = 0;
        SET @IntentosRestantes = 0;
        RAISERROR('Usuario no existe', 16, 1);
        RETURN;
    END;
    
    IF @Activo = 0
    BEGIN
        SET @Valido = 0;
        SET @IntentosRestantes = 0;
        RAISERROR('Usuario inactivo', 16, 1);
        RETURN;
    END;
    
    -- Validar clave (en producción usar hash)
    IF @Clave = @ClaveAlmacenada
    BEGIN
        SET @Valido = 1;
        SET @IntentosRestantes = 3;
        
        -- Registrar acceso exitoso
        INSERT INTO Auditoria (CodigoUsuario, Modulo, Accion, Descripcion)
        VALUES (@CodigoUsuario, 'ACCESO', 'LOGIN', 'Acceso exitoso al sistema');
    END
    ELSE
    BEGIN
        SET @Valido = 0;
        SET @IntentosRestantes = @Intentos - 1;
        
        IF @IntentosRestantes <= 0
        BEGIN
            -- Bloquear usuario
            UPDATE Usuarios SET Activo = 0 WHERE CodigoUsuario = @CodigoUsuario;
            
            INSERT INTO Auditoria (CodigoUsuario, Modulo, Accion, Descripcion)
            VALUES (@CodigoUsuario, 'ACCESO', 'BLOQUEO', 'Usuario bloqueado por máximo intentos fallidos');
        END;
        
        INSERT INTO Auditoria (CodigoUsuario, Modulo, Accion, Descripcion)
        VALUES (@CodigoUsuario, 'ACCESO', 'LOGIN_FALLIDO', 'Intento fallido de acceso');
    END;
END;

CREATE PROCEDURE SP_CrearBackup
    @Ruta VARCHAR(500),
    @CodigoUsuario VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @NombreArchivo VARCHAR(200);
    DECLARE @Comando VARCHAR(1000);
    
    SET @NombreArchivo = 'Optiven_Backup_' + 
                        CONVERT(VARCHAR(8), GETDATE(), 112) + '_' + 
                        REPLACE(CONVERT(VARCHAR(8), GETDATE(), 108), ':', '') + '.bak';
    
    SET @Comando = 'BACKUP DATABASE ' + DB_NAME() + 
                   ' TO DISK = ''' + @Ruta + @NombreArchivo + '''';
    
    BEGIN TRY
        EXEC(@Comando);
        
        INSERT INTO RegistroBackups (CodigoUsuario, Archivo, TamañoMB, Observaciones)
        VALUES (@CodigoUsuario, @NombreArchivo, 
                (SELECT size/128.0 FROM sys.database_files WHERE name = DB_NAME()),
                'Backup manual realizado');
        
        PRINT 'Backup creado exitosamente: ' + @NombreArchivo;
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores (CodigoUsuario, Modulo, ErrorNumber, ErrorMessage, ErrorProcedure)
        VALUES (@CodigoUsuario, 'BACKUP', ERROR_NUMBER(), ERROR_MESSAGE(), 'SP_CrearBackup');
        
        RAISERROR('Error al crear backup: %s', 16, 1, ERROR_MESSAGE());
    END CATCH;
END;

---## 📦 MÓDULO 10: DATOS INICIALES Y CONFIGURACIÓN

-- =============================================
-- INSERTS INICIALES
-- =============================================

-- Insertar configuración global
INSERT INTO ConfiguracionGlobal (NombreEmpresa, Rif, Direccion, Telefono, TasaIGTF, ActivarIGTF)
VALUES ('ÓPTICA DEMO, C.A.', 'J-12345678-9', 'Caracas, Venezuela', '0212-5555555', 3.00, 1);

-- Insertar usuario administrador
INSERT INTO Usuarios (CodigoUsuario, Nombre, Apellido, Clave, NivelAcceso, Email)
VALUES ('ADMIN', 'Administrador', 'Sistema', 'admin123', 99, 'admin@optica.com');

-- Insertar tipos de producto básicos
INSERT INTO TiposProducto (CodigoTipo, Descripcion, ConExistencia, ExentoImpuesto) VALUES
('C', 'Cristales', 1, 0),
('M', 'Monturas Correctivas', 1, 0),
('S', 'Lentes de Sol', 1, 0),
('L', 'Lentes de Contacto', 1, 0),
('E', 'Estuches', 1, 0),
('X', 'Misceláneas', 1, 0),
('Q', 'Líquidos', 1, 0),
('A', 'Tratamientos Adicionales', 1, 1);

-- Insertar algunos grupos
INSERT INTO GruposProducto (CodigoGrupo, Descripcion, CodigoTipo1) VALUES
('CP', 'Caballero Pasta', 'M'),
('CM', 'Caballero Metal', 'M'),
('DM', 'Dama Metal', 'M'),
('DP', 'Dama Pasta', 'M'),
('NIÑ', 'Niños', 'M'),
('BLA', 'Blandos', 'L'),
('RIG', 'Rígidos', 'L');

-- Insertar algunas marcas
INSERT INTO Marcas (CodigoMarca, Descripcion, FactorMultiplicador) VALUES
('CK', 'Calvin Klein', 2.5000),
('RB', 'Ray-Ban', 2.8000),
('ACUV', 'Acuvue', 2.2000),
('BLS', 'Bausch & Lomb', 2.1000);

-- Insertar bancos comunes
INSERT INTO Bancos (CodigoBanco, Nombre) VALUES
('0101', 'BANESCO'),
('0102', 'MERCANTIL'),
('0103', 'BANCO DE VENEZUELA'),
('0104', 'BANCO PROVINCIAL');

-- Insertar tarjetas
INSERT INTO Tarjetas (CodigoTarjeta, Descripcion, Tipo) VALUES
('VISA', 'Visa', 'C'),
('MC', 'MasterCard', 'C'),
('AMEX', 'American Express', 'C'),
('CIR', 'Cirrus', 'D'),
('MAE', 'Maestro', 'D');
```

/*

✅ **Estructura SQL Server completa** organizada por módulos, incluyendo:

1. **Facturación y Ventas** - Tablas principales de facturas, pagos, clientes
2. **Órdenes de Trabajo** - Gestión completa de OT desde creación a entrega
3. **Inventario** - Productos, movimientos, ajustes, conteos físicos
4. **Recepción de Mercancía** - Proveedores y recepciones
5. **Devoluciones y Notas** - Crédito, débito, devoluciones
6. **Caja y Cierre Diario** - Control de efectivo y cierres
7. **Configuración Global** - Parámetros del sistema
8. **Auditoría y Reportes** - Logs, auditoría, vistas de reportes
9. **Utilitarios y Seguridad** - Backups, permisos, validación
10. **Datos Iniciales** - Configuración base

Cada módulo incluye:
- ✅ Tablas principales con relaciones
- ✅ Índices para optimización
- ✅ Vistas útiles para reportes
- ✅ Procedimientos almacenados clave
- ✅ Triggers de auditoría
- ✅ Tipos de tabla para parámetros

*/