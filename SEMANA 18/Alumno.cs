using System;

namespace SEMANA_18
{
    public class Alumno : IAlumnos
    {
        public string Nombre {get; set;}
        public double[] Notas {get; set;}

        public Alumno(string nombre)
        {
            this.Nombre = nombre;
            this.Notas =  new double[10];
        }

        public void IngresarNotas()
        {
            Console.WriteLine($"{Nombre} ingresa tus notas: ");
            for (int i = 0; i < Notas.Length; i++)
            {
                Console.Write($"Nota {i + 1}: ");
                string notaIngreso = Console.ReadLine()?.Trim()??"";

                if (Double.TryParse(notaIngreso, out double nota) && nota >= 0 && nota <= 100)
                {
                    Notas[i] = nota;
                }
                else
                {
                    Console.WriteLine("Nota no válida. Inténtalo de nuevo.");
                    i--;
                }
            }

            Console.WriteLine("Notas ingresadas correctamente.");
            Console.WriteLine("Presiona Enter para continuar...");
            Console.ReadLine();
        }

        public void MostrarNotas()
        {
            Console.WriteLine($"{Nombre} tus notas son: ");
            for (int i = 0; i < Notas.Length; i++)
            {
                Console.WriteLine($"Nota {i + 1}: {Notas[i]}");
            }
        }

        public void MostrarNotasPerdidas()
        {
            Console.WriteLine($"{Nombre} tus notas perdidas son: ");
            for (int i = 0; i < Notas.Length; i++)
            {
                if (Notas[i] < 65)
                {
                    Console.WriteLine($"Nota {i + 1}: {Notas[i]} - Reprobada");
                }
                else
                {
                    Console.WriteLine($"Nota {i + 1}: {Notas[i]} - Aprobada");
                }
            }
        }

        public double CalcularPromedio()
        {
            double suma = 0;
            foreach (double nota in Notas)
            {
                suma += nota;
            }
            return suma / Notas.Length;
        }
        
    }
}