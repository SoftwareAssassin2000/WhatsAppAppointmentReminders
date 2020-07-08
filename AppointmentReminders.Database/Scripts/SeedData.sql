-- Users table data
SET IDENTITY_INSERT dbo.Users ON;

MERGE INTO [dbo].[Users] AS Target
 USING ( VALUES

  ( 1, 'Chris', 'dc53ded3815efb4f6ef4318e' )

 ) AS Source ([UserId],[FirstName],[SunshineUserId])
 ON Target.[UserId] = Source.[UserId]
 WHEN MATCHED THEN
  UPDATE SET [FirstName] = Source.[FirstName], [SunshineUserId] = Source.[SunshineUserId]
 WHEN NOT MATCHED BY TARGET THEN
  INSERT ( [UserId],[FirstName],[SunshineUserId] )
  VALUES ( Source.[UserId], Source.[FirstName], Source.[SunshineUserId] )
 ;

SET IDENTITY_INSERT dbo.Users OFF;


-- Appointments table data
SET IDENTITY_INSERT dbo.Appointments ON;

MERGE INTO [dbo].[Appointments] AS Target
 USING ( VALUES
 
  ( 1, 1, CAST('2020/07/09 12:00:00' AS DATETIME), NULL ),
  ( 2, 1, CAST('2020/07/11 12:00:00' AS DATETIME), NULL ),
  ( 3, 1, CAST('2020/07/13 12:00:00' AS DATETIME), NULL ),
  ( 4, 1, CAST('2020/07/15 12:00:00' AS DATETIME), NULL ),
  ( 5, 1, CAST('2020/07/17 12:00:00' AS DATETIME), NULL ),
  ( 6, 1, CAST('2020/07/19 12:00:00' AS DATETIME), NULL ),
  ( 7, 1, CAST('2020/07/21 12:00:00' AS DATETIME), NULL ),
  ( 8, 1, CAST('2020/07/23 12:00:00' AS DATETIME), NULL ),
  ( 9, 1, CAST('2020/07/25 12:00:00' AS DATETIME), NULL ),
  ( 10, 1, CAST('2020/07/27 12:00:00' AS DATETIME), NULL )

 ) AS Source ([AppointmentId],[UserId],[Time],[ReminderSentTimeStamp])
 ON Target.[AppointmentId] = Source.[AppointmentId]
 WHEN MATCHED THEN
  UPDATE SET [UserId] = Source.[UserId], [Time] = Source.[Time]
 WHEN NOT MATCHED BY TARGET THEN
  INSERT ( [AppointmentId],[UserId],[Time],[ReminderSentTimeStamp] )
  VALUES ( Source.[AppointmentId], Source.[UserId], Source.[Time], Source.[ReminderSentTimeStamp] )
 ;

SET IDENTITY_INSERT dbo.Appointments OFF;
