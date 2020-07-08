using System;
using System.Threading.Tasks;

using AppointmentReminders.Model;

namespace AppointmentReminders.SunshineConversations
{
	public interface ISunshineConversationsProxy
	{
		Task SendMessage(Message input);
	}
}
