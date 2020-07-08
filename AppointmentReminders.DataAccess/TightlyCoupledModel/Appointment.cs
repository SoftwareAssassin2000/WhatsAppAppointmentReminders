using System;

namespace AppointmentReminders.DataAccess.TightlyCoupledModel
{
	internal class Appointment
	{
		internal long AppointmentId { get; set; }
		internal long UserId { get; set; }
		internal DateTime Time { get; set; }
		internal DateTime? ReminderSentTimeStamp { get; set; }
	}
}
