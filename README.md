🎬 Movie Catalog Web API

A clean and scalable ASP.NET Core Web API for managing and querying movie data.
This project is designed as a learning-focused backend application demonstrating modern API design principles, clean architecture, and best practices.

🚀 Learning Objectives

This project helps you:

Design a clean REST API using ASP.NET Core

Implement search, filtering, sorting, and pagination

Understand route handling and query parameter parsing

Apply clean architecture principles in a real-world scenario

🧱 Architecture Overview

The project is built using Onion Architecture, ensuring separation of concerns and high maintainability.

Layers
├── Domain          → Entities, Enums, Core business rules
├── Application     → Services, DTOs, Result Pattern, Validators
├── Infrastructure  → Repositories, EF Core, Data access
├── WebAPI          → Controllers, DI configuration, Swagger

Key Design Patterns Used

🧅 Onion Architecture

📦 Repository Pattern

🔁 Service Pattern

🧩 Dependency Injection

✅ Fluent Validation

❌ Result Pattern for error handling



✅ Features
🔍 Movie Search

Search movies by title using a query parameter.

GET /api/movies?search=batman

🎭 Genre & 📅 Year Filtering

Filter movies by genre and release year.

GET /api/movies?genre=Action

📄 Pagination Support

Control page size and page number via query parameters.

GET /api/movies?pageNumber=1&pageSize=10

🌟 Bonus Features

✔️ Return total movie count for pagination

🔀 Sort movies by rating or release date

📘 Swagger / OpenAPI documentation

⚙️ Technical Stack

ASP.NET Core Web API

Entity Framework Core (In-Memory or Database)

FluentValidation

Swagger (Swashbuckle)

Dependency Injection

🧪 Validation & Error Handling

All incoming requests are validated using FluentValidation

Errors are handled using a Result Pattern

🧩 Dependency Injection

All services and repositories are registered via built-in ASP.NET Core DI container:

Services → Application Layer

Repositories → Infrastructure Layer

Validators → Application Layer

This ensures loose coupling and testability.
