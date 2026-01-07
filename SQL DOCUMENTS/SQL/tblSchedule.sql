CREATE TABLE [dbo].[tblSchedule] (
    [ScheduleID] INT           IDENTITY (1, 1) NOT NULL,
    [LoadID]     INT           NOT NULL,
    [RoomID]     INT           NOT NULL,
    [DayOfWeek]  NVARCHAR (20) NOT NULL,
    [StartTime]  TIME (7)      NOT NULL,
    [EndTime]    TIME (7)      NOT NULL,
    PRIMARY KEY CLUSTERED ([ScheduleID] ASC),
    CONSTRAINT [FK_Sched_Load] FOREIGN KEY ([LoadID]) REFERENCES [dbo].[tblFacultyLoading] ([LoadID]),
    CONSTRAINT [FK_Sched_Room] FOREIGN KEY ([RoomID]) REFERENCES [dbo].[tblRooms] ([RoomID])
);

