using System;
using System.IO;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class datospersona
    {
        static void Main(string[] args)
        {
            // Configurar Serilog para escribir los logs en un archivo
            string basedir = AppDomain.CurrentDomain.BaseDirectory;
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            string logFileName = $"Log_{DateTime.Now:yyyyMMdd}.txt";

            Log.Logger = new LoggerConfiguration()
                            .WriteTo.File(logFileName)
                            .CreateLogger();


            Console.WriteLine("Ingrese su nombre (máximo 10 caracteres):");
            string nombre = Console.ReadLine();

            if (nombre.Length > 10)
            {
                throw new ArgumentException("El nombre ingresado excede los 10 caracteres permitidos");
            }


            Console.WriteLine("Ingrese su edad (0-99):");
            int edad;
            if (!int.TryParse(Console.ReadLine(), out edad) || edad < 0 || edad > 99)
            {
                Log.Error("Error: Edad inválida.");
                Console.WriteLine("Error: Edad inválida.");
                return;
            }


            Console.WriteLine("Ingrese su género (true para masculino, false para femenino):");
            bool genero;

            if (!bool.TryParse(Console.ReadLine(), out genero))
            {
                Log.Error("Error: Género inválido.");
                Console.WriteLine("Error: Género inválido.");
                return;
            }

            // Mostrar el mensaje con los datos ingresados
            string mensaje = $"Hola {nombre}, {edad} años, género {(genero ? "masculino" : "femenino")}";
            Console.WriteLine(mensaje);
            Log.Information(mensaje);
        }

    }
}
