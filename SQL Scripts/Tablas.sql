-- Crear la base de datos

-- Usar la base de datos recién creada
USE GESTOR_USUARIOS;
GO

-- Tabla PERSONA
CREATE TABLE PERSONA (
    id_persona INT IDENTITY(1,1) PRIMARY KEY,
    nombres VARCHAR(60) NOT NULL,
    apellidos VARCHAR(60) NOT NULL,
    identificacion VARCHAR(10) NOT NULL,
    fecha_nacimiento DATE
);
GO

-- Tabla ROL
CREATE TABLE ROL (
    id_rol INT IDENTITY(1,1) PRIMARY KEY,
    rol_name VARCHAR(50) NOT NULL
);
GO

-- Índice para ROL
CREATE INDEX Rol_IDX ON ROL(rol_name);
GO

-- Tabla ROL_OPCIONES
CREATE TABLE ROL_OPCIONES (
    id_opcion INT IDENTITY(1,1) PRIMARY KEY,
    nombre_opciones VARCHAR(50) NOT NULL
);
GO

-- Tabla USUARIOS
CREATE TABLE USUARIOS (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    user_name VARCHAR(50) NOT NULL,
    passcode VARCHAR(50) NOT NULL,
    mail VARCHAR(120) NOT NULL,
    session_active CHAR(1) CHECK (session_active IN ('A', 'I')),  -- A para activo, I para inactivo
    persona_id_persona2 INT NOT NULL,  -- FK que relaciona con la tabla PERSONA
    status CHAR(20) CHECK (status IN ('BLOQUEADO', 'ACTIVO')),  -- Estado del usuario
    CONSTRAINT FK_Usuarios_Persona FOREIGN KEY (persona_id_persona2) REFERENCES PERSONA(id_persona)
);
GO

-- Índices para USUARIOS
CREATE INDEX usuarios_IDX ON USUARIOS(user_name);
CREATE INDEX usuarios_IDXv1 ON USUARIOS(mail);
GO

-- Tabla SESSIONS
CREATE TABLE SESSIONS (
    fecha_ingreso DATETIME NOT NULL,
    fecha_cierre DATETIME,
    usuario_id_usuario INT NOT NULL,  -- FK que relaciona con la tabla USUARIOS
    CONSTRAINT FK_Sessions_Usuarios FOREIGN KEY (usuario_id_usuario) REFERENCES USUARIOS(id_usuario)
);
GO

-- Tabla ROL_USUARIOS
CREATE TABLE ROL_USUARIOS (
    rol_id_rol INT NOT NULL,  -- FK que relaciona con la tabla ROL
    usuario_id_usuario INT NOT NULL,  -- FK que relaciona con la tabla USUARIOS
    CONSTRAINT FK_Rol_Usuarios_Rol FOREIGN KEY (rol_id_rol) REFERENCES ROL(id_rol),
    CONSTRAINT FK_Rol_Usuarios_Usuarios FOREIGN KEY (usuario_id_usuario) REFERENCES USUARIOS(id_usuario)
);
GO

-- Tabla ROL_ROL_OPCIONES
CREATE TABLE ROL_ROL_OPCIONES (
    rol_id_rol INT NOT NULL,  -- FK que relaciona con la tabla ROL
    rol_opciones_id_opciones INT NOT NULL,  -- FK que relaciona con la tabla ROL_OPCIONES
    CONSTRAINT FK_Rol_RolOpciones_Rol FOREIGN KEY (rol_id_rol) REFERENCES ROL(id_rol),
    CONSTRAINT FK_Rol_RolOpciones_RolOpciones FOREIGN KEY (rol_opciones_id_opciones) REFERENCES ROL_OPCIONES(id_opcion)
);
GO

-- Confirma la creación de las tablas
PRINT 'Las tablas se han creado correctamente';
