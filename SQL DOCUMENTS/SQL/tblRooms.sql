CREATE TABLE [dbo].[tblRooms] (
    [RoomID]   INT           IDENTITY (1, 1) NOT NULL,
    [RoomName] NVARCHAR (50) NOT NULL,
    [RoomType] NVARCHAR (50) NULL,
    [Capacity] INT           NULL,
	[Campus] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([RoomID] ASC)
);

