using System;
using System.Windows.Forms;

using HotelReservationProjectUpgraded.Controller;
using HotelReservationProjectUpgraded.Model;
using HotelReservationProjectUpgraded.View;

namespace HotelReservationProjectUpgraded
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			var appView = new ApplicationView();
			var appController = new ApplicationController(appView);

			Application.Run(appView);
			appController.Dispose();
		}
	}
}
