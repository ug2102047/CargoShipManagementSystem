# Cargo Ship Management System

A Windows Forms application for managing cargo ships, berths, and cargo shipments. Built with C# and SQL Server.

---

## 🚀 **New to this project? Start here:** 👉 [QUICK START GUIDE](QUICK_START.md) 👈

**বাংলায় সহজ guide:** [QUICK_START.md](QUICK_START.md) তে সব step-by-step বলা আছে!

---

## 📋 Features

- **User Authentication**: Role-based login system (Admin, Manager, Operator, Viewer)
- **Ship Management**: Track ships, their locations, status, and berth assignments
- **Berth Management**: Manage docking berths and their availability
- **Cargo Management**: Monitor cargo shipments, status, and assignments
- **Dashboard**: Real-time overview of ships, cargo, and berths
- **Report Generation**: Generate PDF reports and invoices for cargo shipments

## 🖥️ Technologies Used

- **Frontend**: Windows Forms (.NET Framework)
- **Backend**: C# .NET Framework
- **Database**: Microsoft SQL Server / SQL Server Express
- **Libraries**:
  - iTextSharp 5.5.13.4 (PDF generation)
  - BouncyCastle.Cryptography 2.4.0 (encryption support)

## 📦 Prerequisites

Before running this project, ensure you have the following installed:

1. **Visual Studio** (2017 or later)
   - With .NET Framework development workload
2. **SQL Server** or **SQL Server Express**
   - Download from [Microsoft SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
3. **.NET Framework 4.7.2** or later

## 🚀 Installation & Setup

### Step 1: Clone the Repository

```bash
git clone https://github.com/yourusername/CargoShipManagementSystem.git
cd CargoShipManagementSystem
```

### Step 2: Install SQL Server (if not already installed)

If you don't have SQL Server installed:

1. Download **SQL Server Express** (Free): [Download Link](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
2. Download **SQL Server Management Studio (SSMS)**: [Download Link](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)
3. Install both applications
4. During SQL Server installation, note down your server name (usually `localhost\SQLEXPRESS` or `.\SQLEXPRESS`)

### Step 3: Database Setup

**Option A: Using SQL Server Management Studio (Recommended)**

1. Open **SQL Server Management Studio (SSMS)**
2. Connect to your SQL Server instance
   - Server name: `localhost\SQLEXPRESS` or `.\SQLEXPRESS` or your custom server name
   - Authentication: Windows Authentication (recommended)
3. Click **File → Open → File** and select `DatabaseSchema.sql` from the project root
4. Click **Execute** or press **F5**
5. You should see success messages confirming:
   - Database `CargoShipDB` created
   - 4 tables created (Users, Ships, Berths, Cargo)
   - Sample data inserted

**Option B: Using Command Line (Alternative)**

```bash
sqlcmd -S localhost\SQLEXPRESS -E -i DatabaseSchema.sql
```

**Option C: Automated Setup (Easiest)**

Double-click the `SetupDatabase.bat` file in the project root folder. It will automatically:

- Check if SQL Server is running
- Create the database
- Create all tables
- Insert sample data

**Note**: The script will drop the existing `CargoShipDB` database if it exists. Make sure to backup any important data.

### Step 4: Configure Database Connection

1. Open the project in Visual Studio
2. Locate `App.config` in the `CargoShipManagementSystem` project folder
3. Find the `<connectionStrings>` section
4. Update the connection string with your SQL Server details:

```xml
<connectionStrings>
  <add name="CargoShipDB"
       connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=CargoShipDB;Integrated Security=True;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

**Replace `YOUR_SERVER_NAME` with your actual server name:**

| Server Type                | Server Name Example                          |
| -------------------------- | -------------------------------------------- |
| SQL Server Express (Local) | `localhost\SQLEXPRESS` or `.\SQLEXPRESS`     |
| SQL Server (Local)         | `localhost` or `(local)` or `.`              |
| Remote Server              | `ServerName\InstanceName` or `192.168.1.100` |

**For SQL Authentication (if not using Windows Authentication):**

```xml
connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=CargoShipDB;User ID=sa;Password=YourPassword;"
```

**How to find your SQL Server name:**

- Open SSMS → When connecting, look at the "Server name" dropdown
- Or run this in Command Prompt: `sqlcmd -L`

### Step 5: Restore NuGet Packages

1. Open the project in Visual Studio
2. Locate `App.config` in the main project folder
3. Update the connection string with your SQL Server details:

```xml
<connectionStrings>
  <add name="CargoShipDB"
       connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=CargoShipDB;Integrated Security=True;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

**Common Server Names:**

- Local SQL Server Express: `localhost\SQLEXPRESS` or `.\SQLEXPRESS`
- Local SQL Server: `localhost` or `(local)`
- Remote server: `ServerName\InstanceName` or `IP_Address`

**For SQL Authentication** (instead of Windows Authentication):

```xml
connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=CargoShipDB;User ID=your_username;Password=your_password;"
```

### Step 4: Restore NuGet Packages

1. Right-click on the solution in Visual Studio
2. Select **Restore NuGet Packages**
3. Wait for packages to download (iTextSharp and BouncyCastle)

### Step 5: Build and Run

1. Press **F5** or click **Start** in Visual Studio
2. The application will launch with the login screen

## 👤 Default Login Credentials

After running the database script, you can login with these accounts:

| Username | Password    | Role     |
| -------- | ----------- | -------- |
| admin    | admin123    | Admin    |
| manager  | manager123  | Manager  |
| operator | operator123 | Operator |
| viewer   | viewer123   | Viewer   |

⚠️ **Security Note**: These are demo credentials. In production, always use hashed passwords and secure authentication.

## 📁 Project Structure

```
CargoShipManagementSystem/
├── CargoShipManagementSystem.sln          # Solution file
├── DatabaseSchema.sql                      # Database creation script
├── README.md                               # This file
├── .gitignore                             # Git ignore rules
└── CargoShipManagementSystem/             # Main project folder
    ├── LoginForm.cs                       # User authentication
    ├── DashboardForm.cs                   # Main dashboard
    ├── ShipManagementForm.cs              # Ship management
    ├── BerthManagementForm.cs             # Berth management
    ├── CargoManagementForm.cs             # Cargo management
    ├── ReportForm.cs                      # Report generation
    ├── App.config                         # Application configuration
    └── packages.config                    # NuGet packages
```

## 🎯 Usage Guide

### Dashboard

- View real-time statistics for ships, cargo, and berths
- Quick overview of pending, loaded, in-transit cargo
- See ship status distribution

### Ship Management

- Add, update, delete ships
- Assign ships to berths
- Track ship locations and status
- Search ships by name, call sign, or location

### Berth Management

- Add, update, delete berths
- Set berth capacity (max length and draft)
- Monitor berth availability
- Track berth maintenance status

### Cargo Management

- Add, update, delete cargo entries
- Assign cargo to ships
- Track cargo status (Pending, Loaded, In Transit, Delivered, Cancelled)
- Search cargo by name, origin, or destination

### Reports

- Generate comprehensive cargo reports
- Create filtered reports by ship
- Generate invoices with cost calculations
- Export reports to PDF

## 🔧 Troubleshooting

### Database Connection Issues

**Error**: "Cannot open database 'CargoShipDB'"

- Solution: Make sure the DatabaseSchema.sql script has been executed successfully

**Error**: "Login failed for user"

- Solution: Check your connection string credentials or use Windows Authentication (Integrated Security=True)

### Build Errors

**Error**: Missing references or packages

- Solution: Right-click solution → Restore NuGet Packages → Rebuild

### Runtime Errors

**Error**: "Could not load file or assembly 'iTextSharp'"

- Solution: Clean solution, restore NuGet packages, and rebuild

## 📝 Database Schema

### Tables

- **Users**: User accounts and roles
- **Ships**: Ship information and status
- **Berths**: Docking berth information
- **Cargo**: Cargo shipment details

### Relationships

- Ships can be assigned to Berths (Many-to-One)
- Cargo can be assigned to Ships (Many-to-One)

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is created for educational purposes as part of a System Analysis project.

## 👥 Authors

- Your Name - Initial work

## 🙏 Acknowledgments

- iTextSharp for PDF generation capabilities
- BouncyCastle for cryptography support
- SQL Server for robust database management

## 📞 Support

For questions or issues:

- Open an issue on GitHub
- Contact: your-email@example.com

---

**Note**: This is a student project developed for academic purposes. It demonstrates fundamental concepts of database-driven Windows Forms applications.
