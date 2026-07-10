using System.ComponentModel;

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
            //Application.Run(new frmLogin());
            string[] usuarioAdmin =
                {
                    "Gustavo",
                    "Martinez",
                    "12345678",
                    "1234567890",
                    "gus@mar.tinez",
                    "Masculino",
                    "Administrador",
                    "6/12/1990",
                    "argentina",
                    "buenos aires",
                    "lomas de zamora",
                    "lomas de zamora",
                    "1934",
                    "Calle falsa",
                    "123",
                    "",
                    "",
                    "admin001",
                    "admin123",
                    "No",
                    "admin001"};

            string[] usuario = {
                    "Gustavo",
                    "Martinez",
                    "12345678",
                    "1234567890",
                    "gus@mar.tinez",
                    "Masculino",
                    "General",
                    "6/12/1990",
                    "argentina",
                    "buenos aires",
                    "lomas de zamora",
                    "lomas de zamora",
                    "1934",
                    "Calle falsa",
                    "123",
                    "",
                    "",
                    "jperez123",
                    "1234",
                    "Si",
                    "jperez123"};

            BindingList<string[]> usuarios = new BindingList<string[]>{ usuarioAdmin, usuario };
            
            Application.Run(new frmLogin(usuarios));
        }
    }
}