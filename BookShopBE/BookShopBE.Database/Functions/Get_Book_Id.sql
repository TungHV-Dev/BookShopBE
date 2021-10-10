USE [BookShopDB]
GO

CREATE FUNCTION [dbo].[Get_Store_Id] (@StoreName NVARCHAR(100))
	RETURNS INT
AS
BEGIN
	DECLARE @StoreId INT
	IF EXISTS (SELECT [Id] FROM [dbo].[Stores] WHERE [Stores].[Name] = @StoreName)
		SELECT @StoreId = [Id]
		FROM [dbo].[Stores] WHERE [Stores].[Name] = @StoreName
	ELSE
		SET @StoreId = 0
	RETURN @StoreId
END