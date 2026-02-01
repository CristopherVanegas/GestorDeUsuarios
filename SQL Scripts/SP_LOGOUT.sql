CREATE PROCEDURE sp_Session_Logout
    @usuario_id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Cerrar la sesión activa
    UPDATE SESSIONS
    SET
        fecha_cierre = GETDATE(),
        status = 'I'
    WHERE usuario_id_usuario = @usuario_id
      AND status = 'A';

    -- Marcar usuario como fuera de sesión
    UPDATE USUARIOS
    SET session_active = 'I'
    WHERE id_usuario = @usuario_id;
END;
