using System;
using System.Collections.Generic;
using System.Linq;

using AppointmentReminders.Model;

namespace AppointmentReminders.DataAccess
{
	public class AppointmentRepository : IAppointmentRepository
	{
		public List<Appointment> GetUpcomingAppointments(DateTime upUntilTimeStamp)
		{
			using (var context = new DbContext())
			{
				return (from a in context.Appointments
						   join u in context.Users on a.UserId equals u.UserId
						where a.Time <= upUntilTimeStamp
						   select new Appointment()
						   {
							   AppointmentId = a.AppointmentId,
							   FirstName = u.FirstName,
							   SunshineUserId = u.SunshineUserId,
							   ScheduledTime = a.Time,
							   ReminderSentTimeStamp = a.ReminderSentTimeStamp
						   }).ToList();
			}
		}

		public void MarkNotificationAsSent(Appointment input)
		{
			using (var context = new DbContext())
			{
				var rec = context.Appointments.Single(r => r.AppointmentId == input.AppointmentId);

				rec.ReminderSentTimeStamp = DateTime.Now;

				context.SaveChanges();
			}
		}
	}
}
