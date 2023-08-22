# SampleAPIWithAuthentication Solution Documentation

The `SampleAPIWithAuthentication` solution is designed to showcase a sample API with user authentication using JSON Web Tokens (JWT). The solution consists of several projects organized into different namespaces, each responsible for specific functionalities. This document provides an overview of the project structure, namespaces, and key components.

## Project Structure

The solution is organized into the following projects:

1. **SampleAPIWithAuthentication**: The main project that hosts the API controllers and startup configurations.
2. **SampleAPIWithAuthentication.DataAccess**: Contains the `AppDbContext` class responsible for database interactions.
3. **SampleAPIWithAuthentication.Entities**: Defines the entity classes used for database entities.
4. **EncryptionLibrary**: An external library for encryption operations.

## Namespaces and Key Components

### SampleAPIWithAuthentication

This namespace represents the main project that configures the API controllers and authentication.

#### Controllers

- `UserController`: Manages user-related actions, such as retrieving users, creating, updating, and deleting users. Requires authentication with the "Admin" role.

- `AuthenticationController`: Handles user authentication using JWT. Provides a login endpoint to authenticate users based on their credentials.

#### Startup

- `Startup`: Configures the services, database, authentication, CORS, and API documentation using Swagger.

### SampleAPIWithAuthentication.DataAccess

This namespace manages database interactions and entity configurations.

#### DbContext

- `AppDbContext`: Represents the database context derived from `DbContext`. It includes the `Users` and `UserRoles` `DbSet` for interacting with the database.

### SampleAPIWithAuthentication.Entities

This namespace defines the entity classes that map to database tables.

- `User`: Represents a user with properties such as username, password, role, and additional user details.

- `UserRole`: Represents a role that can be assigned to users, with properties like name, description, and user collection.

### EncryptionLibrary

This namespace is an external library responsible for encryption operations.

- `AesEncryptor`: An instance of the Advanced Encryption Standard (AES) encryptor. This library provides encryption and decryption methods used for securing sensitive data, such as passwords, in the application.

## Authentication Flow

1. The client sends a POST request to the `AuthenticationController`'s `login` endpoint with the user's login credentials.

2. The `AuthenticationController` validates the credentials against the stored encrypted password using the `ValidatePassword` method.

3. If the credentials are valid, the `GenerateJwtToken` method creates a JWT token with the user's claims and returns it to the client.

4. The client includes the JWT token in the Authorization header for subsequent requests to secure endpoints.

5. The `UserController` endpoints require authentication and specific roles to perform user-related actions.

## Conclusion

The `SampleAPIWithAuthentication` solution demonstrates user authentication using JWT in a .NET Core API. The project structure, namespaces, and key components contribute to a secure and organized API with role-based access control.
