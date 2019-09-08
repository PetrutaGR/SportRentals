CREATE TABLE [dbo].[Orders] (
    [OrderID]    INT        NOT NULL IDENTITY,
    [CustomerID] INT        NOT NULL,
    [ShopID]     INT        NOT NULL,
    [StartDate]  DATETIME   NOT NULL,
    [EndDate]    DATETIME   NOT NULL,
    [Total]      SMALLMONEY NOT NULL,
    [CreatedDateTime] DATETIME NOT NULL, 
    PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [FK_Orders_ToTable] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID]),
    CONSTRAINT [FK_Orders_ToTable_1] FOREIGN KEY ([ShopID]) REFERENCES [dbo].[Shops] ([ShopId])
);

