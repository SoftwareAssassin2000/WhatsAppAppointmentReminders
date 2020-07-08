using System;
using System.Collections.Generic;

using AppointmentReminders.Model;

namespace AppointmentReminders.DataAccess
{
	public interface IAppointmentRepository
	{
		List<Appointment> GetUpcomingAppointments(DateTime upUntilTimeStamp);
		void MarkNotificationAsSent(Appointment input);
	}
}
