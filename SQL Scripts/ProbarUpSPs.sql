-- Usar la base de datos recién creada
USE GESTOR_USUARIOS;
GO

-- Probar el procedimiento para actualizar una persona
EXEC ActualizarPersona 
    @id_persona = 1, 
    @nombres = 'Juan Carlos', 
    @apellidos = 'Piguave Loor', 
    @identificacion = '1203574901', 
    @fecha_nacimiento = '1980-05-12';
GO

-- Probar el procedimiento para actualizar un rol
EXEC ActualizarRol 
    @id_rol = 2, 
    @rol_name = 'Admin';
GO

-- Probar el procedimiento para actualizar una opción de rol
EXEC ActualizarRolOpcion 
    @id_opcion = 3, 
    @nombre_opciones = 'Ver Reportes';
GO

-- Probar el procedimiento para actualizar un usuario
EXEC ActualizarUsuario 
    @id_usuario = 5, 
    @user_name = 'johndoe', 
    @passcode = 'NewPassword123', 
    @mail = 'johndoe@example.com', 
    @session_active = 'A', 
    @status = 'ACTIVO';
GO

-- Probar el procedimiento para actualizar una sesión
EXEC ActualizarSesion 
    @usuario_id_usuario = 5, 
    @fecha_ingreso = '2025-10-07 08:00:00', 
    @fecha_cierre = '2025-10-07 09:00:00';
GO

-- Probar el procedimiento para actualizar el rol asignado a un usuario
EXEC ActualizarRolUsuario 
    @usuario_id_usuario = 5, 
    @rol_id_rol = 2;
GO

-- Probar el procedimiento para actualizar la relación entre rol y opción
EXEC ActualizarRolOpcionRol 
    @rol_id_rol = 2, 
    @rol_opciones_id_opciones = 3;
GO
