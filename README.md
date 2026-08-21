# IT Support Ticketing Operations System (IT_ELECTIVE_PREFINALS_PROJECT)

A clean, high-contrast monochrome IT ticketing and operations management dashboard built for enterprise support workflows.

## .NET Version
* **Framework**: .NET 8.0 (ASP.NET Core MVC)

## EF Core Version
* **Entity Framework Core**: Version 8.0 (with Microsoft.EntityFrameworkCore.Sqlite)

## NuGet Packages Used
* `Microsoft.EntityFrameworkCore` (8.0.x)
* `Microsoft.EntityFrameworkCore.Sqlite` (8.0.x)
* `Microsoft.EntityFrameworkCore.Tools` (8.0.x)

## Database Location
* **Type**: SQLite
* **File Path**: Root directory of the project (locally generated as `app.db` or configured via `DefaultConnection` string in `appsettings.json`).
* **Initialization**: Automatically created and seeded on application startup via `DbContext.Database.EnsureCreated()` and the `DbSeeder` service.

## How to Run
1. Clone or open the repository in **Visual Studio**.
2. Ensure you have **.NET 8.0 SDK** installed.
3. Open the solution file (`.sln`) in Visual Studio.
4. Press **F5** or click the **Start Debugging** button to build and run the application.
5. The application will automatically initialize the SQLite database and launch the Lyceum IT Operations Dashboard in your default browser at `https://localhost:7155`.
