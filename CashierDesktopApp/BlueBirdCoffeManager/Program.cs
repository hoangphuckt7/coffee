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
            Thread.CurrentThread.CurrentUICulture = Sessions.Sessions.CULTURE_INFO;
            Thread.CurrentThread.CurrentCulture = Sessions.Sessions.CULTURE_INFO;
            Application.Run(new LoginForm());
        }
    }
}