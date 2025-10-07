--SE CREAN LOS SP PARA ELIMINAR

-- Usar la base de datos recién creada
USE GESTOR_USUARIOS;
GO

-- Eliminar el procedimiento almacenado si ya existe
IF OBJECT_ID('EliminarUsuario', 'P') IS NOT NULL
    DROP PROCEDURE EliminarUsuario;
GO

-- Procedimiento almacenado para eliminar un usuario (cambiar el status a 'INACTIVO')
CREATE PROCEDURE EliminarUsuario
    @id_usuario INT,  -- ID del usuario a eliminar
    @id_usuario_solicitante INT  -- ID del usuario que solicita la eliminación
AS
BEGIN
    -- Verificar si el usuario solicitante es administrador (rol_id_rol = 1)
    DECLARE @rol_id INT;
    SELECT @rol_id = ru.rol_id_rol
    FROM ROL_USUARIOS ru
    WHERE ru.usuario_id_usuario = @id_usuario_solicitante;

    -- Si el solicitante no es administrador, solo puede eliminar su propio usuario
    IF @rol_id <> 1
    BEGIN
        -- Verificar que el usuario solicitante esté intentando eliminar su propio registro
        IF @id_usuario_solicitante <> @id_usuario
        BEGIN
            PRINT 'Error: Solo puedes eliminar tu propio usuario.';
            RETURN;
        END
    END
    ELSE
    BEGIN
        -- Si el solicitante es administrador, verifica que no se esté intentando eliminar a otro administrador
        IF EXISTS (SELECT 1 FROM ROL_USUARIOS ru JOIN ROL r ON ru.rol_id_rol = r.id_rol WHERE ru.usuario_id_usuario = @id_usuario AND r.rol_name = 'Administrador')
        BEGIN
            PRINT 'Error: No se puede eliminar el rol de Administrador.';
            RETURN;
        END
    END

    -- Cambiar el estado del usuario a 'INACTIVO' (eliminación lógica)
    UPDATE USUARIOS
    SET status = 'INACTIVO'
    WHERE id_usuario = @id_usuario;

    -- Confirmar eliminación exitosa (eliminación lógica)
    PRINT 'El usuario ha sido inactivado correctamente.';
END;
GO

-- Eliminar el procedimiento almacenado si ya existe
IF OBJECT_ID('EliminarRol', 'P') IS NOT NULL
    DROP PROCEDURE EliminarRol;
GO

-- Procedimiento almacenado para eliminar un rol (cambiar el estado a 'INACTIVO')
CREATE PROCEDURE EliminarRol
    @id_rol INT  -- ID del rol a eliminar
AS
BEGIN
    -- Cambiar el estado del rol a 'INACTIVO' (eliminación lógica)
    UPDATE ROL
    SET status = 'I'
    WHERE id_rol = @id_rol;

    -- Confirmar eliminación exitosa (eliminación lógica)
    PRINT 'El rol ha sido inactivado correctamente.';
END;
GO

-- Eliminar el procedimiento almacenado si ya existe
IF OBJECT_ID('EliminarRolOpcion', 'P') IS NOT NULL
    DROP PROCEDURE EliminarRolOpcion;
GO

-- Procedimiento almacenado para eliminar una opción de rol (cambiar el estado a 'INACTIVO')
CREATE PROCEDURE EliminarRolOpcion
    @id_opcion INT  -- ID de la opción de rol a eliminar
AS
BEGIN
    -- Cambiar el estado de la opción de rol a 'INACTIVO' (eliminación lógica)
    UPDATE ROL_OPCIONES
    SET status = 'I'
    WHERE id_opcion = @id_opcion;

    -- Confirmar eliminación exitosa (eliminación lógica)
    PRINT 'La opción de rol ha sido inactivada correctamente.';
END;
GO

-- Eliminar el procedimiento almacenado si ya existe
IF OBJECT_ID('EliminarSesion', 'P') IS NOT NULL
    DROP PROCEDURE EliminarSesion;
GO

-- Procedimiento almacenado para eliminar una sesión (cambiar el estado a 'INACTIVO')
CREATE PROCEDURE EliminarSesion
    @id_sesion INT  -- ID de la sesión a inactivar
AS
BEGIN
    -- Cambiar el estado de la sesión a 'INACTIVO' (eliminación lógica)
    UPDATE SESSIONS
    SET status = 'I'
    WHERE usuario_id_usuario = @id_sesion;

    -- Confirmar eliminación exitosa (eliminación lógica)
    PRINT 'La sesión ha sido inactivada correctamente.';
END;
GO

-- Confirma que los procedimientos han sido creados correctamente
PRINT 'Los procedimientos para eliminación lógica se han creado correctamente.';

