# GestorDeUsuarios
Este proyecto gestiona usuarios, se utiliza las siguientes tecnologías: ASP.NET Core Web API, Angular y SQL Server.

## Proyecto Backend - API_REST
El objetivo de la API es gestionar usuarios, roles, sesiones y relaciones entre entidades, utilizando .NET 8, Entity Framework Core (EF Core), y SQL Server como sistema de base de datos. El sistema permite realizar operaciones CRUD (crear, leer, actualizar y eliminar) sobre las tablas relacionadas con los usuarios, roles, opciones de rol, sesiones, etc.

### Arquitectura del Proyecto:
- Base de datos (SQL Server):
Utiliza SQL Server como base de datos relacional para almacenar información sobre usuarios, roles, opciones de rol, sesiones y stored procedures.
Las tablas incluyen PERSONA, USUARIOS, ROL, SESSIONS, y tablas de relación como ROL_USUARIOS, ROL_OPCIONES, y ROL_ROL_OPCIONES.
La estructura de la base de datos está diseñada para permitir eliminación lógica, control de acceso por roles, y un registro completo de sesiones.

- Entity Framework Core (EF Core):
EF Core se utiliza como ORM (Object Relational Mapper) para mapear las tablas de la base de datos a clases de C#.
Se generará automáticamente el DbContext (ApplicationDbContext) a partir de la base de datos mediante scaffold. Esto permite realizar consultas, actualizaciones e inserciones de manera sencilla y eficiente.
Se implementa eliminación lógica en lugar de eliminación física, actualizando el campo Status de las entidades relacionadas.

- API RESTful en .NET 8:
Está construida con ASP.NET Core 8.
Se emplea la arquitectura hexagonal para organizar el código en capas: controladores, servicios, y repositorios.
El API proporciona endpoints para interactuar con las entidades a través de GET, POST, PUT y DELETE:
  **Usuarios:** Crear, leer, actualizar y eliminar usuarios.
  **Roles:** Gestionar roles de usuarios, asignar y eliminar opciones de rol.
  **Sesiones:** Registrar y gestionar sesiones activas de los usuarios.
  **Controladores:** Expuestos para interactuar con la base de datos a través de los servicios.
  **Servicios:** Implementarán la lógica de negocio, validando datos y controlando el flujo de información.

- Autenticación y Autorización:
El sistema se prepara para integrarse con JWT para la autenticación de usuarios, permitiendo que solo los usuarios con el rol adecuado puedan acceder a los endpoints protegidos.

<img width="2560" height="1440" alt="image" src="https://github.com/user-attachments/assets/3e5aaf74-ee2d-4e50-992d-c23f2a901cd1" />
<img width="1959" height="913" alt="image" src="https://github.com/user-attachments/assets/d1697fea-176d-4fea-bdb5-d81382707967" />


## Proyecto Frontend - Angular v20
Este proyecto frontend interactúa con la API RESTful de gestión de usuarios, roles, y sesiones explicada en el anterior punto. A través de Angular, se gestionan las operaciones CRUD (Crear, Leer, Actualizar, Eliminar) de los usuarios, roles y sesiones, se visualizan las relaciones entre estas entidades y se podrán gestionar permisos para modificar la data desde la página según el rol que tenga el usuario conectado.

### Algunas funcionalidades:
- Visualización de Usuarios y Roles: Mostrar una lista de usuarios y sus roles asociados.
- Gestión de Usuarios: Permitir la creación, edición y eliminación de usuarios. Cada usuario tendrá información como nombre, correo y rol.
- Gestión de Roles: Crear y asignar roles a los usuarios.
- Autenticación y Sesiones: Implementación de login con sesión de usuario, donde las credenciales se validan mediante la API de autenticación de la API RESTful.
- Interacción con API: El frontend consumirá la API usando HttpClient de Angular para realizar las operaciones necesarias sobre la base de datos de SQL Server.

### Tecnologías:
- Angular 20 (Standalone Components, Signals)
- HttpClient para la integración con la API
- Material Design para la UI

<img width="2560" height="1440" alt="image" src="https://github.com/user-attachments/assets/042d4964-dbf5-40b0-9f23-0dfceceec4b9" />
(Por el momento se encuentra así el front porque todavía no he hecho los cambios necesarios).
