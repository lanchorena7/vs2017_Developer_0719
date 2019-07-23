CREATE PROCEDURE usp_UpdateArtist
(
	@ID INT,
	@Name NVARCHAR (120)
)
AS
BEGIN

UPDATE Artist
SET Name = @Name
WHERE ArtistId = @ID

END

go

CREATE PROCEDURE usp_DeleteArtist
(
	@ID INTD
)
AS
BEGIN

DELETE Artist
FROM Artist
WHERE ArtistId = @ID

END

GO

CREATE PROCEDURE usp_GetArtistById
(
	@ID INT
)
AS
BEGIN

SELECT *
FROM Artist
WHERE ArtistId = @ID

END
