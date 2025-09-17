USE BD_OPTICA 
GO

-------------------------------------------------------------------------------------------------------------------------------------------------------------
-----   VISTAS 

CREATE OR ALTER VIEW VCategorias AS
    SELECT C.Categoriaid
         , C.NombreCategoria
    FROM TCategorias C

GO

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
            , U.UbicacionID
            , U.Direccion 
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
            , D.Descuento
            , D.Subtotal
            , D.ModoCargo
    FROM    TDetalleCompra D INNER JOIN
            TProductos P ON D.ProductoID = P.ProductoID

GO

CREATE OR ALTER VIEW VProductos AS
    SELECT    P.ProductoID AS ID
            , P.CodigoProducto AS Codigo
            , P.Descripcion AS Nombre
            , S.StockActual AS Stock
            , C.CategoriaID
            , C.NombreCategoria AS Categoria
            , SC.NombreSubCategoria AS SubCategoria
            , P.Material
            , P.Color
            , P.Activo AS Estatus
            , S.StockMinimo
            , S.StockMaximo
            , PR.PVenta AS Precio_Venta
            , PR.PCosto AS Precio_Costo
            , PR.Promocion
            , PR.Descuento
            , A2.Alicuota AS IvaCompra
            , A.Alicuota AS IvaVenta
            , P.Foto 
    FROM    TAlicuota AS A2 RIGHT OUTER JOIN
            TPrecios AS PR ON A2.AlicuotaID = PR.IvaCompraID LEFT OUTER JOIN
            TAlicuota AS A ON PR.IvaVentaID = A.AlicuotaID RIGHT OUTER JOIN
            TProductos AS P LEFT OUTER JOIN
            TStock AS S ON P.CodigoProducto = S.CodigoProducto ON PR.CodigoProducto = P.CodigoProducto LEFT OUTER JOIN
            TCategorias AS C ON P.CategoriaID = C.CategoriaID LEFT OUTER JOIN
            TSubCategorias AS SC ON P.SubCategoriaID = SC.SubCategoriaID

GO

CREATE OR ALTER VIEW VCProveedor AS
    SELECT P.ProveedorID , P.NombreEmpresa 
    FROM TProveedor P

GO

CREATE OR ALTER VIEW VCTipoPago AS
    SELECT T.TipoPagoID, t.Nombre  
    FROM TTipoPago T

GO

CREATE OR ALTER VIEW VCUbicaciones AS
    SELECT    U.UbicacionID
            , U.NombreUbicacion  
    FROM TUbicaciones U

GO

CREATE OR ALTER VIEW VCCargoEmpleado AS
    SELECT C.CargoEmpleadoID, C.Descripcion  
    FROM TCargoEmpleado C

GO

CREATE OR ALTER VIEW VHistoricoStock AS 
    SELECT  H.MovimientoID AS ID
            , P.Descripcion AS Producto
            , U.NombreUbicacion AS Origen
            , TU.NombreUbicacion AS Destino
            , H.Cantidad
            , T.Descripcion AS Tipo_Movimiento
            , CONCAT(E.Cedula,'-' , E.Nombre, ', ', E.Apellido) AS Empleado
            , C.Descripcion AS Cargo
            , H.Referencia
            , H.FechaMovimiento AS Fecha
            , H.Notas
    FROM    TUbicaciones U RIGHT OUTER JOIN
            THistoricoStock H ON U.UbicacionID = H.UbicacionOrigenID LEFT OUTER JOIN
            TCargoEmpleado C RIGHT OUTER JOIN
            TEmpleados E ON C.CargoEmpleadoID = E.CargoEmpleadoID ON H.EmpleadoID = E.EmpleadoID LEFT OUTER JOIN
            TTipoMovimientos T ON H.TipoMovimientoID = T.TipoMovimientoID LEFT OUTER JOIN
            TUbicaciones AS TU ON H.UbicacionDestinoID = TU.UbicacionID LEFT OUTER JOIN
            TProductos P ON H.CodigoProducto = P.CodigoProducto

GO

CREATE OR ALTER VIEW VStock AS
    SELECT  S.StockID AS ID
            , S.StockActual
            , S.StockMinimo
            , S.StockMaximo
            , U.NombreUbicacion AS Ubicacion
            , P.Descripcion AS Producto
    FROM    TStock S LEFT OUTER JOIN
            TProductos P ON S.CodigoProducto = P.CodigoProducto LEFT OUTER JOIN
            TUbicaciones U ON S.UbicacionID = U.UbicacionID

GO

CREATE OR ALTER VIEW VPrecios AS
    SELECT    P.PrecioID AS ID
            , P.CodigoProducto AS Codigo
            , PR.Descripcion AS Producto
            , U.NombreUbicacion AS Ubicacion
            , A2.Alicuota AS IvaVenta
            , A.Alicuota AS IvaCompra
            , P.PVenta AS PrecioVenta
            , P.PCosto AS PrecioCosto
            , P.Promocion
            , P.Descuento
            , P.Tipo
    FROM      TUbicaciones U INNER JOIN
              TPrecios P ON U.UbicacionID = P.UbicacionID INNER JOIN
              TProductos PR ON P.CodigoProducto = PR.CodigoProducto LEFT OUTER JOIN
              TAlicuota A ON P.IvaCompraID = A.AlicuotaID LEFT OUTER JOIN
              TAlicuota A2 ON P.IvaVentaID = A2.AlicuotaID;


