USE [BookShopDB]
GO

CREATE FUNCTION [dbo].[Get_Book_Id] (@BookName NVARCHAR(100))
	RETURNS INT
AS
BEGIN
	DECLARE @BookId INT
	IF EXISTS (SELECT [Id] FROM [dbo].[Books] WHERE [Books].[Name] = @BookName)
		SELECT @BookId = [Id]
		FROM [dbo].[Books] WHERE [Books].[Name] = @BookName
	ELSE
		SET @BookId = 0
	RETURN @BookId
END