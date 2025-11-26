-- Actualizado el dia: 23/08/2025
--Se incluyo

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

-- Tabla: TMenuOpciones para almacenar los controles que van a aparecer en el menu de opcionesd del menu principal
-- Su uso es para ocultar o activar los botones del menu de Opciones del formulario principal segùn los permisos
-- otorgados al usuario
CREATE TABLE TMenuOpciones (
    id INT IDENTITY(1,1) PRIMARY KEY, -- ID del Menu
    TextoBoton NVARCHAR(50) NOT NULL, --Texto del Boton
    IconUnicode NVARCHAR(10), -- En caso de ser un icono obtener su tipo
    Categoria INT, -- En que categoria de permiso se encuentra
    Activo BIT --Si esta activo o inactivo el procedimiento
);
GO

-- Tabla: Rol -- Ej: 'Administrador', 'Vendedor', 'Almacén', 'Gerente'
CREATE TABLE TRol (
    RolID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(250) NOT NULL
);
GO

-- Tabla: TPermisos para los menu del formulario
CREATE TABLE TPermisosMenu (
    PermisosID INT IDENTITY(1,1) PRIMARY KEY,
    RolID INT NOT NULL,
    NombreMenu NVARCHAR(100) NOT NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (RolID) REFERENCES TRol(RolID)
);
GO

--Tabla: TAlicuota para registrar los porcentajes de iva
CREATE TABLE TAlicuota (
    AlicuotaID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(12) NOT NULL,
    Alicuota INT NOT NULL
);
GO

-- Tabla: TEstado -- Ej: APARTADO, ABONADO PARCIALMENTE, PAGADO (Venta), 
-- En preparación, Listo para entrega, Entregado, Cancelado, Anulado etc..
CREATE TABLE TEstadoOrden (
    EstadoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL
);
GO

-- Tabla: TTipoMovimientos (Detalle del tipo de movimiento)  
-- Ej: 'Entrada por Compra', 'Salida por Venta', 'Traslado', 
-- 'Ajuste Positivo', 'Ajuste Negativo', 'Devolución Cliente', 'Devolución Proveedor'
CREATE TABLE TTipoMovimientos (
    TipoMovimientoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(120) NOT NULL 
);
GO

--Tabla: TTipoPago para registrar los tipos de pagos 
-- Ejemplo Pago movil, efectivo, contado, creditto, cashea etc..
CREATE TABLE TTipoPago (
    TipoPagoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
);
GO

-- Tabla: TCargoEmpleado -- Asesor, Gerente, Optometrista, Marketing etc...
CREATE TABLE TCargoEmpleado (
    CargoEmpleadoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(250) NOT NULL
);
GO

-- Tabla: Categorias (para productos)
CREATE TABLE TCategorias (
    CategoriaID INT IDENTITY(1,1) PRIMARY KEY,
    NombreCategoria NVARCHAR(50) NOT NULL UNIQUE
);
GO

-- Tabla: TTipoProducto (para clasificar el tipo de productos: "M:Montura, C:Cristal; X:Miselaneos etc. " )
-- Aqui se puede crear todos los tipos de productos y sus opciones
CREATE TABLE TTipoProductos (
    TipoProductoID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(1) NOT NULL UNIQUE,
    Descripcion NVARCHAR(50) NOT NULL UNIQUE,
    TipoInventario INT NOT NULL,
    UnidadVenta INT NOT NULL,
    ConExistencia BIT DEFAULT 1,
    SinExistenciaVenta BIT DEFAULT 1,
    RestringirArticulo BIT DEFAULT 1,
    ImprimirPecio BIT DEFAULT 1,
    Exento BIT DEFAULT 1,
    TipoTasa INT,
    FactorMulti BIT DEFAULT 1,
    FactorMultiValue INT,
    FactorMultiTipo BIT
);
GO


-- Tabla: TSubCategorias (para categorias)
CREATE TABLE TSubCategorias (
    SubCategoriaID INT IDENTITY(1,1) PRIMARY KEY,
    CategoriaID INT NOT NULL,
    NombreSubCategoria NVARCHAR(50) NOT NULL,
    FOREIGN KEY (CategoriaID) REFERENCES TCategorias(CategoriaID)
);
GO

-- 2. TABLAS DE DATOS DE NEGOCIO

-- Tabla: Ubicaciones (Almacenes y Sucursales)
CREATE TABLE TUbicaciones (
    UbicacionID INT IDENTITY(1,1) PRIMARY KEY,
    NombreUbicacion NVARCHAR(100) NOT NULL,
    TipoUbicacion NVARCHAR(50) NOT NULL, -- Ej: 'Almacén Principal', 'Sucursal', 'Punto de Venta'
    Direccion NVARCHAR(255) NOT NULL,
    Rif NVARCHAR(50) NOT NULL UNIQUE,
    Telefono NVARCHAR(50) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    Activa BIT NOT NULL DEFAULT 1, -- Para habilitar/deshabilitar ubicaciones
    Porcentaje INT NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

-- Tabla: Clientes
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

-- Tabla: TEmpresaCliente para almacenar información de las empresas de clientes  
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
    FOREIGN KEY (ClienteID) REFERENCES TCliente(ClienteID)
);
GO

-- Tabla: Proveedores de productos
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


-- Tabla: Productos
--Listo en app
CREATE TABLE TProductos (
    ProductoID INT IDENTITY(1,1) PRIMARY KEY,
    CodigoProducto NVARCHAR(50) NOT NULL UNIQUE,
    Descripcion NVARCHAR(255) NULL,
    CategoriaID INT NOT NULL,
    SubCategoriaID INT NOT NULL,
    Material INT NOT NULL,
    Color INT NOT NULL,
    Foto NVARCHAR(MAX) NULL,
    Activo BIT NOT NULL DEFAULT 1,
    RequiereInventario BIT NOT NULL DEFAULT 1, -- Para servicios que no manejan stock
    FOREIGN KEY (CategoriaID) REFERENCES TCategorias(CategoriaID),
    FOREIGN KEY (SubCategoriaID) REFERENCES TSubCategorias(SubCategoriaID)
);
GO

-- TABLA TProductoProveedor es la tabla intermedia para guardar los datos de los proveedores en caso 
-- de que el producto tenga varios proveedores
CREATE TABLE TProductoProveedor (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CodigoProducto NVARCHAR(50) NOT NULL,
    ProveedorID INT NOT NULL,
    PrecioCompra DECIMAL(18,2) NOT NULL,
    CantidadMinima DECIMAL(18,2) NULL,
    FechaVigencia DATE NOT NULL DEFAULT GETDATE(),
    EsPrincipal BIT DEFAULT 0, -- si este proveedor es el principal del producto
    UNIQUE (CodigoProducto, ProveedorID),
    FOREIGN KEY (CodigoProducto) REFERENCES TProductos(CodigoProducto),
    FOREIGN KEY (ProveedorID) REFERENCES TProveedor(ProveedorID)
);

/*

EJEMPLO DE USO A LA HORA DE BUSCAR LOS DATOS PARA HISTORICO
PARA ESTE PUNTO SE CREA UNA VISTAS QUE HACEN ESTA CONSULTA

Proveedor más barato de un producto:

SELECT TOP 1 p.Nombre, pp.PrecioCompra
FROM ProductoProveedor pp
JOIN TProveedor p ON pp.ProveedorID = p.ProveedorID
WHERE pp.ProductoID = 10
ORDER BY pp.PrecioCompra ASC;


Histórico de precios de un producto por proveedor:

SELECT p.NombreProveedor, pr.NombreProducto, pp.PrecioCompra, pp.FechaVigencia
FROM ProductoProveedor pp
JOIN TProveedor p ON pp.ProveedorID = p.ProveedorID
JOIN TProducto pr ON pp.ProductoID = pr.ProductoID
WHERE pp.ProductoID = 10
ORDER BY pp.FechaVigencia DESC;

*/


-- Tabla: Empleados (Usuarios del Sistema)
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
    Estado BIT NOT NULL DEFAULT 1, -- PARA SABER EL ESTADO DE USUARIO
    Zona INT NULL DEFAULT 0,
    Foto NVARCHAR(MAX) NULL,
    FOREIGN KEY (CargoEmpleadoID) REFERENCES TCargoEmpleado(CargoEmpleadoID)
);
GO

-- Tabla: TLogin Inicio de secion al sistema
CREATE TABLE TLogin (
    LoginID INT IDENTITY(1,1) PRIMARY KEY,
    EmpleadoID INT NOT NULL,
    UbicacionID INT NOT NULL, --Para saber la ubicaciòn del empleado al momento de ingresar al sistema
    RolID INT NOT NULL,
    Usuario NVARCHAR(90) NOT NULL UNIQUE, 
    Clave NVARCHAR(255) NOT NULL, -- Almacenar hash seguro (SHA256, BCrypt),
    Estado BIT DEFAULT 1,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (EmpleadoID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (RolID) REFERENCES TRol(RolID),
    FOREIGN KEY (UbicacionID) REFERENCES TUbicaciones(UbicacionID)
);
GO

-- *** 2. Tablas de Inventario Multi-Ubicación ***

-- Tabla: StockPorUbicacion (Inventario real por producto en cada ubicación)
CREATE TABLE TStock (
    StockID INT IDENTITY(1,1) PRIMARY KEY,
    CodigoProducto NVARCHAR(50) NOT NULL,
    UbicacionID INT NOT NULL,
    StockActual INT NOT NULL DEFAULT 0,
    StockMinimo INT NOT NULL DEFAULT 0, -- Stock mínimo por ubicación
    StockMaximo INT NOT NULL DEFAULT 0, -- Stock maximo por ubicación
    UNIQUE (CodigoProducto, UbicacionID), -- Un producto solo puede tener un registro de stock por ubicación
    FOREIGN KEY (CodigoProducto) REFERENCES TProductos(CodigoProducto),
    FOREIGN KEY (UbicacionID) REFERENCES TUbicaciones(UbicacionID)
);
GO

-- Tabla TPrecios para guardar los preciode de lo productos
CREATE TABLE TPrecios (
    PrecioID INT IDENTITY(1,1) PRIMARY KEY,
    CodigoProducto NVARCHAR(50) NOT NULL,
    UbicacionID INT NOT NULL,
    PVenta DECIMAL(18,2) NOT NULL DEFAULT 0, -- Precio de  Promosion
    PCosto DECIMAL(18,2) NOT NULL DEFAULT 0, -- Precio de  Promosion
    Promocion DECIMAL(18,2) NOT NULL DEFAULT 0, -- Precio de  Promosion
    Descuento DECIMAL(18,2) NOT NULL DEFAULT 0, -- Descuento de productos
    IvaVentaID INT NOT NULL, -- Impuesto iva para va venta
    IvaCompraID INT NOT NULL, -- Impuesto para la Compra
    Tipo NVARCHAR(3) NOT NULL DEFAULT 'Ex', --Por si el producto es Exento o Gravamen
    UNIQUE (CodigoProducto, UbicacionID), -- Un producto solo puede tener un registro de stock por ubicación
    FOREIGN KEY (CodigoProducto) REFERENCES TProductos(CodigoProducto),
    FOREIGN KEY (UbicacionID) REFERENCES TUbicaciones(UbicacionID),
    FOREIGN KEY (IvaVentaID) REFERENCES TAlicuota(AlicuotaID),
    FOREIGN KEY (IvaCompraID) REFERENCES TAlicuota(AlicuotaID)
);
GO

-- Tabla: MovimientosInventario (Registro detallado de todo movimiento de stock)
-- Listo en app
CREATE TABLE THistoricoStock (
    MovimientoID INT IDENTITY(1,1) PRIMARY KEY,
    CodigoProducto NVARCHAR(50) NOT NULL,
    UbicacionOrigenID INT NOT NULL, -- NULL para entradas de compra
    UbicacionDestinoID INT NOT NULL, -- NULL para salidas por venta/ajuste negativo
    TipoMovimientoID INT NOT NULL, -- Ej: 'Entrada por Compra', 'Salida por Venta', 'Traslado', 'Ajuste Positivo', 'Ajuste Negativo', 'Devolución Cliente', 'Devolución Proveedor'
    Cantidad BIGINT NOT NULL,
    FechaMovimiento DATETIME NOT NULL DEFAULT GETDATE(),
    Referencia NVARCHAR(255) NULL, -- Ej: 'Venta #123', 'Compra #456', 'Nota Entrega #789', 'Ajuste Físico', 'Devolución'
    EmpleadoID INT NOT NULL, -- Quién realizó el movimiento
    Notas NVARCHAR(MAX) NULL,
    UNIQUE (CodigoProducto),
    FOREIGN KEY (CodigoProducto) REFERENCES TProductos(CodigoProducto),
    FOREIGN KEY (UbicacionOrigenID) REFERENCES TUbicaciones(UbicacionID),
    FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID),
    FOREIGN KEY (EmpleadoID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (TipoMovimientoID) REFERENCES TTipoMovimientos(TipoMovimientoID)
);
GO

-- Tabla: TrasladosInventario (Encabezado para movimientos entre ubicaciones)
CREATE TABLE TMovimiento (
    TrasladoID INT IDENTITY(1,1) PRIMARY KEY,
    FechaTraslado DATETIME NOT NULL DEFAULT GETDATE(),
    UbicacionOrigenID INT NOT NULL, --Lugar de donde sale la mercancia
    UbicacionDestinoID INT NOT NULL, -- Lugar donde reiben 
    EmpleadoOrigenID INT NOT NULL, --Empleado que despacha la mercancia
    EmpleadoDestinoID INT NOT NULL, -- Empleado que recibe en destino
    Estado NVARCHAR(50) NOT NULL DEFAULT 'Pendiente', -- Ej: 'Pendiente', 'En Tránsito', 'Recibido', 'Cancelado'
    FechaRecepcion DATETIME,
    Notas NVARCHAR(MAX) NULL,
    FOREIGN KEY (UbicacionOrigenID) REFERENCES TUbicaciones(UbicacionID),
    FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID),
    FOREIGN KEY (EmpleadoOrigenID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (EmpleadoDestinoID) REFERENCES TEmpleados(EmpleadoID)
);
GO

-- Tabla: DetalleTraslado (Productos en cada traslado)
CREATE TABLE TDetalleMovimiento (
    DetalleTrasladoID INT IDENTITY(1,1) PRIMARY KEY,
    TrasladoID INT NOT NULL,
    ProductoID INT NOT NULL,
    CantidadSolicitada INT NOT NULL,
    CantidadEnviada INT NOT NULL, -- La que realmente se envió (puede ser diferente a la solicitada)
    CantidadRecibida INT NOT NULL DEFAULT 0,
    Notas NVARCHAR(MAX) NULL,
    FOREIGN KEY (TrasladoID) REFERENCES TMovimiento(TrasladoID),
    FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID)
);
GO

-- *** 3. Tablas de Operaciones ***

-- Tabla: Compras (Encabezado de la compra)
--Listo en app
CREATE TABLE TCompras (
    CompraID INT IDENTITY(1,1),
    OrdenCompra BIGINT PRIMARY KEY,
    FechaCompra DATETIME NOT NULL DEFAULT GETDATE(),
    NumeroControl NVARCHAR(30) NOT NULL UNIQUE,
    NumeroFactura NVARCHAR(30) NOT NULL,
    TipoPagoID INT NOT NULL,
    AlicuotaID INT NOT NULL,
    ProveedorID INT NOT NULL,
    EmpleadoID INT NOT NULL, -- Quien registra la compra
    UbicacionDestinoID INT NOT NULL, -- A qué almacén/sucursal ingresa la compra
    TotalCompra DECIMAL(18, 2) NOT NULL,
    Estado NVARCHAR(50) NOT NULL DEFAULT 'Completada', -- Ej: 'Pendiente', 'Completada', 'Anulada'
    Observacion NVARCHAR(MAX) NULL,
    FOREIGN KEY (ProveedorID) REFERENCES TProveedor(ProveedorID),
    FOREIGN KEY (EmpleadoID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (AlicuotaID) REFERENCES TAlicuota(AlicuotaID),
    FOREIGN KEY (TipoPagoID) REFERENCES TTipoPago(TipoPagoID),
    FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID) 
);
GO

-- Tabla: DetalleCompra
--Listo en app
CREATE TABLE TDetalleCompra (
    DetalleCompraID INT IDENTITY(1,1) PRIMARY KEY,
    OrdenCompra BIGINT NOT NULL,
    ProductoID NVARCHAR(50) NOT NULL,
    Cantidad INT NOT NULL,
    CostoUnitario DECIMAL(18, 2) NOT NULL,
    Descuento DECIMAL(18,2) DEFAULT 0,
    Subtotal DECIMAL(18, 2) NOT NULL,
    ModoCargo CHAR(2) NOT NULL,
    FOREIGN KEY (OrdenCompra) REFERENCES TCompras(OrdenCompra),
    FOREIGN KEY (ProductoID) REFERENCES TProductos(CodigoProducto)
);
GO

-- Tabla: TVenta (Encabezado de la venta)
CREATE TABLE TVenta (
    VentaID BIGINT IDENTITY(1,1),
    OrdenVenta BIGINT PRIMARY KEY, -- Número de factura o nota de entrega
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
    FOREIGN KEY (ClienteID) REFERENCES TCliente(ClienteID),
    FOREIGN KEY (AsesorID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (GerenteID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (OptometristaID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (MarketingID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (UbicacionVentaID) REFERENCES TUbicaciones(UbicacionID)
);
GO

-- Tabla: DetalleVenta
CREATE TABLE TDetalleVenta (
    DetalleVentaID BIGINT IDENTITY(1,1),
    OrdenVenta BIGINT PRIMARY KEY,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18, 2) NOT NULL,
    DescuentoUnitario DECIMAL(18, 2) DEFAULT 0,
    Subtotal DECIMAL(18, 2) NOT NULL,
    Observacion NVARCHAR(250) NULL,
    FOREIGN KEY (OrdenVenta) REFERENCES TVenta(OrdenVenta),
    FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID)
);
GO

--Tabla: TRastreo para  registrar el estatus de ubicaciòn y condicion del producto
CREATE table TSeguimientoVenta (
    SeguimientoID INT IDENTITY(1,1),
    OrdenVenta BIGINT PRIMARY KEY, --NUMERO DE LA VENTA
    EstadoID INT NOT NULL, --APARTADO, PAGADO, EN preparacion, listo para entregar, entregado etc.
    UsuarioResponsable INT NOT NULL, --USUARIO RESPONSABLE DE REALIZAR EL CAMBIO
    Observacion NVARCHAR(100) NULL,
    Ubicacion NVARCHAR(100) NULL, --Donde se encuentra fisicamente el producto (Almacen, Tienda, el laboratorio, el montaje)
    Activo BIT NOT NULL DEFAULT 1, --Para marcar el estado actual 1 o historico 0
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (OrdenVenta) REFERENCES TVenta(OrdenVenta),
    FOREIGN KEY (UsuarioResponsable) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (EstadoID) REFERENCES TEstadoOrden(EstadoID),
);
GO

-- Tabla: TFormaDePago Tabla donde se almacena los pagos de la venta
CREATE TABLE TFormaDePago (
    FormaPagoID INT IDENTITY(1,1),
    OrdenVenta BIGINT PRIMARY KEY,
    TipoPagoID INT NOT NULL,
    FechaPago DATETIME NOT NULL,
    MontoPago DECIMAL(18,2) NOT NULL,
    Observacion NVARCHAR(250) NULL,
    FOREIGN KEY (OrdenVenta) REFERENCES TVenta(OrdenVenta),
    FOREIGN KEY (TipoPagoID) REFERENCES TTipoPago(TipoPagoID)
);
GO

--Tabla: TFormula para registrar 
CREATE TABLE TFormula (
    FormulaId INT IDENTITY(1,1),
    OrdenVenta BIGINT NOT NULL PRIMARY KEY,
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
    FOREIGN KEY (OrdenVenta) REFERENCES TVenta(OrdenVenta)
);
GO

--Tabla: TPagosConConceptoMaterializado para almacenar la informaciòn de busqueda del Reporte Semanal
CREATE TABLE TPagosConConceptoMaterializado (
    ID INT PRIMARY KEY,
    OrdenVenta BIGINT NOT NULL,
    Monto DECIMAL(18,2) NULL,
    MontoPagar DECIMAL(18,2) NULL,
    Porcentaje DECIMAL(5,2) NULL,
    Concepto VARCHAR(20) NULL,
    Apartado DECIMAL(18,2) NULL,
	Modo INT NULL,
	FechaPago DATETIME NOT NULL,
	FechaActualizacion DATETIME DEFAULT GETDATE()
    FOREIGN KEY (OrdenVenta) REFERENCES TVenta(OrdenVenta)
);
GO







--Para incorporarlo al sistema

--Imports System.Data.SqlClient

--Public Class MenuDrawerSQL
--    Public Shared Function CargarOpcionesDesdeSQL(cadenaConexion As String) As (List(Of String), List(Of String))
--        Dim textos As New List(Of String)
--        Dim iconos As New List(Of String)

--        Using conn As New SqlConnection(cadenaConexion)
--            conn.Open()
--            Dim cmd As New SqlCommand("SELECT TextoBoton, IconoUnicode FROM OpcionesMenuDrawer WHERE Activo = 1", conn)
--            Dim reader = cmd.ExecuteReader()
--            While reader.Read()
--                textos.Add(reader("TextoBoton").ToString())
--                iconos.Add(reader("IconoUnicode").ToString())
--            End While
--        End Using

--        Return (textos, iconos)
--    End Function
--End Class

--Para verificar los nombres de las columnas de la tabla
--SELECT name 
--FROM sys.columns 
--WHERE object_id = OBJECT_ID('dbo.VDetalleCompras')
--ORDER BY column_id;




