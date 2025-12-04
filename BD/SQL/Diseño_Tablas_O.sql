-- Created by GitHub Copilot in SSMS - review carefully before executing
-- Actualizado el dia: 23/11/2025
-- Se incluyo

IF NOT EXISTS (
    SELECT * FROM sys.databases 
    WHERE name = 'BDOPTICA'
    )
BEGIN
    CREATE DATABASE BDOPTICA;
END
GO

USE BDOPTICA;
GO

---------------------------------------------------------------------------
-- TABLAS MAESTRAS: 
-- SON UTILIZADAS PARA MOSTRAR LAS OPCIONES EN UN COMBOBOX POR EJEMPLO, O SOLO 
-- MUESTRAN INFORMACION SIN ESTAR RELACIONADAS CON OTRAS, EJEMPLO: TABLA TGenero
-- Y COMO DATOS ALMACENA "HOMBRE O MASCULINO, MUJER O FEMENINO, NIÑO O NIÑA"
---------------------------------------------------------------------------

-- TABLA: TAlicuota
-- Utilizada para almacenar los datos de impuestos e IVA
CREATE TABLE TAlicuota (
    idAlicuota INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(150) NOT NULL,
    alicuota INT NOT NULL
);

-- TABLA: TEstadoOrden
--  Almacena los tipo de estado de las ordenes por ejemplo: (Apartado, Pagado, etc.)
CREATE TABLE TEstadoOrden (
    idEstadoOrden INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(150) NOT NULL
);

-- TABLA: TTipoPago
--  Almacena los tipo de pagos por ejemplo: (efectivo, transferencia, pago movil, etc.)
CREATE TABLE TTipoPago (
    idTipoPago INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(150) NOT NULL
);

-- TABLA: TTipoMovimiento
-- Utilizada para almacenar los diferentes tipos de mantenimiento por ejemplo: (entrada, salida, ajuste, traslado)
CREATE TABLE TTipoMovimiento (
    idTipoMovimiento INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(150) NOT NULL,
);

------ AREA DE PRODUCTO E INVENTARIO -------------

---- Tabla: TColor
---- Propósito: Almacena los tipos de colores de las monturas
CREATE TABLE TColor (
    idColor INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(50) NOT NULL UNIQUE
);

---- Tabla: TMaterial
---- Propósito: Almacena los tipos de materiales de las monturas
CREATE TABLE TMaterial (
    idMaterial INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(50) NOT NULL UNIQUE
);

-- TABLA: TCategoria
-- Utilizada para almacenar los datos de las categorias de los productos
CREATE TABLE TCategoria (
    idCategoria INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(150) NOT NULL,
);

---- Tabla: TTipoVisionMontura
---- Propósito: Almacena los tipos de vision de las monturas
CREATE TABLE TTipoVisionMontura (
    idTVMontura INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(50) NOT NULL UNIQUE
);

---- Tabla: TTipoVisionCristales
---- Propósito: Almacena los tipos de vision de los Cristales
CREATE TABLE TTipoVisionCristal (
    idTVCristal INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(50) NOT NULL UNIQUE
);

-- TABLA: TEstadoOrden
--  Almacena los tipo de estado de las ordenes por ejemplo: (Apartado, Pagado, etc.)
CREATE TABLE TZona (
    idZona INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(150) NOT NULL
);

---------------------------------------------------------------------------
-- TABLAS UNICAS: 
-- SON UTILIZADAS PARA MOSTRAR LOS DATOS UNICOS QUE SON UTILIZADOS POR OTRAS TABLAS 
-- DE MAYOR FUERZA POR EJEMPLO: TABLA TRol
-- Y COMO DATOS ALMACENA "ADMINISTRADOR, GERENTE, VENDEDOR ETC." Y SON LLAMADAS DESDE OTRA TABLA
-- RELECIONADAS POR EL ID
---------------------------------------------------------------------------

-- TABLA: TCargos
-- Utilizada para almacenar los diferentes Cargos del Empleado
CREATE TABLE TCargo (
    idCargo INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(150) NOT NULL
);

-- TABLA: TRol
-- Utilizada para almacenar los diferentes Roles del Empleado
CREATE TABLE TRol (
    idRol INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(150) NOT NULL
);

------ AREA DE PRODUCTO E INVENTARIO -------------

---- Tabla: TGrupo
---- Propósito: clasificar productos en categorías principales
CREATE TABLE TGrupo (
    idGrupo INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(15) UNIQUE,
    descripcion NVARCHAR(50) NOT NULL UNIQUE,
    tipoProducto1 INT,
    tipoProducto2 INT,
    tipoProducto3 INT
);

---- Tabla: TMarca
---- Propósito: clasificar productos en categorías principales
CREATE TABLE TMarca (
    idMarca INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(15) UNIQUE,
    descripcion NVARCHAR(50) NOT NULL UNIQUE,
    factorMulti DECIMAL(5,2)
);

---------------------------------------------------------------

---- Tabla: TUbicaciones
---- Propósito: almacenes/sucursales/puntos de venta (multi-ubicación)
CREATE TABLE TCompania (
    idCompania INT IDENTITY(1,1) PRIMARY KEY,
    codigo INT NOT NULL UNIQUE,
    
);



---------------------------------------------------------------------------
-- TABLAS MAYORES: 
-- SON UTILIZADAS PARA ALMACENAR DATOS UTILIZANDO LAS TABLAS UNICAS Y LOS DATOS
-- DE SU PROPIA TABLA: TABLA TVentas
-- Y COMO DATOS ALMACENA "Producto, cliente, pagos etc" Y SON RELACIONADAS CON LA TABLA
-- RELECIONADAS POR EL ID CON LAS TABLAS "TEMPLEADOS, TPRODUCTOS"
---------------------------------------------------------------------------

---- Tabla: TSucursal
---- Propósito: sucursales
CREATE TABLE TSucursal (
    idSucursal INT IDENTITY(1,1) PRIMARY KEY,
    codigo INT NOT NULL UNIQUE,
    descripcion NVARCHAR(100) NOT NULL,
    tipo NVARCHAR(50) NOT NULL,
    direccion NVARCHAR(255) NOT NULL,
    idZona INT NOT NULL, -- Relacionado con la tabla TZona por idZona
    rif NVARCHAR(50) NOT NULL UNIQUE,
    telefono NVARCHAR(50) NOT NULL,
    email NVARCHAR(50) NOT NULL,
    activa BIT NOT NULL DEFAULT 1,
    fechaRegistro DATETIME DEFAULT GETDATE(),
    idCompania INT, -- Relacionado con la tabla TCompania por el idCompania
);

------ AREA DE PRODUCTO E INVENTARIO -------------

-- TABLA: TTipoProducto
-- Utilizada para almacenar las configuraciones de los tipos del producto
CREATE TABLE TTipoProducto (
    idTipoProducto INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(150) NOT NULL,
    tipoInventario INT NOT NULL, -- "CRISTALES, MONTURAS, LENTES DE CONTACTOS O GENERICOS"
    unidadVenta INT NOT NULL, -- Cuanto productos deben mostrarce en la orden de venta 
    conExistencia BIT DEFAULT 0, -- Permitir vender con existencia
    sinExistenciaVenta BIT DEFAULT 0, -- Permitir vender sin existencia en la Orden de Trabajo
    restringirArticulo BIT DEFAULT 0, -- Restringir la entrega de la orden si el articulo no tiene existencia 
    imprimirPrecio BIT DEFAULT 0, -- Imprimir el precio en la orden 
    conExento BIT DEFAULT 0, -- Articulos son exentos de impuesto
    idAlicuota INT, -- Tipo de tasa
    factorMulti BIT DEFAULT 0, -- Usa factor multiplicador?
    factorMultiValue INT, -- Asignar valor en caso de ser por tipo de producto
    factorMultiTipo BIT, -- Usar factor multiplicador por tipo de producto o por marca
    idCategoria INT NOT NULL,
    CONSTRAINT FK_TTipoProducto_TCategoria FOREIGN KEY (idCategoria) REFERENCES TCategoria(idCategoria)
);

---- Tabla: TProductos
---- Propósito: catálogo maestro de productos (SKU / código y categorías)
CREATE TABLE TProductos (
    idProducto INT IDENTITY(1,1) PRIMARY KEY,
    codigo NVARCHAR(50) NOT NULL UNIQUE,
    idTipoProducto INT NOT NULL, -- Relacionado con la tabla TTipoProducto en idTipoProducto
    idGrupo INT NOT NULL, --Relacionado con la tabla TGrupo en idGrupo
    idTVMontura INT NOT NULL, --Relacionado con la tabla TTipoVisionMontura por idTVMontura
    idTVCristal INT NOT NULL, --Relacionado con la tabla TTipoVisionCristal por idTVCristal
    idMarca INT, --Relacionado con la tabla TMarca por idTMarca
    idColor INT, --Relacionado con la tabla TColor por idColor
    idMaterial INT NOT NULL, --Relacionado a la tabla TMaterial por el idMaterial
    modelo NVARCHAR(50), 
    descripcion NVARCHAR(255) NULL,
    foto NVARCHAR(MAX) NULL,
    activo BIT NOT NULL DEFAULT 1,
    requiereInventario BIT NOT NULL DEFAULT 1,
    
    CONSTRAINT FK_TProductos_TTipoProductoID FOREIGN KEY (TipoProductoID) REFERENCES TTipoProducto(TipoProductoID),
    CONSTRAINT FK_TProductos_TGrupoID FOREIGN KEY (GrupoID) REFERENCES TGrupo(idGrupo),
    CONSTRAINT FK_TProductos_TTipoVisionID FOREIGN KEY (TipoVisionID) REFERENCES TTipoVision(idTipoVision),
    CONSTRAINT FK_TProductos_TMarcaID FOREIGN KEY (MarcaID) REFERENCES TMarca(MarcaID),
    CONSTRAINT FK_TProductos_TColorID FOREIGN KEY (ColorID) REFERENCES TColor(ColorID),
    CONSTRAINT FK_TProductos_TMaterialID FOREIGN KEY (MaterialID) REFERENCES TMaterial(MaterialID)
);

---- Tabla: TMedidasMonturas
---- Propósito: Almacena las medidas de las monturas 
CREATE TABLE TMedidasMonturas  (
    idMedMonturas INT IDENTITY(1,1) PRIMARY KEY,
    idProducto INT NOT NULL, --Relacionado con la tabla TProductos por el ProductoID
    horizontal DECIMAL(5,2) NULL,
    vertical DECIMAL(5,2) NULL,
    maxima DECIMAL(5,2) NULL,
    puente DECIMAL(5,2) NULL,
    observacion NVARCHAR(MAX) NULL,
    CONSTRAINT FK_TMedMonturas_TProductos FOREIGN KEY (idProducto) REFERENCES TProductos(idProducto)
);

---- Tabla: TMedidasCristales
---- Propósito: Almacena las medidas de los Cristales "Rango de validación para cristales" 
---- Cabe mensionar que esta tabla medidas de cristales no es la medida que el optometrista coloca en las
---- Formula despues del estudio al cliente
CREATE TABLE TMedidasCristales  (
    idMedCristales INT IDENTITY(1,1) PRIMARY KEY,
    idProducto INT NOT NULL, --Relacionado con la tabla TProductos por el ProductoID
    esferaMax DECIMAL(5,2) NULL,
    esferaMin DECIMAL(5,2) NULL,
    cilindroMax DECIMAL(5,2) NULL,
    cilindroMin DECIMAL(5,2) NULL,
    ejeMax DECIMAL(5,2) NULL,
    ejeMin DECIMAL(5,2) NULL,
    adicionMax DECIMAL(5,2) NULL,
    adicionMin DECIMAL(5,2) NULL,
    alturaMax DECIMAL(5,2) NULL,
    alturaMin DECIMAL(5,2) NULL,
    diametro DECIMAL(5,2) NULL,
    observacion NVARCHAR(MAX) NULL,
    CONSTRAINT FK_TMedidasCristales_TProductos FOREIGN KEY (idProducto) REFERENCES TProductos(idProducto)
);

---- Tabla: TEmpleados
---- Propósito: usuarios/empleados del sistema con su cargo y permisos
CREATE TABLE TEmpleado (
    idEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    codigo NCHAR(5) NOT NULL UNIQUE,
    cedula VARCHAR(20) NOT NULL UNIQUE,
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100) NOT NULL,
    fechaIngreso DATE NOT NULL, 
    examen BIT DEFAULT 0,
    especialidad NVARCHAR(120) NULL,
    licencia NVARCHAR(30) NULL,
    idCargo INT NOT NULL, -- Relaci9onado con la tabla TCargo por el idCargo
    direccion NVARCHAR(MAX) NULL,
    telefono NVARCHAR(60) NULL,
    comision DECIMAL(5,2) DEFAULT 0.00,
    estado BIT NOT NULL DEFAULT 1,
    foto NVARCHAR(MAX) NULL,
    CONSTRAINT FK_TEmpleados_TCargo FOREIGN KEY (idCargo) REFERENCES TCargo(idCargo)
);

---- Tabla: TLogin
---- Propósito: registro de accesos/credenciales por empleado y ubicación
CREATE TABLE TLogin (
    idLogin INT IDENTITY(1,1) PRIMARY KEY,
    idEmpleado INT NOT NULL, -- Relacionado con la tabla TEmpleados por el idEmpleado
    idUbicacion INT NOT NULL, -- Relacionado con la tabla TUbicacion por el idUbicacion
    idRol INT NOT NULL, -- Relacionado con la tabla TRol por el idRol
    Usuario NVARCHAR(90) NOT NULL UNIQUE, 
    Clave NVARCHAR(255) NOT NULL,
    Estado BIT DEFAULT 1,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_TLogin_TEmpleados FOREIGN KEY (EmpleadoID) REFERENCES TEmpleados(EmpleadoID),
    CONSTRAINT FK_TLogin_TRol FOREIGN KEY (RolID) REFERENCES TRol(RolID),
    CONSTRAINT FK_TLogin_TUbicaciones FOREIGN KEY (UbicacionID) REFERENCES TUbicaciones(UbicacionID)
);


---- Tabla: TTipoMoneda
---- Propósito: Almacena los tipo de monedas en sistema
CREATE TABLE TTipoMoneda (
    idTipoMoneda INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(3) NOT NULL, 
    Descripcion NVARCHAR(50) NOT NULL,
    TasaCosto DECIMAL(18,2) NOT NULL,
    TasaVenta DECIMAL(18,2) NOT NULL,
    fecha DATE NOT NULL DEFAULT GETDATE(),
    hora TIME NOT NULL DEFAULT GETDATE(),
    idEmpleado INT NOT NULL
    CONSTRAINT FK_TipoMoneda_TEmpleado FOREIGN KEY (idEmpleado) REFERENCES TEmpleado(idEmpleado)
);





---------------------------------------------------------------------------
-- TABLAS TEMPORALES: 
-- SON UTILIZADAS PARA ALMACENAR DATOS QUE LUEGO SE ELIMINAN AL CERRAR LA CONEXION
-- POR EJEMPLO: TSession donde se almacena el login del usuario etc.. 
---------------------------------------------------------------------------
