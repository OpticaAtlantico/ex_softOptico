-- =============================================
-- BASE DE DATOS SISTEMA OPTIVEN - VERSIÓN MULTI-SUCURSAL COMPLETA
-- Sistema de Gestión Óptica y Oftalmológica
-- Adaptado para SQL Server 2022
-- =============================================
CREATE DATABASE OptivenDB;
GO
USE OptivenDB;
GO

-- =============================================
-- TABLA PARA SUCURSALES
-- =============================================
CREATE TABLE Sucursales (
    SucursalID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    Nombre VARCHAR(200) NOT NULL,
    EsPrincipal BIT DEFAULT 0,  -- 1 si es la Sede Principal
    Direccion VARCHAR(500),
    Ciudad VARCHAR(100),
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    Activa BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE()
);
GO

-- Datos iniciales de ejemplo para sucursales
INSERT INTO Sucursales (Codigo, Nombre, EsPrincipal, Direccion) VALUES
('SP001', 'Sede Principal', 1, 'Dirección Central'),
('SUC01', 'Sucursal 1', 0, 'Dirección Sucursal 1');
GO

-- =============================================
-- TABLAS DE SEGURIDAD Y USUARIOS
-- =============================================
CREATE TABLE Empleados (
    EmpleadoID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    Cedula VARCHAR(20) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    FechaIngreso DATE NOT NULL,
    RealizaExamenes BIT DEFAULT 0,
    Especialidad VARCHAR(100),
    NumeroLicencia VARCHAR(50),
    NumeroDPS VARCHAR(50),
    NumeroDEA VARCHAR(50),
    CargoID INT,
    DepartamentoID INT,
    Direccion VARCHAR(500),
    Telefono1 VARCHAR(20),
    Telefono2 VARCHAR(20),
    Email VARCHAR(100),
    PorcentajeComision DECIMAL(5,2) DEFAULT 0,
    Activo BIT DEFAULT 1,
    SucursalID INT,  -- Asociación a sucursal
    FechaCreacion DATETIME DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50)
);
GO
ALTER TABLE Empleados ADD CONSTRAINT FK_Empleados_Sucursales FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID);
GO

CREATE TABLE Usuarios (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
    EmpleadoID INT NOT NULL,
    NombreUsuario VARCHAR(50) UNIQUE NOT NULL,
    Clave VARCHAR(255) NOT NULL,
    Activo BIT DEFAULT 1,
    FechaUltimoAcceso DATETIME,
    IntentosLogin INT DEFAULT 0,
    FechaCreacion DATETIME DEFAULT GETDATE()
);
GO
ALTER TABLE Usuarios ADD CONSTRAINT FK_Usuarios_Empleados FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID);
GO

CREATE TABLE ControlAsistencia (
    AsistenciaID INT IDENTITY(1,1) PRIMARY KEY,
    EmpleadoID INT NOT NULL,
    Fecha DATE NOT NULL,
    HoraEntrada DATETIME,
    HoraSalida DATETIME,
    Observaciones VARCHAR(500)
);
GO
ALTER TABLE ControlAsistencia ADD CONSTRAINT FK_ControlAsistencia_Empleados FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID);
GO

CREATE TABLE Auditoria (
    AuditoriaID INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioID INT NOT NULL,
    Modulo VARCHAR(100) NOT NULL,
    Accion VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(500),
    FechaHora DATETIME DEFAULT GETDATE(),
    DireccionIP VARCHAR(50)
);
GO
ALTER TABLE Auditoria ADD CONSTRAINT FK_Auditoria_Usuarios FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID);
GO

-- =============================================
-- TABLAS DE CLIENTES Y PACIENTES
-- =============================================
CREATE TABLE Clientes (
    ClienteID INT IDENTITY(1,1) PRIMARY KEY,
    Cedula VARCHAR(20) UNIQUE NOT NULL,
    TipoCliente CHAR(1) CHECK (TipoCliente IN ('N', 'J')), -- Natural o Jurídico
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100),
    RIF VARCHAR(20),
    DigitoVerificador VARCHAR(5),
    FechaNacimiento DATE,
    Sexo CHAR(1) CHECK (Sexo IN ('M', 'F')),
    Direccion VARCHAR(500),
    Ciudad VARCHAR(100),
    Estado VARCHAR(100),
    CodigoPostal VARCHAR(10),
    Telefono1 VARCHAR(20),
    Telefono2 VARCHAR(20),
    Email VARCHAR(100),
    OcupacionID INT,
    ReferidoPor VARCHAR(100),
    EmpresaAfiliadaID INT,
    NumeroAfiliado VARCHAR(50),
    Activo BIT DEFAULT 1,
    SucursalID INT,  -- Asociación a sucursal si aplica
    FechaCreacion DATETIME DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50)
);
GO
ALTER TABLE Clientes ADD CONSTRAINT FK_Clientes_Sucursales FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID);
GO

CREATE TABLE FichaPaciente (
    FichaID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID INT NOT NULL UNIQUE,
    TipoSangre VARCHAR(5),
    Alergias VARCHAR(500),
    MedicamentosActuales VARCHAR(500),
    HistorialMedico VARCHAR(1000),
    ContactoEmergencia VARCHAR(100),
    TelefonoEmergencia VARCHAR(20),
    Observaciones VARCHAR(1000),
    FechaCreacion DATETIME DEFAULT GETDATE()
);
GO
ALTER TABLE FichaPaciente ADD CONSTRAINT FK_FichaPaciente_Clientes FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID);
GO

CREATE TABLE ExamenesOptometricos (
    ExamenID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID INT NOT NULL,
    EmpleadoID INT NOT NULL, -- Optometrista
    FechaExamen DATETIME NOT NULL,
    TipoExamen VARCHAR(50), -- Convencional, Lentes de Contacto
   
    -- OJO DERECHO
    EsferaOD DECIMAL(5,2),
    CilindroOD DECIMAL(5,2),
    EjeOD INT,
    AddOD DECIMAL(5,2),
    DNPOD DECIMAL(5,2),
    AlturaOD DECIMAL(5,2),
    PrismaOD DECIMAL(5,2),
    BaseOD VARCHAR(10),
   
    -- OJO IZQUIERDO
    EsferaOI DECIMAL(5,2),
    CilindroOI DECIMAL(5,2),
    EjeOI INT,
    AddOI DECIMAL(5,2),
    DNPOI DECIMAL(5,2),
    AlturaOI DECIMAL(5,2),
    PrismaOI DECIMAL(5,2),
    BaseOI VARCHAR(10),
   
    -- DATOS ADICIONALES
    TipoVision VARCHAR(20), -- Lejos, Cerca, Bifocal, Trifocal, Progresivo, Balance
    DiagnosticoOD VARCHAR(500),
    DiagnosticoOI VARCHAR(500),
    Observaciones VARCHAR(1000),
    FechaVencimiento DATE,
    Activo BIT DEFAULT 1
);
GO
ALTER TABLE ExamenesOptometricos ADD CONSTRAINT FK_ExamenesOptometricos_Clientes FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID);
ALTER TABLE ExamenesOptometricos ADD CONSTRAINT FK_ExamenesOptometricos_Empleados FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID);
GO

-- =============================================
-- TABLAS DE INVENTARIO
-- =============================================
CREATE TABLE TiposProducto (
    TipoProductoID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo CHAR(1) UNIQUE NOT NULL,
    Descripcion VARCHAR(100) NOT NULL,
    TipoInventario VARCHAR(50),
    UnidadVenta INT DEFAULT 1,
    VenderConExistencia BIT DEFAULT 1,
    PermitirVentaSinExistenciaOT BIT DEFAULT 0,
    RestringirEntregaSinExistencia BIT DEFAULT 1,
    ImprimirPrecioOT BIT DEFAULT 1,
    ExentoImpuesto BIT DEFAULT 0,
    UsarFactorMultiplicador BIT DEFAULT 1,
    EsObsequio BIT DEFAULT 0,
    Activo BIT DEFAULT 1
);
GO

CREATE TABLE Marcas (
    MarcaID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    Descripcion VARCHAR(100) NOT NULL,
    FactorMultiplicador DECIMAL(10,4) DEFAULT 1,
    Activo BIT DEFAULT 1
);
GO

CREATE TABLE Grupos (
    GrupoID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    Descripcion VARCHAR(100) NOT NULL,
    TipoProducto1 CHAR(1),
    TipoProducto2 CHAR(1),
    TipoProducto3 CHAR(1),
    Activo BIT DEFAULT 1
);
GO

CREATE TABLE Productos (
    ProductoID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    CodigoBarras VARCHAR(50),
    TipoProductoID INT NOT NULL,
    GrupoID INT,
    MarcaID INT,
    Descripcion VARCHAR(200) NOT NULL,
    Modelo VARCHAR(100),
    Color VARCHAR(50),
    Tamano VARCHAR(20),
   
    -- PRECIOS Y COSTOS
    CostoUnitario DECIMAL(18,2) DEFAULT 0,
    CostoUSD DECIMAL(18,2) DEFAULT 0,
    PrecioVenta DECIMAL(18,2) DEFAULT 0,
    PrecioVentaUSD DECIMAL(18,2) DEFAULT 0,
    FactorMultiplicador DECIMAL(10,4) DEFAULT 1,
    PorcentajeImpuesto DECIMAL(5,2) DEFAULT 16,
    ExentoImpuesto BIT DEFAULT 0,
   
    -- UBICACIÓN
    Pasillo VARCHAR(20),
    Estante VARCHAR(20),
    Nivel VARCHAR(20),
   
    ProveedorID INT,
    Activo BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50)
);
GO
ALTER TABLE Productos ADD CONSTRAINT FK_Productos_TiposProducto FOREIGN KEY (TipoProductoID) REFERENCES TiposProducto(TipoProductoID);
ALTER TABLE Productos ADD CONSTRAINT FK_Productos_Grupos FOREIGN KEY (GrupoID) REFERENCES Grupos(GrupoID);
ALTER TABLE Productos ADD CONSTRAINT FK_Productos_Marcas FOREIGN KEY (MarcaID) REFERENCES Marcas(MarcaID);
GO

CREATE TABLE InventarioSucursal (
    InventarioSucursalID INT IDENTITY(1,1) PRIMARY KEY,
    SucursalID INT NOT NULL,
    ProductoID INT NOT NULL,
    ExistenciaActual INT DEFAULT 0,
    ExistenciaMinima INT DEFAULT 0,
    ExistenciaMaxima INT DEFAULT 0,
    UltimaActualizacion DATETIME DEFAULT GETDATE()
);
GO
ALTER TABLE InventarioSucursal ADD CONSTRAINT UQ_InventarioSucursal_SucursalProducto UNIQUE (SucursalID, ProductoID);
ALTER TABLE InventarioSucursal ADD CONSTRAINT FK_InventarioSucursal_Sucursales FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID);
ALTER TABLE InventarioSucursal ADD CONSTRAINT FK_InventarioSucursal_Productos FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID);
GO

CREATE TABLE MovimientosInventario (
    MovimientoID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL,
    SucursalID INT,  -- Sucursal del movimiento
    TipoMovimiento VARCHAR(50) NOT NULL, -- Entrada, Salida, Ajuste, Traspaso
    DocumentoReferencia VARCHAR(50),
    Cantidad INT NOT NULL,
    CostoUnitario DECIMAL(18,2),
    Motivo VARCHAR(500),
    EmpleadoID INT,
    FechaMovimiento DATETIME DEFAULT GETDATE()
);
GO
ALTER TABLE MovimientosInventario ADD CONSTRAINT FK_MovimientosInventario_Productos FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID);
ALTER TABLE MovimientosInventario ADD CONSTRAINT FK_MovimientosInventario_Sucursales FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID);
ALTER TABLE MovimientosInventario ADD CONSTRAINT FK_MovimientosInventario_Empleados FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID);
GO

-- =============================================
-- TABLAS DE PROVEEDORES Y COMPRAS
-- =============================================
CREATE TABLE Proveedores (
    ProveedorID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    Nombre VARCHAR(200) NOT NULL,
    RIF VARCHAR(20),
    NIT VARCHAR(20),
    Direccion VARCHAR(500),
    Ciudad VARCHAR(100),
    Telefono VARCHAR(20),
    Fax VARCHAR(20),
    Email VARCHAR(100),
    PaginaWeb VARCHAR(200),
    Contacto1 VARCHAR(100),
    Contacto2 VARCHAR(100),
    Contacto3 VARCHAR(100),
    ConceptoEgresoID INT,
    Activo BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE Laboratorios (
    LaboratorioID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    Descripcion VARCHAR(200) NOT NULL,
    Contacto VARCHAR(100),
    Direccion VARCHAR(500),
    Telefono VARCHAR(20),
    Fax VARCHAR(20),
    Email VARCHAR(100),
    Activo BIT DEFAULT 1
);
GO

CREATE TABLE RecepcionMercancia (
    RecepcionID INT IDENTITY(1,1) PRIMARY KEY,
    NumeroRecepcion VARCHAR(20) UNIQUE NOT NULL,
    ProveedorID INT NOT NULL,
    SucursalID INT NOT NULL,  -- Sucursal que recibe
    FacturaProveedor VARCHAR(50),
    FechaRecepcion DATETIME NOT NULL,
    MontoTotal DECIMAL(18,2) DEFAULT 0,
    Observaciones VARCHAR(500),
    Confirmada BIT DEFAULT 0,
    FechaConfirmacion DATETIME,
    EmpleadoID INT
);
GO
ALTER TABLE RecepcionMercancia ADD CONSTRAINT FK_RecepcionMercancia_Proveedores FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID);
ALTER TABLE RecepcionMercancia ADD CONSTRAINT FK_RecepcionMercancia_Sucursales FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID);
ALTER TABLE RecepcionMercancia ADD CONSTRAINT FK_RecepcionMercancia_Empleados FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID);
GO

CREATE TABLE DetalleRecepcionMercancia (
    DetalleRecepcionID INT IDENTITY(1,1) PRIMARY KEY,
    RecepcionID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    CostoUnitario DECIMAL(18,2) NOT NULL,
    CostoUSD DECIMAL(18,2),
    TotalLinea DECIMAL(18,2)
);
GO
ALTER TABLE DetalleRecepcionMercancia ADD CONSTRAINT FK_DetalleRecepcionMercancia_RecepcionMercancia FOREIGN KEY (RecepcionID) REFERENCES RecepcionMercancia(RecepcionID);
ALTER TABLE DetalleRecepcionMercancia ADD CONSTRAINT FK_DetalleRecepcionMercancia_Productos FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID);
GO

-- =============================================
-- TABLAS DE TRANSFERENCIAS ENTRE SUCURSALES
-- =============================================
CREATE TABLE Transferencias (
    TransferenciaID INT IDENTITY(1,1) PRIMARY KEY,
    NumeroTransferencia VARCHAR(20) UNIQUE NOT NULL,
    SucursalOrigenID INT NOT NULL,
    SucursalDestinoID INT NOT NULL,
    FechaTransferencia DATETIME NOT NULL,
    Motivo VARCHAR(500),  -- e.g., Devolución, Ajuste, Daños
    Status VARCHAR(20) DEFAULT 'Pendiente',  -- Pendiente, Confirmada, Recibida, Anulada
    Confirmada BIT DEFAULT 0,
    EmpleadoID INT NOT NULL,
    Observaciones VARCHAR(1000),
    FechaCreacion DATETIME DEFAULT GETDATE()
);
GO
ALTER TABLE Transferencias ADD CONSTRAINT FK_Transferencias_SucursalOrigen FOREIGN KEY (SucursalOrigenID) REFERENCES Sucursales(SucursalID);
ALTER TABLE Transferencias ADD CONSTRAINT FK_Transferencias_SucursalDestino FOREIGN KEY (SucursalDestinoID) REFERENCES Sucursales(SucursalID);
ALTER TABLE Transferencias ADD CONSTRAINT FK_Transferencias_Empleados FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID);
GO

CREATE TABLE DetalleTransferencias (
    DetalleTransferenciaID INT IDENTITY(1,1) PRIMARY KEY,
    TransferenciaID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    CostoUnitario DECIMAL(18,2)
);
GO
ALTER TABLE DetalleTransferencias ADD CONSTRAINT FK_DetalleTransferencias_Transferencias FOREIGN KEY (TransferenciaID) REFERENCES Transferencias(TransferenciaID);
ALTER TABLE DetalleTransferencias ADD CONSTRAINT FK_DetalleTransferencias_Productos FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID);
GO

-- =============================================
-- TABLAS DE VENTAS Y FACTURACIÓN
-- =============================================
CREATE TABLE Facturas (
    FacturaID INT IDENTITY(1,1) PRIMARY KEY,
    NumeroFactura VARCHAR(20) UNIQUE NOT NULL,
    NumeroControl VARCHAR(20),
    TipoVenta VARCHAR(20) NOT NULL, -- Directa, OrdenTrabajo
    ClienteID INT NOT NULL,
    EmpleadoID INT NOT NULL,
    SucursalID INT NOT NULL,  -- Sucursal de la venta
    FechaFactura DATETIME NOT NULL,
   
    -- MONTOS
    Subtotal DECIMAL(18,2) DEFAULT 0,
    PorcentajeDescuento DECIMAL(5,2) DEFAULT 0,
    MontoDescuento DECIMAL(18,2) DEFAULT 0,
    BaseImponible DECIMAL(18,2) DEFAULT 0,
    PorcentajeImpuesto DECIMAL(5,2) DEFAULT 16,
    MontoImpuesto DECIMAL(18,2) DEFAULT 0,
    MontoExento DECIMAL(18,2) DEFAULT 0,
    PorcentajeIGTF DECIMAL(5,2) DEFAULT 3,
    MontoIGTF DECIMAL(18,2) DEFAULT 0,
    Total DECIMAL(18,2) DEFAULT 0,
   
    -- PAGOS
    TotalAbonado DECIMAL(18,2) DEFAULT 0,
    Saldo DECIMAL(18,2) DEFAULT 0,
   
    Status VARCHAR(20) DEFAULT 'Activa', -- Activa, Cancelada, Anulada
    EmpresaAfiliadaID INT,
    Observaciones VARCHAR(500),
    TasaCambio DECIMAL(18,6),
   
    FechaCreacion DATETIME DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50)
);
GO
ALTER TABLE Facturas ADD CONSTRAINT FK_Facturas_Clientes FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID);
ALTER TABLE Facturas ADD CONSTRAINT FK_Facturas_Empleados FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID);
ALTER TABLE Facturas ADD CONSTRAINT FK_Facturas_Sucursales FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID);
GO

CREATE TABLE DetalleFactura (
    DetalleFacturaID INT IDENTITY(1,1) PRIMARY KEY,
    FacturaID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    PorcentajeDescuento DECIMAL(5,2) DEFAULT 0,
    MontoDescuento DECIMAL(18,2) DEFAULT 0,
    Subtotal DECIMAL(18,2),
    PorcentajeImpuesto DECIMAL(5,2) DEFAULT 16,
    MontoImpuesto DECIMAL(18,2),
    Total DECIMAL(18,2),
    ExentoImpuesto BIT DEFAULT 0
);
GO
ALTER TABLE DetalleFactura ADD CONSTRAINT FK_DetalleFactura_Facturas FOREIGN KEY (FacturaID) REFERENCES Facturas(FacturaID);
ALTER TABLE DetalleFactura ADD CONSTRAINT FK_DetalleFactura_Productos FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID);
GO

CREATE TABLE OrdenesTrabajo (
    OrdenTrabajoID INT IDENTITY(1,1) PRIMARY KEY,
    NumeroOrden VARCHAR(20) UNIQUE NOT NULL,
    ClienteID INT NOT NULL,
    EmpleadoID INT NOT NULL,
    SucursalID INT NOT NULL,  -- Sucursal de la orden
    ExamenID INT,
    LaboratorioID INT,
    TipoLente VARCHAR(50), -- Convencionales, Contacto
   
    FechaOrden DATETIME NOT NULL,
    FechaEntregaEstimada DATE,
    FechaEntregaReal DATE,
   
    -- MONTOS
    MontoTotal DECIMAL(18,2) DEFAULT 0,
    TotalAbonado DECIMAL(18,2) DEFAULT 0,
    Saldo DECIMAL(18,2) DEFAULT 0,
   
    Ubicacion VARCHAR(50), -- Laboratorio, Optica, Montaje, Gaveta
    Status VARCHAR(20) DEFAULT 'Pendiente', -- Pendiente, EnProceso, Recibida, Entregada, Anulada
    Entregada BIT DEFAULT 0,
    Observaciones VARCHAR(1000),
   
    -- COSTOS (si aplica)
    CostoLaboratorio DECIMAL(18,2),
    CostoMontaje DECIMAL(18,2),
    NumeroDocumentoLab VARCHAR(50),
   
    TasaCambio DECIMAL(18,6),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50)
);
GO
ALTER TABLE OrdenesTrabajo ADD CONSTRAINT FK_OrdenesTrabajo_Clientes FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID);
ALTER TABLE OrdenesTrabajo ADD CONSTRAINT FK_OrdenesTrabajo_Empleados FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID);
ALTER TABLE OrdenesTrabajo ADD CONSTRAINT FK_OrdenesTrabajo_Sucursales FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID);
ALTER TABLE OrdenesTrabajo ADD CONSTRAINT FK_OrdenesTrabajo_Examenes FOREIGN KEY (ExamenID) REFERENCES ExamenesOptometricos(ExamenID);
ALTER TABLE OrdenesTrabajo ADD CONSTRAINT FK_OrdenesTrabajo_Laboratorios FOREIGN KEY (LaboratorioID) REFERENCES Laboratorios(LaboratorioID);
GO

CREATE TABLE DetalleOrdenTrabajo (
    DetalleOrdenID INT IDENTITY(1,1) PRIMARY KEY,
    OrdenTrabajoID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    Subtotal DECIMAL(18,2),
    Ojo VARCHAR(10) -- Derecho, Izquierdo, Ambos
);
GO
ALTER TABLE DetalleOrdenTrabajo ADD CONSTRAINT FK_DetalleOrdenTrabajo_OrdenesTrabajo FOREIGN KEY (OrdenTrabajoID) REFERENCES OrdenesTrabajo(OrdenTrabajoID);
ALTER TABLE DetalleOrdenTrabajo ADD CONSTRAINT FK_DetalleOrdenTrabajo_Productos FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID);
GO

CREATE TABLE RevisionesOT (
    RevisionID INT IDENTITY(1,1) PRIMARY KEY,
    OrdenTrabajoID INT NOT NULL,
    CausaRevisionID INT NOT NULL,
    FechaRevision DATETIME NOT NULL,
    EmpleadoID INT NOT NULL,
    Observaciones VARCHAR(500),
    Status VARCHAR(20) -- Enviada, Recibida
);
GO
ALTER TABLE RevisionesOT ADD CONSTRAINT FK_RevisionesOT_OrdenesTrabajo FOREIGN KEY (OrdenTrabajoID) REFERENCES OrdenesTrabajo(OrdenTrabajoID);
ALTER TABLE RevisionesOT ADD CONSTRAINT FK_RevisionesOT_Empleados FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID);
GO

-- =============================================
-- TABLAS DE PAGOS
-- =============================================
CREATE TABLE TiposPago (
    TipoPagoID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    Descripcion VARCHAR(100) NOT NULL,
    RequiereReferencia BIT DEFAULT 0,
    Activo BIT DEFAULT 1
);
GO

CREATE TABLE Pagos (
    PagoID INT IDENTITY(1,1) PRIMARY KEY,
    NumeroRecibo VARCHAR(20) UNIQUE NOT NULL,
    TipoDocumento VARCHAR(20), -- Factura, OrdenTrabajo, VentaPendiente
    DocumentoID INT NOT NULL,
    ClienteID INT NOT NULL,
    SucursalID INT NOT NULL,  -- Sucursal del pago
    FechaPago DATETIME NOT NULL,
    MontoPago DECIMAL(18,2) NOT NULL,
    TasaCambio DECIMAL(18,6),
    EmpleadoID INT NOT NULL,
    Observaciones VARCHAR(500),
    Anulado BIT DEFAULT 0,
    FechaAnulacion DATETIME
);
GO
ALTER TABLE Pagos ADD CONSTRAINT FK_Pagos_Clientes FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID);
ALTER TABLE Pagos ADD CONSTRAINT FK_Pagos_Sucursales FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID);
ALTER TABLE Pagos ADD CONSTRAINT FK_Pagos_Empleados FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID);
GO

CREATE TABLE DetallePagos (
    DetallePagoID INT IDENTITY(1,1) PRIMARY KEY,
    PagoID INT NOT NULL,
    TipoPagoID INT NOT NULL,
    Monto DECIMAL(18,2) NOT NULL,
    MontoUSD DECIMAL(18,2),
   
    -- Para Cheques
    BancoID INT,
    NumeroCheque VARCHAR(50),
   
    -- Para Tarjetas
    TarjetaID INT,
    NumeroReferencia VARCHAR(50),
    Lote VARCHAR(50),
   
    -- Para Transferencias
    NumeroConfirmacion VARCHAR(50),
   
    -- Para Créditos
    EmpresaAfiliadaID INT,
    TipoCredito VARCHAR(50), -- Nomina, CajaAhorro, CtaBanco, Otro
    NumeroCuotas INT,
    MontoCuota DECIMAL(18,2),
    FrecuenciaPago CHAR(1) -- S=Semanal, Q=Quincenal, M=Mensual
);
GO
ALTER TABLE DetallePagos ADD CONSTRAINT FK_DetallePagos_Pagos FOREIGN KEY (PagoID) REFERENCES Pagos(PagoID);
ALTER TABLE DetallePagos ADD CONSTRAINT FK_DetallePagos_TiposPago FOREIGN KEY (TipoPagoID) REFERENCES TiposPago(TipoPagoID);
GO

-- =============================================
-- TABLAS DE NOTAS
-- =============================================
CREATE TABLE NotasCredito (
    NotaCreditoID INT IDENTITY(1,1) PRIMARY KEY,
    NumeroNota VARCHAR(20) UNIQUE NOT NULL,
    NumeroControl VARCHAR(20),
    TipoDocumento VARCHAR(20), -- Factura, OrdenTrabajo
    DocumentoID INT NOT NULL,
    ClienteID INT NOT NULL,
    FechaNota DATETIME NOT NULL,
    Motivo VARCHAR(500),
   
    MontoTotal DECIMAL(18,2) DEFAULT 0,
    MontoDisponible DECIMAL(18,2) DEFAULT 0,
    PorcentajeIGTF DECIMAL(5,2) DEFAULT 3,
    MontoIGTF DECIMAL(18,2) DEFAULT 0,
   
    Aplicada BIT DEFAULT 0,
    EmpleadoID INT NOT NULL,
    TasaCambio DECIMAL(18,6),
    FechaCreacion DATETIME DEFAULT GETDATE()
);
GO
ALTER TABLE NotasCredito ADD CONSTRAINT FK_NotasCredito_Clientes FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID);
ALTER TABLE NotasCredito ADD CONSTRAINT FK_NotasCredito_Empleados FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID);
GO

CREATE TABLE NotasDebito (
    NotaDebitoID INT IDENTITY(1,1) PRIMARY KEY,
    NumeroNota VARCHAR(20) UNIQUE NOT NULL,
    NumeroControl VARCHAR(20),
    FacturaID INT NOT NULL,
    FechaNota DATETIME NOT NULL,
    Motivo VARCHAR(50), -- DiferencialCambiario, InteresMora, Otro
    MotivoDetalle VARCHAR(500),
   
    Subtotal DECIMAL(18,2) DEFAULT 0,
    PorcentajeImpuesto DECIMAL(5,2) DEFAULT 16,
    MontoImpuesto DECIMAL(18,2) DEFAULT 0,
    MontoExento DECIMAL(18,2) DEFAULT 0,
    Total DECIMAL(18,2) DEFAULT 0,
   
    EmpleadoID INT NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE()
);
GO
ALTER TABLE NotasDebito ADD CONSTRAINT FK_NotasDebito_Facturas FOREIGN KEY (FacturaID) REFERENCES Facturas(FacturaID);
ALTER TABLE NotasDebito ADD CONSTRAINT FK_NotasDebito_Empleados FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID);
GO

-- =============================================
-- TABLAS DE CAJA
-- =============================================
CREATE TABLE CierreCaja (
    CierreID INT IDENTITY(1,1) PRIMARY KEY,
    NumeroCierre VARCHAR(20) UNIQUE NOT NULL,
    TipoCierre VARCHAR(20) NOT NULL, -- Parcial, Definitivo
    SucursalID INT NOT NULL,  -- Cierre por sucursal
    FechaCierre DATE NOT NULL,
    HoraCierre DATETIME NOT NULL,
   
    EmpleadoID INT NOT NULL,
    EmpleadoResponsable INT,
   
    -- INGRESOS
    TotalEfectivo DECIMAL(18,2) DEFAULT 0,
    TotalCheques DECIMAL(18,2) DEFAULT 0,
    TotalTarjetaCredito DECIMAL(18,2) DEFAULT 0,
    TotalTarjetaDebito DECIMAL(18,2) DEFAULT 0,
    TotalDepositos DECIMAL(18,2) DEFAULT 0,
    TotalDivisas DECIMAL(18,2) DEFAULT 0,
    TotalIngresos DECIMAL(18,2) DEFAULT 0,
   
    -- EGRESOS
    TotalGastos DECIMAL(18,2) DEFAULT 0,
    TotalReintegros DECIMAL(18,2) DEFAULT 0,
   
    -- DEPOSITOS
    TotalDepositar DECIMAL(18,2) DEFAULT 0,
   
    Observaciones VARCHAR(1000),
    Confirmado BIT DEFAULT 0
);
GO
ALTER TABLE CierreCaja ADD CONSTRAINT FK_CierreCaja_Sucursales FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID);
ALTER TABLE CierreCaja ADD CONSTRAINT FK_CierreCaja_Empleados FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID);
GO

CREATE TABLE DetalleCierreCaja (
    DetalleCierreID INT IDENTITY(1,1) PRIMARY KEY,
    CierreID INT NOT NULL,
    TipoMovimiento VARCHAR(50),
    Concepto VARCHAR(200),
    Monto DECIMAL(18,2)
);
GO
ALTER TABLE DetalleCierreCaja ADD CONSTRAINT FK_DetalleCierreCaja_CierreCaja FOREIGN KEY (CierreID) REFERENCES CierreCaja(CierreID);
GO

-- =============================================
-- TABLAS GENERALES Y CONFIGURACIÓN
-- =============================================
CREATE TABLE EmpresasAfiliadas (
    EmpresaAfiliadaID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    Nombre VARCHAR(200) NOT NULL,
    Contacto1 VARCHAR(100),
    Contacto2 VARCHAR(100),
    CajaAhorro BIT DEFAULT 0,
    Telefono VARCHAR(20),
    Fax VARCHAR(20),
    Direccion VARCHAR(500),
    PorcentajeDescuentoEfectivo DECIMAL(5,2) DEFAULT 0,
    PorcentajeDescuentoTarjeta DECIMAL(5,2) DEFAULT 0,
    Activo BIT DEFAULT 1
);
GO

CREATE TABLE Ocupaciones (
    OcupacionID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    Descripcion VARCHAR(100) NOT NULL,
    Activo BIT DEFAULT 1
);
GO

CREATE TABLE CausasRevision (
    CausaRevisionID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    Descripcion VARCHAR(200) NOT NULL,
    Origen VARCHAR(50), -- Laboratorio, Montaje, Optica
    Activo BIT DEFAULT 1
);
GO

CREATE TABLE Monedas (
    MonedaID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(10) UNIQUE NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Simbolo VARCHAR(5),
    TasaCosto DECIMAL(18,6) DEFAULT 1,
    TasaVenta DECIMAL(18,6) DEFAULT 1,
    FechaActualizacion DATETIME DEFAULT GETDATE(),
    Activo BIT DEFAULT 1
);
GO

CREATE TABLE ConfiguracionGlobal (
    ConfiguracionID INT PRIMARY KEY,
   
    -- UBICACION
    NombreEmpresa VARCHAR(200),
    RIF VARCHAR(20),
    Direccion VARCHAR(500),
    Ciudad VARCHAR(100),
    Telefono VARCHAR(20),
    Fax VARCHAR(20),
    Email VARCHAR(100),
    PaginaWeb VARCHAR(200),
   
    -- INVENTARIO
    CodigoArticuloAutomatico BIT DEFAULT 1,
    PermitirDuplicidadConteoFisico BIT DEFAULT 0,
    CierreInventarioAutomatico BIT DEFAULT 1,
   
    -- CAJA Y VENTAS
    ActivarImpuestoVenta BIT DEFAULT 1,
    PorcentajeImpuesto DECIMAL(5,2) DEFAULT 16,
    ActivarIGTF BIT DEFAULT 0,
    PorcentajeIGTF DECIMAL(5,2) DEFAULT 3,
    PermitirModificarImpuesto BIT DEFAULT 0,
    FondoCaja DECIMAL(18,2) DEFAULT 0,
    MetodoRedondeo VARCHAR(20) DEFAULT 'Normal',
    SolicitarDireccionVentas BIT DEFAULT 1,
   
    -- CONTROL
    ActivarControlAsistencia BIT DEFAULT 1,
    ActivarValidacionAfiliados BIT DEFAULT 0,
   
    -- ORDENES DE TRABAJO
    PorcentajeMinimoAnticipoOT DECIMAL(5,2) DEFAULT 50,
    DiasEntregaOT INT DEFAULT 7,
    ImprimirEncabezadoOT BIT DEFAULT 1,
    RegistrarCostoOrden BIT DEFAULT 1,
    RegistrarCostoMontaje BIT DEFAULT 1,
   
    SucursalID INT,  -- Config por sucursal si aplica
    FechaActualizacion DATETIME DEFAULT GETDATE()
);
GO
ALTER TABLE ConfiguracionGlobal ADD CONSTRAINT FK_ConfiguracionGlobal_Sucursales FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID);
GO

-- Insertar configuración por defecto
INSERT INTO ConfiguracionGlobal (ConfiguracionID, NombreEmpresa, PorcentajeImpuesto, PorcentajeIGTF)
VALUES (1, 'OPTIVEN - Sistema de Gestión Óptica', 16, 3);
GO

-- =============================================
-- ÍNDICES ADICIONALES PARA RENDIMIENTO
-- =============================================
CREATE INDEX IX_Clientes_Cedula ON Clientes(Cedula);
CREATE INDEX IX_Clientes_Nombre ON Clientes(Nombre, Apellido);
CREATE INDEX IX_Productos_Codigo ON Productos(Codigo);
CREATE INDEX IX_Productos_CodigoBarras ON Productos(CodigoBarras);
CREATE INDEX IX_Facturas_Fecha ON Facturas(FechaFactura);
CREATE INDEX IX_Facturas_Cliente ON Facturas(ClienteID);
CREATE INDEX IX_OrdenesTrabajo_Fecha ON OrdenesTrabajo(FechaOrden);
CREATE INDEX IX_OrdenesTrabajo_Status ON OrdenesTrabajo(Status);
CREATE INDEX IX_InventarioSucursal_SucursalProducto ON InventarioSucursal(SucursalID, ProductoID);
CREATE INDEX IX_Facturas_Sucursal ON Facturas(SucursalID);
CREATE INDEX IX_OrdenesTrabajo_Sucursal ON OrdenesTrabajo(SucursalID);
CREATE INDEX IX_Transferencias_OrigenDestino ON Transferencias(SucursalOrigenID, SucursalDestinoID);
GO

-- =============================================
-- DATOS INICIALES
-- =============================================
-- Tipos de Producto
INSERT INTO TiposProducto (Codigo, Descripcion, TipoInventario) VALUES
('M', 'Monturas Correctivas', 'UNIDAD'),
('S', 'Lentes de Sol', 'UNIDAD'),
('C', 'Cristales', 'PAR'),
('L', 'Lentes de Contacto', 'UNIDAD'),
('Q', 'Líquidos', 'UNIDAD');
GO

-- =============================================
-- TRIGGER DE EJEMPLO PARA TRANSFERENCIAS
-- =============================================
CREATE TRIGGER TR_ConfirmarTransferencia
ON Transferencias
AFTER UPDATE
AS
BEGIN
    IF UPDATE(Confirmada)
    BEGIN
        DECLARE @TransferenciaID INT, @SucOrigen INT, @SucDestino INT;
        SELECT @TransferenciaID = i.TransferenciaID, @SucOrigen = i.SucursalOrigenID, @SucDestino = i.SucursalDestinoID
        FROM inserted i WHERE i.Confirmada = 1;

        -- Actualizar inventario origen (restar)
        UPDATE invO
        SET invO.ExistenciaActual = invO.ExistenciaActual - dt.Cantidad
        FROM InventarioSucursal invO
        INNER JOIN DetalleTransferencias dt ON invO.ProductoID = dt.ProductoID
        WHERE dt.TransferenciaID = @TransferenciaID AND invO.SucursalID = @SucOrigen;

        -- Actualizar inventario destino (sumar)
        UPDATE invD
        SET invD.ExistenciaActual = invD.ExistenciaActual + dt.Cantidad
        FROM InventarioSucursal invD
        INNER JOIN DetalleTransferencias dt ON invD.ProductoID = dt.ProductoID
        WHERE dt.TransferenciaID = @TransferenciaID AND invD.SucursalID = @SucDestino;
    END
END;
GO