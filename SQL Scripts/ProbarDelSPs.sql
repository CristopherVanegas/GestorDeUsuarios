-- PROBAR TODOS LOS SP PARA ELIMINAR EN LAS TABLAS

-- Usar la base de datos recién creada
USE GESTOR_USUARIOS;
GO

-- Eliminar (inactivar) el usuario con ID = 3 (usuario no administrador) por el usuario con ID = 2
EXEC EliminarUsuario @id_usuario = 2, @id_usuario_solicitante = 2;
EXEC EliminarRol @id_rol = 2;
EXEC EliminarRolOpcion @id_opcion = 1;
EXEC EliminarSesion @id_sesion = 1;
