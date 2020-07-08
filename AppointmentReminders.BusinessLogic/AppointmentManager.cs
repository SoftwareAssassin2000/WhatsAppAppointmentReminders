using System;
using System.Linq;
using System.Threading.Tasks;

using AppointmentReminders.SunshineConversations;
using AppointmentReminders.DataAccess;
using AppointmentReminders.Model;

namespace AppointmentReminders.BusinessLogic
{
	public class AppointmentManager : IAppointmentManager
	{
		#region Dependencies

		public IAppointmentRepository appointmentRepository { get; set; }
		public ISunshineConversationsProxy sunshineConversationsProxy { get; set; }

		#endregion
		#region Construction/Destruction

		public AppointmentManager()
			: this(new AppointmentRepository(), new SunshineConversationsProxy())
		{ }
		public AppointmentManager(IAppointmentRepository appointmentRepository, ISunshineConversationsProxy sunshineConversationsProxy)
		{
			this.appointmentRepository = appointmentRepository;
			this.sunshineConversationsProxy = sunshineConversationsProxy;
		}

		#endregion

		public async Task SendAppointmentReminders()
		{
			//get appointments upcoming within two days from now
			var twoDaysFromNow = DateTime.Now.AddDays(2);
			var upcoming = this.appointmentRepository.GetUpcomingAppointments(twoDaysFromNow);

			//get appointments where reminder has not been sent
			upcoming = upcoming.Where(r => r.ReminderSentTimeStamp == null).ToList();

			foreach (var appointment in upcoming)
			{
				//send WhatsApp notification
				await this.sunshineConversationsProxy.SendMessage(new Message()
				{
					RecipientUserId = appointment.SunshineUserId,
					Text = string.Format("Hello {0}, this is just a reminder that you have an upcoming appointment at {1} on {2}",
						appointment.FirstName,
						appointment.ScheduledTime.ToString("HH:mm"),
						appointment.ScheduledTime.ToString("MM/dd/yyyy"))
				});

				//mark notification as sent
				this.appointmentRepository.MarkNotificationAsSent(appointment);
			}
		}
	}
}
