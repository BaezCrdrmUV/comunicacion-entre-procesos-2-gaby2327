using System;
using System.Diagnostics;
using System.IO;

namespace ComunicacionEntreProcesos
{
    class Program
    {
        static void Main(string[] args)
        {
            Process process = Process.GetCurrentProcess();
            bool salida = false;

            Console.WriteLine("COMUNICACIÓN ENTRE PROCESOS 2");

            while(!salida)
            {
                Console.WriteLine("--------------- M E N Ú ---------------");
                Console.WriteLine("Selecciona un número de las opciones: ");
                Console.WriteLine("1. Escribir un mensaje");
                Console.WriteLine("2. Mostrar mensajes");
                Console.WriteLine("3. Salir");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("1. Escribir un mensaje");
                        Console.WriteLine("----------------------");
                        Console.WriteLine("Ingresa tu mensaje: ");
                        string mensaje = Console.ReadLine();
                        using (StreamWriter writer = System.IO.File.AppendText("Archivo.txt"))
                        {
                            writer.WriteLine("PID: " + process.Id + ", hora: " + process.StartTime + ", mensaje: " + mensaje);
                        }
                        break;
                    case "2":
                        Console.WriteLine("2. Mostrar mensajes");
                        Console.WriteLine("----------------------");
                        Console.WriteLine(File.ReadAllText("Archivo.txt"));
                        break;
                    case "3":
                        Console.WriteLine("3. Salir");
                        Console.WriteLine("----------------------");
                        salida = true;
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta, intente nuevamente");
                        break;
                }
            }
        }
    }
}
