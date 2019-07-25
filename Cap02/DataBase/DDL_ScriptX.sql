USE [Chinook]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCustomerxName]    Script Date: 24/07/2019 21:33:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_GetCustomerxName]
(
@FullName NVARCHAR (40)
)
AS
BEGIN
SELECT  [CustomerId], [FirstName], [LastName],
		[Company], [Address], [City], [State],
		[Country], [PostalCode], [Phone],
		[Fax], [Email], [SupportRepId]
 From Customer
 Where @FullName = ''
 or (FirstName + '' + LastName Like @FullName)

 end