--SE CREAN LOS SP PARA CONSULTAR

-- Usar la base de datos recién creada
USE GESTOR_USUARIOS;
GO

-- Eliminar el procedimiento almacenado si ya existe  --------------------------------------------------------------------------------
IF OBJECT_ID('ConsultarPersona', 'P') IS NOT NULL
    DROP PROCEDURE ConsultarPersona;
GO

-- Procedimiento almacenado para consultar una persona por ID
CREATE PROCEDURE ConsultarPersona
    @id_persona INT
AS
BEGIN
    -- Consultar los datos de la persona por su ID
    SELECT id_persona, nombres, apellidos, identificacion, fecha_nacimiento
    FROM PERSONA
    WHERE id_persona = @id_persona;
END;
GO

-- Eliminar el procedimiento almacenado si ya existe  --------------------------------------------------------------------------------
IF OBJECT_ID('ConsultarRol', 'P') IS NOT NULL
    DROP PROCEDURE ConsultarRol;
GO

-- Procedimiento almacenado para consultar todos los roles
CREATE PROCEDURE ConsultarRol
AS
BEGIN
    -- Consultar todos los roles
    SELECT id_rol, rol_name
    FROM ROL;
END;
GO

-- Eliminar el procedimiento almacenado si ya existe  --------------------------------------------------------------------------------
IF OBJECT_ID('ConsultarRolOpcion', 'P') IS NOT NULL
    DROP PROCEDURE ConsultarRolOpcion;
GO

-- Procedimiento almacenado para consultar todas las opciones de rol
CREATE PROCEDURE ConsultarRolOpcion
AS
BEGIN
    -- Consultar todas las opciones de rol
    SELECT id_opcion, nombre_opciones
    FROM ROL_OPCIONES;
END;
GO

-- Eliminar el procedimiento almacenado si ya existe  --------------------------------------------------------------------------------
IF OBJECT_ID('ConsultarUsuario', 'P') IS NOT NULL
    DROP PROCEDURE ConsultarUsuario;
GO

-- Procedimiento almacenado para consultar un usuario por ID
CREATE PROCEDURE ConsultarUsuario
    @id_usuario INT
AS
BEGIN
    -- Consultar los datos de un usuario por su ID
    SELECT id_usuario, user_name, passcode, mail, session_active, persona_id_persona2, status
    FROM USUARIOS
    WHERE id_usuario = @id_usuario;
END;
GO

-- Eliminar el procedimiento almacenado si ya existe  --------------------------------------------------------------------------------
IF OBJECT_ID('ConsultarSesion', 'P') IS NOT NULL
    DROP PROCEDURE ConsultarSesion;
GO

-- Procedimiento almacenado para consultar las sesiones por ID de usuario
CREATE PROCEDURE ConsultarSesion
    @usuario_id_usuario INT
AS
BEGIN
    -- Consultar las sesiones de un usuario por su ID
    SELECT usuario_id_usuario, fecha_ingreso, fecha_cierre
    FROM SESSIONS
    WHERE usuario_id_usuario = @usuario_id_usuario;
END;
GO

-- Eliminar el procedimiento almacenado si ya existe  --------------------------------------------------------------------------------
IF OBJECT_ID('ConsultarRolUsuario', 'P') IS NOT NULL
    DROP PROCEDURE ConsultarRolUsuario;
GO

-- Procedimiento almacenado para consultar los roles asignados a un usuario
CREATE PROCEDURE ConsultarRolUsuario
    @usuario_id_usuario INT
AS
BEGIN
    -- Consultar los roles asignados a un usuario por su ID
    SELECT r.id_rol, r.rol_name
    FROM ROL_USUARIOS ru
    JOIN ROL r ON ru.rol_id_rol = r.id_rol
    WHERE ru.usuario_id_usuario = @usuario_id_usuario;
END;
GO

-- Eliminar el procedimiento almacenado si ya existe  --------------------------------------------------------------------------------
IF OBJECT_ID('ConsultarRolOpcionRol', 'P') IS NOT NULL
    DROP PROCEDURE ConsultarRolOpcionRol;
GO

-- Procedimiento almacenado para consultar las opciones de rol asignadas a un rol
CREATE PROCEDURE ConsultarRolOpcionRol
    @rol_id_rol INT
AS
BEGIN
    -- Consultar las opciones de rol asignadas a un rol
    SELECT ro.id_opcion, ro.nombre_opciones
    FROM ROL_ROL_OPCIONES rro
    JOIN ROL_OPCIONES ro ON rro.rol_opciones_id_opciones = ro.id_opcion
    WHERE rro.rol_id_rol = @rol_id_rol;
END;
GO
