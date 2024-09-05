using Vista.Módulo_de_Administración;
using Vista.Módulo_de_Seguridad;
using Vista.Módulo_de_Transacciones;

namespace Vista
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
            Application.Run(new FormIniciarSesion());
        }
    }
}