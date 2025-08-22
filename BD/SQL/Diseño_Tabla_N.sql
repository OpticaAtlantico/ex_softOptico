-- Actualizado el dia: 09/08/2025
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

CREATE TABLE TMenuOpciones (
    id INT IDENTITY(1,1) PRIMARY KEY,
    TextoBoton NVARCHAR(50) NOT NULL,
    IconUnicode NVARCHAR(10),
    Categoria INT,
    Activo BIT
);
GO

-- Tabla: Rol -- Ej: 'Administrador', 'Vendedor', 'Almacén', 'Gerente'
CREATE TABLE TRol (
    RolID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(250) NOT NULL
);
GO

-- Tabla: TEstado -- Ej: APARTADO, ABONADO PARCIALMENTE, PAGADO (Venta), En preparación, Listo para entrega, Entregado, Cancelado, Anulado etc..
CREATE TABLE TEstadoOrden (
    EstadoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL
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

-- Tabla: TCargoEmpleado -- Asesor, Gerente, Optometrista, Marketing etc...
CREATE TABLE TCargoEmpleado (
    CargoEmpleadoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(250) NOT NULL
);
GO

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
    ClienteID INT NOT NULL, 
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

-- Tabla: Proveedores
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

-- Tabla: Categorias (para productos)
CREATE TABLE TCategorias (
    CategoriaID INT IDENTITY(1,1) PRIMARY KEY,
    NombreCategoria NVARCHAR(50) NOT NULL UNIQUE
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

-- Tabla: Productos
CREATE TABLE TProductos (
    ProductoID INT IDENTITY(1,1) PRIMARY KEY,
    CodigoProducto NVARCHAR(50) NOT NULL UNIQUE,
    Descripcion NVARCHAR(255) NULL,
    CategoriaID INT NOT NULL,
    SubCategoriaID INT NOT NULL,
    Precio DECIMAL(18, 2) NOT NULL,
    Costo DECIMAL(18, 2) NOT NULL DEFAULT 0, -- Costo promedio ponderado
    Stock INT NOT NULL DEFAULT 0,
    Material INT NOT NULL,
    Color INT NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    RequiereInventario BIT NOT NULL DEFAULT 1, -- Para servicios que no manejan stock
    FOREIGN KEY (CategoriaID) REFERENCES TCategorias(CategoriaID),
    FOREIGN KEY (SubCategoriaID) REFERENCES TSubCategorias(SubCategoriaID)
);
GO

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
CREATE TABLE TStockProducto (
    StockID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL,
    UbicacionID INT NOT NULL,
    StockActual INT NOT NULL DEFAULT 0,
    StockMinimo INT NOT NULL DEFAULT 0, -- Stock mínimo por ubicación
    UNIQUE (ProductoID, UbicacionID), -- Un producto solo puede tener un registro de stock por ubicación
    FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID),
    FOREIGN KEY (UbicacionID) REFERENCES TUbicaciones(UbicacionID)
);
GO

-- Tabla: TTipoMovimientos (Detalle del tipo de movimiento)  Ej: 'Entrada por Compra', 'Salida por Venta', 'Traslado', 'Ajuste Positivo', 'Ajuste Negativo', 'Devolución Cliente', 'Devolución Proveedor'
CREATE TABLE TTipoMovimientos (
    TipoMovimientoID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(120) NOT NULL 
);
GO

-- Tabla: MovimientosInventario (Registro detallado de todo movimiento de stock)
CREATE TABLE TMovimientosInventario (
    MovimientoID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL,
    UbicacionOrigenID INT NOT NULL, -- NULL para entradas de compra
    UbicacionDestinoID INT NOT NULL, -- NULL para salidas por venta/ajuste negativo
    TipoMovimientoID INT NOT NULL, -- Ej: 'Entrada por Compra', 'Salida por Venta', 'Traslado', 'Ajuste Positivo', 'Ajuste Negativo', 'Devolución Cliente', 'Devolución Proveedor'
    Cantidad BIGINT NOT NULL,
    FechaMovimiento DATETIME NOT NULL DEFAULT GETDATE(),
    Referencia NVARCHAR(255) NULL, -- Ej: 'Venta #123', 'Compra #456', 'Nota Entrega #789', 'Ajuste Físico', 'Devolución'
    EmpleadoID INT NOT NULL, -- Quién realizó el movimiento
    Notas NVARCHAR(MAX) NULL,
    FOREIGN KEY (ProductoID) REFERENCES TProductos(ProductoID),
    FOREIGN KEY (UbicacionOrigenID) REFERENCES TUbicaciones(UbicacionID),
    FOREIGN KEY (UbicacionDestinoID) REFERENCES TUbicaciones(UbicacionID),
    FOREIGN KEY (EmpleadoID) REFERENCES TEmpleados(EmpleadoID),
    FOREIGN KEY (TipoMovimientoID) REFERENCES TTipoMovimientos(TipoMovimientoID)
);
GO

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
GO

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
GO

--Tabla: TAlicuota para registrar los porcentajes de iva
CREATE TABLE TAlicuota (
    AlicuotaID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(12) NOT NULL,
    Alicuota INT NOT NULL
);
GO

--Tabla: TTipoPago para registrar los tipos de pagos
CREATE TABLE TTipoPago (
    TipoPagoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
);
GO

-- *** 3. Tablas de Operaciones ***

-- Tabla: Compras (Encabezado de la compra)
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
CREATE TABLE TDetalleCompra (
    DetalleCompraID INT IDENTITY(1,1) PRIMARY KEY,
    OrdenCompra BIGINT NOT NULL,
    ProductoID NVARCHAR(50) NOT NULL,
    Cantidad INT NOT NULL,
    CostoUnitario DECIMAL(18, 2) NOT NULL,
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
-------------------------------------------------------------------------------------------------------------------------------------------------------------
-----   VISTAS 

CREATE OR ALTER VIEW VCategorias AS
    SELECT C.Categoriaid
         , C.NombreCategoria
    FROM TCategorias C

GO

-- SELECT * FROM VCategorias;
CREATE OR ALTER VIEW VEmpleados AS
    SELECT E.EmpleadoID
            , E.Cedula
            , E.Nombre
            , E.Apellido
            , E.Edad
            , E.Nacionalidad
            , E.EstadoCivil
            , E.Sexo
            , E.FechaNacimiento
            , E.Direccion
            , C.Descripcion AS Cargo
            , E.Correo
            , E.Telefono
            , E.Asesor
            , E.Gerente
            , E.Optometrista
            , E.Marketing
            , E.Cobranza
            , E.Estado
            , E.Zona
            , E.Foto
    FROM TEmpleados E INNER JOIN
         TCargoEmpleado C ON 
         E.CargoEmpleadoID = C.CargoEmpleadoID

GO

--VISTA VCargoEmpleado , para visualizar todos los datos del cargos para los empleados
CREATE OR ALTER VIEW VCargoEmpleado AS
    SELECT C.CargoEmpleadoID
         , C.Descripcion
    FROM TCargoEmpleado C

GO

CREATE OR ALTER VIEW VLogin AS
    SELECT L.Usuario
            , L.Clave
            , E.EmpleadoID AS ID
            , E.Cedula
            , E.Nombre
            , E.Apellido
            , C.Descripcion AS Cargo
            , E.Correo
            , U.NombreUbicacion AS Central
            , U.TipoUbicacion AS Clasificacion
            , R.Descripcion AS Permisos
            , L.Estado
    FROM TEmpleados AS E INNER JOIN TLogin AS L 
                ON E.EmpleadoID = L.EmpleadoID 
            INNER JOIN TCargoEmpleado AS C 
                ON E.CargoEmpleadoID = C.CargoEmpleadoID 
            INNER JOIN TUbicaciones AS U 
                ON L.UbicacionID = U.UbicacionID 
            INNER JOIN TRol AS R 
                ON L.RolID = R.RolID

GO

-- SELECT * FROM VLogin;

CREATE OR ALTER VIEW VProductos AS
    SELECT P.ProductoID 
         , P.CodigoProducto AS Codigo
         , P.Descripcion AS Nombre
         , P.Precio
         , C.CategoriaID
         , C.NombreCategoria AS Categoria
         , P.Stock
         , S.NombreSubCategoria as SubCategoria
    FROM   TProductos P INNER JOIN
           TCategorias C ON P.CategoriaID = C.CategoriaID INNER JOIN
           TSubCategorias S ON P.SubCategoriaID = S.SubCategoriaID

GO

CREATE OR ALTER VIEW VProveedor AS
    SELECT  ProveedorID
            , NombreEmpresa
            , RazonSocial
            , Contacto
            , Telefono
            , Sigla
            , Rif
            , Correo
            , Direccion
            , Estado
            , FechaRegistro
    FROM   TProveedor

    GO

CREATE OR ALTER VIEW VCompras AS
    SELECT C.OrdenCompra
            , C.FechaCompra AS Fecha
            , C.NumeroControl AS NControl
            , C.NumeroFactura AS NFactura
            , C.TotalCompra AS SubTotal
            , C.Observacion
            , U.NombreUbicacion AS Sucursal
            , PV.NombreEmpresa AS Proveedor
            , PV.RazonSocial
            , PV.Telefono
            , PV.Contacto
            , PV.Direccion
            , PV.Correo
            , PV.Rif
            , A.Nombre AS IVA
            , P.Nombre AS TPago
    FROM    TCompras C INNER JOIN
            TUbicaciones U ON C.UbicacionDestinoID = U.UbicacionID INNER JOIN
            TTipoPago P ON C.TipoPagoID = P.TipoPagoID INNER JOIN
            TProveedor PV ON C.ProveedorID = PV.ProveedorID INNER JOIN
            TAlicuota A ON C.AlicuotaID = A.AlicuotaID

GO

CREATE OR ALTER VIEW VDetalleCompras AS
    SELECT  D.OrdenCompra
            , P.Descripcion
            , P.CodigoProducto
            , D.Cantidad
            , D.CostoUnitario
            , D.Subtotal
            , D.ModoCargo
    FROM    TDetalleCompra D INNER JOIN
            TProductos P ON D.ProductoID = P.ProductoID

--DATOS DE INICIO PARA LA TABLA
GO
---DATOS PARA LA TABLA ROL 
INSERT INTO TRol (Descripcion) VALUES ('Administrador')
INSERT INTO TRol (Descripcion) VALUES ('Asesor')
INSERT INTO TRol (Descripcion) VALUES ('Gerente Comercial')
INSERT INTO TRol (Descripcion) VALUES ('Gerente Sucursal')
INSERT INTO TRol (Descripcion) VALUES ('Montador')
INSERT INTO TRol (Descripcion) VALUES ('ROOT')
INSERT INTO TRol (Descripcion) VALUES ('Contador')
GO

--DATOS PARA LA TABLA CARGOS DEL EMPLEADO
INSERT INTO TCargoEmpleado (Descripcion) VALUES ('JEFE')
INSERT INTO TCargoEmpleado (Descripcion) VALUES ('Administrador')
INSERT INTO TCargoEmpleado (Descripcion) VALUES ('Contador')
INSERT INTO TCargoEmpleado (Descripcion) VALUES ('Asesor')
INSERT INTO TCargoEmpleado (Descripcion) VALUES ('Gerente Sucursal')
INSERT INTO TCargoEmpleado (Descripcion) VALUES ('Gerente Comercial')
INSERT INTO TCargoEmpleado (Descripcion) VALUES ('Marketing')
INSERT INTO TCargoEmpleado (Descripcion) VALUES ('Cobranza')
INSERT INTO TCargoEmpleado (Descripcion) VALUES ('Montador')
INSERT INTO TCargoEmpleado (Descripcion) VALUES ('Laboratorista')
INSERT INTO TCargoEmpleado (Descripcion) VALUEs ('Empleado')
INSERT INTO TCargoEmpleado (Descripcion) VALUEs ('Root')
GO

--DATOS PARA LA TABLA ESTADO DE LAS ORDENES DESDE QUE SE REALIZA LA VENTA DEL PRODUCTO
INSERT INTO TEstadoOrden (Descripcion) VALUES ('Pedido generado')
INSERT INTO TEstadoOrden (Descripcion) VALUES ('Pendiente de envío a laboratorio')
INSERT INTO TEstadoOrden (Descripcion) VALUES ('Pedido verificado')
INSERT INTO TEstadoOrden (Descripcion) VALUES ('Pedido por enviar')
INSERT INTO TEstadoOrden (Descripcion) VALUES ('Listo para enviar a laboratorio')
INSERT INTO TEstadoOrden (Descripcion) VALUES ('Pedido Recibido en laboratorio')
INSERT INTO TEstadoOrden (Descripcion) VALUES ('Valija enviada')
INSERT INTO TEstadoOrden (Descripcion) VALUES ('Producto en oficinas ZOOM')
INSERT INTO TEstadoOrden (Descripcion) VALUES ('Producto por montar')
INSERT INTO TEstadoOrden (Descripcion) VALUES ('Producto en montaje')
INSERT INTO TEstadoOrden (Descripcion) VALUES ('Producto en tienda')
INSERT INTO TEstadoOrden (Descripcion) VALUES ('Producto entregado')
GO

--DATOS PARA LA TABLA TEMPRESA O SUCURSAL
INSERT INTO TUbicaciones (NombreUbicacion, TipoUbicacion, Direccion, Rif, Telefono, Email, Porcentaje) VALUES ('Atlantico I', 'Sucursal', 'C.C. Plaza Mall, Local 47-A, Planta Baja, Estado Bolivar', 'J-41324802-6', '0414-9864196', 'opticaatlantico@gmail.com', '40')
INSERT INTO TUbicaciones (NombreUbicacion, TipoUbicacion, Direccion, Rif, Telefono, Email, Porcentaje) VALUES ('Atlantico II', 'Sucursal', 'C.C Ciudad Altavista I, local 112, Planta Baja, Ciudad Guayana Estado Bolivar', 'J-50101192-3', '0412-1155609', 'opticaatlantico@gmail.com', '40')
INSERT INTO TUbicaciones (NombreUbicacion, TipoUbicacion, Direccion, Rif, Telefono, Email, Porcentaje) VALUES ('Atlantico III', 'Sucursal', 'C.C. Biblos Center, Local 9-A, Planta Baja, Unare Ciudad Guayana, Estado Bolivar', 'J-50198691-6', '0414-8604432 / 0414-8605625', 'opticaatlantico@gmail.com', '40')
INSERT INTO TUbicaciones (NombreUbicacion, TipoUbicacion, Direccion, Rif, Telefono, Email, Porcentaje) VALUES ('Atlantico IV', 'Sucursal', 'C.C. Ciudad AltaVista II, Local 67, Planta Baja, Ciudad Guayana Estado Bolivar', 'J-50439445-9', '0414-8605625', 'opticaatlantico@gmail.com', '40')
INSERT INTO TUbicaciones (NombreUbicacion, TipoUbicacion, Direccion, Rif, Telefono, Email, Porcentaje) VALUES ('Atlantico V', 'Sucursal', 'C.C. Anakaro, Local 2, Planta Baja, Upata, Estado Bolivar', 'J-50582413-9', '0412-9226338', 'opticaatlantico@gmail.com', '40')
INSERT INTO TUbicaciones (NombreUbicacion, TipoUbicacion, Direccion, Rif, Telefono, Email, Porcentaje) VALUES ('Atlantico VI', 'Sucursal', 'San Felix Ciudad Guayana Estado Bolivar', '0', '0414-9864196', 'opticaatlantico@gmail.com', '40')
INSERT INTO TUbicaciones (NombreUbicacion, TipoUbicacion, Direccion, Rif, Telefono, Email, Porcentaje) VALUES ('Almacen Central', 'Almacen', 'Alta Vista', '1', '0', 'opticaatlantico@gmail.com', '40')
GO

---DATOAS PARA LA TABLA TCategoria
INSERT INTO TCategorias (NombreCategoria) VALUES ('Cristales')
INSERT INTO TCategorias (NombreCategoria) VALUES ('Monturas')
INSERT INTO TCategorias (NombreCategoria) VALUES ('Lentes de Contactos')
INSERT INTO TCategorias (NombreCategoria) VALUES ('Lentes de Sol')
INSERT INTO TCategorias (NombreCategoria) VALUES ('Accesorios')
INSERT INTO TCategorias (NombreCategoria) VALUES ('Otros')
GO

---DATOAS PARA LA TABLA TSubCategoria
INSERT INTO TSubCategorias (CategoriaID, NombreSubCategoria) VALUES ('1', 'Monofocal')
INSERT INTO TSubCategorias (CategoriaID, NombreSubCategoria) VALUES ('1', 'Bifocal')
INSERT INTO TSubCategorias (CategoriaID, NombreSubCategoria) VALUES ('1', 'Multifocal')
INSERT INTO TSubCategorias (CategoriaID, NombreSubCategoria) VALUES ('2', 'Monturas')
INSERT INTO TSubCategorias (CategoriaID, NombreSubCategoria) VALUES ('5', 'Accesorios')
INSERT INTO TSubCategorias (CategoriaID, NombreSubCategoria) VALUES ('3', 'Lentes de Contactos')
INSERT INTO TSubCategorias (CategoriaID, NombreSubCategoria) VALUES ('4', 'Lentes de Sol')
INSERT INTO TSubCategorias (CategoriaID, NombreSubCategoria) VALUES ('6', 'Otros')
GO

--DATOS PARA LA TABLA TTipoPago 
INSERT INTO TTipoPago (Nombre) VALUES ('Divisas')
INSERT INTO TTipoPago (Nombre) VALUES ('Efectivo')
INSERT INTO TTipoPago (Nombre) VALUES ('Punto de Venta')
INSERT INTO TTipoPago (Nombre) VALUES ('Pago Móvil')
INSERT INTO TTipoPago (Nombre) VALUES ('Zelle')
INSERT INTO TTipoPago (Nombre) VALUES ('BioPago')
INSERT INTO TTipoPago (Nombre) VALUES ('Intercambio Comercial')
INSERT INTO TTipoPago (Nombre) VALUES ('Cashea')
INSERT INTO TTipoPago (Nombre) VALUES ('Garantia')
INSERT INTO TTipoPago (Nombre) VALUES ('Transferencia Bancaria')
GO

--TABLA 
INSERT INTO TEmpleados (Cedula, Nombre, Apellido, Edad, Nacionalidad, EstadoCivil, Sexo, FechaNacimiento, Direccion, CargoEmpleadoID, Correo, Telefono, Asesor, Gerente, Optometrista, Marketing, Cobranza, Estado, Zona, Foto)
     VALUES('12133391','Wilmer Jesus','Flore Zavala','50','0','1','0','10/11/1974','San felix','12','wiflores@gmail.com','0412345678','True','True','True','True','True','1','0','Sin Foto')
GO

--TABLA LOGIN
INSERT INTO TLogin (EmpleadoID, UbicacionID, RolID, Usuario, Clave, Estado, FechaRegistro) VALUES ('1','1','6','admin','admin','1','10/10/2025')
GO

--TABLA ALICUOTA 
INSERT INTO TAlicuota (Nombre,Alicuota) VALUES('16%','16')
INSERT INTO TAlicuota (Nombre,Alicuota) VALUES('8%','8')
INSERT INTO TAlicuota (Nombre,Alicuota) VALUES('31%','31')
INSERT INTO TAlicuota (Nombre,Alicuota) VALUES('Exento','0')
INSERT INTO TAlicuota (Nombre,Alicuota) VALUES('Gravamen','1')

INSERT INTO TProductos (CodigoProducto ,Descripcion ,CategoriaID,SubCategoriaID,Precio,Costo,Stock,Material,Color,Activo,RequiereInventario) VALUES('1','BIFOCAL','1','2','100','100','0','1','1','1','0')
INSERT INTO TProductos (CodigoProducto ,Descripcion ,CategoriaID,SubCategoriaID,Precio,Costo,Stock,Material,Color,Activo,RequiereInventario) VALUES('2','lENTES DE SOL','2','2','100','100','0','1','1','1','0')
INSERT INTO TProductos (CodigoProducto ,Descripcion ,CategoriaID,SubCategoriaID,Precio,Costo,Stock,Material,Color,Activo,RequiereInventario) VALUES('3','MULTIFOCAL','1','3','100','100','0','1','1','1','0')
INSERT INTO TProductos (CodigoProducto ,Descripcion ,CategoriaID,SubCategoriaID,Precio,Costo,Stock,Material,Color,Activo,RequiereInventario) VALUES('4','LENTES DE CONTACTO','2','2','100','100','0','1','1','1','0')
INSERT INTO TProductos (CodigoProducto ,Descripcion ,CategoriaID,SubCategoriaID,Precio,Costo,Stock,Material,Color,Activo,RequiereInventario) VALUES('5','MONOFOCAL','1','1','100','100','0','1','1','1','0')
     


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




