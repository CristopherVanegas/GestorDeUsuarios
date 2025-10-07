-- Usar la base de datos recién creada
USE GESTOR_USUARIOS;
GO

-- Eliminar el procedimiento almacenado si ya existe -------------------------------------------------------------------------------------------------------

-- Eliminar el procedimiento almacenado para actualizar una persona
IF OBJECT_ID('ActualizarPersona', 'P') IS NOT NULL
    DROP PROCEDURE ActualizarPersona;
GO

-- Eliminar el procedimiento almacenado para actualizar un rol
IF OBJECT_ID('ActualizarRol', 'P') IS NOT NULL
    DROP PROCEDURE ActualizarRol;
GO

-- Eliminar el procedimiento almacenado para actualizar una opción de rol
IF OBJECT_ID('ActualizarRolOpcion', 'P') IS NOT NULL
    DROP PROCEDURE ActualizarRolOpcion;
GO

-- Eliminar el procedimiento almacenado para actualizar un usuario
IF OBJECT_ID('ActualizarUsuario', 'P') IS NOT NULL
    DROP PROCEDURE ActualizarUsuario;
GO

-- Eliminar el procedimiento almacenado para actualizar una sesión
IF OBJECT_ID('ActualizarSesion', 'P') IS NOT NULL
    DROP PROCEDURE ActualizarSesion;
GO

-- Eliminar el procedimiento almacenado para actualizar el rol asignado a un usuario
IF OBJECT_ID('ActualizarRolUsuario', 'P') IS NOT NULL
    DROP PROCEDURE ActualizarRolUsuario;
GO

-- Eliminar el procedimiento almacenado para actualizar la relación entre rol y opción
IF OBJECT_ID('ActualizarRolOpcionRol', 'P') IS NOT NULL
    DROP PROCEDURE ActualizarRolOpcionRol;
GO

-- Procedimientos almacenados para actualización -------------------------------------------------------------------------------------------------------

-- Procedimiento almacenado para actualizar una persona
CREATE PROCEDURE ActualizarPersona
    @id_persona INT,
    @nombres VARCHAR(60),
    @apellidos VARCHAR(60),
    @identificacion VARCHAR(10),
    @fecha_nacimiento DATE
AS
BEGIN
    -- Validación para asegurarse de que la identificación sea única
    IF EXISTS (SELECT 1 FROM PERSONA WHERE identificacion = @identificacion AND id_persona <> @id_persona)
    BEGIN
        PRINT 'Error: La identificación ya existe.';
        RETURN;
    END

    -- Actualizar los datos de la persona
    UPDATE PERSONA
    SET nombres = @nombres,
        apellidos = @apellidos,
        identificacion = @identificacion,
        fecha_nacimiento = @fecha_nacimiento
    WHERE id_persona = @id_persona;

    PRINT 'Persona actualizada correctamente.';
END;
GO

-- Procedimiento almacenado para actualizar un rol
CREATE PROCEDURE ActualizarRol
    @id_rol INT,
    @rol_name VARCHAR(50)
AS
BEGIN
    IF @rol_name = ''
    BEGIN
        PRINT 'Error: El nombre del rol no puede estar vacío.';
        RETURN;
    END

    UPDATE ROL
    SET rol_name = @rol_name
    WHERE id_rol = @id_rol;

    PRINT 'Rol actualizado correctamente.';
END;
GO

-- Procedimiento almacenado para actualizar una opción de rol
CREATE PROCEDURE ActualizarRolOpcion
    @id_opcion INT,
    @nombre_opciones VARCHAR(50)
AS
BEGIN
    IF @nombre_opciones = ''
    BEGIN
        PRINT 'Error: El nombre de la opción de rol no puede estar vacío.';
        RETURN;
    END

    UPDATE ROL_OPCIONES
    SET nombre_opciones = @nombre_opciones
    WHERE id_opcion = @id_opcion;

    PRINT 'Opción de rol actualizada correctamente.';
END;
GO

-- Procedimiento almacenado para actualizar un usuario
CREATE PROCEDURE ActualizarUsuario
    @id_usuario INT,
    @user_name VARCHAR(50),
    @passcode VARCHAR(50),
    @mail VARCHAR(120),
    @session_active CHAR(1),
    @status CHAR(20)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM USUARIOS WHERE mail = @mail AND id_usuario <> @id_usuario)
    BEGIN
        PRINT 'Error: El correo electrónico ya está registrado.';
        RETURN;
    END

    IF LEN(@user_name) < 8 OR LEN(@user_name) > 20 OR @user_name NOT LIKE '%[A-Z]%' OR @user_name NOT LIKE '%[0-9]%' OR @user_name LIKE '%[^a-zA-Z0-9]%'
    BEGIN
        PRINT 'Error: El nombre de usuario no cumple con los requisitos.';
        RETURN;
    END

    IF LEN(@passcode) < 8 OR @passcode NOT LIKE '%[A-Z]%' OR @passcode NOT LIKE '%[0-9]%' OR @passcode NOT LIKE '%[^a-zA-Z0-9 ]%'
    BEGIN
        PRINT 'Error: La contraseña no cumple con los requisitos.';
        RETURN;
    END

    IF @status NOT IN ('BLOQUEADO', 'ACTIVO', 'INACTIVO')
    BEGIN
        PRINT 'Error: El estado del usuario debe ser "BLOQUEADO", "ACTIVO" o "INACTIVO".';
        RETURN;
    END

    UPDATE USUARIOS
    SET user_name = @user_name,
        passcode = @passcode,
        mail = @mail,
        session_active = @session_active,
        status = @status
    WHERE id_usuario = @id_usuario;

    PRINT 'Usuario actualizado correctamente.';
END;
GO

-- Procedimiento almacenado para actualizar una sesión
CREATE PROCEDURE ActualizarSesion
    @usuario_id_usuario INT,
    @fecha_ingreso DATETIME,
    @fecha_cierre DATETIME
AS
BEGIN
    IF @fecha_ingreso > @fecha_cierre
    BEGIN
        PRINT 'Error: La fecha de cierre no puede ser anterior a la fecha de ingreso.';
        RETURN;
    END

    UPDATE SESSIONS
    SET fecha_ingreso = @fecha_ingreso,
        fecha_cierre = @fecha_cierre
    WHERE usuario_id_usuario = @usuario_id_usuario;

    PRINT 'Sesión actualizada correctamente.';
END;
GO

-- Procedimiento almacenado para actualizar el rol asignado a un usuario
CREATE PROCEDURE ActualizarRolUsuario
    @usuario_id_usuario INT,
    @rol_id_rol INT
AS
BEGIN
    UPDATE ROL_USUARIOS
    SET rol_id_rol = @rol_id_rol
    WHERE usuario_id_usuario = @usuario_id_usuario;

    PRINT 'Rol asignado al usuario actualizado correctamente.';
END;
GO

-- Procedimiento almacenado para actualizar la relación entre rol y opción
CREATE PROCEDURE ActualizarRolOpcionRol
    @rol_id_rol INT,
    @rol_opciones_id_opciones INT
AS
BEGIN
    UPDATE ROL_ROL_OPCIONES
    SET rol_opciones_id_opciones = @rol_opciones_id_opciones
    WHERE rol_id_rol = @rol_id_rol;

    PRINT 'Relación de rol y opción actualizada correctamente.';
END;
GO
