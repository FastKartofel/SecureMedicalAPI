# SecureMedicalApi

## Overview
SecureMedicalApi is a cutting-edge ASP.NET Core Web API crafted for the secure management of medical data. It's equipped with JWT authentication, ensuring that every endpoint is accessible only to authenticated users, thus offering a secure platform for managing sensitive medical records.

## Features
- **User Authentication:** Robust JWT authentication to ensure secure access.
- **Doctors Management:** Full CRUD capabilities for managing doctor profiles.
- **Prescriptions Endpoint:** Secure retrieval of detailed prescription data.
- **Error Logging:** Comprehensive logging of errors to logs.txt for audit and debugging.
  
# Getting Started
**Prerequisites**
- .NET 6 SDK
- Microsoft SQL Server
- An IDE like Visual Studio
  
# Setup and Installation
- Clone the repository to your local environment.
- Install necessary dependencies with dotnet restore.
- Configure the secret key for JWT in your environment variables or app settings.
- Initialize the database using Entity Framework migrations with dotnet ef database update.

# Running the Application
- Launch the application with dotnet run and navigate to the provided local URLs.
- Access Swagger UI to interact with the API's endpoints.
  
# Endpoints Security
- Apply the [Authorize] attribute to secure endpoints at the controller or action level.
- Only authenticated users with a valid JWT token can access these endpoints.
