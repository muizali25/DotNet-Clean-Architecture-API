# DotNet-Clean-Architecture-API
A .NET 8 Web API built with Clean Architecture principles featuring modular Student, Course, and Teacher management. Designed for scalability, testability, and maintainability using Domain-Driven Design, EF Core, Repository Pattern, and layered architecture.

A basic and beginner-friendly .NET 8 Web API project using Clean Architecture.
In this project, you will learn:

- How CRUD operations are implemented
- How to structure solution into clean layers
- How database is created using EF Core Migrations
- How to configure relationships between entities (Student–Course–Teacher)
- How to call APIs easily using Swagger UI

This project includes:

Layer	Description
Domain	Contains entity models and core business logic
Application	Contains service interfaces, DTOs, validation, mapping
Infrastructure	Contains EF Core DbContext and Repository implementation
API	Exposes controllers and endpoints to clients

🚀 Features

ASP.NET Core 8 Web API

EF Core — Database Migrations

Repository + Service Pattern

DTOs + AutoMapper

Swagger UI API Testing

SQL Server database support

📌 Prerequisites

.NET 8 SDK

SQL Server

Visual Studio 

🛠️ How to Run

1️⃣ Update the DB connection in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=CleanArchDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

2️⃣ Open Package Manager Console and run:

Add-Migration InitialCreate
Update-Database

3️⃣ Run the project → F5 or Ctrl + F5

4️⃣ Test all endpoints on Swagger:

https://localhost:xxxx/swagger

🤝 Contributing

Feel free to:

Fork the repo

Improve structure

Add new modules

Create Pull Requests

🌟 Support

If this helps you learn Clean Architecture, please give a ⭐ on GitHub 🙂
