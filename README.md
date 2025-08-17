## Customer Manager

An ASP.NET Core (.NET 8) Razor Pages app for managing customers with full CRUD using Entity Framework Core and SQL Server.

### Features
- **Customer CRUD**: Create, read, update, delete customers
- **List and details**: List view and details view
- **Bootstrap UI**: Basic styles using Bootstrap 5

### Tech stack
- **Frontend**: Razor Pages, Bootstrap 5, jQuery
- **Backend**: ASP.NET Core 8
- **Data**: Entity Framework Core 8 with SQL Server

### Project structure
```
customer_manager.sln
customer_manager/
  Data/                # EF Core DbContext
  Migrations/          # EF Core migrations
  Models/              # Domain, view, and binding models
  Pages/               # Razor Pages (UI)
  Services/            # Repository interface + implementation
  wwwroot/             # Static files (Bootstrap, JS, CSS)
  Program.cs           # App startup
  appsettings*.json    # Configuration (incl. connection string)
  customer_manager.csproj
```

### Prerequisites
- **.NET 8 SDK**
- A **SQL Server** instance
  - Windows: LocalDB (default in Visual Studio)
  - Cross‑platform: SQL Server in Docker

### Configure the database
By default, the app reads the `ConnectionStrings:SqlServer` setting.

- Example for Docker SQL Server (recommended cross‑platform):
  1) Start SQL Server:
  ```bash
  docker run -e ACCEPT_EULA=Y -e MSSQL_SA_PASSWORD='Your_password123' \
    -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
  ```
  2) Set the connection string (either update `appsettings.Development.json` or use an env var):
  ```bash
  # env var form (note the double underscore for nested config keys)
  export ConnectionStrings__SqlServer="Server=localhost,1433;Database=customer_manager;User Id=sa;Password=Your_password123;TrustServerCertificate=True;"
  ```

- Windows LocalDB (default in `appsettings.json`):
  ```
  Data Source=(localdb)\ProjectModels;Initial Catalog=homework6;Integrated Security=True;Encrypt=False
  ```
  Update this if you prefer a different database name.

### Restore, migrate, and run
From the repository root:

```bash
cd customer_manager

# Restore packages
dotnet restore

# If you don't have the EF CLI:
# dotnet tool install --global dotnet-ef

# Apply migrations to create/update the database
dotnet ef database update

# Run the app
dotnet run
```

The app starts on:
- HTTP: `http://localhost:5282`
- HTTPS: `https://localhost:7008`

### Using the app
- **Customers list**: `/CustomersDisplay`
- **Add customer**: `/AddCustomer`
- **Edit customer**: `/AddCustomer?id={id}`
- **View details**: `/CustomerDetails?id={id}`
- **Delete**: From the list page action button

### Migrations (EF Core)
- Add a migration: `dotnet ef migrations add <Name>`
- Update DB: `dotnet ef database update`
- Remove last migration: `dotnet ef migrations remove`

### Configuration notes
- Override config via environment variables, e.g.:
  - `ASPNETCORE_ENVIRONMENT=Development`
  - `ConnectionStrings__SqlServer=...`
- No authentication/authorization is enabled; the UI is open by default.

### Troubleshooting
- On non‑Windows systems, LocalDB is not available. Use a full SQL Server (e.g., Docker) and set the connection string.
- If `dotnet ef` is not found, install the tool: `dotnet tool install --global dotnet-ef`.

### License
No license specified.