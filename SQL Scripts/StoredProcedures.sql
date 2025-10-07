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

-- Llamar al procedimiento almacenado para insertar una nueva persona
EXEC InsertarPersona 
    @nombres = 'Juan',
    @apellidos = 'P�rez',
    @identificacion = '123456789A',   -- Identificaci�n v�lida
    @fecha_nacimiento = '1985-05-15';


INSERT INTO PERSONA (nombres, apellidos, identificacion, fecha_nacimiento)
	VALUES ('Juan', 'Perez', '123456789A', '1985-05-15');
