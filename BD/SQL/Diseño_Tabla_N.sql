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
);

-- Tabla: TEstado -- Ej: APARTADO, ABONADO PARCIALMENTE, PAGADO (Venta), En preparación, Listo para entrega, Entregado, Cancelado, Anulado etc..
CREATE TABLE TEstado (
    EstadoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL
);

-- Tabla: TPermisos para los menu del formulario
CREATE TABLE TPermisos (
    PermisosID INT IDENTITY(1,1) PRIMARY KEY,
    RolID INT NOT NULL,
    NombreMenu NVARCHAR(100) NOT NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (RolID) REFERENCES TRol(RolID)
);

-- Tabla: TCargoEmpleado -- Asesor, Gerente, Optometrista, Marketing etc...
CREATE TABLE TCargoEmpleado (
    CargoEmpleadoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(250) NOT NULL
);

-- Tabla: Ubicaciones (Almacenes y Sucursales)
CREATE TABLE TUbicaciones (
    UbicacionID INT IDENTITY(1,1) PRIMARY KEY,
    NombreUbicacion NVARCHAR(100) NOT NULL UNIQUE,
    TipoUbicacion NVARCHAR(50) NOT NULL, -- Ej: 'Almacén Principal', 'Sucursal', 'Punto de Venta'
    Direccion NVARCHAR(255) NULL,
    Telefono NVARCHAR(20) NULL,
    Email NVARCHAR(50) NULL,
    Activa BIT NOT NULL DEFAULT 1, -- Para habilitar/deshabilitar ubicaciones
    Porcentaje BIT NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE()
);

-- Tabla: Clientes
CREATE TABLE TClientes (
    ClienteID INT IDENTITY(1,1) PRIMARY KEY,
    Cedula NVARCHAR(20) NOT NULL UNIQUE,
    Rif NVARCHAR(60) NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(255) NULL,
    Telefono NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL    
);

-- Tabla: TEmpresaCliente para almacenar información de las empresas de clientes  
CREATE TABLE TEmpresaCliente (
    EmpresaClienteID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID INT NOT NULL, 
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(250) NOT NULL,
    Direccion NVARCHAR(255) NULL,
    Zona NVARCHAR(30) NULL,
    Telefono NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    Rif NVARCHAR(60) NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (ClienteID) REFERENCES TClientes(ClienteID)
);

-- Tabla: Proveedores
CREATE TABLE TProveedores (
    ProveedorID INT IDENTITY(1,1) PRIMARY KEY,
    RUC NVARCHAR(20) NOT NULL UNIQUE,
    NombreEmpresa NVARCHAR(100) NOT NULL,
    RazonSocial NVARCHAR(250) NULL, 
    Contacto NVARCHAR(100) NULL,
    Telefono NVARCHAR(20) NULL,
    Rif NVARCHAR(30) NOT NULL,
    Email NVARCHAR(100) NULL,
    Direccion NVARCHAR(255) NULL,
);

-- Tabla: Categorias (para productos)
CREATE TABLE TCategorias (
    CategoriaID INT IDENTITY(1,1) PRIMARY KEY,
    NombreCategoria NVARCHAR(50) NOT NULL UNIQUE
);

-- Tabla: TSubCategorias (para categorias)
CREATE TABLE TSubCategorias (
    SubCategoriaID INT IDENTITY(1,1) PRIMARY KEY,
    CategoriaID INT NOT NULL,
    NombreSubCategoria NVARCHAR(50) NOT NULL,
    FOREIGN KEY (SubCategoriaID) REFERENCES TCategorias(CategoriaID)
);

-- Tabla: Productos
CREATE TABLE TProductos (
    ProductoID INT IDENTITY(1,1) PRIMARY KEY,
    CodigoProducto NVARCHAR(50) NOT NULL UNIQUE,
    Descripcion NVARCHAR(255) NULL,
    CategoriaID INT NOT NULL,
    PrecioVenta DECIMAL(18, 2) NOT NULL,
    CostoPromedio DECIMAL(18, 2) NOT NULL DEFAULT 0, -- Costo promedio ponderado
    Activo BIT NOT NULL DEFAULT 1,
    RequiereInventario BIT NOT NULL DEFAULT 1, -- Para servicios que no manejan stock
    FOREIGN KEY (CategoriaID) REFERENCES TCategorias(CategoriaID)
);

-- Tabla: Empleados (Usuarios del Sistema)
CREATE TABLE TEmpleados (
    EmpleadoID INT IDENTITY(1,1) PRIMARY KEY,
    Cedula NVARCHAR(20) UNIQUE,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Edad INT NULL,
    Nacionalidad CHAR(1) NULL,
    EstadoCivil CHAR(1) NULL,
    Sexo CHAR(1) NULL,
    FechaNacimiento DATE NULL,
    Direccion NVARCHAR(MAX) NULL,
    CargoEmpleadoID INT NOT NULL,
    Asesor BIT NOT NULL DEFAULT 0,
    Gerente BIT NOT NULL DEFAULT 0,
    Optometrista BIT NOT NULL DEFAULT 0,
    Marketing BIT NOT NULL DEFAULT 0,
    Cobranza BIT NOT NULL DEFAULT 0,
    Estado BIT NOT NULL DEFAULT 1, -- PARA SABER EL ESTADO DE USUARIO
    FOREIGN KEY (CargoEmpleadoID) REFERENCES TCargoEmpleado(CargoEmpleadoID)
);

-- Tabla: TLogin Inicio de secion al sistema
CREATE TABLE TLogin (
    LoginID INT IDENTITY(1,1) PRIMARY KEY,
    EmpleadoID INT NOT NULL,
    UbicacionID INT NOT NULL, --Para saber la ubicaciòn del empleado al momento de ingresar al sistema
    RolID INT NOT NULL,
    Usuario NVARCHAR(90) NOT NULL, 
    Clave NVARCHAR(255) NOT NULL, -- Almacenar hash seguro (SHA256, BCrypt),
    Estado BIT DEFAULT 1,
    FechaRegitro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (EmpleadoID) REFERENCES TClientes(ClienteID),
    FOREIGN KEY (RolID) REFERENCES TRol(RolID),
    FOREIGN KEY (UbicacionID) REFERENCES TUbicaciones(UbicacionID)
);

-- *** 2. Tablas de Inventario Multi-Ubicación ***

-- Tabla: StockPorUbicacion (Inventario real por producto en cada ubicación)
CREATE TABLE TStockProducto (
    StockUbicacionID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL,
    UbicacionID INT NOT NULL,
    StockActual INT NOT NULL DEFAULT 0,
    StockMinimo INT NOT NULL DEFAULT 0, -- Stock mínimo por ubicación
    UNIQUE (ProductoID, UbicacionID), -- Un producto solo puede tener un registro de stock por ubicación
    FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID),
    FOREIGN KEY (UbicacionID) REFERENCES TUbicaciones(UbicacionID)
);

-- Tabla: MovimientosInventario (Registro detallado de todo movimiento de stock)
CREATE TABLE TMovimientosInventario (
    MovimientoID BIGINT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL,
    UbicacionOrigenID INT NOT NULL, -- NULL para entradas de compra
    UbicacionDestinoID INT NOT NULL, -- NULL para salidas por venta/ajuste negativo
    TipoMovimiento NVARCHAR(50) NOT NULL, -- Ej: 'Entrada por Compra', 'Salida por Venta', 'Traslado', 'Ajuste Positivo', 'Ajuste Negativo', 'Devolución Cliente', 'Devolución Proveedor'
    Cantidad INT NOT NULL,
    FechaMovimiento DATETIME NOT NULL DEFAULT GETDATE(),
    Referencia NVARCHAR(255) NULL, -- Ej: 'Venta #123', 'Compra #456', 'Nota Entrega #789', 'Ajuste Físico', 'Devolución'
    EmpleadoID INT NOT NULL, -- Quién realizó el movimiento
    Notas NVARCHAR(MAX) NULL,
    FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID),
    FOREIGN KEY (UbicacionOrigenID) REFERENCES TUbicaciones(UbicacionID),
    FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID),
    FOREIGN KEY (EmpleadoID) REFERENCES TEmpleados(EmpleadoID)
);

-- Tabla: TrasladosInventario (Encabezado para movimientos entre ubicaciones)
CREATE TABLE TTrasladosInventario (
    TrasladoID INT IDENTITY(1,1) PRIMARY KEY,
    FechaTraslado DATETIME NOT NULL DEFAULT GETDATE(),
    UbicacionOrigenID INT NOT NULL,
    UbicacionDestinoID INT NOT NULL,
    EmpleadoOrigenID INT NOT NULL,
    EmpleadoDestinoID INT NOT NULL, -- Empleado que recibe en destino
    Estado NVARCHAR(50) NOT NULL DEFAULT 'Pendiente', -- Ej: 'Pendiente', 'En Tránsito', 'Recibido', 'Cancelado'
    FechaRecepcion DATETIME,
    Notas NVARCHAR(MAX) NULL,
    FOREIGN KEY (UbicacionOrigenID) REFERENCES TUbicaciones(UbicacionID),
    FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID),
    FOREIGN KEY (EmpleadoOrigenID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (EmpleadoDestinoID) REFERENCES TEmpleados(EmpleadoID)
);

-- Tabla: DetalleTraslado (Productos en cada traslado)
CREATE TABLE TDetalleTraslado (
    DetalleTrasladoID INT IDENTITY(1,1) PRIMARY KEY,
    TrasladoID INT NOT NULL,
    ProductoID INT NOT NULL,
    CantidadSolicitada INT NOT NULL,
    CantidadEnviada INT NOT NULL, -- La que realmente se envió (puede ser diferente a la solicitada)
    CantidadRecibida INT NOT NULL DEFAULT 0,
    Notas NVARCHAR(MAX) NULL,
    FOREIGN KEY (TrasladoID) REFERENCES TTrasladosInventario(TrasladoID),
    FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID)
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

-- *** 3. Tablas de Operaciones ***

-- Tabla: Compras (Encabezado de la compra)
CREATE TABLE TCompras (
    CompraID INT IDENTITY(1,1) PRIMARY KEY,
    FechaCompra DATETIME NOT NULL DEFAULT GETDATE(),
    NumeroControl NVARCHAR(30) NOT NULL,
    NumeroFactura NVARCHAR(30) NOT NULL,
    TipoPagoID INT NOT NULL,
    AlicuotaID INT NOT NULL,
    ProveedorID INT NOT NULL,
    EmpleadoID INT NOT NULL, -- Quien registra la compra
    UbicacionDestinoID INT NOT NULL, -- A qué almacén/sucursal ingresa la compra
    TotalCompra DECIMAL(18, 2) NOT NULL,
    Estado NVARCHAR(50) NOT NULL DEFAULT 'Completada', -- Ej: 'Pendiente', 'Completada', 'Anulada'
    Observacion NVARCHAR(MAX) NULL,
    FOREIGN KEY (ProveedorID) REFERENCES TProveedores(ProveedorID),
    FOREIGN KEY (EmpleadoID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (AlicuotaID) REFERENCES TAlicuota(AlicuotaID),
    FOREIGN KEY (TipoPagoID) REFERENCES TTipoPago(TipoPagoID),
    FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID) 
);

-- Tabla: DetalleCompra
CREATE TABLE TDetalleCompra (
    DetalleCompraID INT IDENTITY(1,1) PRIMARY KEY,
    CompraID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    CostoUnitario DECIMAL(18, 2) NOT NULL,
    Subtotal DECIMAL(18, 2) NOT NULL,
    ModoCargo CHAR(2) NOT NULL,
    FOREIGN KEY (CompraID) REFERENCES TCompras(CompraID),
    FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID)
);

-- Tabla: TVenta (Encabezado de la venta)
CREATE TABLE TVenta (
    VentaID BIGINT IDENTITY(1,1) PRIMARY KEY,
    NOrden NVARCHAR(50) UNIQUE, -- Número de factura o nota de entrega
    FechaVenta DATETIME NOT NULL DEFAULT GETDATE(),
    ClienteID INT NOT NULL,
    AsesorID INT NOT NULL, -- Quien realiza la venta
    GerenteID INT NOT NULL, -- Quien realiza la venta
    OptometristaID INT NOT NULL, -- Quien realiza la venta
    MarketingID INT NOT NULL, -- Quien realiza la venta
    UbicacionVentaID INT NOT NULL, -- Desde qué sucursal/ubicación se realiza la venta
    SubTotalVenta DECIMAL(18, 2) NOT NULL,
    DescuentoTotal DECIMAL(18, 2) DEFAULT 0,
    ImpuestoTotal DECIMAL(18, 2) DEFAULT 0,
    TotalVenta DECIMAL(18, 2) NOT NULL,
    Jornada NVARCHAR(250) NULL,
    Estado NVARCHAR(50) NOT NULL DEFAULT 'Completada', -- Ej: 'Completada', 'Anulada', 'Pendiente'
    EsNotaEntrega BIT NOT NULL DEFAULT 0, -- Indica si esta venta se emite como Nota de Entrega
    FOREIGN KEY (ClienteID) REFERENCES TClientes(ClienteID),
    FOREIGN KEY (AsesorID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (GerenteID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (OptometristaID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (MarketingID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (UbicacionVentaID) REFERENCES TUbicaciones(UbicacionID)
);

-- Tabla: DetalleVenta
CREATE TABLE TDetalleVenta (
    DetalleVentaID BIGINT IDENTITY(1,1) PRIMARY KEY,
    VentaID BIGINT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18, 2) NOT NULL,
    DescuentoUnitario DECIMAL(18, 2) DEFAULT 0,
    Subtotal DECIMAL(18, 2) NOT NULL,
    Observacion NVARCHAR(250) NULL,
    FOREIGN KEY (VentaID) REFERENCES TVenta(VentaID),
    FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID)
);

--Tabla: TRastreo para  registrar el estatus de ubicaciòn y condicion del producto
CREATE table TSeguimientoVenta (
    SeguimientoID INT IDENTITY(1,1) PRIMARY KEY,
    VentaID BIGINT NOT NULL, --NUMERO DE LA VENTA
    EstadoID INT NOT NULL, --APARTADO, PAGADO, EN preparacion, listo para entregar, entregado etc.
    UsuarioResponsableID INT NOT NULL, --USUARIO RESPONSABLE DE REALIZAR EL CAMBIO
    Observacion NVARCHAR(100) NULL,
    Ubicacion NVARCHAR(100) NULL, --Donde se encuentra fisicamente el producto (Almacen, Tienda, el laboratorio, el montaje)
    Activo BIT NOT NULL DEFAULT 1, --Para marcar el estado actual 1 o historico 0
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (VentaID) REFERENCES TVenta(VentaID),
    FOREIGN KEY (UsuarioResponsableID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (EstadoID) REFERENCES TEstado(EstadoID),
);

-- Tabla: TFormaDePago Tabla donde se almacena los pagos de la venta
CREATE TABLE TFormaDePago (
    FormaPagoID INT IDENTITY(1,1) PRIMARY KEY,
    VentaID BIGINT NOT NULL,
    TipoPagoID INT NOT NULL,
    FechaPago DATETIME NOT NULL,
    MontoPago DECIMAL(18,2) NOT NULL,
    Observacion NVARCHAR(250) NULL,
    FOREIGN KEY (VentaID) REFERENCES TVenta(VentaID),
    FOREIGN KEY (TipoPagoID) REFERENCES TTipoPago(TipoPagoID)
);


--Tabla: TFormula para registrar 
CREATE TABLE TFormula (
    FormulaId INT IDENTITY(1,1) PRIMARY KEY,
    VentaID BIGINT NOT NULL,
    EsferaDerecha NVARCHAR(5) NULL,
    EsferaIzquierda NVARCHAR(5) NULL,
    CilinfroDerecho NVARCHAR(5) NULL,
    CilindroIzquierdo NVARCHAR(5) NULL,
    EjeDerecho NVARCHAR(5) NULL,
    EjeIzquierdo NVARCHAR(5) NULL,
    AdicionDerecha NVARCHAR(5) NULL,
    AdicionIzquierda NVARCHAR(5) NULL,
    H NVARCHAR(5) NULL,
    V NVARCHAR(5) NULL,
    D NVARCHAR(5) NULL,
    P NVARCHAR(5) NULL,
    DP NVARCHAR(5) NULL,
    ALT NVARCHAR(5) NULL,
    Maxi NVARCHAR(5) NULL,
    FormulaExterna BIT NULL,
    NombreDoctor NVARCHAR(50) NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    Observacion NVARCHAR(MAX) NULL,
    FOREIGN KEY (VentaID) REFERENCES TVenta(VentaID)
);

--Tabla: TPagosConConceptoMaterializado para almacenar la informaciòn de busqueda del Reporte Semanal
CREATE TABLE TPagosConConceptoMaterializado (
    ID INT PRIMARY KEY,
    VentaID BIGINT NOT NULL,
    Monto DECIMAL(18,2) NULL,
    MontoPagar DECIMAL(18,2) NULL,
    Porcentaje DECIMAL(5,2) NULL,
    Concepto VARCHAR(20) NULL,
    Apartado DECIMAL(18,2) NULL,
	Modo INT NULL,
	FechaPago DATETIME NOT NULL,
	FechaActualizacion DATETIME DEFAULT GETDATE()
    FOREIGN KEY (VentaID) REFERENCES TVenta(VentaID)
);



-------------------------------------------------------------------------------------------------------------------------------------------------------------
-----   VISTAS 


-----   PROCEDIMIENTOS


-----   FUNCIONES




