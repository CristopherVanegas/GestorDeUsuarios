-- PROBAR TODOS LOS SP PARA INSERTAR EN LAS TABLAS

-- Usar la base de datos recién creada
USE GESTOR_USUARIOS;
GO

-- Probar el procedimiento InsertarRol
EXEC InsertarRol @rol_name = 'Administrador';
EXEC InsertarRol @rol_name = 'Usuario';

-- Probar el procedimiento InsertarRolOpcion
EXEC InsertarRolOpcion @nombre_opciones = 'Ver Dashboard';
EXEC InsertarRolOpcion @nombre_opciones = 'Gestionar Usuarios';

-- Probar el procedimiento InsertarUsuario
EXEC InsertarUsuario 
    @user_name = 'itsmrjkali21', 
    @passcode = 'Password1!', 
    @mail = 'cristopher.platzi@gmail.com', 
    @session_active = 'A', 
    @persona_id_persona2 = 1,  -- Asegúrate de que esta persona exista en la tabla PERSONA
    @status = 'ACTIVO';

SELECT * FROM dbo.USUARIOS
SELECT * FROM dbo.PERSONA

-- Llamar al procedimiento almacenado para insertar una nueva persona
EXEC InsertarPersona 
    @nombres = 'Cristopher',
    @apellidos = 'Vanegas',
    @identificacion = '1600940736',   -- Identificación válida
    @fecha_nacimiento = '2004-07-21';

SELECT * FROM dbo.PERSONA

-- Probar el procedimiento InsertarSesion
EXEC InsertarSesion 
    @fecha_ingreso = '2025-10-06 08:00:00', 
    @fecha_cierre = '2025-10-06 10:00:00', 
    @usuario_id_usuario = 1;  -- Asegúrate de que este ID de usuario exista en la tabla USUARIOS

-- Probar el procedimiento InsertarRolUsuario
EXEC InsertarRolUsuario 
    @rol_id_rol = 1,  -- Asegúrate de que este rol exista en la tabla ROL
    @usuario_id_usuario = 1;  -- Asegúrate de que este usuario exista en la tabla USUARIOS

-- Probar el procedimiento InsertarRolOpcionRol
EXEC InsertarRolOpcionRol 
    @rol_id_rol = 1,  -- Asegúrate de que este rol exista en la tabla ROL
    @rol_opciones_id_opciones = 1;  -- Asegúrate de que esta opción exista en la tabla ROL_OPCIONES

INSERT INTO PERSONA (nombres, apellidos, identificacion, fecha_nacimiento)
	VALUES ('Juan', 'Perez', '123456789A', '1985-05-15');


