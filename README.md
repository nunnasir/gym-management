# gym-management
Gym Management Using Clean Architecture, CQRS and MediatR Pattern

# New Migration Command
dotnet ef migrations add AddUserContext -p src/GymManagement.Infrastructure -s src/GymManagement.Api

# Update Database Command
dotnet ef database update -p src/GymManagement.Infrastructure -s src/GymManagement.Api


