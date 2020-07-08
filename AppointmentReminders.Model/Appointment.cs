using System;

namespace AppointmentReminders.Model
{
	public class Appointment
	{
		public long AppointmentId { get; set; }
		public string FirstName { get; set; }
		public string SunshineUserId { get; set; }
		public DateTime ScheduledTime { get; set; }
		public DateTime? ReminderSentTimeStamp { get; set; }
	}
}
