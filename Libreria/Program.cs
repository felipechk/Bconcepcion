using Libreria.FormPrincipal;
using System;
using System.Windows.Forms;
using LogicaNegocio.Libreria;
using AccesodeDatos.ClsDatabase;
using Microsoft.Extensions.DependencyInjection;



namespace Libreria
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Configuración de inyección de dependencias
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ClsDatabase>()  // Inyección de la clase de base de datos
                .AddSingleton<Libros>()       // Inyección de la lógica de negocio para libros
                .BuildServiceProvider();

            // Obtener una instancia de LibroForm con las dependencias inyectadas
            var libroForm = new LibroForm(serviceProvider.GetService<Libros>());

            Application.Run(libroForm);
        }
    }
}
