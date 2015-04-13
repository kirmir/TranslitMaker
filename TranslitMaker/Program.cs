using System;
using System.Windows.Forms;

namespace TranslitMaker
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
			catch
			{
				MessageBox.Show("Во время выполнения возникла критическая ошибка. Приложение будет закрыто.",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
