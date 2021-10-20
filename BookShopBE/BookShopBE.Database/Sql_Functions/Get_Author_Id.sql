USE [BookShopDB]
GO

CREATE FUNCTION [dbo].[Get_Author_Id] (@AuthorName NVARCHAR(100))
	RETURNS INT
AS
BEGIN
	DECLARE @AuthorId INT
	IF EXISTS (SELECT [Id] FROM [dbo].[Authors] WHERE [Authors].[Name] = @AuthorName)
		SELECT @AuthorId = [Id]
		FROM [dbo].[Authors] WHERE [Authors].[Name] = @AuthorName
	ELSE
		SET @AuthorId = 0
	RETURN @AuthorId
END