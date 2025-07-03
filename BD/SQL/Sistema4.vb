

Paso a Paso por Capas del Sistema de Ventas, Compras e Inventarios


Paso 1: Crear esquema de Base de Datos
- Crear tabla de sucursales
CREATE TABLE Sucursal (
  SucursalID   INT IDENTITY PRIMARY KEY,
  Nombre       NVARCHAR(100) NOT NULL,
  Ubicacion    NVARCHAR(200) NOT NULL
);
- Crear tabla de productos
CREATE TABLE Producto (
  ProductoID   INT IDENTITY PRIMARY KEY,
  Nombre       NVARCHAR(200) NOT NULL,
  PrecioCosto  DECIMAL(18,2) NOT NULL,
  PrecioVenta  DECIMAL(18,2) NOT NULL
);
- Crear tabla de inventario por sucursal
CREATE TABLE Inventario (
  InventarioID INT IDENTITY PRIMARY KEY,
  SucursalID   INT NOT NULL REFERENCES Sucursal(SucursalID),
  ProductoID   INT NOT NULL REFERENCES Producto(ProductoID),
  Cantidad     INT NOT NULL,
  UNIQUE(SucursalID, ProductoID)
);
- Crear tablas de venta y detalle de venta
CREATE TABLE Venta (
  VentaID    INT IDENTITY PRIMARY KEY,
  Fecha      DATETIME NOT NULL DEFAULT GETDATE(),
  SucursalID INT NOT NULL REFERENCES Sucursal(SucursalID),
  Total      DECIMAL(18,2) NOT NULL
);
CREATE TABLE DetalleVenta (
  DetalleID  INT IDENTITY PRIMARY KEY,
  VentaID    INT NOT NULL REFERENCES Venta(VentaID),
  ProductoID INT NOT NULL REFERENCES Producto(ProductoID),
  Cantidad   INT NOT NULL,
  Subtotal   DECIMAL(18,2) NOT NULL
);
- Crear tablas de compra y detalle de compra
CREATE TABLE Compra (
  CompraID   INT IDENTITY PRIMARY KEY,
  Fecha      DATETIME NOT NULL DEFAULT GETDATE(),
  SucursalID INT NOT NULL REFERENCES Sucursal(SucursalID),
  Total      DECIMAL(18,2) NOT NULL
);
CREATE TABLE DetalleCompra (
  DetalleCID INT IDENTITY PRIMARY KEY,
  CompraID   INT NOT NULL REFERENCES Compra(CompraID),
  ProductoID INT NOT NULL REFERENCES Producto(ProductoID),
  Cantidad   INT NOT NULL,
  Subtotal   DECIMAL(18,2) NOT NULL
);



Paso 2: Stored Procedures CRUD para Producto
- Insertar producto
CREATE PROCEDURE sp_InsertarProducto
  @Nombre      NVARCHAR(200),
  @PrecioCosto DECIMAL(18,2),
  @PrecioVenta DECIMAL(18,2)
AS
BEGIN
  INSERT INTO Producto (Nombre, PrecioCosto, PrecioVenta)
  VALUES (@Nombre, @PrecioCosto, @PrecioVenta);
  SELECT SCOPE_IDENTITY() AS NuevoID;
END
GO
- Actualizar producto
CREATE PROCEDURE sp_ActualizarProducto
  @ProductoID  INT,
  @Nombre      NVARCHAR(200),
  @PrecioCosto DECIMAL(18,2),
  @PrecioVenta DECIMAL(18,2)
AS
BEGIN
  UPDATE Producto
  SET Nombre = @Nombre,
      PrecioCosto = @PrecioCosto,
      PrecioVenta = @PrecioVenta
  WHERE ProductoID = @ProductoID;
END
GO
- Eliminar producto
CREATE PROCEDURE sp_EliminarProducto
  @ProductoID INT
AS
BEGIN
  DELETE FROM Producto WHERE ProductoID = @ProductoID;
END
GO
- Listar productos
CREATE PROCEDURE sp_ListarProductos
AS
BEGIN
  SELECT * FROM Producto;
END
GO
- Obtener producto por ID
CREATE PROCEDURE sp_ObtenerProductoPorId
  @ProductoID INT
AS
BEGIN
  SELECT * FROM Producto WHERE ProductoID = @ProductoID;
END
GO



Paso 3: Definir Entidades en VB.NET

Public Class Producto
  Public Property ProductoID As Integer
  Public Property Nombre As String
  Public Property PrecioCosto As Decimal
  Public Property PrecioVenta As Decimal
End Class

Public Class Sucursal
  Public Property SucursalID As Integer
  Public Property Nombre As String
  Public Property Ubicacion As String
End Class

Public Class Inventario
  Public Property InventarioID As Integer
  Public Property SucursalID As Integer
  Public Property ProductoID As Integer
  Public Property Cantidad As Integer
End Class

Public Class Venta
  Public Property VentaID As Integer
  Public Property Fecha As DateTime
  Public Property SucursalID As Integer
  Public Property Total As Decimal
  Public Property Detalles As List(Of DetalleVenta)
End Class

Public Class DetalleVenta
  Public Property DetalleID As Integer
  Public Property VentaID As Integer
  Public Property ProductoID As Integer
  Public Property Cantidad As Integer
  Public Property Subtotal As Decimal
End Class




Paso 4: Capa de Acceso a Datos (DAL)

La capa DAL se encarga de abstraer todo el detalle de conexión y ejecución de comandos contra SQL Server. Sus responsabilidades principales son:
- Gestionar la cadena de conexión y apertura/cierre de conexiones.
- Ejecutar stored procedures (lectura y no-lectura) con parámetros.
- Convertir los resultados a objetos .NET visibles para la BL.

4.1 Helper de conexión
Este módulo centraliza la lógica de conexión y ejecución:

Imports System.Data
Imports System.Data.SqlClient

Public Class BaseDatos
    ' Ajusta la cadena según tu servidor, credenciales o nombre de instancia
    Private Shared ReadOnly cadena As String =
        "Server=.;Database=VentasDB;Trusted_Connection=True;"

    ' Ejecuta un SP y retorna un DataTable con los resultados
    Public Shared Function EjecutarReader(
        nombreSP As String,
        params As SqlParameter()
    ) As DataTable
        Dim dt As New DataTable
        Using cn As New SqlConnection(cadena),
              cmd As New SqlCommand(nombreSP, cn)
            cmd.CommandType = CommandType.StoredProcedure
            If params IsNot Nothing Then cmd.Parameters.AddRange(params)
            cn.Open()
            Using rdr = cmd.ExecuteReader()
                dt.Load(rdr)
            End Using
        End Using
        Return dt
    End Function

    ' Ejecuta un SP de tipo INSERT/UPDATE/DELETE y retorna filas afectadas
    Public Shared Function EjecutarNonQuery(
        nombreSP As String,
        params As SqlParameter()
    ) As Integer
        Using cn As New SqlConnection(cadena),
              cmd As New SqlCommand(nombreSP, cn)
            cmd.CommandType = CommandType.StoredProcedure
            If params IsNot Nothing Then cmd.Parameters.AddRange(params)
            cn.Open()
            Return cmd.ExecuteNonQuery()
        End Using
    End Function
End Class



4.2 Ejemplo: ProductoDAL
Implementa los métodos CRUD usando el helper anterior:
Imports System.Data.SqlClient

Public Class ProductoDAL

    ' Crea un nuevo producto y devuelve el ID generado
    Public Function Insertar(prod As Producto) As Integer
        Dim parametros = {
            New SqlParameter("@Nombre", prod.Nombre),
            New SqlParameter("@PrecioCosto", prod.PrecioCosto),
            New SqlParameter("@PrecioVenta", prod.PrecioVenta)
        }
        Dim dt = BaseDatos.EjecutarReader("sp_InsertarProducto", parametros)
        Return Convert.ToInt32(dt.Rows(0)("NuevoID"))
    End Function

    ' Actualiza un producto existente, devuelve True si hubo cambios
    Public Function Actualizar(prod As Producto) As Boolean
        Dim parametros = {
            New SqlParameter("@ProductoID", prod.ProductoID),
            New SqlParameter("@Nombre", prod.Nombre),
            New SqlParameter("@PrecioCosto", prod.PrecioCosto),
            New SqlParameter("@PrecioVenta", prod.PrecioVenta)
        }
        Return BaseDatos.EjecutarNonQuery("sp_ActualizarProducto", parametros) > 0
    End Function

    ' Elimina un producto por su ID
    Public Function Eliminar(productoID As Integer) As Boolean
        Dim parametros = { New SqlParameter("@ProductoID", productoID) }
        Return BaseDatos.EjecutarNonQuery("sp_EliminarProducto", parametros) > 0
    End Function

    ' Lista todos los productos y los convierte a List(Of Producto)
    Public Function Listar() As List(Of Producto)
        Dim lista As New List(Of Producto)
        Dim dt = BaseDatos.EjecutarReader("sp_ListarProductos", Nothing)
        For Each fila As DataRow In dt.Rows
            lista.Add(New Producto With {
                .ProductoID = CInt(fila("ProductoID")),
                .Nombre = fila("Nombre").ToString(),
                .PrecioCosto = CDec(fila("PrecioCosto")),
                .PrecioVenta = CDec(fila("PrecioVenta"))
            })
        Next
        Return lista
    End Function

    ' Obtiene un producto por ID; retorna Nothing si no existe
    Public Function ObtenerPorId(id As Integer) As Producto
        Dim parametros = { New SqlParameter("@ProductoID", id) }
        Dim dt = BaseDatos.EjecutarReader("sp_ObtenerProductoPorId", parametros)
        If dt.Rows.Count = 0 Then Return Nothing
        Dim r = dt.Rows(0)
        Return New Producto With {
            .ProductoID = CInt(r("ProductoID")),
            .Nombre = r("Nombre").ToString(),
            .PrecioCosto = CDec(r("PrecioCosto")),
            .PrecioVenta = CDec(r("PrecioVenta"))
        }
    End Function

End Class



4.3 Otros DALs

SucursalDAL, InventarioDAL, VentaDAL y CompraDAL siguen el mismo patrón:
- Definir métodos Insertar, Actualizar, Eliminar, Listar, ObtenerPorId.
- Pasar parámetros a BaseDatos.EjecutarReader o EjecutarNonQuery.
- Mapear DataTable a listas o instancias de entidades.
Con esto ya tenemos lista la capa que comunica VB.NET con SQL Server.
¿Quieres ver un ejemplo concreto de SucursalDAL o InventarioDAL?



# Paso 4.4: Capa de Acceso a Datos – CompraDAL

Este módulo gestiona inserciones y consultas de compras y sus detalles en SQL Server.

```vbnet
Imports System.Data
Imports System.Data.SqlClient

Public Class CompraDAL
    ' Inserta una compra y retorna el ID generado
    Public Function Insertar(compra As Compra) As Integer
        Dim p = {
            New SqlParameter("@SucursalID", compra.SucursalID),
            New SqlParameter("@Total", compra.Total)
        }
        Dim dt = BaseDatos.EjecutarReader("sp_InsertarCompra", p)
        Return Convert.ToInt32(dt.Rows(0)("NuevoID"))
    End Function

    ' Inserta un detalle de compra asociado
    Public Sub InsertarDetalle(detalle As DetalleCompra)
        Dim p = {
            New SqlParameter("@CompraID", detalle.CompraID),
            New SqlParameter("@ProductoID", detalle.ProductoID),
            New SqlParameter("@Cantidad", detalle.Cantidad),
            New SqlParameter("@Subtotal", detalle.Subtotal)
        }
        BaseDatos.EjecutarNonQuery("sp_InsertarDetalleCompra", p)
    End Sub

    ' Lista todas las compras de una sucursal
    Public Function ListarPorSucursal(sucursalID As Integer) As List(Of Compra)
        Dim lista As New List(Of Compra)
        Dim p = { New SqlParameter("@SucursalID", sucursalID) }
        Dim dt = BaseDatos.EjecutarReader("sp_ListarComprasPorSucursal", p)

        For Each r As DataRow In dt.Rows
            lista.Add(New Compra With {
                .CompraID = CInt(r("CompraID")),
                .Fecha     = CDate(r("Fecha")),
                .SucursalID= CInt(r("SucursalID")),
                .Total     = CDec(r("Total"))
            })
        Next
        Return lista
    End Function

    ' Lista detalles de una compra
    Public Function ListarDetalle(compraID As Integer) As List(Of DetalleCompra)
        Dim lista As New List(Of DetalleCompra)
        Dim p = { New SqlParameter("@CompraID", compraID) }
        Dim dt = BaseDatos.EjecutarReader("sp_ListarDetalleCompra", p)

        For Each r As DataRow In dt.Rows
            lista.Add(New DetalleCompra With {
                .DetalleCID = CInt(r("DetalleCID")),
                .CompraID   = CInt(r("CompraID")),
                .ProductoID = CInt(r("ProductoID")),
                .Cantidad   = CInt(r("Cantidad")),
                .Subtotal   = CDec(r("Subtotal"))
            })
        Next
        Return lista
    End Function
End Class
```

---

# Paso 4.5: Capa de Acceso a Datos – InventarioDAL

Gestiona consulta y ajuste de stock por sucursal y producto.

```vbnet
Public Class InventarioDAL

    ' Obtiene inventario de una sucursal
    Public Function ListarPorSucursal(sucursalID As Integer) As List(Of Inventario)
        Dim lista As New List(Of Inventario)
        Dim p = { New SqlParameter("@SucursalID", sucursalID) }
        Dim dt = BaseDatos.EjecutarReader("sp_ListarInventarioPorSucursal", p)

        For Each r As DataRow In dt.Rows
            lista.Add(New Inventario With {
                .InventarioID = CInt(r("InventarioID")),
                .SucursalID   = CInt(r("SucursalID")),
                .ProductoID   = CInt(r("ProductoID")),
                .Cantidad     = CInt(r("Cantidad"))
            })
        Next
        Return lista
    End Function

    ' Actualiza registro de inventario
    Public Function Actualizar(invent As Inventario) As Boolean
        Dim p = {
            New SqlParameter("@InventarioID", invent.InventarioID),
            New SqlParameter("@Cantidad", invent.Cantidad)
        }
        Return BaseDatos.EjecutarNonQuery("sp_ActualizarInventario", p) > 0
    End Function

    ' Reduce stock tras una venta o transferencia
    Public Sub ReducirStock(sucursalID As Integer, productoID As Integer, cantidad As Integer)
        Dim p = {
            New SqlParameter("@SucursalID", sucursalID),
            New SqlParameter("@ProductoID", productoID),
            New SqlParameter("@Cantidad", cantidad)
        }
        BaseDatos.EjecutarNonQuery("sp_ReducirStock", p)
    End Sub

    ' Aumenta stock tras una compra o transferencia
    Public Sub AumentarStock(sucursalID As Integer, productoID As Integer, cantidad As Integer)
        Dim p = {
            New SqlParameter("@SucursalID", sucursalID),
            New SqlParameter("@ProductoID", productoID),
            New SqlParameter("@Cantidad", cantidad)
        }
        BaseDatos.EjecutarNonQuery("sp_AumentarStock", p)
    End Sub
End Class



---

## Paso 5: Capa de Lógica de Negocio (BL)

La capa BL orquesta la validación de reglas de negocio y coordina llamadas a la DAL. Aquí se centralizan transacciones y lógica que involucra varias entidades.

---

### 5.1 ProductoBL

```vb.net
Public Class ProductoBL
    Private dal As New ProductoDAL()

    Public Function Crear(prod As Producto) As Integer
        If String.IsNullOrWhiteSpace(prod.Nombre) Then
            Throw New ArgumentException("El nombre es obligatorio")
        End If
        Return dal.Insertar(prod)
    End Function

    Public Function Modificar(prod As Producto) As Boolean
        If prod.ProductoID <= 0 Then Throw New ArgumentException("ID inválido")
        Return dal.Actualizar(prod)
    End Function

    Public Function Borrar(id As Integer) As Boolean
        Return dal.Eliminar(id)
    End Function

    Public Function ObtenerTodos() As List(Of Producto)
        Return dal.Listar()
    End Function
End Class
```

---

### 5.2 InventarioBL

```vb.net
Public Class InventarioBL
    Private dal As New InventarioDAL()

    Public Function AjustarStock(invent As Inventario) As Boolean
        If invent.Cantidad < 0 Then
            Throw New ArgumentException("Cantidad inválida")
        End If
        Return dal.Actualizar(invent)
    End Function

    Public Function ListarPorSucursal(sucursalID As Integer) As List(Of Inventario)
        Return dal.ListarPorSucursal(sucursalID)
    End Function
End Class
```

---

### 5.3 VentaBL (con transacción)

```vb.net
Imports System.Transactions

Public Class VentaBL
    Private ventaDal As New VentaDAL()
    Private invDal   As New InventarioDAL()

    Public Function CrearVenta(venta As Venta) As Integer
        Using scope As New TransactionScope()
            Dim idVenta = ventaDal.Insertar(venta)
            For Each d In venta.Detalles
                d.VentaID = idVenta
                ventaDal.InsertarDetalle(d)
                invDal.ReducirStock(venta.SucursalID, d.ProductoID, d.Cantidad)
            Next
            scope.Complete()
            Return idVenta
        End Using
    End Function

    Public Function ListarVentas(sucursalID As Integer) As List(Of Venta)
        Return ventaDal.ListarPorSucursal(sucursalID)
    End Function
End Class
```

---

### 5.4 CompraBL (similar a VentaBL)

```vb.net
Public Class CompraBL
    Private compraDal As New CompraDAL()
    Private invDal    As New InventarioDAL()

    Public Function RegistrarCompra(compra As Compra) As Integer
        Using scope As New TransactionScope()
            Dim id = compraDal.Insertar(compra)
            For Each d In compra.Detalles
                d.CompraID = id
                compraDal.InsertarDetalle(d)
                invDal.AumentarStock(compra.SucursalID, d.ProductoID, d.Cantidad)
            Next
            scope.Complete()
            Return id
        End Using
    End Function
End Class
```

---

## Paso 6: Capa de Presentación (UI con Windows Forms)

Se recomienda un `TabControl` para separar módulos: Productos, Inventario, Ventas y Compras. Cada pestaña usa su propio DataGridView y controles.

---

### 6.1 Formulario de Ventas (`frmVentas`)

1. Controles clave:  
   - ComboBox `cmbSucursal`  
   - DataGridView `dgvProductos` (lista de productos)  
   - DataGridView `dgvDetalles` (líneas de venta)  
   - Botones `btnAgregar`, `btnRegistrar`, `btnLimpiar`

2. Código de carga:

```vb.net
Private blProd As New ProductoBL()
Private blVenta As New VentaBL()

Private Sub frmVentas_Load(...) Handles MyBase.Load
    cmbSucursal.DataSource = New SucursalBL().ObtenerTodos()
    cmbSucursal.DisplayMember = "Nombre"
    dgvProductos.DataSource = blProd.ObtenerTodos()
    dgvDetalles.Columns.Add("ProductoID", "ID")
    dgvDetalles.Columns.Add("Nombre", "Producto")
    dgvDetalles.Columns.Add("Cantidad", "Cant.")
    dgvDetalles.Columns.Add("Subtotal", "Subtotal")
End Sub
```

3. Agregar línea de venta:

```vb.net
Private Sub btnAgregar_Click(...) Handles btnAgregar.Click
    Dim prod = CType(dgvProductos.CurrentRow.DataBoundItem, Producto)
    Dim cant = CInt(InputBox("Cantidad a vender", "Venta"))
    Dim subtotal = prod.PrecioVenta * cant
    dgvDetalles.Rows.Add(prod.ProductoID, prod.Nombre, cant, subtotal)
End Sub
```

4. Registrar venta:

```vb.net
Private Sub btnRegistrar_Click(...) Handles btnRegistrar.Click
    Dim venta As New Venta With {
        .SucursalID = CType(cmbSucursal.SelectedItem, Sucursal).SucursalID,
        .Detalles = New List(Of DetalleVenta)
    }
    For Each row As DataGridViewRow In dgvDetalles.Rows
        venta.Detalles.Add(New DetalleVenta With {
            .ProductoID = CInt(row.Cells("ProductoID").Value),
            .Cantidad = CInt(row.Cells("Cantidad").Value),
            .Subtotal = CDec(row.Cells("Subtotal").Value)
        })
    Next
    Dim idVenta = blVenta.CrearVenta(venta)
    MessageBox.Show($"Venta registrada: {idVenta}")
    dgvDetalles.Rows.Clear()
End Sub
```

---


# Paso 6.1: Formulario de Inventario (`frmInventario`)

1. Controles clave:  
   - ComboBox `cmbSucursal`  
   - DataGridView `dgvInventario`  
   - Button `btnAjustar`

2. Carga inicial:

```vbnet
Private invBL As New InventarioBL()

Private Sub frmInventario_Load(...) Handles MyBase.Load
    cmbSucursal.DataSource = New SucursalBL().ObtenerTodos()
    cmbSucursal.DisplayMember = "Nombre"
    MostrarInventario()
End Sub

Private Sub cmbSucursal_SelectedIndexChanged(...) Handles cmbSucursal.SelectedIndexChanged
    MostrarInventario()
End Sub

Private Sub MostrarInventario()
    Dim sucID = CType(cmbSucursal.SelectedItem, Sucursal).SucursalID
    dgvInventario.DataSource = invBL.ListarPorSucursal(sucID)
End Sub
```

3. Ajustar stock:

```vbnet
Private Sub btnAjustar_Click(...) Handles btnAjustar.Click
    Dim fila = dgvInventario.CurrentRow
    If fila Is Nothing Then Return

    Dim invent = CType(fila.DataBoundItem, Inventario)
    Dim nuevaCant = CInt(InputBox("Nueva cantidad:", "Ajuste de Inventario", invent.Cantidad))
    invent.Cantidad = nuevaCant

    invBL.AjustarStock(invent)
    MostrarInventario()
End Sub
```

---

# Paso 6.2: Formulario de Compras (`frmCompras`)

1. Controles clave:  
   - ComboBox `cmbSucursal`  
   - DataGridView `dgvProductos`  
   - DataGridView `dgvDetallesComp`  
   - Buttons `btnAgregarComp`, `btnRegistrarComp`, `btnLimpiarComp`

2. Carga inicial:

```vbnet
Private prodBL As New ProductoBL()
Private compBL As New CompraBL()

Private Sub frmCompras_Load(...) Handles MyBase.Load
    cmbSucursal.DataSource = New SucursalBL().ObtenerTodos()
    cmbSucursal.DisplayMember = "Nombre"
    dgvProductos.DataSource = prodBL.ObtenerTodos()

    dgvDetallesComp.Columns.Add("ProductoID", "ID")
    dgvDetallesComp.Columns.Add("Nombre", "Producto")
    dgvDetallesComp.Columns.Add("Cantidad", "Cant.")
    dgvDetallesComp.Columns.Add("Subtotal", "Subtotal")
End Sub
```

3. Agregar producto a detalle:

```vbnet
Private Sub btnAgregarComp_Click(...) Handles btnAgregarComp.Click
    Dim prod = CType(dgvProductos.CurrentRow.DataBoundItem, Producto)
    Dim cant = CInt(InputBox("Cantidad a comprar:", "Detalle Compra"))
    Dim subtotal = prod.PrecioCosto * cant
    dgvDetallesComp.Rows.Add(prod.ProductoID, prod.Nombre, cant, subtotal)
End Sub
```

4. Registrar compra:

```vbnet
Private Sub btnRegistrarComp_Click(...) Handles btnRegistrarComp.Click
    Dim compra As New Compra With {
        .SucursalID = CType(cmbSucursal.SelectedItem, Sucursal).SucursalID,
        .Detalles = New List(Of DetalleCompra)
    }
    For Each row As DataGridViewRow In dgvDetallesComp.Rows
        compra.Detalles.Add(New DetalleCompra With {
            .ProductoID = CInt(row.Cells("ProductoID").Value),
            .Cantidad   = CInt(row.Cells("Cantidad").Value),
            .Subtotal   = CDec(row.Cells("Subtotal").Value)
        })
    Next
    Dim idComp = compBL.RegistrarCompra(compra)
    MessageBox.Show($"Compra registrada: {idComp}")
    dgvDetallesComp.Rows.Clear()
End Sub
```




# Paso 4.4: Capa de Acceso a Datos – CompraDAL

Este módulo gestiona inserciones y consultas de compras y sus detalles en SQL Server.

```vbnet
Imports System.Data
Imports System.Data.SqlClient

Public Class CompraDAL
    ' Inserta una compra y retorna el ID generado
    Public Function Insertar(compra As Compra) As Integer
        Dim p = {
            New SqlParameter("@SucursalID", compra.SucursalID),
            New SqlParameter("@Total", compra.Total)
        }
        Dim dt = BaseDatos.EjecutarReader("sp_InsertarCompra", p)
        Return Convert.ToInt32(dt.Rows(0)("NuevoID"))
    End Function

    ' Inserta un detalle de compra asociado
    Public Sub InsertarDetalle(detalle As DetalleCompra)
        Dim p = {
            New SqlParameter("@CompraID", detalle.CompraID),
            New SqlParameter("@ProductoID", detalle.ProductoID),
            New SqlParameter("@Cantidad", detalle.Cantidad),
            New SqlParameter("@Subtotal", detalle.Subtotal)
        }
        BaseDatos.EjecutarNonQuery("sp_InsertarDetalleCompra", p)
    End Sub

    ' Lista todas las compras de una sucursal
    Public Function ListarPorSucursal(sucursalID As Integer) As List(Of Compra)
        Dim lista As New List(Of Compra)
        Dim p = { New SqlParameter("@SucursalID", sucursalID) }
        Dim dt = BaseDatos.EjecutarReader("sp_ListarComprasPorSucursal", p)

        For Each r As DataRow In dt.Rows
            lista.Add(New Compra With {
                .CompraID = CInt(r("CompraID")),
                .Fecha     = CDate(r("Fecha")),
                .SucursalID= CInt(r("SucursalID")),
                .Total     = CDec(r("Total"))
            })
        Next
        Return lista
    End Function

    ' Lista detalles de una compra
    Public Function ListarDetalle(compraID As Integer) As List(Of DetalleCompra)
        Dim lista As New List(Of DetalleCompra)
        Dim p = { New SqlParameter("@CompraID", compraID) }
        Dim dt = BaseDatos.EjecutarReader("sp_ListarDetalleCompra", p)

        For Each r As DataRow In dt.Rows
            lista.Add(New DetalleCompra With {
                .DetalleCID = CInt(r("DetalleCID")),
                .CompraID   = CInt(r("CompraID")),
                .ProductoID = CInt(r("ProductoID")),
                .Cantidad   = CInt(r("Cantidad")),
                .Subtotal   = CDec(r("Subtotal"))
            })
        Next
        Return lista
    End Function
End Class
```

---

# Paso 4.5: Capa de Acceso a Datos – InventarioDAL

Gestiona consulta y ajuste de stock por sucursal y producto.

```vbnet
Public Class InventarioDAL

    ' Obtiene inventario de una sucursal
    Public Function ListarPorSucursal(sucursalID As Integer) As List(Of Inventario)
        Dim lista As New List(Of Inventario)
        Dim p = { New SqlParameter("@SucursalID", sucursalID) }
        Dim dt = BaseDatos.EjecutarReader("sp_ListarInventarioPorSucursal", p)

        For Each r As DataRow In dt.Rows
            lista.Add(New Inventario With {
                .InventarioID = CInt(r("InventarioID")),
                .SucursalID   = CInt(r("SucursalID")),
                .ProductoID   = CInt(r("ProductoID")),
                .Cantidad     = CInt(r("Cantidad"))
            })
        Next
        Return lista
    End Function

    ' Actualiza registro de inventario
    Public Function Actualizar(invent As Inventario) As Boolean
        Dim p = {
            New SqlParameter("@InventarioID", invent.InventarioID),
            New SqlParameter("@Cantidad", invent.Cantidad)
        }
        Return BaseDatos.EjecutarNonQuery("sp_ActualizarInventario", p) > 0
    End Function

    ' Reduce stock tras una venta o transferencia
    Public Sub ReducirStock(sucursalID As Integer, productoID As Integer, cantidad As Integer)
        Dim p = {
            New SqlParameter("@SucursalID", sucursalID),
            New SqlParameter("@ProductoID", productoID),
            New SqlParameter("@Cantidad", cantidad)
        }
        BaseDatos.EjecutarNonQuery("sp_ReducirStock", p)
    End Sub

    ' Aumenta stock tras una compra o transferencia
    Public Sub AumentarStock(sucursalID As Integer, productoID As Integer, cantidad As Integer)
        Dim p = {
            New SqlParameter("@SucursalID", sucursalID),
            New SqlParameter("@ProductoID", productoID),
            New SqlParameter("@Cantidad", cantidad)
        }
        BaseDatos.EjecutarNonQuery("sp_AumentarStock", p)
    End Sub
End Class



# Opciones de Profundización

Para avanzar, elige cuál de estos temas quieres explorar en detalle:

- API REST  
  Desplegar un servicio con ASP NET Core que exponga endpoints seguros (JWT, roles por sucursal) y cómo consumirlo desde React o PHP.

- Reportes Dinámicos  
  Configurar y diseñar reportes en SSRS o Power BI: parámetros por sucursal, estilos corporativos y despliegue automatizado.

- Exportación a Excel Profesional  
  Generar archivos con formato, tablas dinámicas y gráficos usando ClosedXML o Office Interop desde tu capa BL.

¿Cuál prefieres abordar primero?


1. API REST con ASP.NET Core
1.1 Crear el proyecto
- Abre Visual Studio y elige ASP NET Core Web API.
- Selecciona .NET 6/7, activa Enable OpenAPI para Swagger y desmarca Configure for HTTPS si pruebas localmente.
- Asigna nombre VentasApi y crea.
1.2 Definir modelos y DbContext
- Añade paquete NuGet:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- En carpeta Models crea clases:
public class Producto
{
  public int ProductoID { get; set; }
  public string Nombre { get; set; }
  public decimal PrecioCosto { get; set; }
  public decimal PrecioVenta { get; set; }
}
- En Data/VentasContext.cs:
public class VentasContext : DbContext
{
  public VentasContext(DbContextOptions<VentasContext> opts)
    : base(opts) { }

  public DbSet<Producto> Productos { get; set; }
  // DbSet<Sucursal>, DbSet<Inventario>, DbSet<Venta>, etc.
}
- En appsettings.json agrega la cadena:
"ConnectionStrings": {
  "VentasDB": "Server=.;Database=VentasDB;Trusted_Connection=True;"
}
- En Program.cs registra DbContext:
builder.Services.AddDbContext<VentasContext>(opt =>
  opt.UseSqlServer(builder.Configuration.GetConnectionString("VentasDB")));


1.3 Seguridad: JWT y roles por sucursal
- Paquetes NuGet:
- Microsoft.AspNetCore.Authentication.JwtBearer
- System.IdentityModel.Tokens.Jwt
- En Models/UserCredential.cs:
public class UserCredential
{
  public string UserName { get; set; }
  public string Password { get; set; }
}
- Configura JWT en Program.cs:
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(opt =>
  {
    opt.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidateLifetime = true,
      ValidIssuer = builder.Configuration["Jwt:Issuer"],
      ValidAudience = builder.Configuration["Jwt:Audience"],
      IssuerSigningKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
  });

builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("AdminSucursal", policy =>
    policy.RequireClaim("role", "admin"));
  // Agrega políticas con claim "sucursalId" si quieres filtrar por sucursal
});
- Añade sección Jwt en appsettings.json:
"Jwt": {
  "Key": "ClaveSuperSecreta123!",
  "Issuer": "MiEmpresa",
  "Audience": "MiEmpresaClientes"
}
- Crea endpoint de login en Controllers/AuthController.cs:
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private IConfiguration _config;
  public AuthController(IConfiguration config) => _config = config;

  [HttpPost("login")]
  public IActionResult Login(UserCredential creds)
  {
    // Validar credenciales contra tabla Users/LDAP...
    var claims = new[]
    {
      new Claim(ClaimTypes.Name, creds.UserName),
      new Claim("role", "vendedor"),
      new Claim("sucursalId", "2")
    };
    var key = new SymmetricSecurityKey(
      Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
    var token = new JwtSecurityToken(
      issuer: _config["Jwt:Issuer"],
      audience: _config["Jwt:Audience"],
      claims: claims,
      expires: DateTime.UtcNow.AddHours(2),
      signingCredentials:
        new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
  }
}



1.4 Controladores y Endpoints
- Crea Controllers/ProductoController.cs:
[ApiController]
[Route("api/[controller]")]
[Authorize] 
public class ProductoController : ControllerBase
{
  private VentasContext _ctx;
  public ProductoController(VentasContext ctx) => _ctx = ctx;

  [HttpGet]
  public async Task<IEnumerable<Producto>> Get() =>
    await _ctx.Productos.ToListAsync();

  [HttpGet("{id}")]
  public async Task<ActionResult<Producto>> Get(int id) =>
    await _ctx.Productos.FindAsync(id) is Producto p 
      ? Ok(p) : NotFound();

  [HttpPost]
  [Authorize(Policy = "AdminSucursal")]
  public async Task<ActionResult> Post(Producto prod)
  {
    _ctx.Productos.Add(prod);
    await _ctx.SaveChangesAsync();
    return CreatedAtAction(nameof(Get), new { id = prod.ProductoID }, prod);
  }

  [HttpPut("{id}")]
  [Authorize(Policy = "AdminSucursal")]
  public async Task<IActionResult> Put(int id, Producto prod)
  {
    if (id != prod.ProductoID) return BadRequest();
    _ctx.Entry(prod).State = EntityState.Modified;
    await _ctx.SaveChangesAsync();
    return NoContent();
  }

  [HttpDelete("{id}")]
  [Authorize(Policy = "AdminSucursal")]
  public async Task<IActionResult> Delete(int id)
  {
    var p = await _ctx.Productos.FindAsync(id);
    if (p == null) return NotFound();
    _ctx.Productos.Remove(p);
    await _ctx.SaveChangesAsync();
    return NoContent();
  }
}



1.5 Consumir desde React
- Instala Axios:
npm install axios
- Contexto de autenticación:
import { createContext, useState } from "react";
export const AuthContext = createContext();
export const AuthProvider = ({ children }) => {
  const [token, setToken] = useState(null);
  return (
    <AuthContext.Provider value={{ token, setToken }}>
      {children}
    </AuthContext.Provider>
  );
};
- Login y guardado de token:
import axios from "axios";
const login = async (user, pass, setToken) => {
  const res = await axios.post("/api/auth/login", { user, pass });
  setToken(res.data.token);
};
- Llamada protegida:
import axios from "axios";
axios.get("/api/producto", {
  headers: { Authorization: `Bearer ${token}` }
});



1.6 Consumir desde PHP
<?php
// login y obtención de JWT
$ch = curl_init("http://localhost/api/auth/login");
curl_setopt($ch, CURLOPT_POSTFIELDS, json_encode([
  "userName"=>"u", "password"=>"p"
]));
curl_setopt($ch, CURLOPT_HTTPHEADER, [
  "Content-Type: application/json"
]);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
$res = curl_exec($ch);
$jwt = json_decode($res)->token;

// petición de productos
$ch = curl_init("http://localhost/api/producto");
curl_setopt($ch, CURLOPT_HTTPHEADER, [
  "Authorization: Bearer $jwt"
]);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
$list = json_decode(curl_exec($ch));
print_r($list);



2. Reportes Dinámicos
2.1 SQL Server Reporting Services (SSRS)
- Crea un proyecto Report Server Project en Visual Studio.
- Añade Data Source apuntando a VentasDB.
- Define DataSet con consultas parametrizadas:
SELECT * FROM Venta
WHERE Fecha BETWEEN @FechaInicio AND @FechaFin
  AND SucursalID = @SucursalID
- Diseña tablix y gráficos; expón parámetros para sucursal y rango de fechas.
- Publica al servidor SSRS y accede vía URL.
2.2 Power BI
- Conecta Power BI Desktop a SQL Server.
- Importa tablas o usa DirectQuery.
- Crea medidas DAX para total ventas, rotación de stock, etc.
- Diseña dashboards con filtros de sucursal, fechas y drill-down.
- Publica en Power BI Service y comparte con tu equipo.

3. Exportación a Excel Profesional
3.1 ClosedXML (.NET)
- Instala:
Install-Package ClosedXML
- Código de ejemplo:
using(var wb = new XLWorkbook())
{
  var ws = wb.Worksheets.Add("Productos");
  ws.Cell(1,1).Value = "ID";
  ws.Cell(1,2).Value = "Nombre";
  // Carga tu lista
  int row = 2;
  foreach(var p in lista)
  {
    ws.Cell(row,1).Value = p.ProductoID;
    ws.Cell(row,2).Value = p.Nombre;
    row++;
  }
  ws.Range("A1:B1").Style.Font.Bold = true;
  wb.SaveAs("Productos.xlsx");
}


3.2 Office Interop (VB.NET)
- Referencia Microsoft.Office.Interop.Excel.
- Ejemplo:
Dim xl As New Excel.Application
Dim wb = xl.Workbooks.Add()
Dim ws = CType(wb.Sheets(1), Excel.Worksheet)
ws.Range("A1").Value = "ID"
ws.Range("B1").Value = "Nombre"
'... llenar datos
ws.Range("A1:B1").Font.Bold = True
wb.SaveAs(path)
xl.Quit()

