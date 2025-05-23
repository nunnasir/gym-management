# Gym Management System

A modern gym management system built using Clean Architecture, CQRS, and MediatR patterns.

## Overview

This project is designed to manage gyms, subscriptions, rooms, and user profiles. It follows best practices in software design, ensuring scalability, maintainability, and testability.

## Architecture

- **Clean Architecture:** Separation of concerns into distinct layers (API, Application, Domain, Infrastructure).
- **CQRS:** Command Query Responsibility Segregation for handling business logic.
- **MediatR:** Mediator pattern for handling commands and queries.
- **Entity Framework Core:** Data access using SQLite.

## Features

- **Gym Management:** Create, delete, and manage gyms and trainers.
- **Subscription Management:** Handle different subscription types (Free, Starter, Pro).
- **User Authentication:** JWT-based authentication for secure access.
- **API Documentation:** Swagger integration for easy API exploration.

## Setup

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd gym-management
   ```

2. **Install dependencies:**
   ```bash
   dotnet restore
   ```

3. **Run migrations:**
   ```bash
   dotnet ef migrations add AddUserContext -p src/GymManagement.Infrastructure -s src/GymManagement.Api
   dotnet ef database update -p src/GymManagement.Infrastructure -s src/GymManagement.Api
   ```

4. **Run the application:**
   ```bash
   dotnet run --project src/GymManagement.Api
   ```

## Usage

- **API Endpoints:** Access the API documentation via Swagger at `/swagger`.
- **Authentication:** Use JWT tokens for authenticated requests.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
