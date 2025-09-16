USE BD_OPTICA 
GO


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

INSERT INTO TTipoMovimientos (Descripcion) VALUES ('Entrada por Compra')
INSERT INTO TTipoMovimientos (Descripcion) VALUES ('Salida por Venta')
INSERT INTO TTipoMovimientos (Descripcion) VALUES ('Traslado')
INSERT INTO TTipoMovimientos (Descripcion) VALUES ('Ajuste Positivo')
INSERT INTO TTipoMovimientos (Descripcion) VALUES ('Ajuste Negativo')
INSERT INTO TTipoMovimientos (Descripcion) VALUES ('Devolución Cliente')
INSERT INTO TTipoMovimientos (Descripcion) VALUES ('Devolución Proveedor')
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
INSERT INTO TLogin (EmpleadoID, UbicacionID, RolID, Usuario, Clave, Estado, FechaRegistro) VALUES ('1','1','6','admin','123456','1','10/10/2025')
GO

--TABLA ALICUOTA 
INSERT INTO TAlicuota (Nombre,Alicuota) VALUES('16%','16')
INSERT INTO TAlicuota (Nombre,Alicuota) VALUES('8%','8')
INSERT INTO TAlicuota (Nombre,Alicuota) VALUES('31%','31')
INSERT INTO TAlicuota (Nombre,Alicuota) VALUES('Exento','0')
INSERT INTO TAlicuota (Nombre,Alicuota) VALUES('Gravamen','1')

INSERT INTO TProductos (CodigoProducto ,Descripcion ,CategoriaID,SubCategoriaID,Material,Color,Activo,RequiereInventario) VALUES('1','BIFOCAL','1','2','1','1','1','0')
INSERT INTO TProductos (CodigoProducto ,Descripcion ,CategoriaID,SubCategoriaID,Material,Color,Activo,RequiereInventario) VALUES('2','lENTES DE SOL','2','2','1','1','1','0')
INSERT INTO TProductos (CodigoProducto ,Descripcion ,CategoriaID,SubCategoriaID,Material,Color,Activo,RequiereInventario) VALUES('3','MULTIFOCAL','1','3','1','1','1','0')
INSERT INTO TProductos (CodigoProducto ,Descripcion ,CategoriaID,SubCategoriaID,Material,Color,Activo,RequiereInventario) VALUES('4','LENTES DE CONTACTO','2','2','1','1','1','0')
INSERT INTO TProductos (CodigoProducto ,Descripcion ,CategoriaID,SubCategoriaID,Material,Color,Activo,RequiereInventario) VALUES('5','MONOFOCAL','1','1','1','1','1','0')
 