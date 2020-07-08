CREATE TABLE [dbo].[Appointments]
(
	[AppointmentId] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [UserId] BIGINT NOT NULL, 
    [Time] DATETIME NOT NULL, 
    [ReminderSentTimeStamp] DATETIME NULL
)
