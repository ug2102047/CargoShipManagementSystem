-- =============================================
-- Cargo Ship Management System Database Schema
-- =============================================
-- This script creates the complete database schema for the Cargo Ship Management System
-- Execute this script in SQL Server Management Studio or any SQL Server client
-- =============================================

USE master;
GO

-- Drop database if exists (BE CAREFUL - this will delete all data!)
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'CargoShipDB')
BEGIN
    ALTER DATABASE CargoShipDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE CargoShipDB;
END
GO

-- Create the database
CREATE DATABASE CargoShipDB;
GO

USE CargoShipDB;
GO

-- =============================================
-- Table: Users
-- Stores user credentials and roles for authentication
-- =============================================
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL, -- In production, store hashed passwords
    Role NVARCHAR(50) NOT NULL CHECK (Role IN ('Admin', 'Manager', 'Operator', 'Viewer')),
    FullName NVARCHAR(100),
    Email NVARCHAR(100),
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE(),
    LastLogin DATETIME NULL
);
GO

-- =============================================
-- Table: Berths
-- Stores information about docking berths
-- =============================================
CREATE TABLE Berths (
    BerthID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE,
    MaxLength DECIMAL(10,2) NULL, -- Maximum ship length allowed (in meters)
    MaxDraft DECIMAL(10,2) NULL,  -- Maximum ship draft allowed (in meters)
    Status NVARCHAR(50) NOT NULL DEFAULT 'Free' CHECK (Status IN ('Free', 'Occupied', 'Under Maintenance')),
    LastUpdated DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- Table: Ships
-- Stores information about cargo ships
-- =============================================
CREATE TABLE Ships (
    ShipID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    CallSign NVARCHAR(50) UNIQUE,
    CapacityWeight DECIMAL(18,2) NULL, -- Weight capacity in tons
    CapacityVolume DECIMAL(18,2) NULL, -- Volume capacity in cubic meters
    Length DECIMAL(10,2) NULL,         -- Ship length in meters
    Draft DECIMAL(10,2) NULL,          -- Ship draft in meters
    CurrentLocation NVARCHAR(200),
    Status NVARCHAR(50) NOT NULL DEFAULT 'Docked' CHECK (Status IN ('Docked', 'In Transit', 'Maintenance')),
    CurrentBerthID INT NULL,           -- Foreign key to Berths table
    LastUpdated DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CurrentBerthID) REFERENCES Berths(BerthID) ON DELETE SET NULL
);
GO

-- =============================================
-- Table: Cargo
-- Stores information about cargo shipments
-- =============================================
CREATE TABLE Cargo (
    CargoID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    Weight DECIMAL(18,2) NULL,    -- Weight in tons
    Volume DECIMAL(18,2) NULL,    -- Volume in cubic meters
    Status NVARCHAR(50) NOT NULL DEFAULT 'Pending' CHECK (Status IN ('Pending', 'Loaded', 'In Transit', 'Delivered', 'Cancelled')),
    Origin NVARCHAR(200),
    Destination NVARCHAR(200),
    ShipID INT NULL,              -- Foreign key to Ships table
    LastUpdated DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ShipID) REFERENCES Ships(ShipID) ON DELETE SET NULL
);
GO

-- =============================================
-- Create Indexes for Performance
-- =============================================
CREATE INDEX IX_Ships_Status ON Ships(Status);
CREATE INDEX IX_Ships_CurrentBerthID ON Ships(CurrentBerthID);
CREATE INDEX IX_Cargo_Status ON Cargo(Status);
CREATE INDEX IX_Cargo_ShipID ON Cargo(ShipID);
CREATE INDEX IX_Berths_Status ON Berths(Status);
GO

-- =============================================
-- Insert Sample Data
-- =============================================

-- Insert sample users (password is plain text for demo - in production use hashed passwords)
INSERT INTO Users (Username, PasswordHash, Role, FullName, Email) VALUES
('admin', 'admin123', 'Admin', 'System Administrator', 'admin@cargosystem.com'),
('manager', 'manager123', 'Manager', 'Port Manager', 'manager@cargosystem.com'),
('operator', 'operator123', 'Operator', 'Operations Staff', 'operator@cargosystem.com'),
('viewer', 'viewer123', 'Viewer', 'Guest Viewer', 'viewer@cargosystem.com');
GO

-- Insert sample berths
INSERT INTO Berths (Name, MaxLength, MaxDraft, Status) VALUES
('Berth A1', 300.00, 15.00, 'Free'),
('Berth A2', 250.00, 12.00, 'Free'),
('Berth B1', 350.00, 18.00, 'Free'),
('Berth B2', 280.00, 14.00, 'Free'),
('Berth C1', 400.00, 20.00, 'Under Maintenance');
GO

-- Insert sample ships
INSERT INTO Ships (Name, CallSign, CapacityWeight, CapacityVolume, Length, Draft, CurrentLocation, Status, CurrentBerthID) VALUES
('MV Atlantic Star', 'ATLS001', 50000.00, 65000.00, 280.00, 14.50, 'Port of Chittagong', 'Docked', 1),
('MV Pacific Explorer', 'PACE002', 75000.00, 95000.00, 320.00, 16.00, 'Port of Chittagong', 'Docked', 2),
('MV Indian Ocean', 'INDO003', 60000.00, 78000.00, 295.00, 15.20, 'En Route to Singapore', 'In Transit', NULL),
('MV Bengal Express', 'BENG004', 45000.00, 58000.00, 260.00, 13.80, 'Port Workshop', 'Maintenance', NULL),
('MV Bay Carrier', 'BAYC005', 55000.00, 70000.00, 275.00, 14.00, 'Port of Chittagong', 'Docked', 3);
GO

-- Insert sample cargo
INSERT INTO Cargo (Name, Description, Weight, Volume, Status, Origin, Destination, ShipID) VALUES
('Electronics Shipment', 'Laptops, Mobile Phones, and Accessories', 1200.00, 1800.00, 'Loaded', 'Chittagong', 'Singapore', 1),
('Textile Products', 'Ready-made garments for export', 2500.00, 3500.00, 'Loaded', 'Chittagong', 'Dubai', 1),
('Steel Bars', 'Construction grade steel bars', 8000.00, 5000.00, 'Loaded', 'Chittagong', 'Colombo', 2),
('Food Grains', 'Rice and wheat for distribution', 15000.00, 12000.00, 'In Transit', 'Chittagong', 'Singapore', 3),
('Pharmaceuticals', 'Medical supplies and medicines', 500.00, 800.00, 'Pending', 'Chittagong', 'Mumbai', NULL),
('Machinery Parts', 'Industrial machinery components', 3500.00, 2800.00, 'Loaded', 'Chittagong', 'Bangkok', 2),
('Leather Goods', 'Leather bags, shoes, and accessories', 800.00, 1200.00, 'Pending', 'Chittagong', 'Hong Kong', NULL),
('Ceramic Tiles', 'Construction and decorative tiles', 4500.00, 3200.00, 'Delivered', 'Chittagong', 'Karachi', 5),
('Plastic Products', 'Various plastic items for retail', 1800.00, 2500.00, 'Loaded', 'Chittagong', 'Manila', 5),
('Agricultural Products', 'Tea and spices for export', 2200.00, 1800.00, 'Pending', 'Chittagong', 'London', NULL);
GO

-- =============================================
-- Update berth status based on ships
-- =============================================
UPDATE Berths SET Status = 'Occupied' WHERE BerthID IN (SELECT DISTINCT CurrentBerthID FROM Ships WHERE CurrentBerthID IS NOT NULL);
GO

-- =============================================
-- Create a view for comprehensive cargo information
-- =============================================
CREATE VIEW vw_CargoWithShipInfo AS
SELECT 
    c.CargoID,
    c.Name AS CargoName,
    c.Description,
    c.Weight,
    c.Volume,
    c.Status AS CargoStatus,
    c.Origin,
    c.Destination,
    s.Name AS ShipName,
    s.CallSign,
    s.CurrentLocation,
    s.Status AS ShipStatus,
    c.LastUpdated
FROM Cargo c
LEFT JOIN Ships s ON c.ShipID = s.ShipID;
GO

-- =============================================
-- Create a view for ship berth assignments
-- =============================================
CREATE VIEW vw_ShipBerthAssignments AS
SELECT 
    s.ShipID,
    s.Name AS ShipName,
    s.CallSign,
    s.Status AS ShipStatus,
    b.Name AS BerthName,
    b.Status AS BerthStatus,
    s.Length AS ShipLength,
    b.MaxLength AS BerthMaxLength,
    s.Draft AS ShipDraft,
    b.MaxDraft AS BerthMaxDraft
FROM Ships s
LEFT JOIN Berths b ON s.CurrentBerthID = b.BerthID;
GO

-- =============================================
-- Display summary information
-- =============================================
PRINT '========================================';
PRINT 'Database Schema Created Successfully!';
PRINT '========================================';
PRINT '';
PRINT 'Sample Users:';
PRINT '  Username: admin     | Password: admin123     | Role: Admin';
PRINT '  Username: manager   | Password: manager123   | Role: Manager';
PRINT '  Username: operator  | Password: operator123  | Role: Operator';
PRINT '  Username: viewer    | Password: viewer123    | Role: Viewer';
PRINT '';
PRINT 'Database: CargoShipDB';
PRINT 'Tables Created: Users, Berths, Ships, Cargo';
PRINT 'Views Created: vw_CargoWithShipInfo, vw_ShipBerthAssignments';
PRINT '';
PRINT 'Sample Data Inserted:';
SELECT 'Users' AS TableName, COUNT(*) AS RecordCount FROM Users
UNION ALL
SELECT 'Berths', COUNT(*) FROM Berths
UNION ALL
SELECT 'Ships', COUNT(*) FROM Ships
UNION ALL
SELECT 'Cargo', COUNT(*) FROM Cargo;
GO
