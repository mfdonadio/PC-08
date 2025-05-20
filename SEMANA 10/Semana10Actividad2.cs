using System; 
namespace Semana10_Marco_Donadio
{   class Semana10Actividad2
    {
        static void Main()
        {
            int [] numeros = new int[8];
            Console.WriteLine("Hola :D. Por favor ingresa 8 números: ");
            for (int i= 0; i < numeros.Length; i++)
            {
                Console.WriteLine($"Ingresa un número: ");
                numeros[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("\nPresiona enter para continuar...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Los números ingresados son: ");
            foreach (int i in numeros)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nPresiona enter para continuar...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Bien! ahora sumaremos los numeros ingresados...");
            int total = numeros.Sum();
            Console.WriteLine($"\n\nLa suma de los números ingresados es: {total}");
            Console.WriteLine("\nPresiona enter para continuar...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Ahora, vamos a sacar el promedio de los numeros ingresados...");
            decimal promedio = Convert.ToDecimal(numeros.Average());
            Console.WriteLine($"\n\nEl promedio de los números ingresados es: {promedio}");
            Console.WriteLine("\nPresiona enter para FINALIZAR. Gracias por participar :D");
            Console.ReadLine();
            Console.Clear();
        }
    }    
}   