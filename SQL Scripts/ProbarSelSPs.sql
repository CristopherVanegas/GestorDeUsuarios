-- PROBAR TODOS LOS SP PARA CONSULTAR LAS TABLAS

-- Usar la base de datos reci�n creada
USE GESTOR_USUARIOS;
GO

-- Probar el procedimiento ConsultarPersona
EXEC ConsultarPersona @id_persona = 1;  -- Aseg�rate de que exista una persona con ID = 1 en la tabla PERSONA

-- Probar el procedimiento ConsultarRol
EXEC ConsultarRol;  -- Esto devolver� todos los roles en la tabla ROL

-- Probar el procedimiento ConsultarRolOpcion
EXEC ConsultarRolOpcion;  -- Esto devolver� todas las opciones en la tabla ROL_OPCIONES

-- Probar el procedimiento ConsultarUsuario
EXEC ConsultarUsuario @id_usuario = 1;  -- Aseg�rate de que exista un usuario con ID = 1 en la tabla USUARIOS

-- Probar el procedimiento ConsultarSesion
EXEC ConsultarSesion @usuario_id_usuario = 1;  -- Aseg�rate de que exista una sesi�n para el usuario con ID = 1 en la tabla SESSIONS

-- Probar el procedimiento ConsultarRolUsuario
EXEC ConsultarRolUsuario @usuario_id_usuario = 1;  -- Aseg�rate de que el usuario con ID = 1 tenga roles asignados

-- Probar el procedimiento ConsultarRolOpcionRol
EXEC ConsultarRolOpcionRol @rol_id_rol = 1;  -- Aseg�rate de que exista un rol con ID = 1 y tenga opciones asignadas
