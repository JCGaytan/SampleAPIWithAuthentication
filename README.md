# EN
## SampleAPIWithAuthentication Solution Documentation

The `SampleAPIWithAuthentication` solution is designed to showcase a sample API with user authentication using JSON Web Tokens (JWT). The solution consists of several projects organized into different namespaces, each responsible for specific functionalities. This document provides an overview of the project structure, namespaces, and key components.

### Project Structure

The solution is organized into the following projects:

1. **SampleAPIWithAuthentication**: The main project that hosts the API controllers and startup configurations.
2. **SampleAPIWithAuthentication.DataAccess**: Contains the `AppDbContext` class responsible for database interactions.
3. **SampleAPIWithAuthentication.Entities**: Defines the entity classes used for database entities.
4. **EncryptionLibrary**: An external library for encryption operations.

### Namespaces and Key Components

#### SampleAPIWithAuthentication

This namespace represents the main project that configures the API controllers and authentication.

##### Controllers

- `UserController`: Manages user-related actions, such as retrieving users, creating, updating, and deleting users. Requires authentication with the "Admin" role.

- `AuthenticationController`: Handles user authentication using JWT. Provides a login endpoint to authenticate users based on their credentials.

##### Startup

- `Startup`: Configures the services, database, authentication, CORS, and API documentation using Swagger.

#### SampleAPIWithAuthentication.DataAccess

This namespace manages database interactions and entity configurations.

##### DbContext

- `AppDbContext`: Represents the database context derived from `DbContext`. It includes the `Users` and `UserRoles` `DbSet` for interacting with the database.

#### SampleAPIWithAuthentication.Entities

This namespace defines the entity classes that map to database tables.

- `User`: Represents a user with properties such as username, password, role, and additional user details.

- `UserRole`: Represents a role that can be assigned to users, with properties like name, description, and user collection.

#### EncryptionLibrary

This namespace is an external library responsible for encryption operations.

- `AesEncryptor`: An instance of the Advanced Encryption Standard (AES) encryptor. This library provides encryption and decryption methods used for securing sensitive data, such as passwords, in the application.

### Authentication Flow

1. The client sends a POST request to the `AuthenticationController`'s `login` endpoint with the user's login credentials.

2. The `AuthenticationController` validates the credentials against the stored encrypted password using the `ValidatePassword` method.

3. If the credentials are valid, the `GenerateJwtToken` method creates a JWT token with the user's claims and returns it to the client.

4. The client includes the JWT token in the Authorization header for subsequent requests to secure endpoints.

5. The `UserController` endpoints require authentication and specific roles to perform user-related actions.

### Conclusion

The `SampleAPIWithAuthentication` solution demonstrates user authentication using JWT in a .NET Core API. The project structure, namespaces, and key components contribute to a secure and organized API with role-based access control.

---

# ES

## Documentación de la Solución SampleAPIWithAuthentication

La solución `SampleAPIWithAuthentication` está diseñada para mostrar una API de ejemplo con autenticación de usuarios utilizando Tokens Web JSON (JWT). La solución está compuesta por varios proyectos organizados en diferentes espacios de nombres, cada uno responsable de funcionalidades específicas. Este documento proporciona una descripción general de la estructura del proyecto, los espacios de nombres y los componentes clave.

### Estructura del Proyecto

La solución está organizada en los siguientes proyectos:

1. **SampleAPIWithAuthentication**: El proyecto principal que aloja los controladores de la API y las configuraciones de inicio.
2. **SampleAPIWithAuthentication.DataAccess**: Contiene la clase `AppDbContext` responsable de las interacciones con la base de datos.
3. **SampleAPIWithAuthentication.Entities**: Define las clases de entidad utilizadas para las entidades de la base de datos.
4. **EncryptionLibrary**: Una biblioteca externa para operaciones de cifrado.

### Espacios de Nombres y Componentes Clave

#### SampleAPIWithAuthentication

Este espacio de nombres representa el proyecto principal que configura los controladores de la API y la autenticación.

##### Controladores

- `UserController`: Gestiona acciones relacionadas con los usuarios, como recuperar usuarios, crear, actualizar y eliminar usuarios. Requiere autenticación con el rol "Admin".

- `AuthenticationController`: Maneja la autenticación de usuarios mediante JWT. Proporciona un punto final de inicio de sesión para autenticar a los usuarios en función de sus credenciales.

##### Inicio

- `Startup`: Configura los servicios, la base de datos, la autenticación, CORS y la documentación de la API mediante Swagger.

#### SampleAPIWithAuthentication.DataAccess

Este espacio de nombres gestiona las interacciones con la base de datos y las configuraciones de las entidades.

##### DbContext

- `AppDbContext`: Representa el contexto de la base de datos derivado de `DbContext`. Incluye los `DbSet` de `Users` y `UserRoles` para interactuar con la base de datos.

#### SampleAPIWithAuthentication.Entities

Este espacio de nombres define las clases de entidad que se asignan a las tablas de la base de datos.

- `User`: Representa a un usuario con propiedades como nombre de usuario, contraseña, rol y detalles adicionales del usuario.

- `UserRole`: Representa un rol que se puede asignar a los usuarios, con propiedades como nombre, descripción y colección de usuarios.

#### EncryptionLibrary

Este espacio de nombres es una biblioteca externa responsable de las operaciones de cifrado.

- `AesEncryptor`: Una instancia del cifrador Advanced Encryption Standard (AES). Esta biblioteca proporciona métodos de cifrado y descifrado utilizados para proteger datos sensibles, como contraseñas, en la aplicación.

### Flujo de Autenticación

1. El cliente envía una solicitud POST al punto final `login` del `AuthenticationController` con las credenciales de inicio de sesión del usuario.

2. El `AuthenticationController` valida las credenciales frente a la contraseña cifrada almacenada mediante el método `ValidatePassword`.

3. Si las credenciales son válidas, el método `GenerateJwtToken` crea un token JWT con las reclamaciones del usuario y lo devuelve al cliente.

4. El cliente incluye el token JWT en la cabecera de Autorización para las solicitudes posteriores a los puntos finales seguros.

5. Los puntos finales de `UserController` requieren autenticación y roles específicos para realizar acciones relacionadas con los usuarios.

### Conclusión

La solución `SampleAPIWithAuthentication` demuestra la autenticación de usuarios mediante JWT en una API .NET Core. La estructura del proyecto, los espacios de nombres y los componentes clave contribuyen a una API segura y organizada con control de acceso basado
