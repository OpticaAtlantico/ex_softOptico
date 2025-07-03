-- *** 1. Tablas Maestras ***

-- Tabla: Ubicaciones (Almacenes y Sucursales)
CREATE TABLE Ubicaciones (
    UbicacionID INT IDENTITY(1,1) PRIMARY KEY,
    NombreUbicacion NVARCHAR(100) NOT NULL UNIQUE,
    TipoUbicacion NVARCHAR(50) NOT NULL, -- Ej: 'Almacén Principal', 'Sucursal', 'Punto de Venta'
    Direccion NVARCHAR(255),
    Telefono NVARCHAR(20),
    Activa BIT NOT NULL DEFAULT 1 -- Para habilitar/deshabilitar ubicaciones
);

-- Tabla: Clientes
CREATE TABLE Clientes (
    ClienteID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(255),
    Telefono NVARCHAR(20),
    Email NVARCHAR(100),
    RUC_CI NVARCHAR(20) UNIQUE
);

-- Tabla: Proveedores
CREATE TABLE Proveedores (
    ProveedorID INT IDENTITY(1,1) PRIMARY KEY,
    NombreEmpresa NVARCHAR(100) NOT NULL,
    Contacto NVARCHAR(100),
    Telefono NVARCHAR(20),
    Email NVARCHAR(100),
    Direccion NVARCHAR(255),
    RUC NVARCHAR(20) UNIQUE
);

-- Tabla: Categorias (para productos)
CREATE TABLE Categorias (
    CategoriaID INT IDENTITY(1,1) PRIMARY KEY,
    NombreCategoria NVARCHAR(50) NOT NULL UNIQUE
);

-- Tabla: Productos
CREATE TABLE Productos (
    ProductoID INT IDENTITY(1,1) PRIMARY KEY,
    CodigoProducto NVARCHAR(50) UNIQUE NOT NULL,
    NombreProducto NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    CategoriaID INT,
    PrecioVenta DECIMAL(18, 2) NOT NULL,
    CostoPromedio DECIMAL(18, 2) NOT NULL DEFAULT 0, -- Costo promedio ponderado
    Activo BIT NOT NULL DEFAULT 1,
    RequiereInventario BIT NOT NULL DEFAULT 1, -- Para servicios que no manejan stock
    FOREIGN KEY (CategoriaID) REFERENCES Categorias(CategoriaID)
);

-- Tabla: Empleados (Usuarios del Sistema)
CREATE TABLE Empleados (
    EmpleadoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Usuario NVARCHAR(50) UNIQUE NOT NULL,
    ContrasenaHash NVARCHAR(255) NOT NULL, -- Almacenar hash seguro (SHA256, BCrypt)
    Rol NVARCHAR(50) NOT NULL, -- Ej: 'Administrador', 'Vendedor', 'Almacén', 'Gerente'
    UbicacionID INT, -- Ubicación principal del empleado
    FOREIGN KEY (UbicacionID) REFERENCES Ubicaciones(UbicacionID)
);

-- *** 2. Tablas de Inventario Multi-Ubicación ***

-- Tabla: StockPorUbicacion (Inventario real por producto en cada ubicación)
CREATE TABLE StockPorUbicacion (
    StockUbicacionID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL,
    UbicacionID INT NOT NULL,
    StockActual INT NOT NULL DEFAULT 0,
    StockMinimo INT NOT NULL DEFAULT 0, -- Stock mínimo por ubicación
    UNIQUE (ProductoID, UbicacionID), -- Un producto solo puede tener un registro de stock por ubicación
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID),
    FOREIGN KEY (UbicacionID) REFERENCES Ubicaciones(UbicacionID)
);

-- Tabla: MovimientosInventario (Registro detallado de todo movimiento de stock)
CREATE TABLE MovimientosInventario (
    MovimientoID BIGINT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL,
    UbicacionOrigenID INT, -- NULL para entradas de compra
    UbicacionDestinoID INT, -- NULL para salidas por venta/ajuste negativo
    TipoMovimiento NVARCHAR(50) NOT NULL, -- Ej: 'Entrada por Compra', 'Salida por Venta', 'Traslado', 'Ajuste Positivo', 'Ajuste Negativo', 'Devolución Cliente', 'Devolución Proveedor'
    Cantidad INT NOT NULL,
    FechaMovimiento DATETIME NOT NULL DEFAULT GETDATE(),
    Referencia NVARCHAR(255), -- Ej: 'Venta #123', 'Compra #456', 'Nota Entrega #789', 'Ajuste Físico', 'Devolución'
    EmpleadoID INT, -- Quién realizó el movimiento
    Notas NVARCHAR(MAX),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID),
    FOREIGN KEY (UbicacionOrigenID) REFERENCES Ubicaciones(UbicacionID),
    FOREIGN KEY (UbicacionDestinoID) REFERENCES Ubicaciones(UbicacionID),
    FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID)
);

-- Tabla: TrasladosInventario (Encabezado para movimientos entre ubicaciones)
CREATE TABLE TrasladosInventario (
    TrasladoID INT IDENTITY(1,1) PRIMARY KEY,
    FechaTraslado DATETIME NOT NULL DEFAULT GETDATE(),
    UbicacionOrigenID INT NOT NULL,
    UbicacionDestinoID INT NOT NULL,
    EmpleadoOrigenID INT,
    EmpleadoDestinoID INT, -- Empleado que recibe en destino
    Estado NVARCHAR(50) NOT NULL DEFAULT 'Pendiente', -- Ej: 'Pendiente', 'En Tránsito', 'Recibido', 'Cancelado'
    FechaRecepcion DATETIME,
    Notas NVARCHAR(MAX),
    FOREIGN KEY (UbicacionOrigenID) REFERENCES Ubicaciones(UbicacionID),
    FOREIGN KEY (UbicacionDestinoID) REFERENCES Ubicaciones(UbicacionID),
    FOREIGN KEY (EmpleadoOrigenID) REFERENCES Empleados(EmpleadoID),
    FOREIGN KEY (EmpleadoDestinoID) REFERENCES Empleados(EmpleadoID)
);

-- Tabla: DetalleTraslado (Productos en cada traslado)
CREATE TABLE DetalleTraslado (
    DetalleTrasladoID INT IDENTITY(1,1) PRIMARY KEY,
    TrasladoID INT NOT NULL,
    ProductoID INT NOT NULL,
    CantidadSolicitada INT NOT NULL,
    CantidadEnviada INT NOT NULL, -- La que realmente se envió (puede ser diferente a la solicitada)
    CantidadRecibida INT NOT NULL DEFAULT 0,
    Notas NVARCHAR(MAX),
    FOREIGN KEY (TrasladoID) REFERENCES TrasladosInventario(TrasladoID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

-- *** 3. Tablas de Operaciones ***

-- Tabla: Compras (Encabezado de la compra)
CREATE TABLE Compras (
    CompraID INT IDENTITY(1,1) PRIMARY KEY,
    FechaCompra DATETIME NOT NULL DEFAULT GETDATE(),
    ProveedorID INT,
    EmpleadoID INT, -- Quien registra la compra
    UbicacionDestinoID INT NOT NULL, -- A qué almacén/sucursal ingresa la compra
    TotalCompra DECIMAL(18, 2) NOT NULL,
    Estado NVARCHAR(50) NOT NULL DEFAULT 'Completada', -- Ej: 'Pendiente', 'Completada', 'Anulada'
    FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID),
    FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID),
    FOREIGN KEY (UbicacionDestinoID) REFERENCES Ubicaciones(UbicacionID)
);

-- Tabla: DetalleCompra
CREATE TABLE DetalleCompra (
    DetalleCompraID INT IDENTITY(1,1) PRIMARY KEY,
    CompraID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    CostoUnitario DECIMAL(18, 2) NOT NULL,
    Subtotal DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (CompraID) REFERENCES Compras(CompraID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

-- Tabla: Ventas (Encabezado de la venta)
CREATE TABLE Ventas (
    VentaID BIGINT IDENTITY(1,1) PRIMARY KEY,
    FechaVenta DATETIME NOT NULL DEFAULT GETDATE(),
    ClienteID INT,
    EmpleadoID INT, -- Quien realiza la venta
    UbicacionVentaID INT NOT NULL, -- Desde qué sucursal/ubicación se realiza la venta
    TotalVenta DECIMAL(18, 2) NOT NULL,
    DescuentoTotal DECIMAL(18, 2) DEFAULT 0,
    ImpuestoTotal DECIMAL(18, 2) DEFAULT 0,
    TipoPago NVARCHAR(50), -- Ej: 'Efectivo', 'Tarjeta', 'Crédito'
    Estado NVARCHAR(50) NOT NULL DEFAULT 'Completada', -- Ej: 'Completada', 'Anulada', 'Pendiente'
    EsNotaEntrega BIT NOT NULL DEFAULT 0, -- Indica si esta venta se emite como Nota de Entrega
    NumeroDocumento NVARCHAR(50) UNIQUE, -- Número de factura o nota de entrega
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
    FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID),
    FOREIGN KEY (UbicacionVentaID) REFERENCES Ubicaciones(UbicacionID)
);

-- Tabla: DetalleVenta
CREATE TABLE DetalleVenta (
    DetalleVentaID BIGINT IDENTITY(1,1) PRIMARY KEY,
    VentaID BIGINT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18, 2) NOT NULL,
    DescuentoUnitario DECIMAL(18, 2) DEFAULT 0,
    Subtotal DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (VentaID) REFERENCES Ventas(VentaID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);