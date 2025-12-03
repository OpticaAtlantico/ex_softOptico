-- Created by GitHub Copilot in SSMS - review carefully before executing
-- Actualizado el dia: 23/11/2025
-- Se incluyo

IF NOT EXISTS (
    SELECT * FROM sys.databases 
    WHERE name = 'BD_OPTICA'
    )
BEGIN
    CREATE DATABASE BD_OPTICA;
END
GO

USE BD_OPTICA;
GO

---- Tabla: TMenuOpciones
---- Propósito: almacenar controles del menú principal y permitir activar/ocultar botones según permisos
CREATE TABLE TMenuOpciones (
    id INT IDENTITY(1,1) PRIMARY KEY,
    TextoBoton NVARCHAR(50) NOT NULL,
    IconUnicode NVARCHAR(10),
    Categoria INT,
    Activo BIT
);
GO

---- Tabla: TRol
---- Propósito: catálogo de roles (ej. Administrador, Vendedor) para control de permisos
CREATE TABLE TRol (
    RolID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(250) NOT NULL
);
GO

---- Tabla: TPermisosMenu
---- Propósito: asignar permisos de menú a roles (qué menús están habilitados por rol)
CREATE TABLE TPermisosMenu (
    PermisosID INT IDENTITY(1,1) PRIMARY KEY,
    RolID INT NOT NULL,
    NombreMenu NVARCHAR(100) NOT NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_TPermisosMenu_TRol FOREIGN KEY (RolID) REFERENCES TRol(RolID)
);
GO

---- Tabla: TAlicuota
---- Propósito: almacenar tipos/tasas de IVA (alícuotas) utilizadas en precios y compras
CREATE TABLE TAlicuota (
    AlicuotaID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(12) NOT NULL,
    Alicuota INT NOT NULL
);
GO

---- Tabla: TEstadoOrden
---- Propósito: definir estados para órdenes/ventas (APARTADO, PAGADO, ENTREGADO, etc.)
CREATE TABLE TEstadoOrden (
    EstadoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL
);
GO

---- Tabla: TTipoMovimientos
---- Propósito: catálogo de tipos de movimiento de inventario (entrada, salida, ajuste, traslado)
CREATE TABLE TTipoMovimientos (
    TipoMovimientoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(120) NOT NULL 
);
GO

---- Tabla: TTipoPago
---- Propósito: catálogo de medios de pago (efectivo, transferencia, pago móvil, etc.)
CREATE TABLE TTipoPago (
    TipoPagoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL
);
GO

---- Tabla: TCargoEmpleado
---- Propósito: catálogo de cargos/roles de empleados (Asesor, Gerente, Optometrista)
CREATE TABLE TCargoEmpleado (
    CargoEmpleadoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(250) NOT NULL
);
GO

------ Tabla: TCategorias
------ Propósito: clasificar productos en categorías principales ""
CREATE TABLE TCategorias (
    CategoriaID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(80) NOT NULL
);
GO

---- Tabla: TTipoProductos
---- Propósito: definir tipos de producto y sus propiedades (ej. Montura, Cristal)
CREATE TABLE TTipoProductos (
    TipoProductoID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(1) NOT NULL UNIQUE,
    Descripcion NVARCHAR(50) NOT NULL UNIQUE,
    TipoInventario INT NOT NULL,
    UnidadVenta INT NOT NULL,
    ConExistencia BIT DEFAULT 0,
    SinExistenciaVenta BIT DEFAULT 0,
    RestringirArticulo BIT DEFAULT 0,
    ImprimirPrecio BIT DEFAULT 0,
    ConExento BIT DEFAULT 1,
    alicuotaId INT,
    FactorMulti BIT DEFAULT 0,
    FactorMultiValue INT,
    FactorMultiTipo BIT,
    CategoriaID INT NOT NULL,
    CONSTRAINT FK_TTipoProductos_TCategorias FOREIGN KEY (CategoriaID) REFERENCES TCategorias(CategoriaID)
);
GO

---- Tabla: TGrupo
---- Propósito: clasificar productos en categorías principales
CREATE TABLE TGrupo (
    GrupoID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(15) UNIQUE,
    Descripcion NVARCHAR(50) NOT NULL UNIQUE,
    TipoProducto1 INT,
    TipoProducto2 INT,
    TipoProducto3 INT
);
GO

---- Tabla: TMarca
---- Propósito: clasificar productos en categorías principales
CREATE TABLE TMarca (
    MarcaID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(15) UNIQUE,
    Descripcion NVARCHAR(50) NOT NULL UNIQUE,
    FactorMulti DECIMAL(5,2)
);
GO

---- Tabla: TUbicaciones
---- Propósito: almacenes/sucursales/puntos de venta (multi-ubicación)
CREATE TABLE TUbicaciones (
    UbicacionID INT IDENTITY(1,1) PRIMARY KEY,
    NombreUbicacion NVARCHAR(100) NOT NULL,
    TipoUbicacion NVARCHAR(50) NOT NULL,
    Direccion NVARCHAR(255) NOT NULL,
    Rif NVARCHAR(50) NOT NULL UNIQUE,
    Telefono NVARCHAR(50) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    Activa BIT NOT NULL DEFAULT 1,
    Porcentaje INT NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

---- Tabla: TCliente
---- Propósito: almacenar clientes finales (personas naturales)
CREATE TABLE TCliente (
    ClienteID INT IDENTITY(1,1) PRIMARY KEY,
    CedulaCliente VARCHAR(20) NOT NULL UNIQUE,
    Rif NVARCHAR(60) NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(255) NULL,
    Telefono NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL    
);
GO

---- Tabla: TEmpresaCliente
---- Propósito: datos de empresas vinculadas a clientes (cuando aplica)
CREATE TABLE TEmpresaCliente (
    EmpresaClienteID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID INT NOT NULL UNIQUE, 
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(250) NOT NULL,
    Direccion NVARCHAR(255) NULL,
    Zona NVARCHAR(30) NULL,
    Telefono NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    Rif NVARCHAR(60) NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_TEmpresaCliente_TCliente FOREIGN KEY (ClienteID) REFERENCES TCliente(ClienteID)
);
GO

---- Tabla: TProveedor
---- Propósito: catálogo de proveedores para compras y relaciones de abastecimiento
CREATE TABLE TProveedor (
    ProveedorID INT IDENTITY(1,1) PRIMARY KEY,
    NombreEmpresa NVARCHAR(100) NOT NULL,
    RazonSocial NVARCHAR(250) NULL, 
    Contacto NVARCHAR(100) NULL,
    Telefono NVARCHAR(20) NULL,
    Sigla NVARCHAR(1) NULL,
    Rif NVARCHAR(30) NOT NULL UNIQUE,
    Correo NVARCHAR(100) NULL,
    Estado BIT NOT NULL DEFAULT 1,
    Direccion NVARCHAR(255) NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
);
GO

---- Tabla: TColor
---- Propósito: Almacena los tipos de colores de las monturas
CREATE TABLE TColor (
    ColorID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(30) NOT NULL UNIQUE
);
GO

---- Tabla: TMaterial
---- Propósito: Almacena los tipos de materiales de las monturas
CREATE TABLE TMaterial (
    MaterialID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(50) NOT NULL UNIQUE
);
GO

---- Tabla: TTipoVision
---- Propósito: Almacena los tipos de vision de las monturas
CREATE TABLE TTipoVision (
    TipoVisionID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(50) NOT NULL UNIQUE
);
GO

---- Tabla: TProductos
---- Propósito: catálogo maestro de productos (SKU / código y categorías)
CREATE TABLE TProductos (
    ProductoID INT IDENTITY(1,1) PRIMARY KEY,
    CodigoProducto NVARCHAR(50) NOT NULL UNIQUE,
    TipoProductoID INT NOT NULL, -- RELACIONADO CON LA TABLA TTipoProducto en TipoProductoID
    GrupoID INT NOT NULL, --Relacionado con la tabla TGrupo en GrupoID
    TipoVisionID INT NOT NULL, --Relacionado con la tabla TTipoVision por TipoVisionID
    MarcaID INT, --Relacionado con la tabla TMarca por TMarcaID
    Modelo NVARCHAR(50), 
    ColorID INT, --Relacionado con la tabla TColor por ColorID
    MaterialID INT NOT NULL, --Relacionado a la tabla TMaterial por el MaterialID
    Descripcion NVARCHAR(255) NULL,
    Foto NVARCHAR(MAX) NULL,
    Activo BIT NOT NULL DEFAULT 1,
    RequiereInventario BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_TProductos_TTipoProductoID FOREIGN KEY (TipoProductoID) REFERENCES TTipoProductos(TipoProductoID),
    CONSTRAINT FK_TProductos_TGrupoID FOREIGN KEY (GrupoID) REFERENCES TGrupo(GrupoID),
    CONSTRAINT FK_TProductos_TTipoVisionID FOREIGN KEY (TipoVisionID) REFERENCES TTipoVision(TipoVisionID),
    CONSTRAINT FK_TProductos_TMarcaID FOREIGN KEY (MarcaID) REFERENCES TMarca(MarcaID),
    CONSTRAINT FK_TProductos_TColorID FOREIGN KEY (ColorID) REFERENCES TColor(ColorID),
    CONSTRAINT FK_TProductos_TMaterialID FOREIGN KEY (MaterialID) REFERENCES TMaterial(MaterialID)
);
GO

---- Tabla: TMedidasMonturas
---- Propósito: Almacena las medidas de las monturas 
CREATE TABLE TMedidasMonturas  (
    MedidasMonturasID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL, --Relacionado con la tabla TProductos por el ProductoID
    Horizontal DECIMAL(2,2) NULL,
    Vertical DECIMAL(2,2) NULL,
    Maxima DECIMAL(2,2) NULL,
    Puente DECIMAL(2,2) NULL,
    Observacion NVARCHAR(MAX) NULL,
    CONSTRAINT FK_TMedidasMonturas_TProductos FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID)
);
GO

---- Tabla: TMedidasCristales
---- Propósito: Almacena las medidas de los Cristales "Rango de validación para cristales" 
CREATE TABLE TMedidasCristales  (
    MedidasCristalesID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL, --Relacionado con la tabla TProductos por el ProductoID
    EsferaMax DECIMAL(2,2) NULL,
    EsferaMin DECIMAL(2,2) NULL,
    CilindroMax DECIMAL(2,2) NULL,
    CilindroMin DECIMAL(2,2) NULL,
    EjeMax DECIMAL(2,2) NULL,
    EjeMin DECIMAL(2,2) NULL,
    AdicionMax DECIMAL(2,2) NULL,
    AdicionMin DECIMAL(2,2) NULL,
    AlturaMax DECIMAL(2,2) NULL,
    AlturaMin DECIMAL(2,2) NULL,
    Diametro DECIMAL(2,2) NULL,
    Observacion NVARCHAR(MAX) NULL,
    CONSTRAINT FK_TMedidasCristales_TProductos FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID)
);
GO

---- Tabla: TProductoProveedor
---- Propósito: relación muchos-a-muchos producto ⇄ proveedor con precio de compra
CREATE TABLE TProductoProveedor (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL,
    ProveedorID INT NOT NULL,
    PrecioCompra DECIMAL(18,2) NOT NULL,
    CantidadMinima DECIMAL(18,2) NULL,
    FechaVigencia DATE NOT NULL DEFAULT GETDATE(),
    EsPrincipal BIT DEFAULT 0,
    CONSTRAINT UQ_TProductoProveedor_ProductoProveedor UNIQUE (ProductoID, ProveedorID),
    CONSTRAINT FK_TProductoProveedor_TProductos FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID),
    CONSTRAINT FK_TProductoProveedor_TProveedor FOREIGN KEY (ProveedorID) REFERENCES TProveedor(ProveedorID)
);
GO

---- Tabla: TTipoMoneda
---- Propósito: Almacena los tipo de monedas en sistema
CREATE TABLE TTipoMoneda (
    TipoMonedaID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(3) NOT NULL, 
    Descripcion NVARCHAR(50) NOT NULL,
    TasaCosto DECIMAL(18,2) NOT NULL,
    TasaVenta DECIMAL(18,2) NOT NULL    
);
GO

---- Tabla: TEmpleados
---- Propósito: usuarios/empleados del sistema con su cargo y permisos
CREATE TABLE TEmpleados (
    EmpleadoID INT IDENTITY(1,1) PRIMARY KEY,
    Cedula VARCHAR(20) NOT NULL UNIQUE,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Edad INT NULL,
    Nacionalidad INT NULL DEFAULT 0,
    EstadoCivil INT NULL DEFAULT 0,
    Sexo INT NULL DEFAULT 0,
    FechaNacimiento DATE NULL,
    Direccion NVARCHAR(MAX) NULL,
    CargoEmpleadoID INT NOT NULL,
    Correo NVARCHAR(100) NULL,
    Telefono NVARCHAR(60) NULL,
    Asesor BIT NOT NULL DEFAULT 0,
    Gerente BIT NOT NULL DEFAULT 0,
    Optometrista BIT NOT NULL DEFAULT 0,
    Marketing BIT NOT NULL DEFAULT 0,
    Cobranza BIT NOT NULL DEFAULT 0,
    Estado BIT NOT NULL DEFAULT 1,
    Zona INT NULL DEFAULT 0,
    Foto NVARCHAR(MAX) NULL,
    CONSTRAINT FK_TEmpleados_TCargoEmpleado FOREIGN KEY (CargoEmpleadoID) REFERENCES TCargoEmpleado(CargoEmpleadoID)
);
GO

---- Tabla: TLogin
---- Propósito: registro de accesos/credenciales por empleado y ubicación
CREATE TABLE TLogin (
    LoginID INT IDENTITY(1,1) PRIMARY KEY,
    EmpleadoID INT NOT NULL,
    UbicacionID INT NOT NULL,
    RolID INT NOT NULL,
    Usuario NVARCHAR(90) NOT NULL UNIQUE, 
    Clave NVARCHAR(255) NOT NULL,
    Estado BIT DEFAULT 1,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_TLogin_TEmpleados FOREIGN KEY (EmpleadoID) REFERENCES TEmpleados(EmpleadoID),
    CONSTRAINT FK_TLogin_TRol FOREIGN KEY (RolID) REFERENCES TRol(RolID),
    CONSTRAINT FK_TLogin_TUbicaciones FOREIGN KEY (UbicacionID) REFERENCES TUbicaciones(UbicacionID)
);
GO

---- Tabla: TStock
---- Propósito: stock físico por producto y por ubicación (inventario real)
CREATE TABLE TStock (
    StockID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL,
    UbicacionID INT NOT NULL,
    StockActual INT NOT NULL DEFAULT 0,
    StockMinimo INT NOT NULL DEFAULT 0,
    StockMaximo INT NOT NULL DEFAULT 0,
    CONSTRAINT UQ_TStock_ProductoUbicacion UNIQUE (ProductoID, UbicacionID),
    CONSTRAINT FK_TStock_TProductos FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID),
    CONSTRAINT FK_TStock_TUbicaciones FOREIGN KEY (UbicacionID) REFERENCES TUbicaciones(UbicacionID)
);
GO

---- Tabla: TPrecios
---- Propósito: precios por producto y ubicación, incluyendo IVA y descuentos/promociones
CREATE TABLE TPrecios (
    PrecioID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL,
    Dolar BIT DEFAULT 1,



    UbicacionID INT NOT NULL,
    PVenta DECIMAL(18,2) NOT NULL DEFAULT 0,
    PCosto DECIMAL(18,2) NOT NULL DEFAULT 0,
    Promocion DECIMAL(18,2) NOT NULL DEFAULT 0,
    Descuento DECIMAL(18,2) NOT NULL DEFAULT 0,
    IvaVentaID INT NOT NULL,
    IvaCompraID INT NOT NULL,
    Tipo NVARCHAR(3) NOT NULL DEFAULT 'Ex',
    CONSTRAINT UQ_TPrecios_ProductoUbicacion UNIQUE (ProductoID, UbicacionID),
    CONSTRAINT FK_TPrecios_TProductos FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID),
    CONSTRAINT FK_TPrecios_TUbicaciones FOREIGN KEY (UbicacionID) REFERENCES TUbicaciones(UbicacionID),
    CONSTRAINT FK_TPrecios_TAlicuota_VENTA FOREIGN KEY (IvaVentaID) REFERENCES TAlicuota(AlicuotaID),
    CONSTRAINT FK_TPrecios_TAlicuota_COMPRA FOREIGN KEY (IvaCompraID) REFERENCES TAlicuota(AlicuotaID)
);
GO

---- Tabla: THistoricoStock
---- Propósito: historial detallado de movimientos de inventario (entradas, salidas, ajustes, traslados)
CREATE TABLE THistoricoStock (
    MovimientoID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL,
    UbicacionOrigenID INT NULL,
    UbicacionDestinoID INT NULL,
    TipoMovimientoID INT NOT NULL,
    Cantidad BIGINT NOT NULL,
    FechaMovimiento DATETIME NOT NULL DEFAULT GETDATE(),
    Referencia NVARCHAR(255) NULL,
    EmpleadoID INT NOT NULL,
    Notas NVARCHAR(MAX) NULL,
    CONSTRAINT FK_THistoricoStock_TProductos FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID),
    CONSTRAINT FK_THistoricoStock_UbicacionOrigen FOREIGN KEY (UbicacionOrigenID) REFERENCES TUbicaciones(UbicacionID),
    CONSTRAINT FK_THistoricoStock_UbicacionDestino FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID),
    CONSTRAINT FK_THistoricoStock_TEmpleados FOREIGN KEY (EmpleadoID) REFERENCES TEmpleados(EmpleadoID),
    CONSTRAINT FK_THistoricoStock_TTipoMovimientos FOREIGN KEY (TipoMovimientoID) REFERENCES TTipoMovimientos(TipoMovimientoID)
);
GO

---- Tabla: TMovimiento
---- Propósito: encabezado de traslados entre ubicaciones (documenta envíos entre almacenes)
CREATE TABLE TMovimiento (
    TrasladoID INT IDENTITY(1,1) PRIMARY KEY,
    FechaTraslado DATETIME NOT NULL DEFAULT GETDATE(),
    UbicacionOrigenID INT NOT NULL,
    UbicacionDestinoID INT NOT NULL,
    EmpleadoOrigenID INT NOT NULL,
    EmpleadoDestinoID INT NOT NULL,
    Estado NVARCHAR(50) NOT NULL DEFAULT 'Pendiente',
    FechaRecepcion DATETIME NULL,
    Notas NVARCHAR(MAX) NULL,
    CONSTRAINT FK_TMovimiento_Origen FOREIGN KEY (UbicacionOrigenID) REFERENCES TUbicaciones(UbicacionID),
    CONSTRAINT FK_TMovimiento_Destino FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID),
    CONSTRAINT FK_TMovimiento_EmpleadoOrigen FOREIGN KEY (EmpleadoOrigenID) REFERENCES TEmpleados(EmpleadoID),
    CONSTRAINT FK_TMovimiento_EmpleadoDestino FOREIGN KEY (EmpleadoDestinoID) REFERENCES TEmpleados(EmpleadoID)
);
GO

---- Tabla: TDetalleMovimiento
---- Propósito: líneas de cada traslado (productos y cantidades enviadas/recibidas)
CREATE TABLE TDetalleMovimiento (
    DetalleTrasladoID INT IDENTITY(1,1) PRIMARY KEY,
    TrasladoID INT NOT NULL,
    ProductoID INT NOT NULL,
    CantidadSolicitada INT NOT NULL,
    CantidadEnviada INT NOT NULL,
    CantidadRecibida INT NOT NULL DEFAULT 0,
    Notas NVARCHAR(MAX) NULL,
    CONSTRAINT FK_TDetalleMovimiento_TMovimiento FOREIGN KEY (TrasladoID) REFERENCES TMovimiento(TrasladoID),
    CONSTRAINT FK_TDetalleMovimiento_TProductos FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID)
);
GO

---- Tabla: TCompras
---- Propósito: cabecera de compras (facturas/órdenes de compra) registradas en el sistema
CREATE TABLE TCompras (
    CompraID INT IDENTITY(1,1) PRIMARY KEY,
    OrdenCompra BIGINT NOT NULL UNIQUE,
    FechaCompra DATETIME NOT NULL DEFAULT GETDATE(),
    NumeroControl NVARCHAR(30) NOT NULL UNIQUE,
    NumeroFactura NVARCHAR(30) NOT NULL,
    TipoPagoID INT NOT NULL,
    AlicuotaID INT NOT NULL,
    ProveedorID INT NOT NULL,
    EmpleadoID INT NOT NULL,
    UbicacionDestinoID INT NOT NULL,
    TotalCompra DECIMAL(18, 2) NOT NULL,
    Estado NVARCHAR(50) NOT NULL DEFAULT 'Completada',
    Observacion NVARCHAR(MAX) NULL,
    CONSTRAINT FK_TCompras_TProveedor FOREIGN KEY (ProveedorID) REFERENCES TProveedor(ProveedorID),
    CONSTRAINT FK_TCompras_TEmpleados FOREIGN KEY (EmpleadoID) REFERENCES TEmpleados(EmpleadoID),
    CONSTRAINT FK_TCompras_TAlicuota FOREIGN KEY (AlicuotaID) REFERENCES TAlicuota(AlicuotaID),
    CONSTRAINT FK_TCompras_TTipoPago FOREIGN KEY (TipoPagoID) REFERENCES TTipoPago(TipoPagoID),
    CONSTRAINT FK_TCompras_TUbicaciones FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID)
);
GO

---- Tabla: TDetalleCompra
---- Propósito: líneas de cada compra (producto, cantidad, costo unitario)
CREATE TABLE TDetalleCompra (
    DetalleCompraID INT IDENTITY(1,1) PRIMARY KEY,
    OrdenCompra BIGINT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    CostoUnitario DECIMAL(18, 2) NOT NULL,
    Descuento DECIMAL(18,2) DEFAULT 0,
    Subtotal DECIMAL(18, 2) NOT NULL,
    ModoCargo CHAR(2) NOT NULL,
    CONSTRAINT FK_TDetalleCompra_TCompras FOREIGN KEY (OrdenCompra) REFERENCES TCompras(OrdenCompra),
    CONSTRAINT FK_TDetalleCompra_TProductos FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID)
);
GO

---- Tabla: TVenta
---- Propósito: cabecera de ventas (facturas/nota de entrega) registradas por ubicación y personal
CREATE TABLE TVenta (
    VentaID BIGINT IDENTITY(1,1) PRIMARY KEY,
    OrdenVenta BIGINT NOT NULL UNIQUE,
    FechaVenta DATETIME NOT NULL DEFAULT GETDATE(),
    ClienteID INT NOT NULL,
    AsesorID INT NOT NULL,
    GerenteID INT NOT NULL,
    OptometristaID INT NOT NULL,
    MarketingID INT NOT NULL,
    UbicacionVentaID INT NOT NULL,
    SubTotalVenta DECIMAL(18, 2) NOT NULL,
    DescuentoTotal DECIMAL(18, 2) DEFAULT 0,
    ImpuestoTotal DECIMAL(18, 2) DEFAULT 0,
    TotalVenta DECIMAL(18, 2) NOT NULL,
    Jornada NVARCHAR(250) NULL,
    Estado NVARCHAR(50) NOT NULL DEFAULT 'Completada',
    EsNotaEntrega BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_TVenta_TCliente FOREIGN KEY (ClienteID) REFERENCES TCliente(ClienteID),
    CONSTRAINT FK_TVenta_TAsesor FOREIGN KEY (AsesorID) REFERENCES TEmpleados(EmpleadoID),
    CONSTRAINT FK_TVenta_TGerente FOREIGN KEY (GerenteID) REFERENCES TEmpleados(EmpleadoID),
    CONSTRAINT FK_TVenta_TOptometrista FOREIGN KEY (OptometristaID) REFERENCES TEmpleados(EmpleadoID),
    CONSTRAINT FK_TVenta_TMarketing FOREIGN KEY (MarketingID) REFERENCES TEmpleados(EmpleadoID),
    CONSTRAINT FK_TVenta_TUbicaciones FOREIGN KEY (UbicacionVentaID) REFERENCES TUbicaciones(UbicacionID)
);
GO

---- Tabla: TDetalleVenta
---- Propósito: líneas de venta por orden (producto, cantidad, precio unitario)
CREATE TABLE TDetalleVenta (
    DetalleVentaID BIGINT IDENTITY(1,1) PRIMARY KEY,
    OrdenVenta BIGINT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18, 2) NOT NULL,
    DescuentoUnitario DECIMAL(18, 2) DEFAULT 0,
    Subtotal DECIMAL(18, 2) NOT NULL,
    Observacion NVARCHAR(250) NULL,
    CONSTRAINT FK_TDetalleVenta_TVenta FOREIGN KEY (OrdenVenta) REFERENCES TVenta(OrdenVenta),
    CONSTRAINT FK_TDetalleVenta_TProductos FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID)
);
GO

---- Tabla: TSeguimientoVenta
---- Propósito: historial de estados y ubicación física de la venta (tracking)
CREATE TABLE TSeguimientoVenta (
    SeguimientoID INT IDENTITY(1,1) PRIMARY KEY,
    OrdenVenta BIGINT NOT NULL,
    EstadoID INT NOT NULL,
    UsuarioResponsable INT NOT NULL,
    Observacion NVARCHAR(100) NULL,
    Ubicacion NVARCHAR(100) NULL,
    Activo BIT NOT NULL DEFAULT 1,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_TSeguimientoVenta_TVenta FOREIGN KEY (OrdenVenta) REFERENCES TVenta(OrdenVenta),
    CONSTRAINT FK_TSeguimientoVenta_TEmpleados FOREIGN KEY (UsuarioResponsable) REFERENCES TEmpleados(EmpleadoID),
    CONSTRAINT FK_TSeguimientoVenta_TEstadoOrden FOREIGN KEY (EstadoID) REFERENCES TEstadoOrden(EstadoID)
);
GO

---- Tabla: TFormaDePago
---- Propósito: registrar uno o varios pagos asociados a una venta
CREATE TABLE TFormaDePago (
    FormaPagoID INT IDENTITY(1,1) PRIMARY KEY,
    OrdenVenta BIGINT NOT NULL,
    TipoPagoID INT NOT NULL,
    FechaPago DATETIME NOT NULL,
    MontoPago DECIMAL(18,2) NOT NULL,
    Observacion NVARCHAR(250) NULL,
    CONSTRAINT FK_TFormaDePago_TVenta FOREIGN KEY (OrdenVenta) REFERENCES TVenta(OrdenVenta),
    CONSTRAINT FK_TFormaDePago_TTipoPago FOREIGN KEY (TipoPagoID) REFERENCES TTipoPago(TipoPagoID)
);
GO

---- Tabla: TFormula
---- Propósito: almacenar fórmula óptica asociada a una venta (monitoreo y reproducción)
CREATE TABLE TFormula (
    FormulaId INT IDENTITY(1,1) PRIMARY KEY,
    OrdenVenta BIGINT NOT NULL UNIQUE,
    EsferaDerecha NVARCHAR(5) NULL,
    EsferaIzquierda NVARCHAR(5) NULL,
    CilindroDerecho NVARCHAR(5) NULL,
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
    CONSTRAINT FK_TFormula_TVenta FOREIGN KEY (OrdenVenta) REFERENCES TVenta(OrdenVenta)
);
GO

---- Tabla: TPagosConConceptoMaterializado
---- Propósito: tabla materializada para consultas/reportes de pagos por concepto
CREATE TABLE TPagosConConceptoMaterializado (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    OrdenVenta BIGINT NOT NULL,
    Monto DECIMAL(18,2) NULL,
    MontoPagar DECIMAL(18,2) NULL,
    Porcentaje DECIMAL(5,2) NULL,
    Concepto VARCHAR(20) NULL,
    Apartado DECIMAL(18,2) NULL,
    Modo INT NULL,
    FechaPago DATETIME NOT NULL,
    FechaActualizacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_TPagosConConceptoMaterializado_TVenta FOREIGN KEY (OrdenVenta) REFERENCES TVenta(OrdenVenta)
);
GO















---- Created by GitHub Copilot in SSMS - review carefully before executing
---- Actualizado el dia: 23/11/2025
----Se incluyo

--IF NOT EXISTS (
--    SELECT * FROM SYS.databases 
--    WHERE name = 'BD_OPTICA'
--    )
--BEGIN
--    CREATE DATABASE BD_OPTICA
--END

--GO

--USE BD_OPTICA
--GO



---- *** 1. Tablas Maestras ***

---- Tabla: TMenuOpciones para almacenar los controles que van a aparecer en el menu de opcionesd del menu principal
---- Su uso es para ocultar o activar los botones del menu de Opciones del formulario principal segùn los permisos
---- otorgados al usuario
--CREATE TABLE TMenuOpciones (
--    id INT IDENTITY(1,1) PRIMARY KEY, -- ID del Menu
--    TextoBoton NVARCHAR(50) NOT NULL, --Texto del Boton
--    IconUnicode NVARCHAR(10), -- En caso de ser un icono obtener su tipo
--    Categoria INT, -- En que categoria de permiso se encuentra
--    Activo BIT --Si esta activo o inactivo el procedimiento
--);
--GO

---- Tabla: Rol -- Ej: 'Administrador', 'Vendedor', 'Almacén', 'Gerente'
--CREATE TABLE TRol (
--    RolID INT IDENTITY(1,1) PRIMARY KEY,
--    Descripcion NVARCHAR(250) NOT NULL
--);
--GO

---- Tabla: TPermisos para los menu del formulario
--CREATE TABLE TPermisosMenu (
--    PermisosID INT IDENTITY(1,1) PRIMARY KEY,
--    RolID INT NOT NULL,
--    NombreMenu NVARCHAR(100) NOT NULL,
--    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
--    FOREIGN KEY (RolID) REFERENCES TRol(RolID)
--);
--GO

----Tabla: TAlicuota para registrar los porcentajes de iva
--CREATE TABLE TAlicuota (
--    AlicuotaID INT IDENTITY(1,1) PRIMARY KEY,
--    Nombre NVARCHAR(12) NOT NULL,
--    Alicuota INT NOT NULL
--);
--GO

---- Tabla: TEstado -- Ej: APARTADO, ABONADO PARCIALMENTE, PAGADO (Venta), 
---- En preparación, Listo para entrega, Entregado, Cancelado, Anulado etc..
--CREATE TABLE TEstadoOrden (
--    EstadoID INT IDENTITY(1,1) PRIMARY KEY,
--    Descripcion NVARCHAR(100) NOT NULL
--);
--GO

---- Tabla: TTipoMovimientos (Detalle del tipo de movimiento)  
---- Ej: 'Entrada por Compra', 'Salida por Venta', 'Traslado', 
---- 'Ajuste Positivo', 'Ajuste Negativo', 'Devolución Cliente', 'Devolución Proveedor'
--CREATE TABLE TTipoMovimientos (
--    TipoMovimientoID INT IDENTITY(1,1) PRIMARY KEY,
--    Descripcion VARCHAR(120) NOT NULL 
--);
--GO

----Tabla: TTipoPago para registrar los tipos de pagos 
---- Ejemplo Pago movil, efectivo, contado, creditto, cashea etc..
--CREATE TABLE TTipoPago (
--    TipoPagoID INT IDENTITY(1,1) PRIMARY KEY,
--    Nombre NVARCHAR(50) NOT NULL
--);
--GO

---- Tabla: TCargoEmpleado -- Asesor, Gerente, Optometrista, Marketing etc...
--CREATE TABLE TCargoEmpleado (
--    CargoEmpleadoID INT IDENTITY(1,1) PRIMARY KEY,
--    Descripcion NVARCHAR(250) NOT NULL
--);
--GO

---- Tabla: Categorias (para productos)
--CREATE TABLE TCategorias (
--    CategoriaID INT IDENTITY(1,1) PRIMARY KEY,
--    Codigo VARCHAR(15) UNIQUE,
--    NombreCategoria NVARCHAR(50) NOT NULL UNIQUE,
--    TipoProducto1 INT,
--    TipoProducto2 INT,
--    TipoProducto3 INT
--);
--GO

---- Tabla: TTipoProducto (para clasificar el tipo de productos: "M:Montura, C:Cristal; X:Miselaneos etc. " )
---- Aqui se puede crear todos los tipos de productos y sus opciones
--CREATE TABLE TTipoProductos (
--    TipoProductoID INT IDENTITY(1,1) PRIMARY KEY,
--    Codigo VARCHAR(1) NOT NULL UNIQUE,
--    Descripcion NVARCHAR(50) NOT NULL UNIQUE,
--    TipoInventario INT NOT NULL,
--    UnidadVenta INT NOT NULL,
--    ConExistencia BIT DEFAULT 1,
--    SinExistenciaVenta BIT DEFAULT 1,
--    RestringirArticulo BIT DEFAULT 1,
--    ImprimirPecio BIT DEFAULT 1,
--    Exento BIT DEFAULT 1,
--    TipoTasa INT,
--    FactorMulti BIT DEFAULT 1,
--    FactorMultiValue INT,
--    FactorMultiTipo BIT,
--    CategoriaID INT NOT NULL,
--    FOREIGN KEY (CategoriaID) REFERENCES TCategorias(CategoriaID)
--);
--GO


---- Tabla: TSubCategorias (para categorias)
--CREATE TABLE TSubCategorias (
--    SubCategoriaID INT IDENTITY(1,1) PRIMARY KEY,
--    CategoriaID INT NOT NULL,
--    NombreSubCategoria NVARCHAR(50) NOT NULL,
--    FOREIGN KEY (CategoriaID) REFERENCES TCategorias(CategoriaID)
--);
--GO

---- 2. TABLAS DE DATOS DE NEGOCIO

---- Tabla: Ubicaciones (Almacenes y Sucursales)
--CREATE TABLE TUbicaciones (
--    UbicacionID INT IDENTITY(1,1) PRIMARY KEY,
--    NombreUbicacion NVARCHAR(100) NOT NULL,
--    TipoUbicacion NVARCHAR(50) NOT NULL, -- Ej: 'Almacén Principal', 'Sucursal', 'Punto de Venta'
--    Direccion NVARCHAR(255) NOT NULL,
--    Rif NVARCHAR(50) NOT NULL UNIQUE,
--    Telefono NVARCHAR(50) NOT NULL,
--    Email NVARCHAR(50) NOT NULL,
--    Activa BIT NOT NULL DEFAULT 1, -- Para habilitar/deshabilitar ubicaciones
--    Porcentaje INT NOT NULL,
--    FechaRegistro DATETIME DEFAULT GETDATE()
--);
--GO

---- Tabla: Clientes
--CREATE TABLE TCliente (
--    ClienteID INT IDENTITY(1,1) PRIMARY KEY,
--    CedulaCliente VARCHAR(20) NOT NULL UNIQUE,
--    Rif NVARCHAR(60) NULL,
--    Nombre NVARCHAR(100) NOT NULL,
--    Apellido NVARCHAR(100) NOT NULL,
--    Direccion NVARCHAR(255) NULL,
--    Telefono NVARCHAR(20) NULL,
--    Email NVARCHAR(100) NULL    
--);
--GO

---- Tabla: TEmpresaCliente para almacenar información de las empresas de clientes  
--CREATE TABLE TEmpresaCliente (
--    EmpresaClienteID INT IDENTITY(1,1) PRIMARY KEY,
--    ClienteID INT NOT NULL UNIQUE, 
--    Nombre NVARCHAR(100) NOT NULL,
--    Descripcion NVARCHAR(250) NOT NULL,
--    Direccion NVARCHAR(255) NULL,
--    Zona NVARCHAR(30) NULL,
--    Telefono NVARCHAR(20) NULL,
--    Email NVARCHAR(100) NULL,
--    Rif NVARCHAR(60) NULL,
--    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
--    FOREIGN KEY (ClienteID) REFERENCES TCliente(ClienteID)
--);
--GO

---- Tabla: Proveedores de productos
--CREATE TABLE TProveedor (
--    ProveedorID INT IDENTITY(1,1) PRIMARY KEY,
--    NombreEmpresa NVARCHAR(100) NOT NULL,
--    RazonSocial NVARCHAR(250) NULL, 
--    Contacto NVARCHAR(100) NULL,
--    Telefono NVARCHAR(20) NULL,
--    Sigla NVARCHAR(1) NULL,
--    Rif NVARCHAR(30) NOT NULL UNIQUE,
--    Correo NVARCHAR(100) NULL,
--    Estado BIT NOT NULL DEFAULT 1,
--    Direccion NVARCHAR(255) NULL,
--    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
--);
--GO


---- Tabla: Productos
----Listo en app
--CREATE TABLE TProductos (
--    ProductoID INT IDENTITY(1,1) PRIMARY KEY,
--    CodigoProducto NVARCHAR(50) NOT NULL UNIQUE,
--    Descripcion NVARCHAR(255) NULL,
--    CategoriaID INT NOT NULL,
--    SubCategoriaID INT NOT NULL,
--    Material INT NOT NULL,
--    Color INT NOT NULL,
--    Foto NVARCHAR(MAX) NULL,
--    Activo BIT NOT NULL DEFAULT 1,
--    RequiereInventario BIT NOT NULL DEFAULT 1, -- Para servicios que no manejan stock
--    FOREIGN KEY (CategoriaID) REFERENCES TCategorias(CategoriaID),
--    FOREIGN KEY (SubCategoriaID) REFERENCES TSubCategorias(SubCategoriaID)
--);
--GO

---- TABLA TProductoProveedor es la tabla intermedia para guardar los datos de los proveedores en caso 
---- de que el producto tenga varios proveedores
--CREATE TABLE TProductoProveedor (
--    ID INT IDENTITY(1,1) PRIMARY KEY,
--    CodigoProducto NVARCHAR(50) NOT NULL,
--    ProveedorID INT NOT NULL,
--    PrecioCompra DECIMAL(18,2) NOT NULL,
--    CantidadMinima DECIMAL(18,2) NULL,
--    FechaVigencia DATE NOT NULL DEFAULT GETDATE(),
--    EsPrincipal BIT DEFAULT 0, -- si este proveedor es el principal del producto
--    UNIQUE (CodigoProducto, ProveedorID),
--    FOREIGN KEY (CodigoProducto) REFERENCES TProductos(CodigoProducto),
--    FOREIGN KEY (ProveedorID) REFERENCES TProveedor(ProveedorID)
--);

---- Tabla: Empleados (Usuarios del Sistema)
--CREATE TABLE TEmpleados (
--    EmpleadoID INT IDENTITY(1,1) PRIMARY KEY,
--    Cedula VARCHAR(20) NOT NULL UNIQUE,
--    Nombre NVARCHAR(100) NOT NULL,
--    Apellido NVARCHAR(100) NOT NULL,
--    Edad INT NULL,
--    Nacionalidad INT NULL DEFAULT 0,
--    EstadoCivil INT NULL DEFAULT 0,
--    Sexo INT NULL DEFAULT 0,
--    FechaNacimiento DATE NULL,
--    Direccion NVARCHAR(MAX) NULL,
--    CargoEmpleadoID INT NOT NULL,
--    Correo NVARCHAR(100) NULL,
--    Telefono NVARCHAR(60) NULL,
--    Asesor BIT NOT NULL DEFAULT 0,
--    Gerente BIT NOT NULL DEFAULT 0,
--    Optometrista BIT NOT NULL DEFAULT 0,
--    Marketing BIT NOT NULL DEFAULT 0,
--    Cobranza BIT NOT NULL DEFAULT 0,
--    Estado BIT NOT NULL DEFAULT 1, -- PARA SABER EL ESTADO DE USUARIO
--    Zona INT NULL DEFAULT 0,
--    Foto NVARCHAR(MAX) NULL,
--    FOREIGN KEY (CargoEmpleadoID) REFERENCES TCargoEmpleado(CargoEmpleadoID)
--);
--GO

---- Tabla: TLogin Inicio de secion al sistema
--CREATE TABLE TLogin (
--    LoginID INT IDENTITY(1,1) PRIMARY KEY,
--    EmpleadoID INT NOT NULL,
--    UbicacionID INT NOT NULL, --Para saber la ubicaciòn del empleado al momento de ingresar al sistema
--    RolID INT NOT NULL,
--    Usuario NVARCHAR(90) NOT NULL UNIQUE, 
--    Clave NVARCHAR(255) NOT NULL, -- Almacenar hash seguro (SHA256, BCrypt),
--    Estado BIT DEFAULT 1,
--    FechaRegistro DATETIME DEFAULT GETDATE(),
--    FOREIGN KEY (EmpleadoID) REFERENCES TEmpleados(EmpleadoID),
--    FOREIGN KEY (RolID) REFERENCES TRol(RolID),
--    FOREIGN KEY (UbicacionID) REFERENCES TUbicaciones(UbicacionID)
--);
--GO

---- *** 2. Tablas de Inventario Multi-Ubicación ***

---- Tabla: StockPorUbicacion (Inventario real por producto en cada ubicación)
--CREATE TABLE TStock (
--    StockID INT IDENTITY(1,1) PRIMARY KEY,
--    CodigoProducto NVARCHAR(50) NOT NULL,
--    UbicacionID INT NOT NULL,
--    StockActual INT NOT NULL DEFAULT 0,
--    StockMinimo INT NOT NULL DEFAULT 0, -- Stock mínimo por ubicación
--    StockMaximo INT NOT NULL DEFAULT 0, -- Stock maximo por ubicación
--    UNIQUE (CodigoProducto, UbicacionID), -- Un producto solo puede tener un registro de stock por ubicación
--    FOREIGN KEY (CodigoProducto) REFERENCES TProductos(CodigoProducto),
--    FOREIGN KEY (UbicacionID) REFERENCES TUbicaciones(UbicacionID)
--);
--GO

---- Tabla TPrecios para guardar los preciode de lo productos
--CREATE TABLE TPrecios (
--    PrecioID INT IDENTITY(1,1) PRIMARY KEY,
--    CodigoProducto NVARCHAR(50) NOT NULL,
--    UbicacionID INT NOT NULL,
--    PVenta DECIMAL(18,2) NOT NULL DEFAULT 0, -- Precio de  Promosion
--    PCosto DECIMAL(18,2) NOT NULL DEFAULT 0, -- Precio de  Promosion
--    Promocion DECIMAL(18,2) NOT NULL DEFAULT 0, -- Precio de  Promosion
--    Descuento DECIMAL(18,2) NOT NULL DEFAULT 0, -- Descuento de productos
--    IvaVentaID INT NOT NULL, -- Impuesto iva para va venta
--    IvaCompraID INT NOT NULL, -- Impuesto para la Compra
--    Tipo NVARCHAR(3) NOT NULL DEFAULT 'Ex', --Por si el producto es Exento o Gravamen
--    UNIQUE (CodigoProducto, UbicacionID), -- Un producto solo puede tener un registro de stock por ubicación
--    FOREIGN KEY (CodigoProducto) REFERENCES TProductos(CodigoProducto),
--    FOREIGN KEY (UbicacionID) REFERENCES TUbicaciones(UbicacionID),
--    FOREIGN KEY (IvaVentaID) REFERENCES TAlicuota(AlicuotaID),
--    FOREIGN KEY (IvaCompraID) REFERENCES TAlicuota(AlicuotaID)
--);
--GO

---- Tabla: MovimientosInventario (Registro detallado de todo movimiento de stock)
---- Listo en app
--CREATE TABLE THistoricoStock (
--    MovimientoID INT IDENTITY(1,1) PRIMARY KEY,
--    CodigoProducto NVARCHAR(50) NOT NULL,
--    UbicacionOrigenID INT NULL, -- NULL para entradas de compra
--    UbicacionDestinoID INT NULL, -- NULL para salidas por venta/ajuste negativo
--    TipoMovimientoID INT NOT NULL, -- Ej: 'Entrada por Compra', 'Salida por Venta', 'Traslado', 'Ajuste Positivo', 'Ajuste Negativo', 'Devolución Cliente', 'Devolución Proveedor'
--    Cantidad BIGINT NOT NULL,
--    FechaMovimiento DATETIME NOT NULL DEFAULT GETDATE(),
--    Referencia NVARCHAR(255) NULL, -- Ej: 'Venta #123', 'Compra #456', 'Nota Entrega #789', 'Ajuste Físico', 'Devolución'
--    EmpleadoID INT NOT NULL, -- Quién realizó el movimiento
--    Notas NVARCHAR(MAX) NULL,
--    FOREIGN KEY (CodigoProducto) REFERENCES TProductos(CodigoProducto),
--    FOREIGN KEY (UbicacionOrigenID) REFERENCES TUbicaciones(UbicacionID),
--    FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID),
--    FOREIGN KEY (EmpleadoID) REFERENCES TEmpleados(EmpleadoID),
--    FOREIGN KEY (TipoMovimientoID) REFERENCES TTipoMovimientos(TipoMovimientoID)
--);
--GO

---- Tabla: TrasladosInventario (Encabezado para movimientos entre ubicaciones)
--CREATE TABLE TMovimiento (
--    TrasladoID INT IDENTITY(1,1) PRIMARY KEY,
--    FechaTraslado DATETIME NOT NULL DEFAULT GETDATE(),
--    UbicacionOrigenID INT NOT NULL, --Lugar de donde sale la mercancia
--    UbicacionDestinoID INT NOT NULL, -- Lugar donde reiben 
--    EmpleadoOrigenID INT NOT NULL, --Empleado que despacha la mercancia
--    EmpleadoDestinoID INT NOT NULL, -- Empleado que recibe en destino
--    Estado NVARCHAR(50) NOT NULL DEFAULT 'Pendiente', -- Ej: 'Pendiente', 'En Tránsito', 'Recibido', 'Cancelado'
--    FechaRecepcion DATETIME,
--    Notas NVARCHAR(MAX) NULL,
--    FOREIGN KEY (UbicacionOrigenID) REFERENCES TUbicaciones(UbicacionID),
--    FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID),
--    FOREIGN KEY (EmpleadoOrigenID) REFERENCES TEmpleados(EmpleadoID),
--    FOREIGN KEY (EmpleadoDestinoID) REFERENCES TEmpleados(EmpleadoID)
--);
--GO

---- Tabla: DetalleTraslado (Productos en cada traslado)
--CREATE TABLE TDetalleMovimiento (
--    DetalleTrasladoID INT IDENTITY(1,1) PRIMARY KEY,
--    TrasladoID INT NOT NULL,
--    ProductoID INT NOT NULL,
--    CantidadSolicitada INT NOT NULL,
--    CantidadEnviada INT NOT NULL, -- La que realmente se envió (puede ser diferente a la solicitada)
--    CantidadRecibida INT NOT NULL DEFAULT 0,
--    Notas NVARCHAR(MAX) NULL,
--    FOREIGN KEY (TrasladoID) REFERENCES TMovimiento(TrasladoID),
--    FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID)
--);
--GO

---- *** 3. Tablas de Operaciones ***

---- Tabla: Compras (Encabezado de la compra)
----Listo en app
--CREATE TABLE TCompras (
--    CompraID INT IDENTITY(1,1),
--    OrdenCompra BIGINT PRIMARY KEY,
--    FechaCompra DATETIME NOT NULL DEFAULT GETDATE(),
--    NumeroControl NVARCHAR(30) NOT NULL UNIQUE,
--    NumeroFactura NVARCHAR(30) NOT NULL,
--    TipoPagoID INT NOT NULL,
--    AlicuotaID INT NOT NULL,
--    ProveedorID INT NOT NULL,
--    EmpleadoID INT NOT NULL, -- Quien registra la compra
--    UbicacionDestinoID INT NOT NULL, -- A qué almacén/sucursal ingresa la compra
--    TotalCompra DECIMAL(18, 2) NOT NULL,
--    Estado NVARCHAR(50) NOT NULL DEFAULT 'Completada', -- Ej: 'Pendiente', 'Completada', 'Anulada'
--    Observacion NVARCHAR(MAX) NULL,
--    FOREIGN KEY (ProveedorID) REFERENCES TProveedor(ProveedorID),
--    FOREIGN KEY (EmpleadoID) REFERENCES TEmpleados(EmpleadoID),
--    FOREIGN KEY (AlicuotaID) REFERENCES TAlicuota(AlicuotaID),
--    FOREIGN KEY (TipoPagoID) REFERENCES TTipoPago(TipoPagoID),
--    FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID) 
--);
--GO

---- Tabla: DetalleCompra
----Listo en app
--CREATE TABLE TDetalleCompra (
--    DetalleCompraID INT IDENTITY(1,1) PRIMARY KEY,
--    OrdenCompra BIGINT NOT NULL,
--    ProductoID NVARCHAR(50) NOT NULL,
--    Cantidad INT NOT NULL,
--    CostoUnitario DECIMAL(18, 2) NOT NULL,
--    Descuento DECIMAL(18,2) DEFAULT 0,
--    Subtotal DECIMAL(18, 2) NOT NULL,
--    ModoCargo CHAR(2) NOT NULL,
--    FOREIGN KEY (OrdenCompra) REFERENCES TCompras(OrdenCompra),
--    FOREIGN KEY (ProductoID) REFERENCES TProductos(CodigoProducto)
--);
--GO

---- Tabla: TVenta (Encabezado de la venta)
--CREATE TABLE TVenta (
--    VentaID BIGINT IDENTITY(1,1),
--    OrdenVenta BIGINT PRIMARY KEY, -- Número de factura o nota de entrega
--    FechaVenta DATETIME NOT NULL DEFAULT GETDATE(),
--    ClienteID INT NOT NULL,
--    AsesorID INT NOT NULL, -- Quien realiza la venta
--    GerenteID INT NOT NULL, -- Quien realiza la venta
--    OptometristaID INT NOT NULL, -- Quien realiza la venta
--    MarketingID INT NOT NULL, -- Quien realiza la venta
--    UbicacionVentaID INT NOT NULL, -- Desde qué sucursal/ubicación se realiza la venta
--    SubTotalVenta DECIMAL(18, 2) NOT NULL,
--    DescuentoTotal DECIMAL(18, 2) DEFAULT 0,
--    ImpuestoTotal DECIMAL(18, 2) DEFAULT 0,
--    TotalVenta DECIMAL(18, 2) NOT NULL,
--    Jornada NVARCHAR(250) NULL,
--    Estado NVARCHAR(50) NOT NULL DEFAULT 'Completada', -- Ej: 'Completada', 'Anulada', 'Pendiente'
--    EsNotaEntrega BIT NOT NULL DEFAULT 0, -- Indica si esta venta se emite como Nota de Entrega
--    FOREIGN KEY (ClienteID) REFERENCES TCliente(ClienteID),
--    FOREIGN KEY (AsesorID) REFERENCES TEmpleados(EmpleadoID),
--    FOREIGN KEY (GerenteID) REFERENCES TEmpleados(EmpleadoID),
--    FOREIGN KEY (OptometristaID) REFERENCES TEmpleados(EmpleadoID),
--    FOREIGN KEY (MarketingID) REFERENCES TEmpleados(EmpleadoID),
--    FOREIGN KEY (UbicacionVentaID) REFERENCES TUbicaciones(UbicacionID)
--);
--GO

---- Tabla: DetalleVenta
--CREATE TABLE TDetalleVenta (
--    DetalleVentaID BIGINT IDENTITY(1,1) PRIMARY KEY,
--    OrdenVenta BIGINT NOT NULL,
--    ProductoID INT NOT NULL,
--    Cantidad INT NOT NULL,
--    PrecioUnitario DECIMAL(18, 2) NOT NULL,
--    DescuentoUnitario DECIMAL(18, 2) DEFAULT 0,
--    Subtotal DECIMAL(18, 2) NOT NULL,
--    Observacion NVARCHAR(250) NULL,
--    FOREIGN KEY (OrdenVenta) REFERENCES TVenta(OrdenVenta),
--    FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID)
--);
--GO

----Tabla: TRastreo para  registrar el estatus de ubicaciòn y condicion del producto
--CREATE table TSeguimientoVenta (
--    SeguimientoID INT IDENTITY(1,1),
--    OrdenVenta BIGINT PRIMARY KEY, --NUMERO DE LA VENTA
--    EstadoID INT NOT NULL, --APARTADO, PAGADO, EN preparacion, listo para entregar, entregado etc.
--    UsuarioResponsable INT NOT NULL, --USUARIO RESPONSABLE DE REALIZAR EL CAMBIO
--    Observacion NVARCHAR(100) NULL,
--    Ubicacion NVARCHAR(100) NULL, --Donde se encuentra fisicamente el producto (Almacen, Tienda, el laboratorio, el montaje)
--    Activo BIT NOT NULL DEFAULT 1, --Para marcar el estado actual 1 o historico 0
--    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
--    FOREIGN KEY (OrdenVenta) REFERENCES TVenta(OrdenVenta),
--    FOREIGN KEY (UsuarioResponsable) REFERENCES TEmpleados(EmpleadoID),
--    FOREIGN KEY (EstadoID) REFERENCES TEstadoOrden(EstadoID)
--);
--GO

---- Tabla: TFormaDePago Tabla donde se almacena los pagos de la venta
--CREATE TABLE TFormaDePago (
--    FormaPagoID INT IDENTITY(1,1),
--    OrdenVenta BIGINT PRIMARY KEY,
--    TipoPagoID INT NOT NULL,
--    FechaPago DATETIME NOT NULL,
--    MontoPago DECIMAL(18,2) NOT NULL,
--    Observacion NVARCHAR(250) NULL,
--    FOREIGN KEY (OrdenVenta) REFERENCES TVenta(OrdenVenta),
--    FOREIGN KEY (TipoPagoID) REFERENCES TTipoPago(TipoPagoID)
--);
--GO

----Tabla: TFormula para registrar 
--CREATE TABLE TFormula (
--    FormulaId INT IDENTITY(1,1),
--    OrdenVenta BIGINT NOT NULL PRIMARY KEY,
--    EsferaDerecha NVARCHAR(5) NULL,
--    EsferaIzquierda NVARCHAR(5) NULL,
--    CilinfroDerecho NVARCHAR(5) NULL,
--    CilindroIzquierdo NVARCHAR(5) NULL,
--    EjeDerecho NVARCHAR(5) NULL,
--    EjeIzquierdo NVARCHAR(5) NULL,
--    AdicionDerecha NVARCHAR(5) NULL,
--    AdicionIzquierda NVARCHAR(5) NULL,
--    H NVARCHAR(5) NULL,
--    V NVARCHAR(5) NULL,
--    D NVARCHAR(5) NULL,
--    P NVARCHAR(5) NULL,
--    DP NVARCHAR(5) NULL,
--    ALT NVARCHAR(5) NULL,
--    Maxi NVARCHAR(5) NULL,
--    FormulaExterna BIT NULL,
--    NombreDoctor NVARCHAR(50) NULL,
--    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
--    Observacion NVARCHAR(MAX) NULL,
--    FOREIGN KEY (OrdenVenta) REFERENCES TVenta(OrdenVenta)
--);
--GO

----Tabla: TPagosConConceptoMaterializado para almacenar la informaciòn de busqueda del Reporte Semanal
--CREATE TABLE TPagosConConceptoMaterializado (
--    ID INT PRIMARY KEY,
--    OrdenVenta BIGINT NOT NULL,
--    Monto DECIMAL(18,2) NULL,
--    MontoPagar DECIMAL(18,2) NULL,
--    Porcentaje DECIMAL(5,2) NULL,
--    Concepto VARCHAR(20) NULL,
--    Apartado DECIMAL(18,2) NULL,
--	Modo INT NULL,
--	FechaPago DATETIME NOT NULL,
--	FechaActualizacion DATETIME DEFAULT GETDATE(),
--    FOREIGN KEY (OrdenVenta) REFERENCES TVenta(OrdenVenta)
--);
--GO

--/*

--EJEMPLO DE USO A LA HORA DE BUSCAR LOS DATOS PARA HISTORICO
--PARA ESTE PUNTO SE CREA UNA VISTAS QUE HACEN ESTA CONSULTA

--Proveedor más barato de un producto:

--SELECT TOP 1 p.Nombre, pp.PrecioCompra
--FROM ProductoProveedor pp
--JOIN TProveedor p ON pp.ProveedorID = p.ProveedorID
--WHERE pp.ProductoID = 10
--ORDER BY pp.PrecioCompra ASC;


--Histórico de precios de un producto por proveedor:

--SELECT p.NombreProveedor, pr.NombreProducto, pp.PrecioCompra, pp.FechaVigencia
--FROM ProductoProveedor pp
--JOIN TProveedor p ON pp.ProveedorID = p.ProveedorID
--JOIN TProducto pr ON pp.ProductoID = pr.ProductoID
--WHERE pp.ProductoID = 10
--ORDER BY pp.FechaVigencia DESC;

--*/



----Para incorporarlo al sistema

----Imports System.Data.SqlClient

----Public Class MenuDrawerSQL
----    Public Shared Function CargarOpcionesDesdeSQL(cadenaConexion As String) As (List(Of String), List(Of String))
----        Dim textos As New List(Of String)
----        Dim iconos As New List(Of String)

----        Using conn As New SqlConnection(cadenaConexion)
----            conn.Open()
----            Dim cmd As New SqlCommand("SELECT TextoBoton, IconoUnicode FROM OpcionesMenuDrawer WHERE Activo = 1", conn)
----            Dim reader = cmd.ExecuteReader()
----            While reader.Read()
----                textos.Add(reader("TextoBoton").ToString())
----                iconos.Add(reader("IconoUnicode").ToString())
----            End While
----        End Using

----        Return (textos, iconos)
----    End Function
----End Class

----Para verificar los nombres de las columnas de la tabla
----SELECT name 
----FROM sys.columns 
----WHERE object_id = OBJECT_ID('dbo.VDetalleCompras')
----ORDER BY column_id;




