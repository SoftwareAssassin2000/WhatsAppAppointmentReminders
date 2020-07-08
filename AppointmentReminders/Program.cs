using System;
using System.Threading.Tasks;

using AppointmentReminders.BusinessLogic;

namespace AppointmentReminders
{
	public class Program
	{
		#region Dependencies

		public IAppointmentManager appointmentManager { get; set; }

		#endregion
		#region Construction/Destruction

		public Program()
			: this(new AppointmentManager())
		{ }
		public Program(IAppointmentManager appointmentManager)
		{
			this.appointmentManager = appointmentManager;
		}

		#endregion

		public static void Main(string[] args)
		{
			var p = new Program();
			p.Run().Wait();
			p = null;
		}

		public async Task Run()
		{
			await this.appointmentManager.SendAppointmentReminders();
		}
	}
}
