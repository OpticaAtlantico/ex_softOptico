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




---------------------------------------------------------------------------
-- TABLAS UNICAS: 
-- SON UTILIZADAS PARA MOSTRAR LOS DATOS UNICOS QUE SON UTILIZADOS POR OTRAS TABLAS 
-- DE MAYOR FUERZA POR EJEMPLO: TABLA TRol
-- Y COMO DATOS ALMACENA "ADMINISTRADOR, GERENTE, VENDEDOR ETC." Y SON LLAMADAS DESDE OTRA TABLA
-- RELECIONADAS POR EL ID
---------------------------------------------------------------------------




---------------------------------------------------------------------------
-- TABLAS MAYORES: 
-- SON UTILIZADAS PARA ALMACENAR DATOS UTILIZANDO LAS TABLAS UNICAS Y LOS DATOS
-- DE SU PROPIA TABLA: TABLA TVentas
-- Y COMO DATOS ALMACENA "Producto, cliente, pagos etc" Y SON RELACIONADAS CON LA TABLA
-- RELECIONADAS POR EL ID CON LAS TABLAS "TEMPLEADOS, TPRODUCTOS"
---------------------------------------------------------------------------




---------------------------------------------------------------------------
-- TABLAS TEMPORALES: 
-- SON UTILIZADAS PARA ALMACENAR DATOS QUE LUEGO SE ELIMINAN AL CERRAR LA CONEXION
-- POR EJEMPLO: TSession donde se almacena el login del usuario etc.. 
---------------------------------------------------------------------------
