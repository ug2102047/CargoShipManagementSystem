-- =============================================
-- Update Users Table Script
-- This script adds missing columns to existing Users table
-- Run this if you get "Invalid column name" errors during registration
-- =============================================

USE CargoShipDB;
GO

-- Check if FullName column exists, if not add it
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND name = 'FullName')
BEGIN
    ALTER TABLE Users ADD FullName NVARCHAR(100) NULL;
    PRINT 'FullName column added successfully.';
END
ELSE
BEGIN
    PRINT 'FullName column already exists.';
END
GO

-- Check if Email column exists, if not add it
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND name = 'Email')
BEGIN
    ALTER TABLE Users ADD Email NVARCHAR(100) NULL;
    PRINT 'Email column added successfully.';
END
ELSE
BEGIN
    PRINT 'Email column already exists.';
END
GO

-- Check if IsActive column exists, if not add it
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND name = 'IsActive')
BEGIN
    ALTER TABLE Users ADD IsActive BIT DEFAULT 1;
    PRINT 'IsActive column added successfully.';
END
ELSE
BEGIN
    PRINT 'IsActive column already exists.';
END
GO

-- Check if CreatedAt column exists, if not add it
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND name = 'CreatedAt')
BEGIN
    ALTER TABLE Users ADD CreatedAt DATETIME DEFAULT GETDATE();
    PRINT 'CreatedAt column added successfully.';
END
ELSE
BEGIN
    PRINT 'CreatedAt column already exists.';
END
GO

-- Check if LastLogin column exists, if not add it
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND name = 'LastLogin')
BEGIN
    ALTER TABLE Users ADD LastLogin DATETIME NULL;
    PRINT 'LastLogin column added successfully.';
END
ELSE
BEGIN
    PRINT 'LastLogin column already exists.';
END
GO

PRINT '========================================';
PRINT 'Users table update completed!';
PRINT '========================================';

-- Show current table structure
SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH,
    IS_NULLABLE
FROM 
    INFORMATION_SCHEMA.COLUMNS
WHERE 
    TABLE_NAME = 'Users'
ORDER BY 
    ORDINAL_POSITION;
GO
