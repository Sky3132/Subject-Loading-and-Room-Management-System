CREATE OR ALTER PROCEDURE DeleteSubjectOffering
    @OfferingId INT
AS
BEGIN
    SET NOCOUNT ON;
	
    DELETE FROM tblsubjectOffering
    WHERE offeringId = @OfferingId;
END
GO
