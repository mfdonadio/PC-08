namespace Proyecto2
{
    class Inicio
    {
        static void Main(string[] args)
        {
            Juego battleShip = new Juego();
            battleShip.Iniciar();

            Console.WriteLine("\nGracias por jugar. Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }   
    }
}
