namespace TP_1_Heladeria
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

            // Para iniciar normalmente desde el Login:
            // Application.Run(new frmLogin());

            

            // Para probar Modo Usuario Normal: pasar 'false'
            // Para probar Modo Administrador: cambiar a 'true' o usar Id = 1 (Gustavo Martinez)
            // Application.Run(new frmEditarPerfil(1, false));
            Application.Run(new frmRecuperarContrasena());
        }
    }
}
