CREATE TABLE [dbo].[tblRoomAssignment] (
    [AssignmentID] INT IDENTITY (1, 1) NOT NULL,
    [LoadID]       INT NOT NULL, -- Links to Faculty Loading Table
    [RoomID]       INT NOT NULL, -- Links to your tblRooms
    [Day]          NVARCHAR (50) NULL,
    [StartTime]    NVARCHAR (50) NULL,
    [EndTime]      NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([AssignmentID] ASC),
    -- Create the Relationship to Faculty Loading
    CONSTRAINT [FK_tblRoomAssignment_ToFacultyLoading] FOREIGN KEY ([LoadID]) 
        REFERENCES [dbo].[tblFacultyLoading] ([LoadID]),
    -- Create the Relationship to Rooms
    CONSTRAINT [FK_tblRoomAssignment_ToRooms] FOREIGN KEY ([RoomID]) 
        REFERENCES [dbo].[tblRooms] ([RoomID])
);