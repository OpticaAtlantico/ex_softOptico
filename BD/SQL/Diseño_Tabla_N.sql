IF NOT EXISTS (
    SELECT * FROM SYS.databases 
    WHERE name = 'BD_OPTICA'
    )
BEGIN
    CREATE DATABASE BD_OPTICA
END

GO

USE BD_OPTICA
GO

-- *** 1. Tablas Maestras ***

-- Tabla: Rol -- Ej: 'Administrador', 'Vendedor', 'Almacén', 'Gerente'
CREATE TABLE TRol (
    RolID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(250) NOT NULL
    )

-- Tabla: Permiso para los menu del formulario
CREATE TABLE TPermisos (
    PermisosID INT IDENTITY(1,1) PRIMARY KEY,
    RolID INT NOT NULL,
    NombreMenu NVARCHAR(100) NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (RolID) REFERENCES TRol(RolID)
    )

-- Tabla: TCargoEmpleado -- Asesor, Gerente, Optometrista, Marketing etc...
CREATE TABLE TCargoEmpleado (
    CargoEmpleadoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(250) NOT NULL
    )

-- Tabla: TSucursal indica el los datos principales de la empresa o sucursal
CREATE table tab_TSucursal(
    SucursalID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(60) NOT NULL, 
    Rif NVARCHAR(15) NOT NULL,
    Direccion NVARCHAR(MAX),
    Sucursal NVARCHAR(50) NOT NULL,
    Telefono NVARCHAR(50) NOT NULL,
    Email NVARCHAR(50),
    Estado BIT,
    FechaRegistro DATETIME DEFAULT GETDATE()
    )

-- Tabla: Ubicaciones (Almacenes y Sucursales)
CREATE TABLE TUbicaciones (
    UbicacionID INT IDENTITY(1,1) PRIMARY KEY,
    NombreUbicacion NVARCHAR(100) NOT NULL UNIQUE,
    TipoUbicacion NVARCHAR(50) NOT NULL, -- Ej: 'Almacén Principal', 'Sucursal', 'Punto de Venta'
    Direccion NVARCHAR(255),
    Telefono NVARCHAR(20),
    Activa BIT NOT NULL DEFAULT 1 -- Para habilitar/deshabilitar ubicaciones
);

-- Tabla: Clientes
CREATE TABLE TClientes (
    ClienteID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(255),
    Telefono NVARCHAR(20),
    Email NVARCHAR(100),
    RUC_CI NVARCHAR(20) UNIQUE,
    Rif NVARCHAR(60)
);

-- Tabla: TEmpresaCliente para almacenar información de las empresas de clientes  
CREATE TABLE TEmpresaCliente (
    EmpresaClienteID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID INT, 
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(250) NOT NULL,
    Direccion NVARCHAR(255),
    Zona NVARCHAR(30),
    Telefono NVARCHAR(20),
    Email NVARCHAR(100),
    Rif NVARCHAR(60),
    FechaRegistro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ClienteID) REFERENCES TClientes(ClienteID)
);

-- Tabla: Proveedores
CREATE TABLE Proveedores (
    ProveedorID INT IDENTITY(1,1) PRIMARY KEY,
    NombreEmpresa NVARCHAR(100) NOT NULL,
    RazonSocial NVARCHAR(250), 
    Contacto NVARCHAR(100),
    Telefono NVARCHAR(20),
    Rif NVARCHAR(30),
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
    Descripcion NVARCHAR(255),
    CategoriaID INT,
    PrecioVenta DECIMAL(18, 2) NOT NULL,
    CostoPromedio DECIMAL(18, 2) NOT NULL DEFAULT 0, -- Costo promedio ponderado
    Activo BIT NOT NULL DEFAULT 1,
    RequiereInventario BIT NOT NULL DEFAULT 1, -- Para servicios que no manejan stock
    FOREIGN KEY (CategoriaID) REFERENCES Categorias(CategoriaID)
);

-- Tabla: Empleados (Usuarios del Sistema)
CREATE TABLE TEmpleados (
    EmpleadoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Edad INT,
    Nacionalidad CHAR(1),
    EstadoCivil CHAR(1),
    Sexo CHAR(1),
    FechaNacimiento DATE,
    Direccion NVARCHAR(MAX),
    CargoEmpleadoID INT,
    Estado BIT, -- PARA SABER EL ESTADO DE USUARIO
    FOREIGN KEY (CargoEmpleadoID) REFERENCES TCargoEmpleado(CargoEmpleadoID)
);

-- Tabla: TLogin Inicio de secion al sistema
CREATE TABLE TLogin (
    LoginID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteEmpleadoID INT NOT NULL,
    UbicacionID INT NOT NULL,
    RolID INT NOT NULL DEFAULT 0,
    Email NVARCHAR(90), 
    Clave NVARCHAR(255) NOT NULL, -- Almacenar hash seguro (SHA256, BCrypt),
    FOREIGN KEY (ClienteEmpleadoID) REFERENCES TClientes(ClienteID),
    FOREIGN KEY (RolID) REFERENCES TRol(RolID),
    FOREIGN KEY (UbicacionID) REFERENCES TUbicaciones(UbicacionID)
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
    FOREIGN KEY (UbicacionID) REFERENCES TUbicaciones(UbicacionID)
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
    FOREIGN KEY (UbicacionOrigenID) REFERENCES TUbicaciones(UbicacionID),
    FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID),
    FOREIGN KEY (EmpleadoID) REFERENCES TEmpleados(EmpleadoID)
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
    FOREIGN KEY (UbicacionOrigenID) REFERENCES TUbicaciones(UbicacionID),
    FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID),
    FOREIGN KEY (EmpleadoOrigenID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (EmpleadoDestinoID) REFERENCES TEmpleados(EmpleadoID)
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

--Tabla: TAlicuota para registrar los porcentajes de iva
CREATE TABLE TAlicuota (
    AlicuotaID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(12) NOT NULL,
    Alicuota INT NOT NULL
);

--Tabla: TTipoPago para registrar los tipos de pagos
CREATE TABLE TTipoPago (
    TipoPagoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
);

--Tabla: TFormaPago para registrar los tipos de pagos
CREATE TABLE TFormaPago (
    TipoPagoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
);



-- *** 3. Tablas de Operaciones ***

-- Tabla: Compras (Encabezado de la compra)
CREATE TABLE Compras (
    CompraID INT IDENTITY(1,1) PRIMARY KEY,
    FechaCompra DATETIME NOT NULL DEFAULT GETDATE(),
    NumeroControl NVARCHAR(30) NOT NULL,
    NumeroFactura NVARCHAR(30) NOT NULL,
    TipoPagoID INT,
    AlicuotaID INT,
    ProveedorID INT,
    EmpleadoID INT, -- Quien registra la compra
    UbicacionDestinoID INT NOT NULL, -- A qué almacén/sucursal ingresa la compra
    TotalCompra DECIMAL(18, 2) NOT NULL,
    Estado NVARCHAR(50) NOT NULL DEFAULT 'Completada', -- Ej: 'Pendiente', 'Completada', 'Anulada'
    Observacion NVARCHAR(MAX),
    FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID),
    FOREIGN KEY (EmpleadoID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (AlicuotaID) REFERENCES TAlicuota(AlicuotaID),
    FOREIGN KEY (TipoPagoID) REFERENCES TTipoPago(TipoPagoID),
    FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID) 
);

-- Tabla: DetalleCompra
CREATE TABLE DetalleCompra (
    DetalleCompraID INT IDENTITY(1,1) PRIMARY KEY,
    CompraID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    CostoUnitario DECIMAL(18, 2) NOT NULL,
    Subtotal DECIMAL(18, 2) NOT NULL,
    ModoCargo CHAR(2) NOT NULL,
    FOREIGN KEY (CompraID) REFERENCES Compras(CompraID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

-- Tabla: TVenta (Encabezado de la venta)
CREATE TABLE TVenta (
    VentaID BIGINT IDENTITY(1,1) PRIMARY KEY,
    FechaVenta DATETIME NOT NULL DEFAULT GETDATE(),
    ClienteID INT,
    AsesorID INT, -- Quien realiza la venta
    GerenteID INT, -- Quien realiza la venta
    OptometristaID INT, -- Quien realiza la venta
    MarketingID INT, -- Quien realiza la venta
    UbicacionVentaID INT NOT NULL, -- Desde qué sucursal/ubicación se realiza la venta
    SubTotalVenta DECIMAL(18, 2) NOT NULL,
    DescuentoTotal DECIMAL(18, 2) DEFAULT 0,
    ImpuestoTotal DECIMAL(18, 2) DEFAULT 0,
    TotalVenta DECIMAL(18, 2) NOT NULL,
    Jornada NVARCHAR(250),
    Estado NVARCHAR(50) NOT NULL DEFAULT 'Completada', -- Ej: 'Completada', 'Anulada', 'Pendiente'
    EsNotaEntrega BIT NOT NULL DEFAULT 0, -- Indica si esta venta se emite como Nota de Entrega
    NumeroDocumento NVARCHAR(50) UNIQUE, -- Número de factura o nota de entrega
    FOREIGN KEY (ClienteID) REFERENCES TClientes(ClienteID),
    FOREIGN KEY (AsesorID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (GerenteID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (OptometristaID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (MarketingID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (UbicacionVentaID) REFERENCES TUbicaciones(UbicacionID)
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
    Observacion NVARCHAR(250),
    FOREIGN KEY (VentaID) REFERENCES TVenta(VentaID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

-- Tabla: TFormaDePago Tabla donde se almacena los pagos de la venta
CREATE TABLE TFormaDePago (
    FormaPagoID INT IDENTITY(1,1) PRIMARY KEY,
    VentaID BIGINT NOT NULL,
    TipoPagoID INT NOT NULL,
    FechaPago DATETIME NOT NULL,
    MontoPago DECIMAL(18,2) NOT NULL,
    Observacion NVARCHAR(250),
    FOREIGN KEY (VentaID) REFERENCES TVenta(VentaID),
    FOREIGN KEY (TipoPagoID) REFERENCES TTipoPago(TipoPagoID)
);


--Tabla: TFormula para registrar 
CREATE table TFormula (
    FormulaId INT IDENTITY(1,1) PRIMARY KEY,
    VentaID BIGINT NOT NULL,
    EsferaDerecha NVARCHAR(5),
    EsferaIzquierda NVARCHAR(5),
    CilinfroDerecho NVARCHAR(5),
    CilindroIzquierdo NVARCHAR(5),
    EjeDerecho NVARCHAR(5),
    EjeIzquierdo NVARCHAR(5),
    AdicionDerecha NVARCHAR(5),
    AdicionIzquierda NVARCHAR(5),
    H NVARCHAR(5),
    V NVARCHAR(5),
    D NVARCHAR(5),
    P NVARCHAR(5),
    DP NVARCHAR(5),
    ALT NVARCHAR(5),
    Maxi NVARCHAR(5),
    FormulaExterna BIT,
    NombreDoctor NVARCHAR(50),
    FechaRegistro DATETIME DEFAULT GETDATE(),
    Observacion NVARCHAR(MAX),
    FOREIGN KEY (VentaID) REFERENCES TVenta(VentaID)
);



