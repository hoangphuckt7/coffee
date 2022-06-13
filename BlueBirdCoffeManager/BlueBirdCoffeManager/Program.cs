using BlueBirdCoffeManager.Forms;

namespace BlueBirdCoffeManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            System.Threading.Thread.CurrentThread.CurrentUICulture = Sessions.Sessions.CULTURE_INFO;
            System.Threading.Thread.CurrentThread.CurrentCulture = Sessions.Sessions.CULTURE_INFO;
            Application.Run(new MainForm());
        }
    }
}