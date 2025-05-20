using System;

namespace SEMANA_18
{
    public class MenuInicio
    {
        public Alumno[] Alumnos { get; private set; }
        public MenuInicio()
        {
            Alumnos = new Alumno[10];
        }

        public void IniciarMenu()
        {
            Console.WriteLine("Bienvenidos al sistema de gestión de notas.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Ingrese los nombres de los alumnos por favor...");
            IngresarNombresAlumnos();

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Escoja una opción: ");
                Console.WriteLine("1. Mostrar nombre y notas de los alumnos");
                Console.WriteLine("2. Mostrar notas perdidas de los alumnos");
                Console.WriteLine("3. Mostrar promedio de notas de los alumnos");
                Console.WriteLine("4. Salir del programa.");

                string opcion = Console.ReadLine()?.Trim() ?? "";
                if (int.TryParse(opcion, out int opcionSeleccionada))
                {
                    switch (opcionSeleccionada)
                    {
                        case 1:
                            MostrarNotas();
                            break;
                        case 2:
                            MostrarNotasPerdidas();
                            break;
                        case 3:
                            MostrarPromedioNotas();
                            break;
                        case 4:
                            continuar = false;
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                            break;
                    }
                }
                if (continuar)
                {
                    Console.WriteLine("Presiona Enter para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        public void IngresarNombresAlumnos()
        {
            string[] nombresAlumnos = new string[10];
            for (int i = 0; i < nombresAlumnos.Length; i++)
            {
                Console.Write($"Ingrese el nombre del alumno {i + 1}: ");
                string nombreIngresado = Console.ReadLine()?.Trim() ?? "";

                if (!string.IsNullOrEmpty(nombreIngresado))
                {
                    nombresAlumnos[i] = nombreIngresado;
                }
                else
                {
                    Console.WriteLine("Nombre no válido. Inténtalo de nuevo.");
                    i--;
                }
            }

            for (int i = 0; i < nombresAlumnos.Length; i++)
            {
                Alumnos[i] = new Alumno(nombresAlumnos[i]);
            }

            Console.WriteLine("Ahora, por favor, ingrese las notas de los alumnos.");
            foreach (Alumno alumno in Alumnos)
            {
                alumno.IngresarNotas();
                Console.Clear();
            }

            Console.WriteLine("Regresando al menú principal....");
        }

        public void MostrarNotas()
        {
            Console.WriteLine("Nombre y notas de los alumnos:");
            foreach (Alumno alumno in Alumnos)
            {
                alumno.MostrarNotas();
                Console.WriteLine();
            }
        }

        public void MostrarNotasPerdidas()
        {
            Console.WriteLine("Notas perdidas de los alumnos:");
            foreach (Alumno alumno in Alumnos)
            {
                alumno.MostrarNotasPerdidas();
                Console.WriteLine();
            }
        }

        public void MostrarPromedioNotas()
        {
            Console.WriteLine("Promedio de notas de los alumnos:");
            foreach (Alumno alumno in Alumnos)
            {
                double promedio = alumno.CalcularPromedio();
                Console.WriteLine($"El promedio de {alumno.Nombre} es: {promedio}");
            }
        }
    }
}