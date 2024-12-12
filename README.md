# Restaurant Management System

## Overview
The Restaurant Management System is a C# application designed to manage food and drink items for a restaurant. The project is structured using a multi-layered architecture to ensure modularity and scalability. It provides functionalities to create, read, update, and delete (CRUD) items in the menu and supports database integration for persistence.

## Features
- **Food and Drink Management:** Add, update, delete, and retrieve menu items.
- **Multi-layered Architecture:** Separation of concerns using Domain, Contract, Application, EF, and Host layers.
- **Database Integration:** Entity Framework Core for database operations.
- **API Layer:** Web API endpoints for interacting with the application.
- **Logging and Error Handling:** Logs errors and can send email notifications for critical issues.

## Project Structure
```
Root Directory0
├── Domain         # Contains core entities and business logic
├── Contract       # Interfaces and DTOs for communication between layers
├── Application    # Application services (e.g., DrinkServices, FoodServices)
├── EF             # Database configuration and migrations
├── Host           # Web API project with controllers and startup configuration
```

## Technologies Used
- **Language:** C#
- **Frameworks:** .NET Core, Entity Framework Core
- **Database:** SQL Server
- **Frontend:** React (optional, if integrated)
- **Tools:** Visual Studio Code, Git

## Getting Started

### Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Visual Studio Code](https://code.visualstudio.com/)

### Setup Instructions
1. **Clone the Repository:**
   ```bash
   git clone <repository_url>
   cd RestaurantManagement
   ```

2. **Set Up the Database:**
   - Configure the connection string in `appsettings.json` located in the `Host` project.
   - Apply migrations:
     ```bash
     dotnet ef database update
     ```

3. **Run the Application:**
   ```bash
   cd Host
   dotnet run
   ```
   The API will be available at `http://localhost:5000`.

4. **Test API Endpoints:**
   Use a tool like [Postman](https://www.postman.com/) or Swagger UI (if configured).

## Key Functionalities

### Food and Drink Management
- **Create:** Add new menu items with properties such as `Name`, `Price`, `CreationTime`, and `IsDeleted`.
- **Retrieve:** Get all menu items or search by `Id`.
- **Update:** Modify existing menu items.
- **Delete:** Mark items as deleted.

### Logging
- Logs are maintained for critical actions and errors.
- Error logs trigger email notifications.

## API Documentation
Example Endpoints:
- **Get All Drinks:** `GET /api/drinks`
- **Add a Drink:** `POST /api/drinks`
- **Update a Drink:** `PUT /api/drinks/{id}`
- **Delete a Drink:** `DELETE /api/drinks/{id}`

## Future Enhancements
- Integration with a front-end application (React/Angular).
- Implement authentication and authorization.
- Add support for menu categories and inventory management.
- Enhance logging with real-time monitoring tools.

## Contributors
- **Lama Abdelmuhsen** - Developer

