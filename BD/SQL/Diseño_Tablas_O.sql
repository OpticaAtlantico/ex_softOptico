-- =====================================================================
-- SCRIPT DE CREACIÓN DE BASE DE DATOS: BDOPTICA
-- Versión: 2.0 (Corregida y Optimizada)
-- Fecha: 06/12/2025
-- Descripción: Sistema de gestión para óptica
-- =====================================================================

-- Crear base de datos si no existe
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

-- =====================================================================
-- SECCIÓN 1: TABLAS MAESTRAS (CATÁLOGOS)
-- Propósito: Datos de referencia estándar del sistema
-- =====================================================================

-- Tabla: TAlicuota
-- Propósito: Almacenar tasas de impuestos e IVA
CREATE TABLE TAlicuota (
    idAlicuota INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(150) NOT NULL,
    alicuota DECIMAL(5,2) NOT NULL, -- Cambiado de INT a DECIMAL para porcentajes
    activo BIT NOT NULL DEFAULT 1,
    fechaCreacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT CHK_Alicuota_Valor CHECK (alicuota >= 0 AND alicuota <= 100)
);

-- Tabla: TEstadoOrden
-- Propósito: Estados de órdenes (Apartado, Pagado, Entregado, Cancelado, etc.)
CREATE TABLE TEstadoOrden (
    idEstadoOrden INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(150) NOT NULL UNIQUE,
    activo BIT NOT NULL DEFAULT 1
);

-- Tabla: TTipoPago
-- Propósito: Métodos de pago (Efectivo, Transferencia, Pago Móvil, Tarjeta, etc.)
CREATE TABLE TTipoPago (
    idTipoPago INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(150) NOT NULL UNIQUE,
    activo BIT NOT NULL DEFAULT 1
);

-- Tabla: TTipoMovimiento
-- Propósito: Tipos de movimientos de inventario (Entrada, Salida, Ajuste, Traslado)
CREATE TABLE TTipoMovimiento (
    idTipoMovimiento INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(150) NOT NULL UNIQUE,
    afectaInventario CHAR(1) NOT NULL, -- '+' suma, '-' resta, '=' ajuste
    activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT CHK_TipoMov_Afecta CHECK (afectaInventario IN ('+', '-', '='))
);

-- Tabla: TColor
-- Propósito: Catálogo de colores para monturas y productos
CREATE TABLE TColor (
    idColor INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(10) UNIQUE,
    descripcion NVARCHAR(50) NOT NULL UNIQUE,
    activo BIT NOT NULL DEFAULT 1
);

-- Tabla: TMaterial
-- Propósito: Tipos de materiales (Acetato, Metal, Titanio, Plástico, etc.)
CREATE TABLE TMaterial (
    idMaterial INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(10) UNIQUE,
    descripcion NVARCHAR(50) NOT NULL UNIQUE,
    activo BIT NOT NULL DEFAULT 1
);

-- Tabla: TCategoria
-- Propósito: Categorías de productos
CREATE TABLE TCategoria (
    idCategoria INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(15) UNIQUE,
    descripcion NVARCHAR(150) NOT NULL UNIQUE,
    activo BIT NOT NULL DEFAULT 1
);

-- Tabla: TTipoVisionMontura
-- Propósito: Tipos de visión para monturas (Monofocal, Bifocal, Progresivo, etc.)
CREATE TABLE TTipoVisionMontura (
    idTVMontura INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(10) UNIQUE,
    descripcion NVARCHAR(50) NOT NULL UNIQUE,
    activo BIT NOT NULL DEFAULT 1
);

-- Tabla: TTipoVisionCristal
-- Propósito: Tipos de visión para cristales (Monofocal, Bifocal, Progresivo, etc.)
CREATE TABLE TTipoVisionCristal (
    idTVCristal INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(10) UNIQUE,
    descripcion NVARCHAR(50) NOT NULL UNIQUE,
    activo BIT NOT NULL DEFAULT 1
);

-- =====================================================================
-- SECCIÓN 2: TABLAS ÚNICAS (DATOS OPERATIVOS)
-- Propósito: Entidades únicas que alimentan el sistema
-- =====================================================================

-- Tabla: TCargo
-- Propósito: Cargos de empleados (Gerente, Vendedor, Optometrista, etc.)
CREATE TABLE TCargo (
    idCargo INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(10) UNIQUE,
    descripcion NVARCHAR(150) NOT NULL UNIQUE,
    activo BIT NOT NULL DEFAULT 1
);

-- Tabla: TRol
-- Propósito: Roles del sistema (Administrador, Usuario, Consulta, etc.)
CREATE TABLE TRol (
    idRol INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(10) UNIQUE,
    descripcion NVARCHAR(150) NOT NULL UNIQUE,
    activo BIT NOT NULL DEFAULT 1
);

-- Tabla: TGrupo
-- Propósito: Grupos de productos (clasificación principal)
CREATE TABLE TGrupo (
    idGrupo INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(15) UNIQUE,
    descripcion NVARCHAR(50) NOT NULL UNIQUE,
    tipoProducto1 INT NULL, -- Referencias opcionales a tipos de producto
    tipoProducto2 INT NULL,
    tipoProducto3 INT NULL,
    activo BIT NOT NULL DEFAULT 1
);

-- Tabla: TMarca
-- Propósito: Marcas de productos
CREATE TABLE TMarca (
    idMarca INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(15) UNIQUE,
    descripcion NVARCHAR(50) NOT NULL UNIQUE,
    factorMulti DECIMAL(5,2) DEFAULT 1.00,
    activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT CHK_FactorMulti CHECK (factorMulti > 0)
);

-- Tabla: TZona
-- Propósito: Zonas geográficas (Estados, Regiones, etc.)
CREATE TABLE TZona (
    idZona INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(10) UNIQUE,
    descripcion NVARCHAR(150) NOT NULL UNIQUE,
    activo BIT NOT NULL DEFAULT 1
);

-- Tabla: TCompania
-- Propósito: Datos de la empresa principal
CREATE TABLE TCompania (
    idCompania INT IDENTITY(1,1) PRIMARY KEY,
    codigo INT NOT NULL UNIQUE,
    razonSocial NVARCHAR(250) NOT NULL,
    rif NVARCHAR(50) NULL,
    nit NVARCHAR(50) NULL,
    telefono NVARCHAR(120) NULL,
    fax NVARCHAR(30) NULL,
    director1 NVARCHAR(250) NULL,
    director2 NVARCHAR(250) NULL,
    director3 NVARCHAR(250) NULL,
    direccion NVARCHAR(MAX) NULL,
    cierreFiscal NVARCHAR(5) NOT NULL,
    tipoEmpresa CHAR(1) NOT NULL, -- 'N'=Natural, 'J'=Jurídico, 'G'=Gobierno
    predeterminada BIT NOT NULL DEFAULT 0,
    activo BIT NOT NULL DEFAULT 1,
    fechaCreacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT CHK_TipoEmpresa CHECK (tipoEmpresa IN ('N', 'J', 'G'))
);

-- =====================================================================
-- SECCIÓN 3: TABLAS MAYORES (ENTIDADES PRINCIPALES)
-- Propósito: Tablas principales con múltiples relaciones
-- =====================================================================

-- Tabla: TCiudad
-- Propósito: Ciudades por zona
CREATE TABLE TCiudad (
    idCiudad INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(10) UNIQUE,
    descripcion NVARCHAR(150) NOT NULL,
    idZona INT NOT NULL,
    activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_TCiudad_TZona FOREIGN KEY (idZona) REFERENCES TZona(idZona)
);
CREATE INDEX IX_TCiudad_Zona ON TCiudad(idZona);

-- Tabla: TSucursal
-- Propósito: Sucursales de la empresa
CREATE TABLE TSucursal (
    idSucursal INT IDENTITY(1,1) PRIMARY KEY,
    codigo INT NOT NULL UNIQUE,
    descripcion NVARCHAR(100) NOT NULL,
    tipo NVARCHAR(50) NOT NULL, -- Principal, Secundaria, etc.
    direccion NVARCHAR(255) NOT NULL,
    idZona INT NOT NULL,
    idCiudad INT NULL,
    rif NVARCHAR(50) NOT NULL UNIQUE,
    telefono NVARCHAR(50) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    activa BIT NOT NULL DEFAULT 1,
    fechaRegistro DATETIME DEFAULT GETDATE(),
    idCompania INT NOT NULL,
    CONSTRAINT FK_TSucursal_TCompania FOREIGN KEY (idCompania) REFERENCES TCompania(idCompania),
    CONSTRAINT FK_TSucursal_TZona FOREIGN KEY (idZona) REFERENCES TZona(idZona),
    CONSTRAINT FK_TSucursal_TCiudad FOREIGN KEY (idCiudad) REFERENCES TCiudad(idCiudad)
);
CREATE INDEX IX_TSucursal_Compania ON TSucursal(idCompania);
CREATE INDEX IX_TSucursal_Zona ON TSucursal(idZona);

-- Tabla: TTipoProducto
-- Propósito: Configuración de tipos de productos
CREATE TABLE TTipoProducto (
    idTipoProducto INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(15) UNIQUE,
    descripcion NVARCHAR(150) NOT NULL,
    tipoInventario INT NOT NULL, -- 1=Cristales, 2=Monturas, 3=Lentes Contacto, 4=Genérico
    unidadVenta INT NOT NULL DEFAULT 1,
    conExistencia BIT DEFAULT 0,
    sinExistenciaVenta BIT DEFAULT 0,
    restringirArticulo BIT DEFAULT 0,
    imprimirPrecio BIT DEFAULT 1,
    conExento BIT DEFAULT 0,
    idAlicuota INT NULL,
    factorMulti BIT DEFAULT 0,
    factorMultiValue DECIMAL(5,2) NULL,
    factorMultiTipo BIT DEFAULT 0, -- 0=Por Marca, 1=Por Tipo Producto
    idCategoria INT NOT NULL,
    activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_TTipoProducto_TCategoria FOREIGN KEY (idCategoria) REFERENCES TCategoria(idCategoria),
    CONSTRAINT FK_TTipoProducto_TAlicuota FOREIGN KEY (idAlicuota) REFERENCES TAlicuota(idAlicuota),
    CONSTRAINT CHK_TipoInventario CHECK (tipoInventario IN (1, 2, 3, 4)),
    CONSTRAINT CHK_FactorMultiValue CHECK (factorMultiValue IS NULL OR factorMultiValue > 0)
);
CREATE INDEX IX_TTipoProducto_Categoria ON TTipoProducto(idCategoria);

-- Tabla: TProductos
-- Propósito: Catálogo maestro de productos
CREATE TABLE TProductos (
    idProducto INT IDENTITY(1,1) PRIMARY KEY,
    codigo NVARCHAR(50) NOT NULL UNIQUE,
    codigoBarras NVARCHAR(50) UNIQUE,
    idTipoProducto INT NOT NULL,
    idGrupo INT NOT NULL,
    idTVMontura INT NULL,
    idTVCristal INT NULL,
    idMarca INT NULL,
    idColor INT NULL,
    idMaterial INT NULL,
    modelo NVARCHAR(50) NULL,
    descripcion NVARCHAR(255) NULL,
    rutaFoto NVARCHAR(500) NULL, -- Ruta al archivo de imagen
    activo BIT NOT NULL DEFAULT 1,
    requiereInventario BIT NOT NULL DEFAULT 1,
    fechaCreacion DATETIME DEFAULT GETDATE(),
    fechaModificacion DATETIME NULL,
    CONSTRAINT FK_TProductos_TTipoProducto FOREIGN KEY (idTipoProducto) REFERENCES TTipoProducto(idTipoProducto),
    CONSTRAINT FK_TProductos_TGrupo FOREIGN KEY (idGrupo) REFERENCES TGrupo(idGrupo),
    CONSTRAINT FK_TProductos_TMarca FOREIGN KEY (idMarca) REFERENCES TMarca(idMarca),
    CONSTRAINT FK_TProductos_TColor FOREIGN KEY (idColor) REFERENCES TColor(idColor),
    CONSTRAINT FK_TProductos_TMaterial FOREIGN KEY (idMaterial) REFERENCES TMaterial(idMaterial),
    CONSTRAINT FK_TProductos_TTipoVisionMontura FOREIGN KEY (idTVMontura) REFERENCES TTipoVisionMontura(idTVMontura),
    CONSTRAINT FK_TProductos_TTipoVisionCristal FOREIGN KEY (idTVCristal) REFERENCES TTipoVisionCristal(idTVCristal)
);
CREATE INDEX IX_TProductos_Codigo ON TProductos(codigo);
CREATE INDEX IX_TProductos_CodigoBarras ON TProductos(codigoBarras);
CREATE INDEX IX_TProductos_TipoProducto ON TProductos(idTipoProducto);
CREATE INDEX IX_TProductos_Marca ON TProductos(idMarca);

-- Tabla: TMedidasMonturas
-- Propósito: Medidas específicas de monturas
CREATE TABLE TMedidasMonturas (
    idMedMonturas INT IDENTITY(1,1) PRIMARY KEY,
    idProducto INT NOT NULL,
    horizontal DECIMAL(5,2) NULL,
    vertical DECIMAL(5,2) NULL,
    diagonal DECIMAL(5,2) NULL,
    puente DECIMAL(5,2) NULL,
    varilla DECIMAL(5,2) NULL,
    observacion NVARCHAR(MAX) NULL,
    CONSTRAINT FK_TMedMonturas_TProductos FOREIGN KEY (idProducto) REFERENCES TProductos(idProducto) ON DELETE CASCADE,
    CONSTRAINT UQ_MedMonturas_Producto UNIQUE (idProducto)
);

-- Tabla: TMedidasCristales
-- Propósito: Rangos de validación para cristales
CREATE TABLE TMedidasCristales (
    idMedCristales INT IDENTITY(1,1) PRIMARY KEY,
    idProducto INT NOT NULL,
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
    CONSTRAINT FK_TMedidasCristales_TProductos FOREIGN KEY (idProducto) REFERENCES TProductos(idProducto) ON DELETE CASCADE,
    CONSTRAINT UQ_MedCristales_Producto UNIQUE (idProducto)
);

-- Tabla: TEmpleado
-- Propósito: Empleados del sistema
CREATE TABLE TEmpleado (
    idEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    codigo CHAR(5) NOT NULL UNIQUE,
    cedula VARCHAR(20) NOT NULL UNIQUE,
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100) NOT NULL,
    nombreCompleto AS (nombre + ' ' + apellido) PERSISTED, -- Columna calculada
    fechaNacimiento DATE NULL,
    fechaIngreso DATE NOT NULL,
    examen BIT DEFAULT 0,
    especialidad NVARCHAR(120) NULL,
    licencia NVARCHAR(30) NULL,
    idCargo INT NOT NULL,
    direccion NVARCHAR(MAX) NULL,
    telefono NVARCHAR(60) NULL,
    email NVARCHAR(100) NULL,
    comision DECIMAL(5,2) DEFAULT 0.00,
    estado BIT NOT NULL DEFAULT 1,
    rutaFoto NVARCHAR(500) NULL,
    fechaCreacion DATETIME DEFAULT GETDATE(),
    fechaModificacion DATETIME NULL,
    CONSTRAINT FK_TEmpleado_TCargo FOREIGN KEY (idCargo) REFERENCES TCargo(idCargo),
    CONSTRAINT CHK_Comision CHECK (comision >= 0 AND comision <= 100)
);
CREATE INDEX IX_TEmpleado_Cedula ON TEmpleado(cedula);
CREATE INDEX IX_TEmpleado_Cargo ON TEmpleado(idCargo);

-- Tabla: TLogin
-- Propósito: Credenciales de acceso al sistema
CREATE TABLE TLogin (
    idLogin INT IDENTITY(1,1) PRIMARY KEY,
    idEmpleado INT NOT NULL,
    idSucursal INT NOT NULL, -- Corregido: ahora referencia TSucursal
    idRol INT NOT NULL,
    usuario NVARCHAR(90) NOT NULL UNIQUE,
    clave NVARCHAR(255) NOT NULL, -- Almacenar hash, no texto plano
    estado BIT DEFAULT 1,
    fechaRegistro DATETIME DEFAULT GETDATE(),
    fechaUltimoAcceso DATETIME NULL,
    intentosFallidos INT DEFAULT 0,
    CONSTRAINT FK_TLogin_TEmpleado FOREIGN KEY (idEmpleado) REFERENCES TEmpleado(idEmpleado),
    CONSTRAINT FK_TLogin_TRol FOREIGN KEY (idRol) REFERENCES TRol(idRol),
    CONSTRAINT FK_TLogin_TSucursal FOREIGN KEY (idSucursal) REFERENCES TSucursal(idSucursal)
);
CREATE INDEX IX_TLogin_Usuario ON TLogin(usuario);
CREATE INDEX IX_TLogin_Empleado ON TLogin(idEmpleado);

-- Tabla: TTipoMoneda
-- Propósito: Tipos de moneda y tasas de cambio
CREATE TABLE TTipoMoneda (
    idTipoMoneda INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(3) NOT NULL UNIQUE, -- ISO 4217 (USD, EUR, VES, etc.)
    descripcion NVARCHAR(50) NOT NULL,
    simbolo NVARCHAR(5) NULL, -- $, €, Bs, etc.
    tasaCosto DECIMAL(18,4) NOT NULL,
    tasaVenta DECIMAL(18,4) NOT NULL,
    esPrincipal BIT DEFAULT 0, -- Moneda base del sistema
    activo BIT NOT NULL DEFAULT 1,
    fecha DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    hora TIME NOT NULL DEFAULT CAST(GETDATE() AS TIME),
    idEmpleado INT NOT NULL,
    CONSTRAINT FK_TTipoMoneda_TEmpleado FOREIGN KEY (idEmpleado) REFERENCES TEmpleado(idEmpleado),
    CONSTRAINT CHK_TasaCosto CHECK (tasaCosto > 0),
    CONSTRAINT CHK_TasaVenta CHECK (tasaVenta > 0)
);
CREATE INDEX IX_TTipoMoneda_Fecha ON TTipoMoneda(fecha DESC);

-- =====================================================================
-- SECCIÓN 4: TABLAS TEMPORALES Y DE SESIÓN
-- Propósito: Datos de sesión y temporales
-- =====================================================================

-- Tabla: TSesion
-- Propósito: Registro de sesiones activas
CREATE TABLE TSesion (
    idSesion INT IDENTITY(1,1) PRIMARY KEY,
    idLogin INT NOT NULL,
    tokenSesion UNIQUEIDENTIFIER DEFAULT NEWID(),
    fechaInicio DATETIME DEFAULT GETDATE(),
    fechaFin DATETIME NULL,
    ipAddress NVARCHAR(50) NULL,
    navegador NVARCHAR(255) NULL,
    activa BIT DEFAULT 1,
    CONSTRAINT FK_TSesion_TLogin FOREIGN KEY (idLogin) REFERENCES TLogin(idLogin)
);
CREATE INDEX IX_TSesion_Token ON TSesion(tokenSesion);
CREATE INDEX IX_TSesion_Login ON TSesion(idLogin);

-- =====================================================================
-- SECCIÓN 5: DATOS INICIALES (SEED DATA)
-- Propósito: Datos básicos para iniciar el sistema
-- =====================================================================

-- Insertar alícuotas básicas
INSERT INTO TAlicuota (descripcion, alicuota) VALUES
('Exento', 0.00),
('IVA General 16%', 16.00),
('IVA Reducido 8%', 8.00);

-- Insertar estados de orden básicos
INSERT INTO TEstadoOrden (descripcion) VALUES
('Pendiente'),
('En Proceso'),
('Apartado'),
('Pagado'),
('Entregado'),
('Cancelado');

-- Insertar tipos de pago básicos
INSERT INTO TTipoPago (descripcion) VALUES
('Efectivo'),
('Transferencia Bancaria'),
('Pago Móvil'),
('Tarjeta de Débito'),
('Tarjeta de Crédito'),
('Cheque');

-- Insertar tipos de movimiento básicos
INSERT INTO TTipoMovimiento (descripcion, afectaInventario) VALUES
('Entrada por Compra', '+'),
('Salida por Venta', '-'),
('Ajuste Positivo', '+'),
('Ajuste Negativo', '-'),
('Traslado Salida', '-'),
('Traslado Entrada', '+'),
('Devolución Cliente', '+'),
('Devolución a Proveedor', '-');

-- Insertar rol administrador por defecto
INSERT INTO TRol (codigo, descripcion) VALUES
('ADM', 'Administrador'),
('VEN', 'Vendedor'),
('CON', 'Consulta');

-- Insertar cargo por defecto
INSERT INTO TCargo (codigo, descripcion) VALUES
('GER', 'Gerente'),
('VEN', 'Vendedor'),
('OPT', 'Optometrista'),
('CAJ', 'Cajero');

GO

PRINT '============================================================';
PRINT 'Base de datos BDOPTICA creada exitosamente';
PRINT 'Versión: 2.0 - Fecha: 06/12/2025';
PRINT '============================================================';
PRINT 'Tablas Maestras: 9';
PRINT 'Tablas Únicas: 7';
PRINT 'Tablas Mayores: 12';
PRINT 'Tablas Temporales: 1';
PRINT '============================================================';
GO