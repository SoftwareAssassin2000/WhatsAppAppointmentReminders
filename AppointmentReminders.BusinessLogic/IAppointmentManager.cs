using System;
using System.Threading.Tasks;

namespace AppointmentReminders.BusinessLogic
{
	public interface IAppointmentManager
	{
		Task SendAppointmentReminders();
	}
}
