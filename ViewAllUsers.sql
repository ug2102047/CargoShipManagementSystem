-- =============================================
-- View All Users in Database
-- Run this query to see all registered users
-- =============================================

USE CargoShipDB;
GO

-- Display all users with their details
SELECT 
    UserID,
    Username,
    PasswordHash AS Password,
    Role,
    FullName,
    Email,
    CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS Status,
    CreatedAt,
    LastLogin
FROM 
    Users
ORDER BY 
    CreatedAt DESC;
GO

-- Summary: Count users by role
PRINT '';
PRINT '========================================';
PRINT 'User Statistics by Role:';
PRINT '========================================';

SELECT 
    Role,
    COUNT(*) AS UserCount
FROM 
    Users
GROUP BY 
    Role
ORDER BY 
    UserCount DESC;
GO
