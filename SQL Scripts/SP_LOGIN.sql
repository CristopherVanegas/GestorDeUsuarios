CREATE PROCEDURE sp_Session_Login
    @usuario_id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que el usuario exista y esté activo
    IF NOT EXISTS (
        SELECT 1
        FROM USUARIOS
        WHERE id_usuario = @usuario_id
          AND status = 'A'
    )
    BEGIN
        RAISERROR('El usuario no existe o está inactivo', 16, 1);
        RETURN;
    END

    -- Insertar sesión
    INSERT INTO SESSIONS (
        fecha_ingreso,
        fecha_cierre,
        usuario_id_usuario,
        status
    )
    VALUES (
        GETDATE(),
        NULL,
        @usuario_id,
        'A'
    );

    -- Marcar usuario como en sesión
    UPDATE USUARIOS
    SET session_active = 'A'
    WHERE id_usuario = @usuario_id;
END;
