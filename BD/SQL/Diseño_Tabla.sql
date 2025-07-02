
CREATE DATABASE DB_OPTICA

GO

USE DB_OPTICA

GO

CREATE table tab_ROL(
IdRol int primary key identity,
Descripcion varchar(50),
FechaRegistro datetime default getdate()
)
GO

CREATE table tab_PERMISOS(
IdPermiso  int primary key identity,
IdRol int references tab_ROL(IdRol),
NombreMenu varchar(100),
FechaRegistro datetime default getdate()
)
GO

CREATE table tab_PROVEEDOR(
IdProveedor int primary key identity,
Nombre varchar(50),
Direccion varchar(200),
Rif varchar(15),
RazonSocial varchar(50),
Correo varchar(50),
Telefono varchar(50),
Estado bit,
FechaRegistro datetime default getdate()
)
GO

CREATE table tab_CLIENTE(
IdCliente int primary key identity,
Rif varchar(20),
Cedula varchar(15),
NombreCompleto varchar(50),
Direccion varchar(150),
Correo varchar(50),
Telefono varchar(50),
Estado bit,
FechaRegistro datetime default getdate()
)
GO

CREATE table tab_EMPRESACLIENTE(
IdEmpresaCliente int primary key identity,
IdCliente int references tab_CLIENTE(IdCliente),
Rif varchar(15),
Nombre varchar(50),
ExentoIva bit,
Descripcion varchar(100),
Direccion varchar(Max),
Zona varchar(20),
Correo varchar(50),
Telefono varchar(50),
Pagina varchar(25),
Estado bit,
FechaRegistro datetime default getdate()
)
GO

CREATE table tab_CARGOEMPLEADO(
IdCargoEmpleado int primary key identity,
Descripcion varchar(60),
)
GO 

CREATE table tab_EMPLEADO(
IdEmpleado int primary key identity,
IdCargoEmpleado int references tab_CARGOEMPLEADO(IdCargoEmpleado),
Cedula varchar(12),
NombreCompleto varchar(50),
Edad int,
Nacionalidad varchar(1),
EstadoCivil varchar(1),
Sexo varchar(1),
FechaNacimiento date,
Parentesco varchar(20),
Zona varchar(40),
Dirección varchar(200),
Estado bit,
FechaRegistro datetime default getdate()
)
GO 

CREATE table tab_LOGIN(
IdLogin int primary key identity,
IdRol int references tab_ROL(IdRol),
IdEmpleado int references tab_EMPLEADO(IdEmpleado),
Correo varchar(50),
Clave varchar(50),
Estado bit,
FechaRegistro datetime default getdate()
)
GO

CREATE table tab_EMPRESA(
IdEmpresa int primary key identity,
Nombre varchar(60),
Rif varchar(15),
Direccion varchar(MAX),
Sucursal varchar(50),
Telefono varchar(50),
Correo varchar(50),
Pagina varchar(50),
Estado bit,
FechaRegistro datetime default getdate()
)
GO 

CREATE table tab_COMISION(
IdComision int primary key identity,
IdCargoEmpleado int references tab_CARGOEMPLEADO(IdCargoEmpleado),
Monto int
)
GO

CREATE table tab_DETALLEEMPLEADO(
IdDetalleEmpleado int primary key identity,
IdEmpleado int references tab_EMPLEADO(IdEmpleado),
IdAsesor int references tab_EMPLEADO(IdEmpleado),
IdGerente int references tab_EMPLEADO(IdEmpleado),
IdOptometrista int references tab_EMPLEADO(IdEmpleado),
IdMarketing int references tab_EMPLEADO(IdEmpleado),
IdCobranza int references tab_EMPRESA(IdEmpresa),
IdComision int references tab_COMISION(IdComision),
FechaRegistro datetime default getdate()
)
GO 

CREATE table tab_CATEGORIA(
IdCategoria int primary key identity,
Descripcion varchar(100)
)
GO

CREATE table tab_SUBCATEGORIA(
IdSubCategoria int primary key identity,
IdCategoria int references tab_CATEGORIA(IdCategoria),
Descripcion varchar(100)
)
GO

CREATE table tab_MARCAPRODUCTO(
IdMarcaProducto int primary key identity,
Descripcion varchar(150)
)
GO

CREATE table tab_STOCK(
IdStock int primary key identity,
ExistenciaMin int,
ExistenciaMax int,
Stock int
)
GO

CREATE table tab_PRECIO(
IdPrecio int primary key identity,
PrecioCompra decimal(10,2) default 0,
PrecioVenta decimal(10,2) default 0,
PrecioPromocion decimal(10,2) default 0,
PrecioIvaCompra decimal(10,2) default 0,
PrecioIvaVenta decimal(10,2) default 0
)
GO

CREATE table tab_PRODUCTO(
IdProducto int primary key identity,
IdCategoria int references tab_CATEGORIA(IdCategoria),
IdMarcaProducto int references tab_MARCAPRODUCTO(IdMarcaProducto),
IdPrecio int references tab_PRECIO(IdPrecio),
IdStock int references tab_STOCK(IdStock),
Codigo varchar(50),
Descripcion varchar(100),
Nacionalidad varchar(1),
Modelo varchar(50),
Garantia bit,
Observacion varchar(Max),
Foto varchar(100),
Estado bit,
FechaRegistro datetime default getdate()
)
GO

CREATE table tab_COMPRA(
IdCompra int primary key identity,
IdEmpleado int references tab_EMPLEADO(IdEmpleado),
IdProveedor int references tab_PROVEEDOR(IdProveedor),
TipoDocumento varchar(50),
NumeroDocumento varchar(50),
MontoTotal decimal(10,2) default 0,
Condicion varchar(20),
Observacion varchar(Max),
Estado bit,
FechaRegistro datetime default getdate()
)
GO 

CREATE table tab_DETALLE_COMPRA(
IdDetalleCompra int primary key identity,
IdCompra int references tab_COMPRA(IdCompra),
IdProducto int references tab_PRODUCTO(IdProducto),
IdPrecio int references tab_PRECIO(IdPrecio),
PrecioCompra decimal(10,2) default 0,
PrecioVenta decimal(10,2) default 0,
Cantidad int,
FechaRegistro datetime default getdate()
)
GO 

CREATE table tab_RASTREOPRODUCTO(
IdRastreo int primary key identity,
Descripcion varchar(100),
Condcion varchar(50),
FechaRegistro datetime default getdate()
)
GO

CREATE table tab_VENTA(
IdVenta int primary key identity,
IdDetalleEmpleado int references tab_DETALLEEMPLEADO(IdDetalleEmpleado),
IdCliente int references tab_CLIENTE(IdCliente),
MontoPago decimal(10,2),
Descuento decimal(10,2) Default 0,
FechaRegistro datetime default getdate(),
Condicion varchar(20),
Observacion varchar(Max)
)
GO 

CREATE table tab_DETALLE_VENTA(
IdDetalleVenta int primary key identity,
IdVenta int references tab_VENTA(IdVenta),
IdProducto int references tab_PRODUCTO(IdProducto),
IdPrecio int references tab_PRECIO(IdPrecio),
IdRastreo int references tab_RASTREOPRODUCTO(IdRastreo),
Monto decimal(10,2) default 0,
Cantidad int,
FechaRegistro datetime default getdate()
)
GO

CREATE table tab_TIPOPAGO(
IdTipoPago int primary key identity,
Descripcion varchar(60)
)
GO

CREATE table tab_FORMAPAGOVENTA(
IdFormaPagoVenta int primary key identity,
IdVenta int references tab_VENTA(IdVenta),
IdTipoPago int references tab_TIPOPAGO(IdTipoPago),
FechaRegistro datetime default getdate(),
MontoPago decimal(10,2),
Observacion varchar(Max)
)
GO

CREATE table tab_FORMAPAGOCOMPRA(
IdFormaPagoCompra int primary key identity,
IdCompra int references tab_Compra(IdCompra),
IdTipoPago int references tab_TIPOPAGO(IdTipoPago),
FechaRegistro datetime default getdate(),
MontoPago decimal(10,2),
Observacion varchar(Max)
)
GO

CREATE table tab_FORMULA(
IdFormula int primary key identity,
IdVenta int references tab_VENTA(IdVenta),
EsferaDerecha varchar(5),
EsferaIzquierda varchar(5),
CilinfroDerecho varchar(5),
CilindroIzquierdo varchar(5),
EjeDerecho varchar(5),
EjeIzquierdo varchar(5),
AdicionDerecha varchar(5),
AdicionIzquierda varchar(5),
H varchar(5),
V varchar(5),
D varchar(5),
P varchar(5),
DP varchar(5),
ALT varchar(5),
Max Varchar(5),
FormulaExterna bit,
NombreDoctor varchar(50),
FechaRegistro datetime default getdate(),
Observacion varchar(Max)
)

/*CREAR LAS VISTAS*/

CREATE VIEW VBUSCARPRODUCTOS
AS
SELECT dbo.tab_PRODUCTO.Codigo
	 , dbo.tab_PRODUCTO.Descripcion
	 , dbo.tab_MARCAPRODUCTO.Descripcion AS Marca
	 , dbo.tab_PRODUCTO.Modelo
	 , dbo.tab_CATEGORIA.Descripcion AS Categoria
	 , dbo.tab_PRECIO.PrecioCompra AS [Precio Compra]
	 , dbo.tab_PRECIO.PrecioVenta AS [Precio Venta]
FROM dbo.tab_PRODUCTO INNER JOIN
     dbo.tab_PRECIO ON dbo.tab_PRODUCTO.IdPrecio = dbo.tab_PRECIO.IdPrecio INNER JOIN
     dbo.tab_MARCAPRODUCTO ON dbo.tab_PRODUCTO.IdMarcaProducto = dbo.tab_MARCAPRODUCTO.IdMarcaProducto INNER JOIN
     dbo.tab_CATEGORIA ON dbo.tab_PRODUCTO.IdCategoria = dbo.tab_CATEGORIA.IdCategoria INNER JOIN
     dbo.tab_SUBCATEGORIA ON dbo.tab_CATEGORIA.IdCategoria = dbo.tab_SUBCATEGORIA.IdSubCategoria


/*INSERTAR DATOS EN LA TABLA CATEGORIA */

INSERT INTO [dbo].[tab_CATEGORIA] ([Descripcion]) VALUES ('Lentes de Protección')
INSERT INTO [dbo].[tab_CATEGORIA] ([Descripcion]) VALUES ('Cristales')
INSERT INTO [dbo].[tab_CATEGORIA] ([Descripcion]) VALUES ('Monturas')
INSERT INTO [dbo].[tab_CATEGORIA] ([Descripcion]) VALUES ('Lentes de Contactos')
INSERT INTO [dbo].[tab_CATEGORIA] ([Descripcion]) VALUES ('Accesorios')
INSERT INTO [dbo].[tab_CATEGORIA] ([Descripcion]) VALUES ('Lentes de Sol')


/*INSERTAR DATOS EN LA TABLA SUB CATEGORIA */

INSERT INTO [dbo].[tab_SUBCATEGORIA] ([IdCategoria], [Descripcion]) VALUES ('2', 'MonoFocales')
INSERT INTO [dbo].[tab_SUBCATEGORIA] ([IdCategoria], [Descripcion]) VALUES ('2', 'BiFocales')
INSERT INTO [dbo].[tab_SUBCATEGORIA] ([IdCategoria], [Descripcion]) VALUES ('2', 'MultiFocales')
INSERT INTO [dbo].[tab_SUBCATEGORIA] ([IdCategoria], [Descripcion]) VALUES ('3', 'Montura')
INSERT INTO [dbo].[tab_SUBCATEGORIA] ([IdCategoria], [Descripcion]) VALUES ('5', 'Accesorios')
INSERT INTO [dbo].[tab_SUBCATEGORIA] ([IdCategoria], [Descripcion]) VALUES ('4', 'Lentes de Contactos')
INSERT INTO [dbo].[tab_SUBCATEGORIA] ([IdCategoria], [Descripcion]) VALUES ('6', 'Lentes de Sol')


/*INSERTAR DATOS EN LA TABLA CARGOS DEL EMPLEADOS */

INSERT INTO [dbo].[tab_CARGOEMPLEADO] ([Descripcion]) VALUES ('Asesor')
INSERT INTO [dbo].[tab_CARGOEMPLEADO] ([Descripcion]) VALUES ('Optometrista')
INSERT INTO [dbo].[tab_CARGOEMPLEADO] ([Descripcion]) VALUES ('Gerente')
INSERT INTO [dbo].[tab_CARGOEMPLEADO] ([Descripcion]) VALUES ('Sub-Gerente')
INSERT INTO [dbo].[tab_CARGOEMPLEADO] ([Descripcion]) VALUES ('Marketing')
INSERT INTO [dbo].[tab_CARGOEMPLEADO] ([Descripcion]) VALUES ('Cobranza')


/*INSERTAR DATOS EN LA TABLA TIPO DE PAGO */

INSERT INTO [dbo].[tab_TIPOPAGO] ([Descripcion]) VALUES ('Divisas')
INSERT INTO [dbo].[tab_TIPOPAGO] ([Descripcion]) VALUES ('Efectivo')
INSERT INTO [dbo].[tab_TIPOPAGO] ([Descripcion]) VALUES ('Punto de Venta')
INSERT INTO [dbo].[tab_TIPOPAGO] ([Descripcion]) VALUES ('Pago Móvil')
INSERT INTO [dbo].[tab_TIPOPAGO] ([Descripcion]) VALUES ('Zelle')
INSERT INTO [dbo].[tab_TIPOPAGO] ([Descripcion]) VALUES ('BioPago')
INSERT INTO [dbo].[tab_TIPOPAGO] ([Descripcion]) VALUES ('Intercambio Comercial')
INSERT INTO [dbo].[tab_TIPOPAGO] ([Descripcion]) VALUES ('BitCoin')
INSERT INTO [dbo].[tab_TIPOPAGO] ([Descripcion]) VALUES ('Otros')


/*INSERTAR DATOS EN LA TABLA PRODUCTOS*/

INSERT INTO [dbo].[tab_PRODUCTO] ([IdCategoria],[IdMarcaProducto],[IdPrecio],[IdStock],[Codigo],[Descripcion],[Nacionalidad],[Modelo],[Garantia],[Observacion],[Foto],[Estado],[FechaRegistro])
VALUES ('IdCategoria','IdMarcaProducto','IdPrecio','IdStock','Codigo','Descripcion','Nacionalidad','Modelo','Garantia','observacion','Foto','Estado','FechaRegistro')
GO



/*
Para la tabla PRODUCTOS hay que desarrollar lo siguiente

tab_Productos
	- idproducto
	- idcategoria forekey con la labla de Categoria de Producto
	- idmarca forekey con la tabla Marca de los productos
	- idmodelo forekey con la tabla modelo
	- idmaterial forekey con la tabla de materiales del producto
	- idgrupos forekey con la tabla de grupos 
	- idcolor forekey con la tabla de colores de productos
	- idgenero forekey con la tabla gereros
	- idprecio  forekey con la tabla de precios de costos y ventas del producto
	- idstock forekey con la tabla de manejo de inventarios de productos
	- idProveedores forkey con la tabla entre proveedores y productos
	-idnacionalidad forekey con la tabla nacionalidad del producto

	- descripcion 
	- estatus
	- observaciones
	- garantia
	- fechaRegistro

CREAR LA TABLA COLORES
	tab_color
		
		- idcolor
		- descripcion
		- estatus

CREAR LA TABLA GRUPOS
	tab_grupos
		
		- idgrupo
		- descripcion
		- estatus

CREAR LA TABLA GENERO
	tab_genero
		
		- idgenero 
		- descripcion 
		- estatus

CREAR LA TABLA MATERIAL
	tab_material
		
		- idmaterial = Pasta, Metal
		- descripcion
		- estatus

CREAR UNA TABLA PARA LOS LENTES 
	tab_lentes
		- idlentes
		- idtipo forekey con la labla de Categoria de Producto
		- idprecio  forekey con la tabla de precios de costos y ventas del producto
		- idstock forekey con la tabla de manejo de inventarios de productos
		- idProveedores forkey con la tabla entre proveedores y productos
		- idmaterial forekey con la tabla Materiales del lente
		- idtratamiento forekey con la tabla tratamiento
		- idcolor forekey con la tabla color de cristales
		- descripcion 
		- estatus
		- observaciones
		- garantia
		- fechaRegistro

CREAR LA TABLA COLORES
	tab_color
		
		- idcolor
		- descripcion
		- estatus

CREAR LA TABLA TRATAMIENTO
	tab_tratamiento
		
		- idtratamiento
		- descripcion
		- estatus

CREAR LA TABLA MATERIALES
	tab_materiales
		
	- idmaterial
	- descripcion 
	- estatus








*/