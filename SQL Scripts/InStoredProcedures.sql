--SE CREAN LOS SP PARA INSERTAR

-- Usar la base de datos reci�n creada
USE GESTOR_USUARIOS;
GO

-- Eliminar el procedimiento almacenado si ya existe --------------------------------------------------------------------------------
IF OBJECT_ID('InsertarPersona', 'P') IS NOT NULL
    DROP PROCEDURE InsertarPersona;
GO

-- Crear el procedimiento almacenado para insertar datos en la tabla PERSONA
CREATE PROCEDURE InsertarPersona
    @nombres VARCHAR(60),
    @apellidos VARCHAR(60),
    @identificacion VARCHAR(10),
    @fecha_nacimiento DATE
AS
BEGIN
    -- Validar que la identificaci�n tenga exactamente 10 caracteres
    IF LEN(@identificacion) <> 10 OR @identificacion NOT LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
    BEGIN
        PRINT 'Error: La identificaci�n debe tener exactamente 10 caracteres num�ricos.';
        RETURN;
    END

    -- Insertar los datos en la tabla PERSONA si la validaci�n es correcta
    INSERT INTO PERSONA (nombres, apellidos, identificacion, fecha_nacimiento)
    VALUES (@nombres, @apellidos, @identificacion, @fecha_nacimiento);

    -- Confirmar inserci�n exitosa
    PRINT 'Registro insertado correctamente.';
END;
GO

-- Eliminar el procedimiento almacenado si ya existe --------------------------------------------------------------------------------
IF OBJECT_ID('InsertarUsuario', 'P') IS NOT NULL
    DROP PROCEDURE InsertarUsuario;
GO

-- Procedimiento almacenado para insertar un nuevo usuario
CREATE PROCEDURE InsertarUsuario
    @user_name VARCHAR(50),
    @passcode VARCHAR(50),
    @mail VARCHAR(120),
    @session_active CHAR(1),
    @persona_id_persona2 INT,
    @status CHAR(20)
AS
BEGIN
    -- Validar que el nombre de usuario sea v�lido
    IF LEN(@user_name) < 8 OR LEN(@user_name) > 20 OR @user_name NOT LIKE '%[A-Z]%' OR @user_name NOT LIKE '%[0-9]%' OR @user_name LIKE '%[^a-zA-Z0-9]%'
    BEGIN
        PRINT 'Error: El nombre de usuario no cumple con los requisitos.';
        RETURN;
    END

    -- Validar el correo electr�nico (formato b�sico)
    IF @mail NOT LIKE '%@%.%'
    BEGIN
        PRINT 'Error: El correo electr�nico no tiene un formato v�lido.';
        RETURN;
    END

    -- Validar que la contrase�a tenga al menos 8 caracteres, una letra may�scula, un n�mero y un s�mbolo
    IF LEN(@passcode) < 8 OR @passcode NOT LIKE '%[A-Z]%' OR @passcode NOT LIKE '%[0-9]%' OR @passcode NOT LIKE '%[^a-zA-Z0-9 ]%'
    BEGIN
        PRINT 'Error: La contrase�a no cumple con los requisitos.';
        RETURN;
    END

    -- Validar el estado del usuario
    IF @status NOT IN ('BLOQUEADO', 'ACTIVO')
    BEGIN
        PRINT 'Error: El estado del usuario debe ser "BLOQUEADO" o "ACTIVO".';
        RETURN;
    END

    -- Validar si ya existe un usuario con el mismo correo para la misma persona
    IF EXISTS (SELECT 1 FROM USUARIOS WHERE mail = @mail AND persona_id_persona2 = @persona_id_persona2)
    BEGIN
        PRINT 'Error: Ya existe un usuario con este correo para esta persona.';
        RETURN;
    END

    -- Insertar el nuevo usuario en la tabla USUARIOS
    INSERT INTO USUARIOS (user_name, passcode, mail, session_active, persona_id_persona2, status)
    VALUES (@user_name, @passcode, @mail, @session_active, @persona_id_persona2, @status);

    -- Confirmar inserci�n exitosa
    PRINT 'Nuevo usuario insertado correctamente.';
END;
GO

-- Eliminar el procedimiento almacenado si ya existe --------------------------------------------------------------------------------
IF OBJECT_ID('InsertarRol', 'P') IS NOT NULL
    DROP PROCEDURE InsertarRol;
GO

-- Procedimiento almacenado para insertar un nuevo rol
CREATE PROCEDURE InsertarRol
    @rol_name VARCHAR(50)
AS
BEGIN
    -- Validar que el nombre del rol no est� vac�o
    IF @rol_name = ''
    BEGIN
        PRINT 'Error: El nombre del rol no puede estar vac�o.';
        RETURN;
    END

    -- Insertar el nuevo rol en la tabla ROL
    INSERT INTO ROL (rol_name)
    VALUES (@rol_name);

    -- Confirmar inserci�n exitosa
    PRINT 'Nuevo rol insertado correctamente.';
END;
GO

-- Eliminar el procedimiento almacenado si ya existe --------------------------------------------------------------------------------
IF OBJECT_ID('InsertarRolOpcion', 'P') IS NOT NULL
    DROP PROCEDURE InsertarRolOpcion;
GO

-- Procedimiento almacenado para insertar una nueva opci�n de rol
CREATE PROCEDURE InsertarRolOpcion
    @nombre_opciones VARCHAR(50)
AS
BEGIN
    -- Validar que el nombre de la opci�n no est� vac�o
    IF @nombre_opciones = ''
    BEGIN
        PRINT 'Error: El nombre de la opci�n no puede estar vac�o.';
        RETURN;
    END

    -- Insertar la nueva opci�n de rol en la tabla ROL_OPCIONES
    INSERT INTO ROL_OPCIONES (nombre_opciones)
    VALUES (@nombre_opciones);

    -- Confirmar inserci�n exitosa
    PRINT 'Nueva opci�n de rol insertada correctamente.';
END;
GO

-- Eliminar el procedimiento almacenado si ya existe --------------------------------------------------------------------------------
IF OBJECT_ID('InsertarRolUsuario', 'P') IS NOT NULL
    DROP PROCEDURE InsertarRolUsuario;
GO

-- Procedimiento almacenado para insertar un nuevo rol de usuario
CREATE PROCEDURE InsertarRolUsuario
    @rol_id_rol INT,
    @usuario_id_usuario INT
AS
BEGIN
    -- Insertar la relaci�n de rol y usuario en la tabla ROL_USUARIOS
    INSERT INTO ROL_USUARIOS (rol_id_rol, usuario_id_usuario)
    VALUES (@rol_id_rol, @usuario_id_usuario);

    -- Confirmar inserci�n exitosa
    PRINT 'Rol de usuario insertado correctamente.';
END;
GO

-- Eliminar el procedimiento almacenado si ya existe --------------------------------------------------------------------------------
IF OBJECT_ID('InsertarRolOpcionRol', 'P') IS NOT NULL
    DROP PROCEDURE InsertarRolOpcionRol;
GO

-- Procedimiento almacenado para insertar una opci�n de rol
CREATE PROCEDURE InsertarRolOpcionRol
    @rol_id_rol INT,
    @rol_opciones_id_opciones INT
AS
BEGIN
    -- Insertar la relaci�n de rol y opci�n de rol en la tabla ROL_ROL_OPCIONES
    INSERT INTO ROL_ROL_OPCIONES (rol_id_rol, rol_opciones_id_opciones)
    VALUES (@rol_id_rol, @rol_opciones_id_opciones);

    -- Confirmar inserci�n exitosa
    PRINT 'Opci�n de rol insertada correctamente en la relaci�n de rol.';
END;
GO
