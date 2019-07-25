USE [Chinook]
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertInvoice]    Script Date: 24/07/2019 21:41:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_InsertInvoice]
(
	@CustomerId INT,
	@InvoiceDate DATETIME,
	@BillingAddress nvarchar (70),
	@BillingCity nvarchar (40),
	@BillingState nvarchar(40),
	@BillingCountry nvarchar(40),
	@BillingPostalCode nvarchar(10),
	@Total NUMERIC (10,2)
)
AS
BEGIN
	INSERT INTO Invoice (
		[CustomerId], [InvoiceDate],
		[BillingAddress], [BillingCity],
		[BillingState], [BillingCountry],
		[BillingPostalCode], [Total]
	)
	VALUES(
		@CustomerId, @InvoiceDate,
		@BillingAddress, @BillingCity,
		@BillingState, @BillingCountry,
		@BillingPostalCode, @Total
	)

	SELECT  SCOPE_IDENTITY()
END