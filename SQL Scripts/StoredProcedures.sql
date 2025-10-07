-- Crear el procedimiento almacenado para insertar datos en la tabla PERSONA
CREATE PROCEDURE InsertarPersona
    @nombres VARCHAR(60),
    @apellidos VARCHAR(60),
    @identificacion VARCHAR(10),
    @fecha_nacimiento DATE
AS
BEGIN
    -- Validar que la identificación tenga exactamente 10 caracteres
    IF LEN(@identificacion) <> 10 OR @identificacion NOT LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
    BEGIN
        PRINT 'Error: La identificación debe tener exactamente 10 caracteres numéricos.';
        RETURN;
    END

    -- Insertar los datos en la tabla PERSONA si la validación es correcta
    INSERT INTO PERSONA (nombres, apellidos, identificacion, fecha_nacimiento)
    VALUES (@nombres, @apellidos, @identificacion, @fecha_nacimiento);

    -- Confirmar inserción exitosa
    PRINT 'Registro insertado correctamente.';
END;
GO

