USE TanPhucMiniSupermarketDb;
GO

-- =========================================================================
-- Ho ten sinh vien: Nguyen Le Tan Phuc
-- Ma sinh vien: 2124110108
-- Mo ta: Thu tuc luu tru thong ke tong hop doanh thu theo thu ngan
-- =========================================================================

-- Xoa thu tuc cu neu da ton tai truoc do de tao lai sach se
IF OBJECT_ID('sp_GetRevenueByCashier', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetRevenueByCashier;
GO

CREATE PROCEDURE sp_GetRevenueByCashier
AS
BEGIN
    -- SET NOCOUNT ON: Ngan SQL Server gui thong bao so dong bi anh huong (DoneInProc)
    -- Giup toi uu toc do truyen goi tin qua mang cho SqlDataReader
    SET NOCOUNT ON;

    -- Truy van gom nhom theo ten dang nhap thu ngan (CashierUsername)
    -- Tinh tong hoa don, tong doanh thu va tong diem thuong da phat hanh
    SELECT
        CashierUsername,
        COUNT(OrderId) AS TotalOrders,
        SUM(FinalAmount) AS TotalRevenue,
        SUM(RewardPoints) AS TotalPointsAwarded
    FROM Orders
    GROUP BY CashierUsername
    ORDER BY TotalRevenue DESC; -- Sap xep doanh thu tu cao xuong thap
END
GO

-- Chay thu: EXEC sp_GetRevenueByCashier;
GO

-- =========================================================================
-- Ho ten sinh vien: Nguyen Le Tan Phuc
-- Ma sinh vien: 2124110108
-- Mo ta: Thu tuc thong ke doanh thu theo thu ngan trong khoang ngay (Bai tap 3.1)
-- =========================================================================

-- Xoa thu tuc cu neu da ton tai truoc do de tao lai sach se
IF OBJECT_ID('sp_GetRevenueByDateRange', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetRevenueByDateRange;
GO

CREATE PROCEDURE sp_GetRevenueByDateRange
    @FromDate DATETIME,
    @ToDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    -- Chi tinh cac hoa don lap trong khoang tu @FromDate den @ToDate
    SELECT
        CashierUsername,
        COUNT(OrderId) AS TotalOrders,
        SUM(FinalAmount) AS TotalRevenue,
        SUM(RewardPoints) AS TotalPointsAwarded
    FROM Orders
    WHERE CreatedDate >= @FromDate AND CreatedDate <= @ToDate
    GROUP BY CashierUsername
    ORDER BY TotalRevenue DESC;
END
GO

-- Chay thu: EXEC sp_GetRevenueByDateRange @FromDate = 2026-03-01, @ToDate = 2026-03-31 23:59:59;
GO

-- =========================================================================
-- Ho ten sinh vien: Nguyen Le Tan Phuc
-- Ma sinh vien: 2124110108
-- Mo ta: Thu tuc thong ke Top 5 san pham ban chay nhat cho Dashboard Admin (Bai tap 3.2)
-- =========================================================================

-- Xoa thu tuc cu neu da ton tai truoc do de tao lai sach se
IF OBJECT_ID('sp_GetTop5SellingProducts', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetTop5SellingProducts;
GO

CREATE PROCEDURE sp_GetTop5SellingProducts
AS
BEGIN
    SET NOCOUNT ON;

    -- Ket hop OrderDetails va Products, gom nhom theo san pham
    -- Lay 5 mon co tong so luong ban nhieu nhat
    SELECT TOP 5
        p.ProductId,
        p.ProductName,
        SUM(od.Quantity) AS TotalSold,
        SUM(od.LineTotal) AS TotalRevenue
    FROM OrderDetails od
    INNER JOIN Products p ON p.ProductId = od.ProductId
    GROUP BY p.ProductId, p.ProductName
    ORDER BY TotalSold DESC, TotalRevenue DESC;
END
GO

-- Chay thu: EXEC sp_GetTop5SellingProducts;
GO

