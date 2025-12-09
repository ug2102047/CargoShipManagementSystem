@echo off
REM =============================================
REM Cargo Ship Management System - Database Setup
REM This script automatically sets up the database
REM =============================================

echo.
echo ========================================
echo   Cargo Ship Management System
echo   Automated Database Setup
echo ========================================
echo.

REM Check if SQL Server is installed
echo Checking for SQL Server installation...
sqlcmd -? >nul 2>&1
if %errorlevel% neq 0 (
    echo ERROR: SQL Server command-line tools not found!
    echo Please install SQL Server or add it to your PATH.
    echo.
    echo Download SQL Server Express from:
    echo https://www.microsoft.com/en-us/sql-server/sql-server-downloads
    echo.
    pause
    exit /b 1
)

echo SQL Server tools found!
echo.

REM Prompt for server name
echo Please enter your SQL Server instance name.
echo Common examples:
echo   - localhost\SQLEXPRESS  (for SQL Server Express)
echo   - localhost             (for default SQL Server instance)
echo   - .\SQLEXPRESS          (alternative for Express)
echo   - (local)               (alternative for default instance)
echo.
set /p SERVER_NAME="Enter server name [default: localhost\SQLEXPRESS]: "

if "%SERVER_NAME%"=="" set SERVER_NAME=localhost\SQLEXPRESS

echo.
echo Testing connection to %SERVER_NAME%...
sqlcmd -S %SERVER_NAME% -E -Q "SELECT @@VERSION" >nul 2>&1

if %errorlevel% neq 0 (
    echo.
    echo ERROR: Cannot connect to SQL Server instance '%SERVER_NAME%'
    echo.
    echo Please check:
    echo   1. SQL Server is running
    echo   2. Server name is correct
    echo   3. You have permission to connect
    echo.
    echo You can check SQL Server service status:
    echo   - Open Services (services.msc)
    echo   - Look for 'SQL Server (SQLEXPRESS)' or 'SQL Server (MSSQLSERVER)'
    echo   - Make sure it's running
    echo.
    pause
    exit /b 1
)

echo Successfully connected to SQL Server!
echo.

REM Confirm before proceeding
echo WARNING: This will DROP the existing CargoShipDB database if it exists!
echo All data in the existing database will be LOST!
echo.
set /p CONFIRM="Do you want to continue? (Y/N): "

if /i not "%CONFIRM%"=="Y" (
    echo.
    echo Setup cancelled by user.
    pause
    exit /b 0
)

echo.
echo ========================================
echo Creating database and tables...
echo ========================================
echo.

REM Execute the database schema script
sqlcmd -S %SERVER_NAME% -E -i "DatabaseSchema.sql" -o "setup_log.txt"

if %errorlevel% neq 0 (
    echo.
    echo ERROR: Database setup failed!
    echo Check setup_log.txt for details.
    echo.
    pause
    exit /b 1
)

echo.
echo ========================================
echo Database Setup Completed Successfully!
echo ========================================
echo.
echo Database: CargoShipDB
echo Tables: Users, Ships, Berths, Cargo
echo Sample data has been inserted.
echo.
echo Default login credentials:
echo   Username: admin     Password: admin123     Role: Admin
echo   Username: manager   Password: manager123   Role: Manager
echo   Username: operator  Password: operator123  Role: Operator
echo   Username: viewer    Password: viewer123    Role: Viewer
echo.
echo ========================================
echo Next Steps:
echo ========================================
echo 1. Open the project in Visual Studio
echo 2. Update App.config with your server name: %SERVER_NAME%
echo 3. Build and run the application
echo.
echo See setup_log.txt for detailed execution log.
echo.
pause
