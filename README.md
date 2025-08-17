# Customer Manager

**Customer Manager** is a lightweight web application built with ASP.NET Core Razor Pages and .NET 8 that streamlines customer management for businesses and organizations. The app enables users to create, edit, view, and delete customers with comprehensive contact information, personal details, and business data management.

## 🚀 Features

- **Complete CRUD Operations**: Create, read, update, and delete customer records
- **Customer List View**: Browse all customers with key information at a glance
- **Detailed Customer Profiles**: View comprehensive customer information
- **Responsive Design**: Modern Bootstrap 5 interface that works on all devices
- **Data Validation**: Built-in form validation for data integrity

## 🛠️ Tech Stack

- **Frontend**: ASP.NET Core Razor Pages, Bootstrap 5, jQuery
- **Backend**: ASP.NET Core 8
- **Database**: Entity Framework Core 8 with SQL Server
- **Architecture**: Repository pattern with clean separation of concerns

## 📁 Project Structure

```
customer_manager/
├── customer_manager.sln          # Solution file
├── customer_manager/
│   ├── Data/                     # Entity Framework DbContext
│   ├── Migrations/               # Database migrations
│   ├── Models/                   # Domain, view, and binding models
│   ├── Pages/                    # Razor Pages (UI layer)
│   ├── Services/                 # Repository interface + implementation
│   ├── wwwroot/                  # Static files (Bootstrap, JS, CSS)
│   ├── Program.cs                # Application startup and configuration
│   ├── appsettings.json          # Application configuration
│   └── customer_manager.csproj   # Project file
```

## 📋 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server instance (LocalDB for Windows or Docker for cross-platform)
- [Entity Framework Core CLI tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) (optional but recommended)

## ⚡ Quick Start

### 1. Clone the Repository
```bash
git clone <repository-url>
cd customer-manager
```

### 2. Database Setup

#### Option A: SQL Server with Docker (Recommended for cross-platform)
```bash
# Start SQL Server container
docker run -e ACCEPT_EULA=Y -e MSSQL_SA_PASSWORD='YourStrong!Passw0rd' \
  -p 1433:1433 --name customer-db \
  -d mcr.microsoft.com/mssql/server:2022-latest

# Set connection string (Linux/macOS)
export ConnectionStrings__SqlServer="Server=localhost,1433;Database=customer_manager;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"
```

#### Option B: Windows LocalDB (Default)
The application is pre-configured for Windows LocalDB. No additional setup required.

### 3. Install Dependencies and Run
```bash
cd customer_manager

# Restore NuGet packages
dotnet restore

# Install EF Core CLI tools (if not already installed)
dotnet tool install --global dotnet-ef

# Apply database migrations
dotnet ef database update

# Start the application
dotnet run
```

### 4. Access the Application
Open your browser and navigate to:
- **HTTP**: `http://localhost:5282`
- **HTTPS**: `https://localhost:7008`

## 🎯 Usage

### Key Endpoints

| Route | Description |
|-------|-------------|
| `/CustomersDisplay` | View all customers |
| `/AddCustomer` | Create a new customer |
| `/AddCustomer?id={id}` | Edit existing customer |
| `/CustomerDetails?id={id}` | View customer details |
| Delete actions | Available from the customer list |

### Creating Your First Customer

1. Navigate to the application homepage
2. Click "Add New Customer" or go to `/AddCustomer`
3. Fill in the customer information:
   - Name and contact details
   - Address information
   - Any additional business details
4. Save the customer record

## 🔧 Configuration

### Database Connection
The application uses the `ConnectionStrings:SqlServer` setting from `appsettings.json`. You can override this with environment variables:

```bash
# Environment variable format (note the double underscore)
export ConnectionStrings__SqlServer="Your_Connection_String_Here"
```

### Environment Variables
- `ASPNETCORE_ENVIRONMENT`: Set to `Development`, `Staging`, or `Production`
- `ConnectionStrings__SqlServer`: Override the default connection string

## 🗃️ Database Management

### Entity Framework Core Commands
```bash
# Create a new migration
dotnet ef migrations add MigrationName

# Apply migrations to database
dotnet ef database update

# Remove the last migration (if not applied)
dotnet ef migrations remove

# View migration history
dotnet ef migrations list
```

## 🏗️ Development

### Architecture Overview
- **Presentation Layer**: Razor Pages handle UI and user interactions
- **Business Logic**: Services layer contains business rules and data operations
- **Data Access**: Repository pattern with Entity Framework Core
- **Database**: SQL Server with code-first migrations

### Adding New Features
1. Update models in the `Models` folder
2. Modify services in the `Services` layer
3. Create or update Razor Pages in the `Pages` folder
4. Generate and apply EF Core migrations

## 🚨 Troubleshooting

### Common Issues

**"dotnet ef command not found"**
```bash
dotnet tool install --global dotnet-ef
```

**Database connection errors on non-Windows systems**
- LocalDB is Windows-only. Use SQL Server in Docker or a full SQL Server instance
- Verify your connection string format
- Ensure SQL Server is running and accessible

**Migration errors**
- Check that you're in the correct project directory
- Verify the connection string is valid
- Ensure the database server is running

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is open source. Please add a license file (MIT, Apache 2.0, etc.) to specify usage terms.

## 🆘 Support

If you encounter any issues:
1. Check the troubleshooting section above
2. Search existing [issues](../../issues)
3. Create a new issue with detailed information about your problem

---

Built with ❤️ using ASP.NET Core 8 and Entity Framework Core
